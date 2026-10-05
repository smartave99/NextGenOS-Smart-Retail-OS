using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Xunit;

namespace NextGenOS.Licensing.Tests
{
    /// <summary>Every situation a customer or a salesperson can cause, with the real client against the real Studio.</summary>
    public class LiveStudioTests
    {
        [LiveFact]
        public async Task A_typed_key_activates_the_PC_and_the_licence_carries_what_was_sold()
        {
            var lic = LiveStudio.NewLicence("business", "y1");
            using (var pc = new FakePc("counter-1"))
            {
                var state = await pc.Manager().ActivateAsync("  " + lic.Item2.ToLowerInvariant().Replace("-", " ") + " ");
                Assert.Equal(LicenceStatus.Valid, state.Status);
                Assert.True(state.IsUsable);
                Assert.Equal(lic.Item1, state.Licence.LicenceId);
                Assert.Equal("business", state.Licence.Edition);
                Assert.Contains("pos", state.Licence.Modules);
                Assert.Equal(3, state.Licence.Limits.Devices);
                Assert.Equal("theme", state.WhiteLabelLevel);
                Assert.Equal("Smart Retail POS", state.Brand.Name);
                Assert.True(state.ExpiresUtc.Value > DateTime.UtcNow.AddDays(360));

                // A second look (a program start) needs no network and gives the same answer.
                var again = new FakePc("unused");
                again.Dispose();
                var offline = new LicenceManager(new LicenceOptions { Directory = pc.Directory, ServerUrl = "http://127.0.0.1:1", TrustedKeys = pc.Keys, RequiredModule = "pos", Fingerprint = new FixedFingerprintSource(pc.Hardware) });
                Assert.Equal(LicenceStatus.Valid, offline.Evaluate().Status);
            }
        }

        [LiveFact]
        public async Task A_wrong_key_or_unknown_key_gets_a_plain_message()
        {
            using (var pc = new FakePc("counter-1"))
            {
                var ex = await Assert.ThrowsAsync<LicenceServerException>(() => pc.Manager().ActivateAsync("NGOS-AAAAA-AAAAA-AAAAA-AAAAA"));
                Assert.Equal("unknown_key", ex.Code);
                Assert.Contains("licence key was not found", ex.Message);
                Assert.False(ex.IsNetwork);
                Assert.Equal(LicenceStatus.Missing, pc.Manager().Evaluate().Status);
            }
        }

        [LiveFact]
        public async Task The_PC_limit_is_enforced_and_freeing_a_PC_makes_room()
        {
            var lic = LiveStudio.NewLicence("starter", "y1"); // starter: one PC
            using (var a = new FakePc("pc-a"))
            using (var b = new FakePc("pc-b"))
            {
                Assert.Equal(LicenceStatus.Valid, (await a.Manager().ActivateAsync(lic.Item2)).Status);
                var ex = await Assert.ThrowsAsync<LicenceServerException>(() => b.Manager().ActivateAsync(lic.Item2));
                Assert.Equal("limit_reached", ex.Code);
                Assert.Contains("all it allows", ex.Message);

                // The same PC activating again does not use a second seat.
                Assert.Equal(LicenceStatus.Valid, (await a.Manager().ActivateAsync(lic.Item2)).Status);

                LiveStudio.Cli("free-devices", lic.Item1);
                Assert.Equal(LicenceStatus.Valid, (await b.Manager().ActivateAsync(lic.Item2)).Status);

                // The first PC learns at its next check-in that it was released, and asks for activation again.
                var state = await a.Manager().CheckInAsync(force: true);
                Assert.Equal(LicenceStatus.NotActivated, state.Status);
            }
        }

        [LiveFact]
        public async Task A_licence_copied_to_another_PC_does_not_work()
        {
            var lic = LiveStudio.NewLicence("business", "y1");
            using (var original = new FakePc("original"))
            using (var thief = new FakePc("thief"))
            {
                await original.Manager().ActivateAsync(lic.Item2);
                foreach (var file in Directory.GetFiles(original.Directory)) File.Copy(file, Path.Combine(Directory.CreateDirectory(thief.Directory).FullName, Path.GetFileName(file)), true);
                Assert.Equal(LicenceStatus.DeviceMismatch, thief.Manager().Evaluate().Status);
                Assert.Equal(LicenceStatus.Valid, original.Manager().Evaluate().Status);
            }
        }

        [LiveFact]
        public async Task Upgrades_keep_the_licence_working_but_a_cloned_image_or_a_new_machine_does_not()
        {
            var lic = LiveStudio.NewLicence("business", "y1");
            using (var pc = new FakePc("upgraded"))
            {
                await pc.Manager().ActivateAsync(lic.Item2);
                pc.Hardware["disk"] = "NEW-SSD-SERIAL";          // a new disk
                Assert.Equal(LicenceStatus.Valid, pc.Manager().Evaluate().Status);
                pc.Hardware["os"] = "REINSTALLED-GUID";          // and Windows reinstalled
                Assert.Equal(LicenceStatus.Valid, pc.Manager().Evaluate().Status);
                pc.Hardware["bios"] = "NEW-BIOS";                // a new motherboard as well: that is a different machine
                Assert.Equal(LicenceStatus.DeviceMismatch, pc.Manager().Evaluate().Status);
            }

            // A cloned Windows image on identical PCs: same CPU model and machine id, different serial numbers.
            lic = LiveStudio.NewLicence("starter", "y1"); // one PC only, so a clone has no seat to take
            using (var original = new FakePc("original"))
            using (var clone = new FakePc("clone"))
            {
                await original.Manager().ActivateAsync(lic.Item2);
                foreach (var file in Directory.GetFiles(original.Directory)) File.Copy(file, Path.Combine(Directory.CreateDirectory(clone.Directory).FullName, Path.GetFileName(file)), true);
                clone.Hardware["cpu"] = original.Hardware["cpu"];
                clone.Hardware["os"] = original.Hardware["os"];
                Assert.Equal(LicenceStatus.DeviceMismatch, clone.Manager().Evaluate().Status);
                var ex = await Assert.ThrowsAsync<LicenceServerException>(() => clone.Manager().ActivateAsync(lic.Item2)); // and no free seat either
                Assert.Equal("limit_reached", ex.Code);
            }
        }

        [LiveFact]
        public async Task Without_internet_the_PC_works_through_the_grace_period_then_asks_for_a_check_in_and_recovers()
        {
            var lic = LiveStudio.NewLicence("business", "y1");
            using (var pc = new FakePc("rural-shop"))
            {
                await pc.Manager().ActivateAsync(lic.Item2);

                pc.ClockOffset = TimeSpan.FromDays(3);
                Assert.Equal(LicenceStatus.Valid, pc.Manager().Evaluate().Status);

                pc.ClockOffset = TimeSpan.FromDays(10); // check-in is overdue, the server cannot be reached
                pc.Server = "http://127.0.0.1:1";
                var grace = await pc.Manager().CheckInAsync(force: true);
                Assert.Equal(LicenceStatus.Grace, grace.Status);
                Assert.True(grace.IsUsable);
                Assert.InRange(grace.GraceDaysLeft, 10, 12);
                Assert.Contains("Internet", grace.Message);

                pc.ClockOffset = TimeSpan.FromDays(30);
                var locked = await pc.Manager().CheckInAsync(force: true);
                Assert.Equal(LicenceStatus.NeedsCheckIn, locked.Status);
                Assert.False(locked.IsUsable);

                // The internet is back and the clock is right again: one check-in and it works.
                pc.Server = LiveStudio.Url;
                pc.ClockOffset = TimeSpan.Zero;
                var back = pc.Manager();
                var state = await back.CheckInAsync(force: true);
                Assert.Equal(LicenceStatus.Valid, state.Status);
                Assert.Null(back.LastError);
            }
        }

        [LiveFact]
        public async Task Putting_the_clock_back_is_noticed_and_a_check_in_with_the_right_clock_clears_it()
        {
            var lic = LiveStudio.NewLicence("business", "y1");
            using (var pc = new FakePc("clock-games"))
            {
                await pc.Manager().ActivateAsync(lic.Item2);
                pc.ClockOffset = TimeSpan.FromDays(5);
                Assert.Equal(LicenceStatus.Valid, pc.Manager().Evaluate().Status); // time passes forward: fine
                pc.ClockOffset = TimeSpan.Zero; // now the clock is set back by five days
                Assert.Equal(LicenceStatus.ClockTampered, pc.Manager().Evaluate().Status);
                var fixedState = await pc.Manager().CheckInAsync(force: true); // honest clock + the server's word
                Assert.Equal(LicenceStatus.Valid, fixedState.Status);
            }
        }

        [LiveFact]
        public async Task A_withdrawn_licence_stops_at_the_next_check_in_and_a_hold_can_be_released()
        {
            var held = LiveStudio.NewLicence("business", "y1");
            using (var pc = new FakePc("held-shop"))
            {
                var m = pc.Manager();
                await m.ActivateAsync(held.Item2);

                LiveStudio.Cli("suspend", held.Item1, "--reason", "unpaid");
                var s1 = await pc.Manager().CheckInAsync(force: true);
                Assert.Equal(LicenceStatus.Revoked, s1.Status);
                Assert.False(s1.IsUsable);

                LiveStudio.Cli("resume", held.Item1);
                var s2 = await pc.Manager().CheckInAsync(force: true);
                Assert.Equal(LicenceStatus.Valid, s2.Status);

                LiveStudio.Cli("revoke", held.Item1, "--reason", "fraud");
                Assert.Equal(LicenceStatus.Revoked, (await pc.Manager().CheckInAsync(force: true)).Status);

                // Withdrawn for good: the same key can no longer activate another PC either.
                using (var other = new FakePc("someone-else"))
                {
                    var ex = await Assert.ThrowsAsync<LicenceServerException>(() => other.Manager().ActivateAsync(held.Item2));
                    Assert.Equal("revoked", ex.Code);
                }
            }
        }

        [LiveFact]
        public async Task A_renewal_and_a_bigger_plan_reach_the_PC_at_its_next_check_in()
        {
            var lic = LiveStudio.NewLicence("starter", "y1");
            using (var pc = new FakePc("growing-shop"))
            {
                var before = await pc.Manager().ActivateAsync(lic.Item2);
                Assert.Equal(1, before.Licence.Limits.Devices);
                Assert.Equal(1, before.Licence.Revision);

                LiveStudio.Cli("renew", lic.Item1, "--term", "y2");
                LiveStudio.Cli("change", lic.Item1, "--devices", "2");
                var after = await pc.Manager().CheckInAsync(force: true);
                Assert.Equal(3, after.Licence.Revision);
                Assert.Equal(2, after.Licence.Limits.Devices);
                Assert.True(after.ExpiresUtc.Value > before.ExpiresUtc.Value.AddDays(700));
            }
        }

        [LiveFact]
        public async Task A_trial_that_has_ended_is_refused_in_plain_words_and_a_future_licence_is_not_started()
        {
            var ended = LiveStudio.NewLicence("business", "trial30", "--start", "2020-01-01");
            var future = LiveStudio.NewLicence("business", "y1", "--start", "2099-01-01");
            using (var pc = new FakePc("late-shop"))
            {
                var ex = await Assert.ThrowsAsync<LicenceServerException>(() => pc.Manager().ActivateAsync(ended.Item2));
                Assert.Equal("expired", ex.Code);
                Assert.Contains("renew", ex.Message);
                var ex2 = await Assert.ThrowsAsync<LicenceServerException>(() => pc.Manager().ActivateAsync(future.Item2));
                Assert.Equal("not_started", ex2.Code);
            }
        }

        [LiveFact]
        public async Task Offline_activation_round_trip_gives_a_long_lived_activation()
        {
            var lic = LiveStudio.NewLicence("business", "y1", "--offline");
            using (var pc = new FakePc("no-internet"))
            {
                var m = pc.Manager();
                var request = m.CreateOfflineRequest(lic.Item2);
                Assert.StartsWith("NGOSREQ1.", request);
                var answer = LiveStudio.Cli("offline-activate", request);
                var state = m.ImportOfflineResponse(answer);
                Assert.Equal(LicenceStatus.Valid, state.Status);
                Assert.True(state.Activation.NextCheckIn - state.Activation.IssuedAt >= 364 * 86400L);

                // An answer made for another PC is refused.
                using (var other = new FakePc("another-pc"))
                {
                    Assert.Throws<LicenceException>(() => other.Manager().ImportOfflineResponse(answer));
                }
            }
        }

        [LiveFact]
        public async Task A_website_licence_needs_no_activation_but_only_works_on_its_own_address()
        {
            var lic = LiveStudio.NewLicence("growth", "y1", "--bind", "domain", "--domains", "shop.example.com,*.example.org");
            using (var server = new FakePc("web-server") { Module = "storefront" })
            {
                server.Host = "shop.example.com";
                var state = await server.Manager().ActivateAsync(lic.Item2);
                Assert.Equal(LicenceStatus.Valid, state.Status);
                Assert.Null(state.Activation);

                server.Host = "SHOP.example.com:3000";
                Assert.Equal(LicenceStatus.Valid, server.Manager().Evaluate().Status);
                server.Host = "a.example.org";
                Assert.Equal(LicenceStatus.Valid, server.Manager().Evaluate().Status);
                server.Host = "evil.example.net";
                Assert.Equal(LicenceStatus.DomainMismatch, server.Manager().Evaluate().Status);
                server.Host = "shop.example.com.evil.test";
                Assert.Equal(LicenceStatus.DomainMismatch, server.Manager().Evaluate().Status);
            }
        }

        [LiveFact]
        public async Task A_module_the_customer_did_not_buy_is_refused()
        {
            var lic = LiveStudio.NewLicence("starter", "y1"); // billing only
            using (var pc = new FakePc("billing-only") { Module = "ai" })
            {
                var state = await pc.Manager().ActivateAsync(lic.Item2);
                Assert.Equal(LicenceStatus.ModuleNotLicensed, state.Status);
                Assert.False(state.IsUsable);
                pc.Module = "pos";
                Assert.Equal(LicenceStatus.Valid, pc.Manager().Evaluate().Status);
            }
        }

        [LiveFact]
        public async Task Edited_or_damaged_files_are_refused()
        {
            var lic = LiveStudio.NewLicence("business", "y1");
            using (var pc = new FakePc("tamper"))
            {
                await pc.Manager().ActivateAsync(lic.Item2);
                var file = Path.Combine(pc.Directory, "licence.ngos");
                var original = File.ReadAllText(file);

                // Change the payload (for example to add a module or a PC): the signature no longer matches.
                var parts = original.Trim().Split('.');
                var payload = JObject.Parse(System.Text.Encoding.UTF8.GetString(Base64Url.Decode(parts[1])));
                payload["limits"]["devices"] = 500;
                File.WriteAllText(file, parts[0] + "." + Base64Url.Encode(System.Text.Encoding.UTF8.GetBytes(payload.ToString(Newtonsoft.Json.Formatting.None))) + "." + parts[2]);
                Assert.Equal(LicenceStatus.Invalid, pc.Manager().Evaluate().Status);

                File.WriteAllText(file, "garbage");
                Assert.Equal(LicenceStatus.Invalid, pc.Manager().Evaluate().Status);

                File.Delete(file);
                Assert.Equal(LicenceStatus.Missing, pc.Manager().Evaluate().Status);

                File.WriteAllText(file, original);
                Assert.Equal(LicenceStatus.Valid, pc.Manager().Evaluate().Status);

                // Deleting the activation leaves a licence that needs activating.
                File.Delete(Path.Combine(pc.Directory, "activation.ngos"));
                Assert.Equal(LicenceStatus.NotActivated, pc.Manager().Evaluate().Status);
            }
        }

        [LiveFact]
        public async Task A_server_that_is_not_ours_cannot_install_a_licence()
        {
            var lic = LiveStudio.NewLicence("business", "y1");
            using (var pc = new FakePc("careful"))
            {
                // This build trusts a different key than the server signs with, as if the address were hijacked.
                pc.Keys = new[] { new TrustedKey("k-someone-else", LiveStudio.Keys[0].PublicKey) };
                Assert.ThrowsAny<Exception>(() => pc.Manager().ActivateAsync(lic.Item2).GetAwaiter().GetResult());
                Assert.Equal(LicenceStatus.Missing, pc.Manager().Evaluate().Status);
                Assert.Null(new LicenceStore(pc.Directory).LicenceToken);
            }
        }

        [LiveFact]
        public async Task The_licence_can_be_given_back_so_the_seat_is_free()
        {
            var lic = LiveStudio.NewLicence("starter", "y1");
            using (var a = new FakePc("old-pc"))
            using (var b = new FakePc("new-pc"))
            {
                await a.Manager().ActivateAsync(lic.Item2);
                await a.Manager().DeactivateAsync();
                Assert.Equal(LicenceStatus.Missing, a.Manager().Evaluate().Status);
                Assert.Equal(LicenceStatus.Valid, (await b.Manager().ActivateAsync(lic.Item2)).Status);
            }
        }
    }
}
