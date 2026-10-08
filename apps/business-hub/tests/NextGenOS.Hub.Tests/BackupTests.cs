using System.Security.Cryptography;
using NextGenOS.Hub.Backups;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Documents;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// Blueprint OPS-002 and the restore drill: a copy every night to a second place, the owner told whether it worked, an unplugged drive handled in plain words, and a copy put back on a
/// clean PC that holds the same money. Nothing here needs a real drive: a folder that goes away stands in for one that is unplugged.
/// </summary>
public class BackupTests : IDisposable
{
    private readonly string area = Path.Combine(Path.GetTempPath(), "hub-backup-" + Guid.NewGuid().ToString("N"));
    private readonly HubFixture f = new();                     // 12:00 in India on 5 October 2026
    private string Place => Path.Combine(area, "usb-drive");

    public BackupTests()
    {
        Directory.CreateDirectory(area);
        Directory.CreateDirectory(Place);
        var rice = f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Rice", PriceMinor = 11_800, TaxClass = "standard", TrackStock = true });
        f.App.Catalog.Adjust(rice.Id, 100_000, "delivery");
        f.App.Documents.Checkout(new CheckoutRequest { Lines = { new LineInput { ItemId = rice.Id, QtyMilli = 2000 } }, Payments = { new PaymentInput { Method = "cash", AmountMinor = 23_600 } } });
    }

    public void Dispose()
    {
        f.Dispose();
        try { Directory.Delete(area, recursive: true); } catch (IOException) { }
    }

    private BackupSettings SwitchOn(string time = "02:00", int keep = 14) => f.App.Backups.Save(new BackupSettings(true, Place, time, keep), null);

    private static string Sha(string file) => Convert.ToHexString(SHA256.HashData(File.ReadAllBytes(file))).ToLowerInvariant();

    [Fact]
    public void The_choices_are_checked_kept_and_the_place_is_marked_so_that_another_drive_is_not_mistaken_for_it()
    {
        var b = f.App.Backups;
        Assert.False(b.Settings().Enabled);
        Assert.Equal("backup-folder", Assert.Throws<HubException>(() => b.Save(new BackupSettings(true, null, "02:00", 14), null)).Code);
        Assert.Equal("backup-time", Assert.Throws<HubException>(() => b.Save(new BackupSettings(true, Place, "2am", 14), null)).Code);
        Assert.Equal("backup-keep", Assert.Throws<HubException>(() => b.Save(new BackupSettings(true, Place, "02:00", 0), null)).Code);
        var blocker = Path.Combine(area, "a-file");
        File.WriteAllText(blocker, "x");
        var unwritable = Assert.Throws<HubException>(() => b.Save(new BackupSettings(true, Path.Combine(blocker, "copies"), "02:00", 14), null));
        Assert.Equal("backup-folder", unwritable.Code);
        Assert.Contains("plugged in", unwritable.Message);

        var saved = SwitchOn("03:30", 7);
        Assert.Equal(new BackupSettings(true, Place, "03:30", 7, saved.PlaceId), b.Settings());
        Assert.False(string.IsNullOrEmpty(saved.PlaceId));
        Assert.Equal(saved.PlaceId, File.ReadAllText(Path.Combine(Place, ".nextgenos-backup-place")).Trim());

        // Saving the same place again keeps its mark; another place gets its own.
        Assert.Equal(saved.PlaceId, b.Save(saved, null).PlaceId);
        var other = Path.Combine(area, "other-drive");
        Assert.NotEqual(saved.PlaceId, b.Save(saved with { Folder = other }, null).PlaceId);
    }

    [Fact]
    public void A_copy_made_now_is_whole_checked_fingerprinted_and_written_down()
    {
        SwitchOn();
        var run = f.App.Backups.RunNow(BackupKinds.Manual);

        Assert.True(run.Good, run.Error);
        var file = Path.Combine(Place, run.FileName!);
        Assert.True(File.Exists(file));
        Assert.Equal(new FileInfo(file).Length, run.SizeBytes);
        Assert.Equal(Sha(file), run.Sha256);
        Assert.Equal(HubDb.LatestVersion, run.SchemaVersion);
        var report = DatabaseCheck.Inspect(file);
        Assert.True(report.Healthy, string.Join("; ", report.Problems));

        var status = f.App.Backups.Status();
        Assert.Equal(run.Id, status.LastGood!.Id);
        Assert.Null(status.LastFailed);
        Assert.False(status.Overdue);
        Assert.Contains("The last good copy was made on 5 Oct 2026, 12:00", status.Summary);
        Assert.Single(f.App.Backups.Copies());
    }

    [Fact]
    public void A_drive_that_is_not_there_is_a_failed_try_in_plain_words_the_till_goes_on_and_the_copy_is_made_when_the_drive_is_back()
    {
        SwitchOn();
        var good = f.App.Backups.RunNow(BackupKinds.Manual);
        Assert.True(good.Good, good.Error);
        Directory.Delete(Place, recursive: true);                         // unplugged

        f.Clock.Advance(TimeSpan.FromHours(2));
        var failed = f.App.Backups.RunNow(BackupKinds.Nightly);
        Assert.False(failed.Good);
        Assert.Contains("not the one chosen", failed.Error);
        Assert.Contains("plugged in", failed.Error);
        var status = f.App.Backups.Status();
        Assert.Equal(good.Id, status.LastGood!.Id);                        // the last good copy is still the old one
        Assert.Equal(failed.Id, status.LastFailed!.Id);
        Assert.Contains("did not work", status.Summary);
        Assert.Contains("The last good copy was made on", status.Summary);

        // The till does not notice: a sale still goes through.
        var item = f.App.Catalog.Search("Rice").First();
        Assert.Equal(DocStatus.Issued, f.App.Documents.Checkout(new CheckoutRequest { Lines = { new LineInput { ItemId = item.Id } }, Payments = { new PaymentInput { Method = "cash", AmountMinor = 11_800 } } }).Document.Status);

        // A different, empty drive in the same place is not the place the owner chose.
        Directory.CreateDirectory(Place);
        Assert.Contains("not the one chosen", f.App.Backups.RunNow(BackupKinds.Nightly).Error);

        // The owner chooses it (or puts the old one back): it works again.
        f.App.Backups.Save(f.App.Backups.Settings(), null);
        Assert.True(f.App.Backups.RunNow(BackupKinds.Nightly).Good);
        Assert.Null(f.App.Backups.Status().LastFailed);
    }

    [Fact]
    public void No_good_copy_for_a_day_and_a_half_is_overdue_and_says_so()
    {
        SwitchOn();
        f.App.Backups.RunNow(BackupKinds.Manual);
        f.Clock.Advance(TimeSpan.FromHours(35));
        Assert.False(f.App.Backups.Status().Overdue);
        f.Clock.Advance(TimeSpan.FromHours(2));
        var status = f.App.Backups.Status();
        Assert.True(status.Overdue);
        Assert.Contains("too long ago", status.Summary);
    }

    [Fact]
    public void The_nightly_round_runs_once_when_the_time_has_come_catches_up_after_a_night_off_and_does_not_hammer_a_missing_drive()
    {
        SwitchOn("02:00");                                                   // the clock says 12:00 in India: today's 02:00 has passed and nothing was copied yet
        Assert.True(f.App.Backups.RunIfDue());
        Assert.False(f.App.Backups.RunIfDue());                              // already done for today
        Assert.Equal(BackupKinds.Nightly, f.App.Backups.Runs(1)[0].Kind);

        f.Clock.Set(new DateTimeOffset(2026, 10, 5, 19, 0, 0, TimeSpan.Zero));   // 00:30 the next morning in India: before the time, yesterday's copy stands
        Assert.False(f.App.Backups.RunIfDue());
        f.Clock.Set(new DateTimeOffset(2026, 10, 5, 21, 30, 0, TimeSpan.Zero)); // 03:00: the time has come
        Assert.True(f.App.Backups.RunIfDue());
        Assert.False(f.App.Backups.RunIfDue());

        // The PC was off for two nights and is switched on at 15:00: one catch-up copy, not two.
        f.Clock.Set(new DateTimeOffset(2026, 10, 8, 9, 30, 0, TimeSpan.Zero));
        Assert.True(f.App.Backups.RunIfDue());
        Assert.False(f.App.Backups.RunIfDue());

        // The drive goes away. The next night's try fails, and is not repeated every few minutes: after an hour it tries again.
        Directory.Delete(Place, recursive: true);
        f.Clock.Set(new DateTimeOffset(2026, 10, 8, 21, 30, 0, TimeSpan.Zero));   // 03:00 on 9 October
        Assert.True(f.App.Backups.RunIfDue());
        var failures = () => f.App.Backups.Runs(50).Count(r => !r.Good);
        Assert.Equal(1, failures());
        f.Clock.Advance(TimeSpan.FromMinutes(10));
        Assert.False(f.App.Backups.RunIfDue());
        f.Clock.Advance(TimeSpan.FromMinutes(55));
        Assert.True(f.App.Backups.RunIfDue());
        Assert.Equal(2, failures());
    }

    [Fact]
    public void Switched_off_or_with_no_place_the_nightly_round_does_nothing_and_a_copy_by_hand_with_no_place_says_what_to_do()
    {
        Assert.False(f.App.Backups.RunIfDue());
        var none = f.App.Backups.RunNow(BackupKinds.Manual);
        Assert.False(none.Good);
        Assert.Contains("No place for the copies", none.Error);
        f.App.Backups.Save(new BackupSettings(false, Place, "02:00", 14), null);
        Assert.False(f.App.Backups.RunIfDue());
        Assert.Contains("switched off", f.App.Backups.Status().Summary);
    }

    [Fact]
    public void Only_the_newest_nightly_copies_are_kept_and_nothing_else_in_the_folder_is_ever_touched()
    {
        SwitchOn(keep: 3);
        var stranger = Path.Combine(Place, "holiday-photos.bak");
        File.WriteAllText(stranger, "not ours");
        var manual = f.App.Backups.RunNow(BackupKinds.Manual);
        for (var night = 0; night < 5; night++)
        {
            f.Clock.Advance(TimeSpan.FromDays(1));
            Assert.True(f.App.Backups.RunNow(BackupKinds.Nightly).Good);
        }

        var kept = f.App.Backups.Copies().Select(c => c.FileName).ToList();
        Assert.Equal(3, kept.Count(n => n.EndsWith("-nightly.bak", StringComparison.Ordinal)));
        Assert.Contains(manual.FileName, kept);                                    // a copy the owner asked for stays
        Assert.True(File.Exists(stranger));                                        // so does anything else
        Assert.Equal(2, f.App.Backups.Runs(50).Count(r => r.Kind == BackupKinds.Nightly && r.Good && !File.Exists(Path.Combine(Place, r.FileName!))));
    }

    [Fact]
    public void A_copy_put_back_on_a_clean_PC_with_nothing_else_holds_the_same_sales_stock_books_and_numbers()
    {
        SwitchOn();
        var made = f.App.Backups.RunNow(BackupKinds.Manual);
        var copy = Path.Combine(Place, made.FileName!);

        // The clean PC: an empty data folder, the copy chosen, the program started.
        var clean = Path.Combine(area, "clean-pc");
        Directory.CreateDirectory(clean);
        var staged = PendingRestore.Stage(clean, copy);
        Assert.Equal(made.FileName, staged.SourceName);
        Assert.True(PendingRestore.IsPending(clean));
        var shopFile = Path.Combine(clean, "shop.db");
        var outcome = PendingRestore.ApplyIfPending(clean, shopFile)!;
        Assert.True(outcome.Done, outcome.Message);
        Assert.Null(outcome.KeptAs);                                               // there was no shop before
        Assert.False(PendingRestore.IsPending(clean));
        Assert.Null(PendingRestore.ApplyIfPending(clean, shopFile));               // the note is gone: starting again changes nothing

        var restored = HubApp.OpenTrusted(shopFile, f.Clock);
        foreach (var sql in new[]
        {
            "SELECT COUNT(*) FROM documents", "SELECT COALESCE(SUM(total_minor), 0) FROM documents", "SELECT COUNT(*) FROM payments", "SELECT COALESCE(SUM(qty_milli), 0) FROM stock_moves",
            "SELECT COALESCE(SUM(debit_minor), 0) FROM journal_lines", "SELECT COALESCE(SUM(credit_minor), 0) FROM journal_lines", "SELECT COUNT(*) FROM items", "SELECT next_no FROM number_series WHERE type = 'invoice'",
        })
            Assert.Equal(Convert.ToInt64(f.App.Db.Scalar(sql) ?? 0L), Convert.ToInt64(restored.Db.Scalar(sql) ?? 0L));
        Assert.True(DatabaseCheck.Inspect(shopFile).Healthy);

        // The next bill carries on from the numbers it had, not from 1.
        var rice = restored.Catalog.Search("Rice").First();
        var next = restored.Documents.Checkout(new CheckoutRequest { Lines = { new LineInput { ItemId = rice.Id } }, Payments = { new PaymentInput { Method = "cash", AmountMinor = 11_800 } } });
        Assert.Equal("INV-2026-000002", next.Document.Number);
    }

    [Fact]
    public void Putting_a_copy_back_over_a_working_shop_keeps_the_shop_as_it_was_and_the_owner_can_see_what_happened()
    {
        SwitchOn();
        var made = f.App.Backups.RunNow(BackupKinds.Manual);
        var rice = f.App.Catalog.Search("Rice").First();
        for (var i = 0; i < 3; i++) f.App.Documents.Checkout(new CheckoutRequest { Lines = { new LineInput { ItemId = rice.Id } }, Payments = { new PaymentInput { Method = "cash", AmountMinor = 11_800 } } });   // sales after the copy
        Assert.Equal(4, Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM documents WHERE status = 'issued'")));

        var data = Path.GetDirectoryName(f.App.Db.Path)!;
        var staged = f.App.Backups.StageRestore(Path.Combine(Place, made.FileName!), null);
        Assert.Equal(made.FileName, staged.SourceName);
        var outcome = PendingRestore.ApplyIfPending(data, f.App.Db.Path)!;   // the program was closed and opened again
        Assert.True(outcome.Done, outcome.Message);
        Assert.NotNull(outcome.KeptAs);
        Assert.True(File.Exists(Path.Combine(outcome.KeptAs!, Path.GetFileName(f.App.Db.Path))));   // the shop as it was is still there
        Assert.Equal(outcome.Message, PendingRestore.Last(data)!.Message);

        var after = HubApp.OpenTrusted(f.App.Db.Path, f.Clock);
        Assert.Equal(1, Convert.ToInt64(after.Db.Scalar("SELECT COUNT(*) FROM documents WHERE status = 'issued'")));   // as of the copy
        var kept = new HubDb(Path.Combine(outcome.KeptAs!, Path.GetFileName(f.App.Db.Path)));
        Assert.Equal(4, Convert.ToInt64(kept.Scalar("SELECT COUNT(*) FROM documents WHERE status = 'issued'")));
    }

    [Fact]
    public void A_copy_that_is_damaged_made_by_a_newer_program_or_not_a_shop_at_all_is_refused_and_a_copy_spoiled_after_it_was_set_aside_is_refused_at_the_start()
    {
        SwitchOn();
        var made = f.App.Backups.RunNow(BackupKinds.Manual);
        var good = Path.Combine(Place, made.FileName!);
        var data = Path.Combine(area, "pc");
        Directory.CreateDirectory(data);

        Assert.Contains("not there", Assert.Throws<HubException>(() => PendingRestore.Stage(data, Path.Combine(area, "missing.bak"))).Message);
        var junk = Path.Combine(area, "junk.bak");
        File.WriteAllText(junk, "this is only a note and long enough to look like a page of something, but it is not a shop at all");
        Assert.Equal("restore", Assert.Throws<HubException>(() => PendingRestore.Stage(data, junk)).Code);
        var cut = Path.Combine(area, "cut.bak");
        var bytes = File.ReadAllBytes(good);
        File.WriteAllBytes(cut, bytes[..(bytes.Length / 2)]);
        Assert.Equal("restore", Assert.Throws<HubException>(() => PendingRestore.Stage(data, cut)).Code);

        var newer = Path.Combine(area, "newer.bak");
        File.Copy(good, newer);
        new HubDb(newer).InTransaction((c, t) => HubDb.Exec(c, "INSERT INTO schema_version(version) VALUES ($v)", t, ("$v", HubDb.LatestVersion + 1)));
        Assert.Contains("newer version", Assert.Throws<HubException>(() => PendingRestore.Stage(data, newer)).Message);
        Assert.False(PendingRestore.IsPending(data));                                   // nothing was set aside by a refusal

        // Set aside, then spoiled before the next start: the start refuses it and leaves the shop alone.
        File.Copy(good, Path.Combine(data, "shop.db"));
        var before = Sha(Path.Combine(data, "shop.db"));
        PendingRestore.Stage(data, good);
        File.WriteAllBytes(Path.Combine(data, "restore", "pending.db"), bytes[..(bytes.Length / 3)]);
        var outcome = PendingRestore.ApplyIfPending(data, Path.Combine(data, "shop.db"))!;
        Assert.False(outcome.Done);
        Assert.Contains("did not pass its check", outcome.Message);
        Assert.Equal(before, Sha(Path.Combine(data, "shop.db")));                       // the shop is exactly as it was
        Assert.False(PendingRestore.IsPending(data));                                   // and the bad note is gone, so it is not tried every start
    }

    [Fact]
    public void A_copy_set_aside_can_be_taken_back_before_the_next_start()
    {
        SwitchOn();
        var made = f.App.Backups.RunNow(BackupKinds.Manual);
        var data = Path.GetDirectoryName(f.App.Db.Path)!;
        f.App.Backups.StageRestore(Path.Combine(Place, made.FileName!), null);
        Assert.True(PendingRestore.IsPending(data));
        f.App.Backups.CancelRestore(null);
        Assert.False(PendingRestore.IsPending(data));
        Assert.Null(PendingRestore.ApplyIfPending(data, f.App.Db.Path));
    }

    [Fact]
    public void An_update_puts_its_safe_copy_in_the_place_the_owner_chose_when_no_other_place_is_set()
    {
        SwitchOn();
        var path = f.App.Db.Path;
        f.App.Db.Rollback(1);                                                           // an old shop: first structure only
        var db = new HubDb(path);                                                       // no Hub:BackupFolder given
        db.Migrate();
        Assert.Equal(Place, Path.GetDirectoryName(db.LastBackup));
        Assert.Contains($"before-update-1-to-{HubDb.LatestVersion}", db.LastBackup);
    }

    [Fact]
    public void Undoing_the_backup_step_drops_only_its_list_and_keeps_every_bill_and_every_copy()
    {
        SwitchOn();
        var made = f.App.Backups.RunNow(BackupKinds.Manual);
        var path = f.App.Db.Path;

        f.App.Db.Rollback(12);
        Assert.Null(f.App.Db.Scalar("SELECT name FROM sqlite_master WHERE name = 'backup_runs'"));
        Assert.Equal(1, Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM documents WHERE status = 'issued'")));
        Assert.True(File.Exists(Path.Combine(Place, made.FileName!)));

        var again = HubApp.OpenTrusted(path, f.Clock);
        Assert.NotNull(again.Db.Scalar("SELECT name FROM sqlite_master WHERE name = 'backup_runs'"));
        Assert.Empty(again.Backups.Runs());
    }

    [Fact]
    public void Only_the_owner_may_change_the_choices_make_a_copy_by_hand_or_put_one_back()
    {
        var owner = f.App.Users.Create("olivia", "Olivia Owner", NextGenOS.Hub.Security.Roles.Owner, "correct horse battery").Id;
        var till = f.App.Users.Create("tara", "Tara Till", NextGenOS.Hub.Security.Roles.Cashier, "another good password").Id;
        var strict = HubApp.Open(f.App.Db.Path, f.Clock);
        var settings = new BackupSettings(true, Place, "02:00", 14);
        using (strict.Access.As(till))
        {
            Assert.Equal("forbidden", Assert.Throws<HubException>(() => strict.Backups.Save(settings, till)).Code);
            Assert.Equal("forbidden", Assert.Throws<HubException>(() => strict.Backups.RunNow(BackupKinds.Manual, till)).Code);
            Assert.Equal("forbidden", Assert.Throws<HubException>(() => strict.Backups.StageRestore("x", till)).Code);
        }

        using (strict.Access.As(owner))
        {
            strict.Backups.Save(settings, owner);
            Assert.True(strict.Backups.RunNow(BackupKinds.Manual, owner).Good);
        }
    }
}
