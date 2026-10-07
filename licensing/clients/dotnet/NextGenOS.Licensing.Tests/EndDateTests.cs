using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Xunit;

namespace NextGenOS.Licensing.Tests
{
    /// <summary>A licence that ended: "banner" keeps working with a banner, anything else stops (spec section 10.1). Uses the Studio's signed vectors.</summary>
    public class EndDateTests
    {
        private static readonly JObject Vectors = JObject.Parse(System.IO.File.ReadAllText(System.IO.Path.Combine(AppContext.BaseDirectory, "vectors.json")));

        private static LicenceState Run(string name)
        {
            var c = Vectors["cases"].First(x => (string)x["name"] == name);
            return LicenceEvaluator.Evaluate(new EvaluationInput
            {
                LicenceToken = (string)c["lic"],
                ActivationToken = (string)c["act"],
                RevocationListToken = (string)c["crl"],
                Fingerprint = c["fp"].Children<JProperty>().Select(p => p.Name + ":" + (string)p.Value).OrderBy(x => x, StringComparer.Ordinal).ToList(),
                Host = (string)c["host"],
                RequiredModule = (string)c["module"],
                Now = (long)c["now"],
                LastSeen = c["lastSeen"].Type == JTokenType.Null ? 0 : (long)c["lastSeen"],
                TrustedKeys = Vectors["publicKeys"].Select(k => new TrustedKey((string)k["kid"], (string)k["publicKey"])).ToList(),
            });
        }

        [Fact]
        public void A_licence_signed_banner_keeps_working_after_its_end_and_says_how_long_ago()
        {
            var s = Run("ended_banner_runs");
            Assert.Equal(LicenceStatus.Ended, s.Status);
            Assert.True(s.IsUsable);
            Assert.Equal(5, s.EndedDaysAgo);
            Assert.Contains("ended 5 days ago", s.Message);
            Assert.Contains("keeps working", s.Message);
            Assert.Equal(s.Message, s.Banner);
            Assert.Equal("Your licence has ended, but the program keeps working. Please renew it with your supplier.", Run("ended_banner_first_day_is_day_zero").Banner);
            Assert.Contains("ended 1 day ago", new LicenceState { Status = LicenceStatus.Ended, EndedDaysAgo = 1 }.Message);
        }

        [Theory]
        [InlineData("expired")]
        [InlineData("expired_when_on_end_is_stop")]
        [InlineData("expired_when_on_end_is_unknown_text")]
        [InlineData("expired_when_on_end_is_not_text")]
        [InlineData("expired_when_on_end_has_other_case")]
        [InlineData("trial_ended_stops")]
        [InlineData("trial_without_on_end_stops")]
        public void It_stops_when_the_licence_says_stop_says_nothing_or_says_anything_but_exactly_banner(string name)
        {
            var s = Run(name);
            Assert.Equal(LicenceStatus.Expired, s.Status);
            Assert.False(s.IsUsable);
            Assert.Null(s.EndedDaysAgo);
            Assert.Null(s.Banner);
        }

        [Fact]
        public void Editing_the_licence_to_say_banner_breaks_the_signature_and_never_gives_a_banner()
        {
            Assert.Equal(LicenceStatus.Invalid, Run("tampered_on_end_to_banner").Status);
            Assert.Equal(LicenceStatus.Invalid, Run("tampered_on_end_added").Status);
            Assert.False(Run("tampered_on_end_to_banner").IsUsable);
        }

        [Theory]
        [InlineData("ended_banner_still_revoked_by_crl", LicenceStatus.Revoked)]
        [InlineData("ended_banner_copied_to_another_pc", LicenceStatus.DeviceMismatch)]
        [InlineData("ended_banner_not_activated", LicenceStatus.NotActivated)]
        [InlineData("ended_banner_module_not_licensed", LicenceStatus.ModuleNotLicensed)]
        [InlineData("ended_banner_clock_rolled_back_by_state", LicenceStatus.ClockTampered)]
        [InlineData("ended_banner_not_yet_valid", LicenceStatus.NotYetValid)]
        [InlineData("ended_banner_website_other_address", LicenceStatus.DomainMismatch)]
        [InlineData("ended_banner_after_grace_needs_check_in", LicenceStatus.NeedsCheckIn)]
        public void Every_other_check_still_stops_a_licence_that_ended(string name, LicenceStatus expected)
        {
            var s = Run(name);
            Assert.Equal(expected, s.Status);
            Assert.False(s.IsUsable);
            Assert.Null(s.Banner);
        }

        [Fact]
        public void A_missed_check_in_is_still_shown_when_the_licence_has_also_ended()
        {
            var s = Run("ended_banner_in_grace_stays_grace");
            Assert.Equal(LicenceStatus.Grace, s.Status);
            Assert.True(s.IsUsable);
            Assert.Equal(15, s.EndedDaysAgo);
            Assert.Contains("more days", s.Banner);
            Assert.Contains("ended 15 days ago", s.Banner);
        }

        [Fact]
        public void A_trial_shows_how_many_days_are_left()
        {
            var s = Run("trial_running_reports_days_left");
            Assert.Equal(LicenceStatus.Valid, s.Status);
            Assert.Equal(10, s.TrialDaysLeft);
            Assert.Equal("This is a trial. 10 days left.", s.Banner);
            Assert.Equal("This is a trial. 1 day left.", Run("trial_last_day_is_one_day_left").Banner);
            Assert.Null(Run("valid_online").Banner);
            Assert.Null(Run("valid_online").TrialDaysLeft);
        }

        [Fact]
        public void Only_the_text_banner_counts_whatever_else_the_licence_holds()
        {
            Func<string, LicenceClaims> parse = json => JObject.Parse(json).ToObject<LicenceClaims>();
            Assert.Equal("banner", parse("{\"onEnd\":\"banner\"}").OnEnd);
            foreach (var other in new[] { "{}", "{\"onEnd\":null}", "{\"onEnd\":\"stop\"}", "{\"onEnd\":\"Banner\"}", "{\"onEnd\":\" banner\"}", "{\"onEnd\":true}", "{\"onEnd\":1}", "{\"onEnd\":[\"banner\"]}", "{\"onEnd\":{\"banner\":1}}" })
            {
                Assert.Equal("stop", parse(other).OnEnd);
            }
        }

        [Fact]
        public void Every_place_that_decides_may_the_program_run_treats_Ended_as_usable_and_every_stopped_state_as_not()
        {
            var usable = new[] { LicenceStatus.Valid, LicenceStatus.Grace, LicenceStatus.Ended };
            foreach (LicenceStatus status in Enum.GetValues(typeof(LicenceStatus)))
            {
                var state = new LicenceState { Status = status };
                Assert.Equal(usable.Contains(status), state.IsUsable);
                Assert.Equal(usable.Contains(status), LegacyAdapter.From(state, DateTime.UtcNow).Allowed);
                Assert.Equal(!usable.Contains(status), LegacyAdapter.From(state, DateTime.UtcNow).ShowActivation);
            }
        }

        [Fact]
        public void The_old_programs_view_of_a_licence_that_ended_keeps_its_real_end_date()
        {
            var s = Run("ended_banner_runs");
            var view = LegacyAdapter.From(s, new DateTime(2027, 1, 15, 12, 0, 0, DateTimeKind.Utc));
            Assert.True(view.Allowed);
            Assert.False(view.ShowActivation);
            Assert.Equal(LicenceStatus.Ended, view.Status);
            Assert.True(view.Till < new DateTime(2027, 1, 15), "the title bar shows the real (past) end date, which is honest");
        }
    }
}
