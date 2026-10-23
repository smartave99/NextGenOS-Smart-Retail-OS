using System.Net;
using System.Net.Sockets;
using NextGenOS.Hub.Ai;
using NextGenOS.Hub.Cameras;
using NextGenOS.Hub.Security;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// The register of the shop's cameras (Version 2, Phase 7, step 1): off until the owner says so; only the owner; only addresses on this computer or the shop's own network; no password in an
/// address or in the database; no face in the list of things to look for; a camera can be switched on only once the program has reached it; and the program only connects to a camera and lets go
/// (it reads no picture and no video).
/// </summary>
public sealed class CameraTests : IDisposable
{
    private readonly AiFixture f = new();
    private readonly long owner, manager, cashier;
    private HubApp? strict;

    public CameraTests()
    {
        f.Allow(FlagKey.CameraAnalytics);
        owner = f.App.Users.Create("olivia", "Olivia Owner", Roles.Owner, "correct horse battery").Id;
        manager = f.App.Users.Create("mia", "Mia Manager", Roles.Manager, "manager good password").Id;
        cashier = f.App.Users.Create("tara", "Tara Till", Roles.Cashier, "another good password").Id;
    }

    public void Dispose() => f.Dispose();

    private HubApp S => strict ??= f.OpenStrict();

    private CameraService C => f.App.Cameras;

    private static CameraInput Input(string name = "Front door", string kind = CameraKind.Rtsp, string address = "rtsp://192.168.1.50:554/stream1", string? zone = "zone:entrance",
        string[]? classes = null, int confidence = 60) => new(name, kind, address, zone, classes ?? [CameraClass.Person], confidence);

    private static string Code(Action act) => Assert.Throws<HubException>(act).Code;

    /// <summary>A "camera" that is only a door on this computer: it accepts a connection and notes whether anything is sent to it.</summary>
    private sealed class Door : IDisposable
    {
        private readonly TcpListener listener = new(IPAddress.Loopback, 0);
        private readonly List<byte> received = new();
        private readonly CancellationTokenSource stop = new();

        public Door()
        {
            listener.Start();
            _ = Task.Run(async () =>
            {
                try
                {
                    while (!stop.IsCancellationRequested)
                    {
                        using var client = await listener.AcceptTcpClientAsync(stop.Token);
                        var buffer = new byte[256];
                        client.ReceiveTimeout = 300;
                        try { var n = await client.GetStream().ReadAsync(buffer, stop.Token); lock (received) received.AddRange(buffer.Take(n)); } catch (Exception e) when (e is IOException or OperationCanceledException) { }
                    }
                }
                catch (Exception e) when (e is OperationCanceledException or ObjectDisposedException or SocketException) { }
            });
        }

        public int Port => ((IPEndPoint)listener.LocalEndpoint).Port;

        public int BytesReceived { get { lock (received) return received.Count; } }

        public void Dispose() { stop.Cancel(); listener.Stop(); }
    }

    private static int ClosedPort()
    {
        var l = new TcpListener(IPAddress.Loopback, 0);
        l.Start();
        var port = ((IPEndPoint)l.LocalEndpoint).Port;
        l.Stop();
        return port;
    }

    // ---- off until the owner says so, and only the owner ----------------------------------------------------------------------------

    [Fact]
    public async Task Nothing_is_added_or_tested_until_the_owner_switches_camera_analytics_on_and_the_licence_has_the_AI_part()
    {
        var camera = C.Register(Input(), owner);
        f.Ai.Flags.Set(FlagKey.CameraAnalytics, false, owner);
        Assert.False(C.On);
        Assert.Equal("cameras-off", Code(() => C.Register(Input("Back door"), owner)));
        Assert.Equal("cameras-off", Code(() => C.Update(camera.Id, Input("Front"), owner)));
        Assert.Equal("cameras-off", (await Assert.ThrowsAsync<HubException>(() => C.TestAsync(camera.Id, owner))).Code);
        Assert.Single(C.List());            // what was kept stays readable
        C.SetEnabled(camera.Id, false, owner);   // and switching off is always possible

        f.Ai.Flags.Set(FlagKey.CameraAnalytics, true, owner);
        f.Entitled.Allowed = false;
        Assert.Equal("not-licensed", Code(() => C.Register(Input("Back door"), owner)));
        Assert.Single(C.List());
    }

    [Fact]
    public void Only_the_owner_may_see_or_change_the_cameras_and_nobody_signed_out_may_do_anything()
    {
        var camera = C.Register(Input(), owner);
        foreach (var person in new[] { manager, cashier })
        {
            using var scope = S.Access.As(person);
            Assert.Equal("forbidden", Code(() => S.Cameras.List()));
            Assert.Equal("forbidden", Code(() => S.Cameras.Get(camera.Id)));
            Assert.Equal("forbidden", Code(() => S.Cameras.Register(Input("Back door"), person)));
            Assert.Equal("forbidden", Code(() => S.Cameras.Update(camera.Id, Input("Front"), person)));
            Assert.Equal("forbidden", Code(() => S.Cameras.SetEnabled(camera.Id, false, person)));
            Assert.Equal("forbidden", Code(() => S.Cameras.Retire(camera.Id, person)));
            Assert.Equal("forbidden", Code(() => S.Cameras.SetPassword(camera.Id, "secret", person)));
            Assert.Equal("forbidden", Code(() => S.Cameras.ClearPassword(camera.Id, person)));
            Assert.Equal("forbidden", Assert.ThrowsAsync<HubException>(() => S.Cameras.TestAsync(camera.Id, person)).GetAwaiter().GetResult().Code);
        }

        using (S.Access.As(owner)) Assert.Single(S.Cameras.List());
        using (S.Access.As(null as long?)) Assert.Equal("not-signed-in", Code(() => S.Cameras.List()));
    }

    // ---- what is kept ----------------------------------------------------------------------------------------------------------------

    [Fact]
    public void A_camera_is_kept_with_a_short_name_for_it_and_starts_switched_off_and_not_checked()
    {
        var a = C.Register(Input("  Front   door "), owner);
        var b = C.Register(Input("Front door", address: "rtsp://192.168.1.51/stream1"), owner);

        Assert.Equal(("camera:front-door", "Front door", CameraKind.Rtsp, "rtsp://192.168.1.50:554/stream1", "zone:entrance", 60), (a.Ref, a.Name, a.Kind, a.Address, a.ZoneRef, a.MinConfidencePercent));
        Assert.Equal("camera:front-door-2", b.Ref);
        Assert.All(new[] { a, b }, c => { Assert.False(c.Enabled); Assert.Null(c.CheckStatus); Assert.Null(c.CheckedAt); Assert.False(c.HasPassword); Assert.False(c.Retired); });
        Assert.Equal(["camera:front-door", "camera:front-door-2"], C.List().Select(c => c.Ref).ToArray());
        Assert.Equal("camera:camera", C.Register(Input("***", address: "rtsp://192.168.1.52/s"), owner).Ref);
    }

    [Fact]
    public void Each_kind_of_camera_has_its_own_way_of_writing_the_address_and_a_wrong_one_is_refused_in_plain_words()
    {
        Assert.Equal("rtsp://192.168.1.50/stream1?channel=1", C.Register(Input("a", CameraKind.Rtsp, "rtsp://192.168.1.50/stream1?channel=1"), owner).Address);
        Assert.Equal("rtsps://10.0.0.7:322/x", C.Register(Input("b", CameraKind.Rtsp, "rtsps://10.0.0.7:322/x"), owner).Address);
        Assert.Equal("http://192.168.1.60/onvif/device_service", C.Register(Input("c", CameraKind.Onvif, "192.168.1.60"), owner).Address);
        Assert.Equal("http://192.168.1.61:8080/onvif/device_service", C.Register(Input("d", CameraKind.Onvif, "192.168.1.61:8080"), owner).Address);
        Assert.Equal("http://192.168.1.62/custom", C.Register(Input("e", CameraKind.Onvif, "http://192.168.1.62/custom"), owner).Address);
        Assert.Equal("USB Camera (0)", C.Register(Input("f", CameraKind.Usb, "USB Camera (0)"), owner).Address);
        Assert.Equal("/dev/video0", C.Register(Input("g", CameraKind.Usb, "/dev/video0"), owner).Address);
        Assert.Equal("/home/shop/clips/door.MP4", C.Register(Input("h", CameraKind.File, "/home/shop/clips/door.MP4"), owner).Address);
        Assert.Equal(@"C:\Clips\door.jpg", C.Register(Input("i", CameraKind.File, @"C:\Clips\door.jpg"), owner).Address);

        string Refused(string kind, string address) => Assert.Throws<HubException>(() => C.Register(Input("x", kind, address), owner)).Code;
        Assert.Equal("bad-address", Refused(CameraKind.Rtsp, ""));
        Assert.Equal("bad-address", Refused(CameraKind.Rtsp, "http://192.168.1.50/stream"));       // not a stream address
        Assert.Equal("bad-address", Refused(CameraKind.Rtsp, "192.168.1.50"));
        Assert.Equal("bad-address", Refused(CameraKind.Rtsp, new string('a', CameraService.MaxAddressChars + 1)));
        Assert.Equal("bad-address", Refused(CameraKind.Rtsp, "rtsp://192.168.1.50/a\u0001b"));
        Assert.Equal("bad-address", Refused(CameraKind.Onvif, "ftp://192.168.1.50/"));
        Assert.Equal("bad-address", Refused(CameraKind.Usb, "../../etc/passwd"));
        Assert.Equal("bad-address", Refused(CameraKind.Usb, "cam;rm -rf"));
        Assert.Equal("bad-address", Refused(CameraKind.File, "/home/shop/../etc/shadow.mp4"));
        Assert.Equal("bad-address", Refused(CameraKind.File, "/home/shop/notes.txt"));
        Assert.Equal("bad-address", Refused(CameraKind.File, @"\\server\share\door.mp4"));
        Assert.Equal("bad-address", Refused(CameraKind.File, "//server/share/door.mp4"));
        Assert.Equal("bad-kind", Assert.Throws<HubException>(() => C.Register(Input("x", "bluetooth", "x"), owner)).Code);
        Assert.Equal("bad-kind", Assert.Throws<HubException>(() => C.Register(Input("x", "", "x"), owner)).Code);
    }

    [Fact]
    public void A_camera_must_be_on_this_computer_or_the_shops_own_network_and_one_on_the_internet_is_refused()
    {
        foreach (var ok in new[] { "rtsp://127.0.0.1/s", "rtsp://localhost/s", "rtsp://[::1]/s", "rtsp://10.1.2.3/s", "rtsp://172.16.0.9/s", "rtsp://172.31.255.1/s", "rtsp://192.168.0.1/s", "rtsp://169.254.1.1/s", "rtsp://cam1/s", "rtsp://hall.local/s" })
            C.Register(Input("cam " + ok, CameraKind.Rtsp, ok), owner);
        foreach (var bad in new[] { "rtsp://8.8.8.8/s", "rtsp://172.32.0.1/s", "rtsp://192.169.0.1/s", "rtsp://cam.example.com/s", "rtsp://203.0.113.9:554/s", "rtsp://[2001:db8::1]/s" })
            Assert.Equal("outside-network", Code(() => C.Register(Input("x", CameraKind.Rtsp, bad), owner)));
        Assert.Equal("outside-network", Code(() => C.Register(Input("x", CameraKind.Onvif, "93.184.216.34"), owner)));
        Assert.Equal("outside-network", Code(() => C.Register(Input("x", CameraKind.Onvif, "https://camera.example.org/onvif"), owner)));
    }

    [Fact]
    public void A_user_name_or_password_in_the_address_is_refused()
    {
        Assert.Equal("password-in-address", Code(() => C.Register(Input("x", CameraKind.Rtsp, "rtsp://admin:hunter2@192.168.1.50/s"), owner)));
        Assert.Equal("password-in-address", Code(() => C.Register(Input("x", CameraKind.Rtsp, "rtsp://admin@192.168.1.50/s"), owner)));
        Assert.Equal("password-in-address", Code(() => C.Register(Input("x", CameraKind.Onvif, "http://admin:hunter2@192.168.1.50/onvif"), owner)));
        Assert.Empty(C.List());
    }

    [Fact]
    public void What_a_camera_may_look_for_is_a_short_closed_list_and_never_a_face()
    {
        Assert.Equal([CameraClass.Person, CameraClass.Basket], C.Register(Input("a", classes: [CameraClass.Basket, CameraClass.Person, CameraClass.Person]), owner).Classes.ToArray());   // in the order of the list, once each
        Assert.Equal(CameraClass.All, C.Register(Input("b", address: "rtsp://192.168.1.51/s", classes: [.. CameraClass.All]), owner).Classes.ToArray());
        foreach (var bad in new[] { "face", "FACE", "biometric", "licence-plate", "person,face", "" })
            Assert.Equal("bad-classes", Code(() => C.Register(Input("x", classes: [bad]), owner)));
        Assert.Equal("bad-classes", Code(() => C.Register(Input("x", classes: [CameraClass.Person, "face"]), owner)));
        Assert.Equal("bad-classes", Code(() => C.Register(Input("x", classes: []), owner)));
        Assert.DoesNotContain(CameraClass.All, c => c.Contains("face", StringComparison.OrdinalIgnoreCase) || c.Contains("bio", StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public void The_name_the_place_and_how_sure_the_program_must_be_are_checked()
    {
        Assert.Equal("bad-name", Code(() => C.Register(Input("  "), owner)));
        Assert.Equal("bad-name", Code(() => C.Register(Input(new string('n', CameraService.MaxNameChars + 1)), owner)));
        Assert.Equal("bad-name", Code(() => C.Register(Input("a\u0001b"), owner)));
        Assert.Equal("bad-place", Code(() => C.Register(Input(zone: "aisle-3"), owner)));
        Assert.Equal("bad-place", Code(() => C.Register(Input(zone: "zone:Aisle 3"), owner)));
        Assert.Equal("bad-place", Code(() => C.Register(Input(zone: "device:cam1"), owner)));
        Assert.Null(C.Register(Input("none", zone: null, address: "rtsp://192.168.1.60/s"), owner).ZoneRef);
        Assert.Null(C.Register(Input("blank", zone: "  ", address: "rtsp://192.168.1.61/s"), owner).ZoneRef);
        Assert.Equal("zone:aisle-3", C.Register(Input("ok", zone: "zone:aisle-3", address: "rtsp://192.168.1.62/s"), owner).ZoneRef);
        foreach (var bad in new[] { 0, 9, 100, -5 }) Assert.Equal("bad-confidence", Code(() => C.Register(Input(confidence: bad), owner)));
        Assert.Equal(10, C.Register(Input("low", address: "rtsp://192.168.1.63/s", confidence: 10), owner).MinConfidencePercent);
        Assert.Equal(99, C.Register(Input("high", address: "rtsp://192.168.1.64/s", confidence: 99), owner).MinConfidencePercent);
        Assert.Equal("bad-camera", Code(() => C.Register(null!, owner)));
    }

    [Fact]
    public void There_are_at_most_sixty_four_cameras_and_a_retired_one_does_not_count()
    {
        for (var i = 0; i < CameraService.MaxCameras; i++) C.Register(Input("cam " + i, address: "rtsp://192.168.1." + (i + 1) + "/s"), owner);
        Assert.Equal("too-many", Code(() => C.Register(Input("one more"), owner)));
        C.Retire(C.List()[0].Id, owner);
        C.Register(Input("one more"), owner);
    }

    // ---- the password -------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void The_password_is_kept_in_the_secret_store_and_nowhere_else_and_is_deleted_with_the_camera()
    {
        var camera = C.Register(Input(), owner);
        C.SetPassword(camera.Id, "  hunter2-very-secret  ", owner);

        Assert.True(C.Get(camera.Id).HasPassword);
        Assert.Equal("hunter2-very-secret", f.Secrets.Get("camera/" + camera.Id));
        // Not in the database, not in the audit trail, and not in anything the program hands to a screen.
        var everywhere = string.Join("\n", new[] { "cameras", "audit_log", "ai_usage" }.SelectMany(t => f.App.Db.Query($"SELECT * FROM {t}", r => string.Join("|", Enumerable.Range(0, r.FieldCount).Select(i => r.IsDBNull(i) ? "" : Convert.ToString(r.GetValue(i), System.Globalization.CultureInfo.InvariantCulture))))));
        Assert.DoesNotContain("hunter2", everywhere);
        Assert.DoesNotContain("hunter2", C.Get(camera.Id).ToString());
        Assert.Contains("camera.password", f.App.Audit.Recent().Select(a => a.Action));

        C.ClearPassword(camera.Id, owner);
        Assert.False(C.Get(camera.Id).HasPassword);
        Assert.Null(f.Secrets.Get("camera/" + camera.Id));

        C.SetPassword(camera.Id, "another-one", owner);
        C.Retire(camera.Id, owner);
        Assert.Null(f.Secrets.Get("camera/" + camera.Id));   // a retired camera keeps no password
    }

    [Fact]
    public void A_password_that_is_empty_too_long_or_has_odd_characters_is_refused_and_a_retired_camera_takes_none()
    {
        var camera = C.Register(Input(), owner);
        Assert.Equal("no-password", Code(() => C.SetPassword(camera.Id, "   ", owner)));
        Assert.Equal("no-password", Code(() => C.SetPassword(camera.Id, null, owner)));
        Assert.Equal("password-too-long", Code(() => C.SetPassword(camera.Id, new string('p', CameraService.MaxPasswordChars + 1), owner)));
        Assert.Equal("bad-password", Code(() => C.SetPassword(camera.Id, "pass\u0001word", owner)));
        Assert.False(C.Get(camera.Id).HasPassword);
        C.Retire(camera.Id, owner);
        Assert.Equal("retired", Code(() => C.SetPassword(camera.Id, "x", owner)));
    }

    // ---- switching on only after it was reached -------------------------------------------------------------------------------------

    [Fact]
    public async Task A_camera_can_be_switched_on_only_after_the_program_has_reached_it_and_moving_it_switches_it_off_again()
    {
        using var door = new Door();
        var camera = C.Register(Input(address: "rtsp://127.0.0.1:" + door.Port + "/s"), owner);
        Assert.Equal("not-checked", Code(() => C.SetEnabled(camera.Id, true, owner)));            // never tested

        var ok = await C.TestAsync(camera.Id, owner);
        Assert.Equal(CameraCheckStatus.Ok, ok.Status);
        Assert.Contains("answered at 127.0.0.1:" + door.Port, ok.Note);
        Assert.Contains("No picture was read", ok.Note);
        var checkedNow = C.Get(camera.Id);
        Assert.Equal((CameraCheckStatus.Ok, f.Shop.Clock.UtcNow), (checkedNow.CheckStatus, checkedNow.CheckedAt!.Value));
        Assert.True(C.SetEnabled(camera.Id, true, owner).Enabled);

        // Changing only the name or what it looks for keeps it on; a new address is a different thing to reach.
        Assert.True(C.Update(camera.Id, Input("Door camera", address: "rtsp://127.0.0.1:" + door.Port + "/s", classes: [CameraClass.Person, CameraClass.Cart]), owner).Enabled);
        var moved = C.Update(camera.Id, Input("Door camera", address: "rtsp://127.0.0.1:" + door.Port + "/other"), owner);
        Assert.False(moved.Enabled);
        Assert.Null(moved.CheckStatus);
        Assert.Null(moved.CheckedAt);
        Assert.Null(moved.CheckNote);
        Assert.Equal("not-checked", Code(() => C.SetEnabled(camera.Id, true, owner)));
        Assert.Contains("switched off: it moved", f.App.Audit.Recent().Where(a => a.Action == "camera.update").Select(a => a.Detail).First());

        // Switching off is always possible, and a camera that cannot be reached cannot be switched on.
        await C.TestAsync(camera.Id, owner);
        C.SetEnabled(camera.Id, true, owner);
        Assert.False(C.SetEnabled(camera.Id, false, owner).Enabled);
    }

    [Fact]
    public async Task A_camera_that_does_not_answer_says_so_in_plain_words_and_cannot_be_switched_on()
    {
        var camera = C.Register(Input(address: "rtsp://127.0.0.1:" + ClosedPort() + "/s"), owner);

        var answer = await C.TestAsync(camera.Id, owner);

        Assert.Equal(CameraCheckStatus.Failed, answer.Status);
        Assert.Contains("could not be reached", answer.Note);
        Assert.Equal(CameraCheckStatus.Failed, C.Get(camera.Id).CheckStatus);
        var refusal = Assert.Throws<HubException>(() => C.SetEnabled(camera.Id, true, owner));
        Assert.Equal("not-checked", refusal.Code);
        Assert.Contains("could not reach this camera", refusal.Message);
        Assert.False(C.Get(camera.Id).Enabled);
    }

    [Fact]
    public async Task Testing_a_network_camera_only_connects_and_lets_go_and_sends_nothing()
    {
        using var door = new Door();
        var camera = C.Register(Input(address: "rtsp://127.0.0.1:" + door.Port + "/s"), owner);
        var onvif = C.Register(Input("Second", CameraKind.Onvif, "127.0.0.1:" + door.Port), owner);

        await C.TestAsync(camera.Id, owner);
        await C.TestAsync(onvif.Id, owner);
        await Task.Delay(600);

        Assert.Equal(0, door.BytesReceived);   // not a word was said to the camera: no request, no picture asked for
    }

    [Fact]
    public async Task A_person_who_gives_up_waiting_cancels_the_test()
    {
        var camera = C.Register(Input(address: "rtsp://127.0.0.1:9/s"), owner);
        using var cancel = new CancellationTokenSource();
        cancel.Cancel();
        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => C.TestAsync(camera.Id, owner, cancel.Token));
    }

    [Fact]
    public async Task A_file_is_checked_by_looking_for_it_and_a_camera_plugged_into_the_computer_cannot_be_checked_from_here()
    {
        var path = Path.Combine(Path.GetTempPath(), "cam-test-" + Guid.NewGuid().ToString("N") + ".mp4");
        File.WriteAllBytes(path, new byte[3000]);
        try
        {
            var file = C.Register(Input("Clip", CameraKind.File, path), owner);
            var there = await C.TestAsync(file.Id, owner);
            Assert.Equal(CameraCheckStatus.Ok, there.Status);
            Assert.Contains("The file is there", there.Note);
            Assert.Contains("No picture was read", there.Note);
        }
        finally
        {
            File.Delete(path);
        }

        var missing = C.Register(Input("Gone", CameraKind.File, path), owner);
        var gone = await C.TestAsync(missing.Id, owner);
        Assert.Equal(CameraCheckStatus.Failed, gone.Status);
        Assert.Equal("not-checked", Code(() => C.SetEnabled(missing.Id, true, owner)));

        var usb = C.Register(Input("Counter", CameraKind.Usb, "USB Camera"), owner);
        var cannot = await C.TestAsync(usb.Id, owner);
        Assert.Equal(CameraCheckStatus.NotCheckable, cannot.Status);
        Assert.True(C.SetEnabled(usb.Id, true, owner).Enabled);   // it cannot be checked, so the owner's word is what there is
    }

    // ---- retiring and the record ------------------------------------------------------------------------------------------------------

    [Fact]
    public async Task A_retired_camera_is_switched_off_leaves_the_list_and_cannot_be_changed_tested_or_switched_on()
    {
        var camera = C.Register(Input("Old", CameraKind.Usb, "USB Camera"), owner);
        await C.TestAsync(camera.Id, owner);
        C.SetEnabled(camera.Id, true, owner);

        C.Retire(camera.Id, owner);
        C.Retire(camera.Id, owner);   // retiring twice is harmless

        Assert.Empty(C.List());
        Assert.Single(C.List(includeRetired: true));
        var gone = C.Get(camera.Id);
        Assert.True(gone.Retired);
        Assert.False(gone.Enabled);
        Assert.Equal("retired", Code(() => C.Update(camera.Id, Input("Old", CameraKind.Usb, "USB Camera"), owner)));
        Assert.Equal("retired", Code(() => C.SetEnabled(camera.Id, true, owner)));
        Assert.Equal("retired", (await Assert.ThrowsAsync<HubException>(() => C.TestAsync(camera.Id, owner))).Code);
        Assert.Equal("no-camera", Code(() => C.Get(9999)));
        Assert.Single(f.App.Audit.Recent().Where(a => a.Action == "camera.retire"));
    }

    [Fact]
    public async Task Every_change_is_in_the_audit_trail_with_the_name_and_never_the_address_or_the_password()
    {
        using var door = new Door();
        var camera = C.Register(Input("Secret place", address: "rtsp://127.0.0.1:" + door.Port + "/very-private-path"), owner);
        C.SetPassword(camera.Id, "hunter2", owner);
        await C.TestAsync(camera.Id, owner);
        C.SetEnabled(camera.Id, true, owner);
        C.SetEnabled(camera.Id, false, owner);
        C.Retire(camera.Id, owner);

        var actions = f.App.Audit.Recent(100).Where(a => a.Action.StartsWith("camera.", StringComparison.Ordinal)).Select(a => a.Action).ToList();
        foreach (var action in new[] { "camera.add", "camera.password", "camera.test", "camera.enable", "camera.disable", "camera.retire" }) Assert.Contains(action, actions);
        var text = string.Join("\n", f.App.Audit.Recent(100).Select(a => a.Detail));
        Assert.Contains("Secret place", text);
        Assert.DoesNotContain("very-private-path", text);
        Assert.DoesNotContain("127.0.0.1", text);
        Assert.DoesNotContain("hunter2", text);
    }

    [Fact]
    public void Changing_a_camera_changes_what_is_written_about_it_and_keeps_its_reference()
    {
        var camera = C.Register(Input(), owner);
        var changed = C.Update(camera.Id, Input("Main entrance", zone: "zone:lobby", classes: [CameraClass.Person, CameraClass.Product], confidence: 75), owner);

        Assert.Equal((camera.Ref, "Main entrance", "zone:lobby", 75), (changed.Ref, changed.Name, changed.ZoneRef, changed.MinConfidencePercent));
        Assert.Equal([CameraClass.Person, CameraClass.Product], changed.Classes.ToArray());
        Assert.Equal("bad-classes", Code(() => C.Update(camera.Id, Input(classes: ["face"]), owner)));
        Assert.Equal("outside-network", Code(() => C.Update(camera.Id, Input(address: "rtsp://8.8.8.8/s"), owner)));
        Assert.Equal("Main entrance", C.Get(camera.Id).Name);   // a refused change changes nothing
    }

    // ---- the database step ------------------------------------------------------------------------------------------------------------

    [Fact]
    public void The_new_table_carries_the_tenant_and_the_site()
    {
        var columns = f.App.Db.Query("SELECT name FROM pragma_table_info('cameras')", r => r.GetString(0));
        Assert.Contains("tenant_id", columns);
        Assert.Contains("site_id", columns);
        Assert.DoesNotContain(columns, c => c.Contains("password", StringComparison.OrdinalIgnoreCase) || c.Contains("secret", StringComparison.OrdinalIgnoreCase) || c.Contains("frame", StringComparison.OrdinalIgnoreCase) || c.Contains("image", StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public void The_step_can_be_undone_alone_and_the_shop_and_the_earlier_steps_are_untouched()
    {
        var item = f.App.Catalog.Create(new NextGenOS.Hub.Catalog.ItemInput { Kind = "stock", Name = "Rice", PriceMinor = 42500, TaxClass = "standard" });
        C.Register(Input(), owner);
        f.App.Db.Rollback(31);
        var names = f.App.Db.Query("SELECT name FROM sqlite_master", r => r.GetString(0)).ToHashSet();
        Assert.DoesNotContain("cameras", names);
        Assert.DoesNotContain("ux_cameras_ref", names);
        Assert.Contains("assistant_questions", names);   // the step before stays
        Assert.Equal("Rice", f.App.Db.Scalar("SELECT name FROM items WHERE id = $i", ("$i", item.Id)));
        Assert.True(File.Exists(f.App.Db.LastBackup));

        var again = HubApp.OpenTrusted(f.App.Db.Path, f.Shop.Clock, null, null);
        Assert.Equal(0L, Convert.ToInt64(again.Db.Scalar("SELECT COUNT(*) FROM cameras")));
    }
}
