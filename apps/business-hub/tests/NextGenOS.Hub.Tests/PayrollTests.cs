using NextGenOS.Hub;
using NextGenOS.Hub.Staff;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// Merge, staff part 2: employees, their days, pay in advance and the monthly pay (study 03 B3). The older program's worked examples P1 to P18 are here. The shop in these tests uses a fixed
/// 30-day month (the older program's rule) where an example needs it; one test shows the starting setting, the days of the month. Money in rupees, minor units are paise.
/// </summary>
public class PayrollTests
{
    private static HubFixture Shop(int daysBasis = 30, bool payShortTime = false) => new("IN", "retail", s => { s.PayrollDaysBasis = daysBasis; s.PayrollPayShortTime = payShortTime; });

    private static Employee Person(HubFixture f, string name = "Meera", long salaryMinor = 3_000_000, int basicMinutes = 480) =>
        f.App.Payroll.Save(new EmployeeInput { Name = name, SalaryMinor = salaryMinor, BasicMinutes = basicMinutes });

    private static DateOnly D(int month, int day) => new(2026, month, day);

    /// <summary>September 2026 days from the first to the last given, all present, with no times.</summary>
    private static void Present(HubFixture f, long employeeId, int month, int from, int to)
    {
        for (var d = from; d <= to; d++) f.App.Payroll.Mark(employeeId, D(month, d), true);
    }

    // ---- the pay: P1 to P5, P9 to P12 ---------------------------------------------------------------------------------------------------------

    [Theory]
    [InlineData(3_000_000, 30, 3_000_000)]   // P1: 30,000.00 for 30 days
    [InlineData(3_000_000, 26, 2_600_000)]   // P2: 30,000.00 x 26 / 30
    [InlineData(1_850_000, 22, 1_356_667)]   // P3: 18,500.00 x 22 / 30 = 13,566.666... -> 13,566.67
    [InlineData(1_000_000, 15, 500_000)]     // P4
    [InlineData(1_234_500, 7, 288_050)]      // P5: 86,415 / 30 = 2,880.50
    public void P1_to_P5_the_pay_is_the_monthly_pay_times_the_days_present_over_the_days_basis(long salary, int days, long expected)
    {
        using var f = Shop();
        var e = Person(f, salaryMinor: salary);
        Present(f, e.Id, 9, 1, days);

        var preview = f.App.Payroll.Preview(e.Id, D(9, 1), D(9, 30));

        Assert.Equal(days, preview.PresentDays);
        Assert.Equal(expected, preview.EarnedMinor);
        Assert.Null(preview.Problem);
    }

    [Fact]
    public void The_starting_setting_divides_by_the_days_of_the_month_so_a_full_month_is_the_monthly_pay_in_every_month()
    {
        using var f = Shop(daysBasis: 0);
        var e = Person(f, salaryMinor: 3_100_000);
        Present(f, e.Id, 8, 1, 31);   // 31 days in August: the older program paid 31/30 of the monthly pay
        Present(f, e.Id, 9, 1, 15);   // 15 of 30 in September

        Assert.Equal(3_100_000, f.App.Payroll.Preview(e.Id, D(8, 1), D(8, 31)).EarnedMinor);
        Assert.Equal(1_550_000, f.App.Payroll.Preview(e.Id, D(9, 1), D(9, 30)).EarnedMinor);
        // a range that crosses a month counts each day against its own month: 10 days of August (10/31) and 15 of September (15/30)
        var g = Person(f, "Gita", 3_100_000);
        Present(f, g.Id, 8, 22, 31);
        Present(f, g.Id, 9, 1, 15);
        Assert.Equal(1_000_000 + 1_550_000, f.App.Payroll.Preview(g.Id, D(8, 22), D(9, 15)).EarnedMinor);
    }

    [Fact]
    public void P6_and_P7_overtime_is_paid_by_the_minute_at_the_rate_for_an_hour_and_the_rate_may_have_decimals()
    {
        using var f = Shop();
        var e = Person(f, salaryMinor: 3_000_000);
        // 5:30 of overtime in one day: in 09:00, out 22:30 on an 8-hour day
        f.App.Payroll.Mark(e.Id, D(9, 1), true, new TimeOnly(9, 0), new TimeOnly(22, 30));

        var p = f.App.Payroll.Preview(e.Id, D(9, 1), D(9, 1), 10_000);   // 100.00 an hour

        Assert.Equal(330, p.OvertimeMinutes);
        Assert.Equal(55_000, p.OvertimeMinor);   // 330 x 100 / 60 = 550.00
        // P8: the older program ignored 12.5; here it is a rate like any other (330 x 12.50 / 60 = 68.75)
        Assert.Equal(6_875, f.App.Payroll.Preview(e.Id, D(9, 1), D(9, 1), 1_250).OvertimeMinor);
    }

    [Fact]
    public void P7_overtime_of_several_days_is_added_before_it_is_paid_for()
    {
        using var f = Shop(payShortTime: true);
        var e = Person(f);
        f.App.Payroll.Mark(e.Id, D(9, 1), true, new TimeOnly(9, 0), new TimeOnly(18, 15));   // 8h + 1:15
        f.App.Payroll.Mark(e.Id, D(9, 2), true, new TimeOnly(9, 0), new TimeOnly(16, 30));   // 7:30 = -0:30
        f.App.Payroll.Mark(e.Id, D(9, 3), true, new TimeOnly(9, 0), new TimeOnly(19, 0));    // +2:00

        var p = f.App.Payroll.Preview(e.Id, D(9, 1), D(9, 3), 8_000);   // 80.00 an hour

        Assert.Equal(165, p.OvertimeMinutes);   // 75 - 30 + 120 = 2:45
        Assert.Equal(22_000, p.OvertimeMinor);   // 165 x 80 / 60 = 220.00
    }

    [Fact]
    public void Short_time_is_not_taken_from_the_pay_unless_the_shop_says_so()
    {
        using var f = Shop(payShortTime: false);
        var e = Person(f);
        f.App.Payroll.Mark(e.Id, D(9, 1), true, new TimeOnly(9, 0), new TimeOnly(18, 15));   // +75
        f.App.Payroll.Mark(e.Id, D(9, 2), true, new TimeOnly(9, 0), new TimeOnly(16, 30));   // -30, counted as nothing

        var p = f.App.Payroll.Preview(e.Id, D(9, 1), D(9, 2), 6_000);

        Assert.Equal(75, p.OvertimeMinutes);
        Assert.Equal(7_500, p.OvertimeMinor);
    }

    [Fact]
    public void P13_to_P15_the_overtime_of_a_day_is_the_time_worked_less_the_usual_time_and_an_absent_day_has_none()
    {
        using var f = Shop();
        var e = Person(f);

        var more = f.App.Payroll.Mark(e.Id, D(9, 1), true, new TimeOnly(9, 0), new TimeOnly(18, 30));   // P13
        var less = f.App.Payroll.Mark(e.Id, D(9, 2), true, new TimeOnly(9, 0), new TimeOnly(16, 0));    // P14
        var away = f.App.Payroll.Mark(e.Id, D(9, 3), false);                                           // P15
        var night = f.App.Payroll.Mark(e.Id, D(9, 4), true, new TimeOnly(22, 0), new TimeOnly(7, 0));   // past midnight: 9 hours

        Assert.Equal(90, more.OvertimeMinutes);
        Assert.Equal(-60, less.OvertimeMinutes);
        Assert.Equal((false, 0, null, null), (away.Present, away.OvertimeMinutes, away.InMinute, away.OutMinute));
        Assert.Equal(60, night.OvertimeMinutes);
        Assert.Equal(0, f.App.Payroll.Preview(e.Id, D(9, 3), D(9, 3)).PresentDays);   // an absent day counts as nobody present
    }

    [Fact]
    public void P16_a_day_is_written_down_once_and_corrected_with_a_change()
    {
        using var f = Shop();
        var e = Person(f);
        f.App.Payroll.Mark(e.Id, D(9, 1), true);

        var ex = Assert.Throws<HubException>(() => f.App.Payroll.Mark(e.Id, D(9, 1), true));
        Assert.Equal("day-saved", ex.Code);
        Assert.Contains("already written down", ex.Message);

        var changed = f.App.Payroll.Change(e.Id, D(9, 1), false);
        Assert.False(changed.Present);
        Assert.Throws<HubException>(() => f.App.Payroll.Change(e.Id, D(9, 2), true));   // nothing to correct
        f.App.Payroll.Remove(e.Id, D(9, 1));
        Assert.Empty(f.App.Payroll.Days(e.Id, D(9, 1), D(9, 30)));
    }

    [Fact]
    public void Times_come_in_pairs_and_a_day_that_has_not_come_cannot_be_written_down()
    {
        using var f = Shop();
        var e = Person(f);

        Assert.Equal("times", Assert.Throws<HubException>(() => f.App.Payroll.Mark(e.Id, D(9, 1), true, new TimeOnly(9, 0), null)).Code);
        Assert.Equal("times", Assert.Throws<HubException>(() => f.App.Payroll.Mark(e.Id, D(9, 1), true, new TimeOnly(9, 0), new TimeOnly(9, 0))).Code);
        Assert.Equal("day-ahead", Assert.Throws<HubException>(() => f.App.Payroll.Mark(e.Id, D(10, 6), true)).Code);   // the shop's clock says 5 October
    }

    // ---- advances and paying: P9 to P12, P17, P18 ----------------------------------------------------------------------------------------------

    [Fact]
    public void P17_an_advance_is_owed_back_and_is_in_the_books()
    {
        using var f = Shop();
        var e = Person(f);

        f.App.Payroll.GiveAdvance(e.Id, 500_000, "cash", note: "festival");

        Assert.Equal(500_000, f.App.Payroll.Outstanding(e.Id));
        var line = Assert.Single(f.App.Payroll.Advances(e.Id));
        Assert.Equal(("given", 500_000L, 500_000L), (line.Kind, line.AmountMinor, line.BalanceMinor));
        Assert.Contains("festival", line.Memo);
        var trial = f.App.Books.TrialBalance();
        Assert.Equal(500_000, trial.Single(x => x.Name == "Paid to staff in advance").DebitMinor);
        Assert.Equal(trial.Sum(x => x.DebitMinor), trial.Sum(x => x.CreditMinor));
    }

    [Fact]
    public void P9_and_P18_the_pay_is_the_earned_pay_and_the_overtime_less_the_advance_paid_back_and_the_books_follow()
    {
        using var f = Shop();
        var e = Person(f, salaryMinor: 3_000_000);
        Present(f, e.Id, 9, 1, 26);   // 26 of 30: 26,000.00
        f.App.Payroll.Mark(e.Id, D(9, 27), true, new TimeOnly(9, 0), new TimeOnly(22, 30));   // 5:30 overtime, paid at 100.00 an hour: 550.00 (and a 27th day: 27,000.00)
        f.App.Payroll.GiveAdvance(e.Id, 500_000, "cash");

        var slip = f.App.Payroll.Pay(e.Id, D(9, 1), D(9, 30), 10_000, repaidMinor: 200_000, "cash");

        Assert.Equal(27, slip.PresentDays);
        Assert.Equal(2_700_000, slip.SalaryMinor);
        Assert.Equal(55_000, slip.OvertimeMinor);
        Assert.Equal(2_700_000 + 55_000 - 200_000, slip.NetMinor);   // 25,550.00 paid out
        Assert.Equal("PAY-1", slip.Number);
        Assert.Equal(300_000, f.App.Payroll.Outstanding(e.Id));   // P9: 5,000.00 less 2,000.00
        var trial = f.App.Books.TrialBalance();
        Assert.Equal(2_755_000, trial.Single(x => x.Name == "Staff pay").DebitMinor);
        Assert.Equal(300_000, trial.Single(x => x.Name == "Paid to staff in advance").BalanceMinor);
        Assert.Equal(trial.Sum(x => x.DebitMinor), trial.Sum(x => x.CreditMinor));
        Assert.Contains(f.App.Books.DayBook(f.Clock.UtcNow.AddDays(-1), f.Clock.UtcNow.AddDays(1)), x => x.Kind == "Staff pay");
    }

    [Fact]
    public void P10_an_advance_cannot_be_paid_back_by_more_than_is_outstanding()
    {
        using var f = Shop();
        var e = Person(f);
        Present(f, e.Id, 9, 1, 30);
        f.App.Payroll.GiveAdvance(e.Id, 500_000, "cash");

        var ex = Assert.Throws<HubException>(() => f.App.Payroll.Pay(e.Id, D(9, 1), D(9, 30), 0, repaidMinor: 600_000, "cash"));

        Assert.Equal("pay-repay", ex.Code);
        Assert.Contains("still to pay back", ex.Message);
        Assert.Empty(f.App.Payroll.Slips());
    }

    [Fact]
    public void P11_what_is_paid_out_must_be_more_than_nothing()
    {
        using var f = Shop();
        var e = Person(f, salaryMinor: 10_000);   // 100.00 a month
        Present(f, e.Id, 9, 1, 30);
        f.App.Payroll.GiveAdvance(e.Id, 10_000, "cash");

        var ex = Assert.Throws<HubException>(() => f.App.Payroll.Pay(e.Id, D(9, 1), D(9, 30), 0, repaidMinor: 10_000, "cash"));

        Assert.Equal("pay-net", ex.Code);
    }

    [Fact]
    public void P12_two_slips_for_one_person_may_not_overlap_but_a_single_day_may_be_paid()
    {
        using var f = Shop();
        var e = Person(f);
        Present(f, e.Id, 9, 1, 20);
        f.App.Payroll.Pay(e.Id, D(9, 10), D(9, 20), 0, 0, "cash");

        var preview = f.App.Payroll.Preview(e.Id, D(9, 1), D(9, 15));
        Assert.Contains("already paid", preview.Problem);
        var ex = Assert.Throws<HubException>(() => f.App.Payroll.Pay(e.Id, D(9, 1), D(9, 15), 0, 0, "cash"));
        Assert.Equal("pay-days", ex.Code);
        Assert.Contains("PAY-1", ex.Message);

        // the older program refused from = to; one day can be paid
        var one = f.App.Payroll.Pay(e.Id, D(9, 9), D(9, 9), 0, 0, "cash");
        Assert.Equal(1, one.PresentDays);
        Assert.Equal(100_000, one.SalaryMinor);   // 30,000.00 / 30
        // the last day cannot be before the first
        Assert.Contains("before", f.App.Payroll.Preview(e.Id, D(9, 5), D(9, 4)).Problem);
    }

    [Fact]
    public void A_day_on_a_slip_cannot_be_changed_until_the_slip_is_cancelled_and_cancelling_gives_the_advance_back()
    {
        using var f = Shop();
        var e = Person(f);
        Present(f, e.Id, 9, 1, 30);
        f.App.Payroll.GiveAdvance(e.Id, 500_000, "cash");
        var slip = f.App.Payroll.Pay(e.Id, D(9, 1), D(9, 30), 0, 200_000, "cash");

        var locked = Assert.Throws<HubException>(() => f.App.Payroll.Change(e.Id, D(9, 5), false));
        Assert.Equal("day-paid", locked.Code);
        Assert.Contains(slip.Number, locked.Message);
        Assert.Equal("day-paid", Assert.Throws<HubException>(() => f.App.Payroll.Remove(e.Id, D(9, 5))).Code);

        Assert.Equal("cancel-reason", Assert.Throws<HubException>(() => f.App.Payroll.CancelSlip(slip.Id, " ")).Code);
        f.App.Payroll.CancelSlip(slip.Id, "wrong month");

        Assert.True(f.App.Payroll.Slip(slip.Id)!.Cancelled);
        Assert.Equal(500_000, f.App.Payroll.Outstanding(e.Id));   // the 2,000.00 paid back is owed again
        Assert.Equal("already-cancelled", Assert.Throws<HubException>(() => f.App.Payroll.CancelSlip(slip.Id, "again")).Code);
        var trial = f.App.Books.TrialBalance();
        Assert.Equal(0, trial.Single(x => x.Name == "Staff pay").BalanceMinor);
        Assert.Equal(500_000, trial.Single(x => x.Name == "Paid to staff in advance").BalanceMinor);
        Assert.Equal(trial.Sum(x => x.DebitMinor), trial.Sum(x => x.CreditMinor));
        // the day can be changed now, and the person paid again
        f.App.Payroll.Change(e.Id, D(9, 5), false);
        Assert.Equal(29, f.App.Payroll.Pay(e.Id, D(9, 1), D(9, 30), 0, 0, "cash").PresentDays);
        Assert.Equal(2, f.App.Payroll.Slips(e.Id).Count);
    }

    [Fact]
    public void Paying_by_a_way_other_than_cash_takes_it_from_that_way_in_the_books()
    {
        using var f = Shop();
        var e = Person(f);
        Present(f, e.Id, 9, 1, 30);

        f.App.Payroll.Pay(e.Id, D(9, 1), D(9, 30), 0, 0, "upi");

        var trial = f.App.Books.TrialBalance();
        Assert.Equal(3_000_000, trial.Single(x => x.Name == "Staff pay").DebitMinor);
        Assert.Equal(trial.Sum(x => x.DebitMinor), trial.Sum(x => x.CreditMinor));
        Assert.DoesNotContain(trial, x => x.Name == "Cash" && x.CreditMinor > 0);
    }

    // ---- the people ----------------------------------------------------------------------------------------------------------------------------

    [Fact]
    public void A_name_and_a_monthly_pay_are_needed_and_each_person_gets_the_next_number()
    {
        using var f = Shop();

        Assert.Equal("employee-name", Assert.Throws<HubException>(() => f.App.Payroll.Save(new EmployeeInput { Name = " ", SalaryMinor = 100 })).Code);
        Assert.Equal("employee-pay", Assert.Throws<HubException>(() => f.App.Payroll.Save(new EmployeeInput { Name = "A", SalaryMinor = 0 })).Code);
        Assert.Equal("employee-hours", Assert.Throws<HubException>(() => f.App.Payroll.Save(new EmployeeInput { Name = "A", SalaryMinor = 100, BasicMinutes = 0 })).Code);
        var first = f.App.Payroll.Save(new EmployeeInput { Name = "Meera", SalaryMinor = 2_000_000, Department = "Counter", JoinedOn = new DateOnly(2026, 4, 1) });
        var second = f.App.Payroll.Save(new EmployeeInput { Name = "Ravi", SalaryMinor = 2_500_000 });

        Assert.Equal(("EMP-1", "EMP-2"), (first.Code, second.Code));
        Assert.Equal(new DateOnly(2026, 4, 1), first.JoinedOn);
        var changed = f.App.Payroll.Save(new EmployeeInput { Id = first.Id, Name = "Meera K", SalaryMinor = 2_200_000, Department = "Counter" });
        Assert.Equal(("Meera K", 2_200_000L, "EMP-1"), (changed.Name, changed.SalaryMinor, changed.Code));
    }

    [Fact]
    public void A_person_who_left_is_switched_off_and_keeps_their_records()
    {
        using var f = Shop();
        var e = Person(f);
        Present(f, e.Id, 9, 1, 3);

        f.App.Payroll.SetActive(e.Id, false);

        Assert.Empty(f.App.Payroll.List());
        Assert.Single(f.App.Payroll.List(includeInactive: true));
        Assert.Equal("employee-off", Assert.Throws<HubException>(() => f.App.Payroll.Mark(e.Id, D(9, 4), true)).Code);
        Assert.Equal(3, f.App.Payroll.Days(e.Id, D(9, 1), D(9, 30)).Count);
    }

    [Fact]
    public void The_pay_of_a_range_with_nobody_present_is_refused_in_plain_words()
    {
        using var f = Shop();
        var e = Person(f);
        f.App.Payroll.Mark(e.Id, D(9, 1), false);

        var ex = Assert.Throws<HubException>(() => f.App.Payroll.Pay(e.Id, D(9, 1), D(9, 30), 0, 0, "cash"));

        Assert.Contains("No day is written down as present", ex.Message);
    }

    [Fact]
    public void Slips_can_be_listed_for_a_person_and_a_range()
    {
        using var f = Shop();
        var a = Person(f, "Meera");
        var b = Person(f, "Ravi");
        Present(f, a.Id, 9, 1, 5);
        Present(f, b.Id, 9, 1, 5);
        f.App.Payroll.Pay(a.Id, D(9, 1), D(9, 5), 0, 0, "cash");
        f.App.Payroll.Pay(b.Id, D(9, 1), D(9, 5), 0, 0, "cash");

        Assert.Equal(2, f.App.Payroll.Slips().Count);
        Assert.Equal("Meera", Assert.Single(f.App.Payroll.Slips(a.Id)).EmployeeName);
        Assert.Empty(f.App.Payroll.Slips(a.Id, D(9, 20), D(9, 30)));
    }
}
