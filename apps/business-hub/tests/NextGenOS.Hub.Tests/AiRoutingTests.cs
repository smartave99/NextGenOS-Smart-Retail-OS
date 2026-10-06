using NextGenOS.Hub.Ai;

namespace NextGenOS.Hub.Tests;

/// <summary>The privacy rules: which AI service may receive which kind of data. They are a pure function, so every rule is tried here.</summary>
public class AiRoutingTests
{
    private static ProviderFacts Service(string id, string location, bool enabled = true, string endpoint = "", string[]? tasks = null, IEnumerable<ConsentFact>? consents = null) =>
        new(id, id, location, enabled, (tasks ?? new[] { AiTask.Generate }).ToHashSet(),
            endpoint.Length > 0 ? endpoint : location is ProviderLocation.Local or ProviderLocation.LocalOptimized ? EndpointClassifier.Loopback : location == ProviderLocation.Lan ? EndpointClassifier.PrivateNetwork : EndpointClassifier.Internet,
            (consents ?? Array.Empty<ConsentFact>()).ToList());

    private static RouteQuestion Ask(string dataClass, string feature = "assistant", bool remote = true, string task = AiTask.Generate, string? preferred = null) => new(task, dataClass, feature, remote, preferred);

    private static ConsentFact Allow(string dataClass, string features = "*") => new(dataClass, features);

    [Theory]
    [InlineData(DataClass.PaymentSensitive)]
    [InlineData(DataClass.Biometric)]
    public void Card_details_and_biometric_data_never_leave_the_computer_whatever_the_owner_allowed(string dataClass)
    {
        var everythingAllowed = DataClass.All.Select(c => Allow(c)).ToArray();
        var providers = new[]
        {
            Service("here", ProviderLocation.Local),
            Service("shop", ProviderLocation.Lan, consents: everythingAllowed),
            Service("online", ProviderLocation.Api, consents: everythingAllowed),
            Service("tool", ProviderLocation.Cli, consents: everythingAllowed),
        };

        var decision = Routing.Decide(Ask(dataClass), providers);

        Assert.Equal(new[] { "here" }, decision.Order);
        foreach (var outside in new[] { "shop", "online", "tool" })
            Assert.Contains("never leave this computer", decision.Trace.Single(s => s.ProviderId == outside).Reason);

        var withoutLocal = Routing.Decide(Ask(dataClass), providers.Skip(1));
        Assert.False(withoutLocal.Allowed);
        Assert.Contains("never leave this computer", withoutLocal.Refusal);
    }

    [Fact]
    public void A_service_on_this_computer_may_receive_every_other_kind_of_data_without_being_asked()
    {
        foreach (var dataClass in DataClass.All)
        {
            var decision = Routing.Decide(Ask(dataClass, remote: false), new[] { Service("here", ProviderLocation.Local) });
            Assert.Equal(new[] { "here" }, decision.Order);
        }
    }

    [Fact]
    public void A_service_in_the_shop_network_takes_public_and_internal_data_but_needs_permission_for_the_rest()
    {
        var shop = Service("shop", ProviderLocation.Lan);
        Assert.True(Routing.Decide(Ask(DataClass.Public, remote: false), new[] { shop }).Allowed);
        Assert.True(Routing.Decide(Ask(DataClass.Internal, remote: false), new[] { shop }).Allowed);
        foreach (var dataClass in new[] { DataClass.Confidential, DataClass.Personal, DataClass.Financial, DataClass.Video, DataClass.Audio })
        {
            Assert.False(Routing.Decide(Ask(dataClass), new[] { shop }).Allowed, dataClass);
            Assert.True(Routing.Decide(Ask(dataClass), new[] { Service("shop", ProviderLocation.Lan, consents: new[] { Allow(dataClass) }) }).Allowed, dataClass);
        }
    }

    [Fact]
    public void An_online_service_needs_the_online_switch_and_for_anything_but_public_data_the_owners_permission()
    {
        var consented = Service("online", ProviderLocation.Api, consents: new[] { Allow(DataClass.Financial, "reports,assistant") });

        // The switch "Use online AI services" is off: nothing goes, whatever was allowed.
        var off = Routing.Decide(Ask(DataClass.Financial, remote: false), new[] { consented });
        Assert.False(off.Allowed);
        Assert.Contains("switched off", off.Refusal);

        Assert.True(Routing.Decide(Ask(DataClass.Financial, "reports"), new[] { consented }).Allowed);
        // Allowed for two features only: a third feature is not covered.
        var otherFeature = Routing.Decide(Ask(DataClass.Financial, "forecast"), new[] { consented });
        Assert.False(otherFeature.Allowed);
        Assert.Contains("not allowed it to receive", otherFeature.Refusal);
        // Another kind of data was not allowed.
        Assert.False(Routing.Decide(Ask(DataClass.Personal, "reports"), new[] { consented }).Allowed);
        // Public data needs no permission, only the switch.
        Assert.True(Routing.Decide(Ask(DataClass.Public), new[] { Service("online", ProviderLocation.Api) }).Allowed);
        Assert.False(Routing.Decide(Ask(DataClass.Public, remote: false), new[] { Service("online", ProviderLocation.Api) }).Allowed);
        // Internal figures to an online service do need permission.
        Assert.False(Routing.Decide(Ask(DataClass.Internal), new[] { Service("online", ProviderLocation.Api) }).Allowed);
    }

    [Fact]
    public void A_tool_the_owner_signed_in_to_counts_as_online()
    {
        var tool = Service("tool", ProviderLocation.Cli, consents: new[] { Allow(DataClass.Internal) });
        Assert.False(Routing.Decide(Ask(DataClass.Internal, remote: false), new[] { tool }).Allowed);
        Assert.True(Routing.Decide(Ask(DataClass.Internal), new[] { tool }).Allowed);
    }

    [Theory]
    [InlineData(ProviderLocation.Local, EndpointClassifier.Internet)]
    [InlineData(ProviderLocation.Local, EndpointClassifier.PrivateNetwork)]
    [InlineData(ProviderLocation.LocalOptimized, EndpointClassifier.Internet)]
    [InlineData(ProviderLocation.Lan, EndpointClassifier.Internet)]
    public void A_service_said_to_be_here_or_in_the_shop_but_with_an_address_elsewhere_is_not_used(string location, string endpoint)
    {
        var decision = Routing.Decide(Ask(DataClass.Public, remote: true), new[] { Service("liar", location, endpoint: endpoint) });
        Assert.False(decision.Allowed);
        Assert.Contains("address", decision.Trace.Single().Reason);
    }

    [Fact]
    public void Services_are_tried_here_first_then_in_the_shop_then_online_and_a_preferred_one_goes_first_when_allowed()
    {
        var providers = new[]
        {
            Service("online", ProviderLocation.Api), Service("shop", ProviderLocation.Lan), Service("here", ProviderLocation.Local),
            Service("fast-here", ProviderLocation.LocalOptimized), Service("tool", ProviderLocation.Cli),
        };
        Assert.Equal(new[] { "here", "fast-here", "shop", "tool", "online" }, Routing.Decide(Ask(DataClass.Public), providers).Order);
        Assert.Equal(new[] { "shop", "here", "fast-here", "tool", "online" }, Routing.Decide(Ask(DataClass.Public, preferred: "shop"), providers).Order);
        // A preferred service that is not allowed is not used just because it was asked for.
        Assert.DoesNotContain("online", Routing.Decide(Ask(DataClass.Personal, preferred: "online"), providers).Order);
    }

    [Fact]
    public void A_service_that_is_off_or_does_not_do_the_work_is_left_out_and_the_reason_is_kept()
    {
        var providers = new[]
        {
            Service("off", ProviderLocation.Local, enabled: false),
            Service("writes", ProviderLocation.Local, tasks: new[] { AiTask.Generate }),
            Service("finds", ProviderLocation.Local, tasks: new[] { AiTask.Embed }),
        };
        var decision = Routing.Decide(Ask(DataClass.Public, task: AiTask.Embed), providers);
        Assert.Equal(new[] { "finds" }, decision.Order);
        Assert.Equal("It is switched off.", decision.Trace.Single(s => s.ProviderId == "off").Reason);
        Assert.Contains("does not do", decision.Trace.Single(s => s.ProviderId == "writes").Reason);

        var none = Routing.Decide(Ask(DataClass.Public, task: AiTask.Vision), providers);
        Assert.False(none.Allowed);
        Assert.NotNull(none.Refusal);
    }

    [Fact]
    public void An_unknown_kind_of_data_or_work_is_refused_and_nothing_is_chosen()
    {
        var here = new[] { Service("here", ProviderLocation.Local) };
        Assert.False(Routing.Decide(Ask("SECRET_SAUCE"), here).Allowed);
        Assert.False(Routing.Decide(Ask(DataClass.Public, task: "mind-reading"), here).Allowed);
        Assert.False(Routing.Decide(Ask(""), here).Allowed);
        Assert.False(Routing.Decide(Ask(DataClass.Public), Array.Empty<ProviderFacts>()).Allowed);
        Assert.Equal("No AI service is set up.", Routing.Decide(Ask(DataClass.Public), Array.Empty<ProviderFacts>()).Refusal);
    }

    [Fact]
    public void Every_kind_of_data_has_words_for_the_owner_and_the_two_that_never_leave_are_named()
    {
        Assert.Equal(9, DataClass.All.Count);
        foreach (var c in DataClass.All) Assert.NotEqual(c, DataClass.Label(c));
        Assert.Equal(new[] { DataClass.Biometric, DataClass.PaymentSensitive }.OrderBy(x => x), DataClass.All.Where(Routing.NeverLeavesTheComputer).OrderBy(x => x));
    }
}

public class EndpointAndTextGuardTests
{
    [Theory]
    [InlineData("http://localhost:11434", EndpointClassifier.Loopback)]
    [InlineData("http://127.0.0.1:8080/v1", EndpointClassifier.Loopback)]
    [InlineData("http://[::1]:8080", EndpointClassifier.Loopback)]
    [InlineData("http://ai.localhost", EndpointClassifier.Loopback)]
    [InlineData("http://192.168.1.20:11434", EndpointClassifier.PrivateNetwork)]
    [InlineData("http://10.0.0.7", EndpointClassifier.PrivateNetwork)]
    [InlineData("http://172.20.1.1", EndpointClassifier.PrivateNetwork)]
    [InlineData("http://backoffice", EndpointClassifier.PrivateNetwork)]
    [InlineData("http://ollama.local:11434", EndpointClassifier.PrivateNetwork)]
    [InlineData("http://172.32.0.1", EndpointClassifier.Internet)]
    [InlineData("http://8.8.8.8", EndpointClassifier.Internet)]
    [InlineData("https://api.example.com/v1", EndpointClassifier.Internet)]
    [InlineData("http://localhost.evil.example", EndpointClassifier.Internet)]
    [InlineData("ftp://192.168.1.1", EndpointClassifier.Invalid)]
    [InlineData("not a web address", EndpointClassifier.Invalid)]
    [InlineData("", EndpointClassifier.Invalid)]
    public void An_address_is_this_computer_the_shop_network_or_the_internet(string url, string expected) => Assert.Equal(expected, EndpointClassifier.Classify(url));

    [Fact]
    public void The_place_a_service_is_said_to_be_must_match_its_address()
    {
        Assert.Null(EndpointClassifier.Mismatch(ProviderLocation.Local, "http://127.0.0.1:11434"));
        Assert.NotNull(EndpointClassifier.Mismatch(ProviderLocation.Local, "http://192.168.1.5:11434"));
        Assert.NotNull(EndpointClassifier.Mismatch(ProviderLocation.LocalOptimized, "https://api.example.com"));
        Assert.Null(EndpointClassifier.Mismatch(ProviderLocation.Lan, "http://192.168.1.5:11434"));
        Assert.NotNull(EndpointClassifier.Mismatch(ProviderLocation.Lan, "https://api.example.com"));
        Assert.Null(EndpointClassifier.Mismatch(ProviderLocation.Api, "https://api.example.com/v1"));
        Assert.Contains("https://", EndpointClassifier.Mismatch(ProviderLocation.Api, "http://api.example.com/v1"));
        Assert.Null(EndpointClassifier.Mismatch(ProviderLocation.Cli, ""));
        Assert.NotNull(EndpointClassifier.Mismatch("somewhere", "http://localhost"));
        Assert.NotNull(EndpointClassifier.Mismatch(ProviderLocation.Local, "nonsense"));
    }

    [Theory]
    [InlineData("http://user:secret@127.0.0.1:11434")]
    [InlineData("https://sk-live-abc123@api.example.com/v1")]
    [InlineData("https://api.example.com/v1?api_key=abc123")]
    [InlineData("https://api.example.com/v1#token")]
    [InlineData("http://192.168.1.5:11434/v1?key=1")]
    public void A_key_cannot_be_written_into_an_address_where_it_would_be_kept_in_the_open(string url)
    {
        foreach (var place in new[] { ProviderLocation.Local, ProviderLocation.Lan, ProviderLocation.Api })
        {
            var problem = EndpointClassifier.Mismatch(place, url);
            Assert.NotNull(problem);
            Assert.Contains("key", problem);
        }
    }

    [Theory]
    [InlineData("Pay with 4111 1111 1111 1111 please", true)]
    [InlineData("card 4111-1111-1111-1111", true)]
    [InlineData("5500005555555559", true)]
    [InlineData("340000000000009", true)]
    [InlineData("4111 1111 1111 1112", false)]
    [InlineData("Order 1234567890123456 shipped", false)]
    [InlineData("Call +91 98765 43210 today", false)]
    [InlineData("The total is 1,250.00 for 3 items", false)]
    [InlineData("", false)]
    public void A_payment_card_number_in_a_text_is_found_and_ordinary_numbers_are_not(string text, bool found) => Assert.Equal(found, TextGuard.ContainsCardNumber(text));
}

public class ContactDetailsTests
{
    [Theory]
    [InlineData("Write to maria.santos@example.com about the order", true)]
    [InlineData("a@b.co", true)]
    [InlineData("Call +91 98765 43210 today", true)]
    [InlineData("Call +63 917 123 4567", true)]
    [InlineData("Call (555) 123-4567 now", true)]
    [InlineData("555-123-4567", true)]
    [InlineData("555.123.4567", true)]
    [InlineData("Barcode 8901000000019 is on the shelf", false)]
    [InlineData("Invoice INV-2026-000012 for 1,250.00", false)]
    [InlineData("Sold 12 units between 10:30 and 11:45", false)]
    [InlineData("Version 2.10.3 shipped", false)]
    [InlineData("the price is 25 @ 3 for 2", false)]
    [InlineData("", false)]
    [InlineData(null, false)]
    public void An_email_address_or_a_phone_number_is_found_and_a_barcode_or_an_invoice_number_is_not(string? text, bool found) => Assert.Equal(found, TextGuard.ContainsContactDetails(text));
}

public class BudgetTests
{
    [Fact]
    public void A_cost_is_worked_out_from_the_prices_of_a_thousand_tokens_and_rounded_up()
    {
        // 2,000 millionths for 1,000 tokens sent, 6,000 for 1,000 received.
        Assert.Equal(2_000 + 3_000, Budget.Cost(1_000, 500, 2_000, 6_000));
        Assert.Equal(1, Budget.Cost(1, 0, 1, null));   // a fraction of a millionth is never shown as free
        Assert.Equal(0, Budget.Cost(5_000, 5_000, null, null));   // a service with no price costs nothing
        Assert.Equal(0, Budget.Cost(0, 0, 100, 100));
    }

    [Fact]
    public void Every_limit_stops_a_call_and_says_which()
    {
        var limits = new ProviderLimits(RequestsPerDay: 10, TokensPerDay: 1_000, TokensPerMonth: 5_000, CostMicrosPerMonth: 9_000);
        var quiet = new UsageTotals(0, 0, 0, 0);
        Assert.Null(Budget.Check("Svc", limits, quiet, quiet, 100));
        Assert.Contains("10 requests", Budget.Check("Svc", limits, new UsageTotals(10, 0, 0, 0), quiet, 1));
        Assert.Contains("for today", Budget.Check("Svc", limits, new UsageTotals(1, 900, 0, 0), quiet, 200));
        Assert.Contains("this month", Budget.Check("Svc", limits, quiet, new UsageTotals(1, 4_900, 0, 0), 200));
        Assert.Contains("spending limit", Budget.Check("Svc", limits, quiet, new UsageTotals(1, 0, 0, 9_000), 1));
        Assert.Null(Budget.Check("Svc", new ProviderLimits(), new UsageTotals(1_000_000, 1, 1, 1), new UsageTotals(1_000_000, 1, 1, 1), 1_000_000));
    }
}

public class HardwareProfileTests
{
    private static RawHardware Machine(double ram = 16, int cores = 8, double? vram = null, bool integrated = false, bool edge = false, string arch = "x64", string metal = Support.Unknown, double? disk = 200) =>
        new(arch, cores / 2, cores, ram, ram / 2, vram is null ? Array.Empty<GpuInfo>() : new[] { new GpuInfo("Test", "Test card", vram, integrated) }, null,
            new Accelerators(Support.Unknown, Support.Unknown, Support.Unknown, metal, Support.Unknown, Support.Unknown, Support.Unknown), disk, "test", true, edge, Array.Empty<string>());

    [Theory]
    [InlineData(4, 2, null, HardwareProfile.Light)]
    [InlineData(8, 8, null, HardwareProfile.Light)]
    [InlineData(16, 2, null, HardwareProfile.Light)]
    [InlineData(16, 4, null, HardwareProfile.Standard)]
    [InlineData(32, 16, null, HardwareProfile.Standard)]
    [InlineData(16, 8, 8.0, HardwareProfile.GpuLocal)]
    [InlineData(32, 8, 12.0, HardwareProfile.GpuLocal)]
    [InlineData(8, 8, 12.0, HardwareProfile.Light)]
    [InlineData(32, 16, 24.0, HardwareProfile.HeavyGpu)]
    [InlineData(16, 16, 24.0, HardwareProfile.GpuLocal)]
    [InlineData(64, 16, 80.0, HardwareProfile.Enterprise)]
    [InlineData(128, 32, null, HardwareProfile.Enterprise)]
    public void A_computer_is_put_in_the_profile_its_memory_processor_and_graphics_card_allow(double ram, int cores, double? vram, string expected) =>
        Assert.Equal(expected, ProfileClassifier.Classify(Machine(ram, cores, vram)).Profile);

    [Fact]
    public void A_small_board_next_to_the_cameras_is_an_edge_server_and_an_integrated_graphics_chip_is_not_a_graphics_card()
    {
        Assert.Equal(HardwareProfile.EdgeServer, ProfileClassifier.Classify(Machine(8, 6, edge: true, arch: "arm64")).Profile);
        Assert.Equal(HardwareProfile.Light, ProfileClassifier.Classify(Machine(8, 6, edge: false)).Profile);
        Assert.Equal(HardwareProfile.Standard, ProfileClassifier.Classify(Machine(16, 8, vram: 8, integrated: true)).Profile);
    }

    [Fact]
    public void An_apple_chip_shares_one_memory_so_it_counts_as_having_a_graphics_card()
    {
        Assert.Equal(HardwareProfile.GpuLocal, ProfileClassifier.Classify(Machine(16, 8, arch: "arm64", metal: Support.Yes)).Profile);
        Assert.Equal(HardwareProfile.Standard, ProfileClassifier.Classify(Machine(16, 8, arch: "arm64", metal: Support.No)).Profile);
    }

    [Fact]
    public void A_computer_with_little_memory_or_disk_gets_a_warning_in_plain_words_and_the_shop_program_is_not_blocked()
    {
        var small = ProfileClassifier.Classify(Machine(4, 2, disk: 5));
        Assert.Equal(HardwareProfile.Light, small.Profile);
        Assert.Equal(2, small.Warnings.Count);
        Assert.Contains("shop program is not affected", small.Warnings[0]);
        Assert.Empty(ProfileClassifier.Classify(Machine(16, 8, disk: 100)).Warnings);
        // Free disk space that could not be read is not reported as "no space".
        Assert.Empty(ProfileClassifier.Classify(Machine(16, 8, disk: null)).Warnings);
    }

    [Fact]
    public void The_sizes_that_separate_the_profiles_can_be_given_from_outside()
    {
        var strict = new ProfileThresholds(StandardRamGb: 64);
        Assert.Equal(HardwareProfile.Light, ProfileClassifier.Classify(Machine(16, 8), strict).Profile);
        Assert.Equal(HardwareProfile.Standard, ProfileClassifier.Classify(Machine(16, 8)).Profile);
    }

    [Fact]
    public void Every_profile_has_a_label_and_a_plain_description()
    {
        foreach (var profile in HardwareProfile.All)
        {
            Assert.NotEqual(profile, HardwareProfile.Label(profile));
            Assert.False(string.IsNullOrWhiteSpace(HardwareProfile.WhatItCanDo(profile)));
        }
    }

    [Fact]
    public void The_computer_is_looked_at_once_in_a_while_not_on_every_screen()
    {
        var clock = new FixedClock(new DateTimeOffset(2026, 10, 5, 6, 30, 0, TimeSpan.Zero));
        var probe = new CountingProbe(Machine());
        var service = new HardwareService(probe, Path.GetTempPath(), clock);
        service.Capabilities();
        service.Capabilities();
        Assert.Equal(1, probe.Looks);
        clock.Advance(TimeSpan.FromMinutes(6));
        service.Capabilities();
        Assert.Equal(2, probe.Looks);
        service.Refresh();
        Assert.Equal(3, probe.Looks);
    }

    [Fact]
    public void The_real_probe_never_throws_and_reports_what_it_could_not_see_as_unknown_rather_than_guessing()
    {
        var found = new SystemHardwareProbe().Probe(Path.GetTempPath());
        Assert.True(found.LogicalCores >= 1);
        Assert.True(found.RamTotalGb > 0);
        Assert.False(string.IsNullOrWhiteSpace(found.CpuArch));
        foreach (var flag in new[] { found.Accelerators.Cuda, found.Accelerators.Rocm, found.Accelerators.DirectMl, found.Accelerators.Metal, found.Accelerators.OpenVino, found.Accelerators.TensorRt, found.Accelerators.OnnxRuntime })
            Assert.Contains(flag, new[] { Support.Yes, Support.No, Support.Unknown });
    }

    private sealed class CountingProbe(RawHardware hardware) : IHardwareProbe
    {
        public int Looks { get; private set; }

        public RawHardware Probe(string dataFolder) { Looks++; return hardware; }
    }
}
