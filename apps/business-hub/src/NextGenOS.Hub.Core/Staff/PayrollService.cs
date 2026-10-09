using System.Numerics;
using Microsoft.Data.Sqlite;
using NextGenOS.Hub.Books;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Security;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Staff;

/// <summary>A person who works for the shop. <see cref="SalaryMinor"/> is the pay for a month; <see cref="BasicMinutes"/> is the usual working time of a day.</summary>
public sealed record Employee(long Id, string Code, string Name, string? Phone, string? Email, string? Address, string? City, string? Department, string? Designation, DateOnly? JoinedOn, long SalaryMinor, int BasicMinutes, bool Active, string? Notes);

public sealed class EmployeeInput
{
    public long? Id { get; set; }
    public string Name { get; set; } = "";
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Department { get; set; }
    public string? Designation { get; set; }
    public DateOnly? JoinedOn { get; set; }
    public long SalaryMinor { get; set; }
    public int BasicMinutes { get; set; } = 480;
    public string? Notes { get; set; }
}

/// <summary>One person's day: present ("P") or absent ("A"), when they came and left (minutes since midnight, if written down), and the overtime of the day in minutes (below nothing when they left early).</summary>
public sealed record AttendanceDay(long Id, long EmployeeId, DateOnly Day, string Status, int? InMinute, int? OutMinute, int OvertimeMinutes)
{
    public bool Present => Status == "P";
}

/// <summary>One line of the money given to a person in advance: given (+), paid back out of their pay (-), or given back when a pay slip was cancelled (+).</summary>
public sealed record AdvanceLine(long Id, DateOnly Day, string Kind, string Memo, long AmountMinor, long BalanceMinor);

/// <summary>What a pay slip would be, worked out and not saved. <see cref="Problem"/> says in plain words why it could not be paid (null when it can).</summary>
public sealed record PayPreview(long EmployeeId, string Name, DateOnly From, DateOnly To, int PresentDays, long EarnedMinor, int OvertimeMinutes, long OvertimeRateMinor, long OvertimeMinor, long OutstandingMinor, int DaysBasis, string? Problem)
{
    public long GrossMinor => EarnedMinor + OvertimeMinor;
    public long NetFor(long repaidMinor) => GrossMinor - repaidMinor;
}

public sealed record PaySlip(long Id, string Number, long EmployeeId, string EmployeeName, DateOnly From, DateOnly To, int PresentDays, long SalaryMinor, int OvertimeMinutes, long OvertimeRateMinor, long OvertimeMinor,
    long RepaidMinor, long NetMinor, string Method, string? Note, DateTimeOffset PaidAt, bool Cancelled, string? CancelReason)
{
    public long GrossMinor => SalaryMinor + OvertimeMinor;
}

/// <summary>
/// The people who work for the shop, their days, the pay in advance and the monthly pay (the older POS, study 03 B3). The older program was a small monthly payroll with no statutory parts, and so is this one;
/// what it changes is the rules the study called quirks:
/// <list type="bullet">
/// <item>The pay of a month is the monthly pay times the days present over the days of the month (<c>PayrollDaysBasis</c> 0, the starting setting), or over a fixed number the shop chooses (26, 30 ...). The older program always divided by 30, so a person present on all 31 days earned more than the monthly pay. A range that crosses a month counts each day against its own month.</item>
/// <item>The overtime rate is a money amount for an hour, with decimals (the older program took only whole numbers and silently ignored 12.5). Short time (leaving early) is not taken from the pay unless the shop turns <c>PayrollPayShortTime</c> on.</item>
/// <item>A pay slip may cover a single day (the older program refused from = to), two slips for one person may not overlap, and a day that is on a slip cannot be changed until the slip is cancelled.</item>
/// <item>The only deduction is paying back an advance, never more than is outstanding; the pay out must be more than nothing. (Fines, PF, ESI, tax: none in the older program, so nothing to port; they belong to a country's payroll rules, kept as data later.)</item>
/// <item>Everything is written in the books: an advance is money out to "Paid to staff in advance", a slip is "Staff pay" (cost) against the advance paid back and the money paid out; cancelling a slip writes the opposite.</item>
/// </list>
/// </summary>
public sealed class PayrollService(HubDb db, ShopContextProvider shop, IClock clock, AuditService audit, BooksService books, Access access)
{
    // ---- the people ----------------------------------------------------------------------------------------------------------------------

    private const string Columns = "id, code, name, phone, email, address, city, department, designation, joined_on, salary_minor, basic_minutes, active, notes";

    private static Employee Map(SqliteDataReader r) => new(r.Int("id"), r.Text("code"), r.Text("name"), r.TextOrNull("phone"), r.TextOrNull("email"), r.TextOrNull("address"), r.TextOrNull("city"), r.TextOrNull("department"),
        r.TextOrNull("designation"), r.TextOrNull("joined_on") is { } d ? DateOnly.ParseExact(d, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : null, r.Int("salary_minor"), (int)r.Int("basic_minutes"), r.Flag("active"), r.TextOrNull("notes"));

    private static string DayText(DateOnly day) => day.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

    private static DateOnly ParseDay(string text) => DateOnly.ParseExact(text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

    private static string? Blank(string? text) => string.IsNullOrWhiteSpace(text) ? null : text.Trim();

    private DateOnly Today => shop.Current.Time.LocalDate(clock.UtcNow);

    public IReadOnlyList<Employee> List(bool includeInactive = false)
    {
        access.Require(Perm.Staff);
        return db.Query($"SELECT {Columns} FROM employees WHERE ($all = 1 OR active = 1) ORDER BY name COLLATE NOCASE, id", Map, ("$all", includeInactive ? 1 : 0));
    }

    public Employee? Get(long id)
    {
        access.Require(Perm.Staff);
        return db.QueryOne($"SELECT {Columns} FROM employees WHERE id = $id", Map, ("$id", id));
    }

    /// <summary>Adds a person, or changes the one named by the id. A name and the monthly pay are needed.</summary>
    public Employee Save(EmployeeInput input, long? userId = null)
    {
        access.Require(Perm.Staff);
        var name = (input.Name ?? "").Trim();
        if (name.Length == 0) throw new HubException("employee-name", "Please give a name.");
        if (name.Length > 120) throw new HubException("employee-name", "That name is too long.");
        if (input.SalaryMinor <= 0) throw new HubException("employee-pay", "Please give the monthly pay, above nothing.");
        if (input.BasicMinutes is < 1 or > 1440) throw new HubException("employee-hours", "The usual working time of a day must be between 1 minute and 24 hours.");
        return db.InTransaction((c, t) =>
        {
            long id;
            if (input.Id is { } existing)
            {
                if (HubDb.Scalar(c, "SELECT 1 FROM employees WHERE id = $id", t, ("$id", existing)) is null) throw new HubException("not-found", "That person was not found.");
                HubDb.Exec(c, "UPDATE employees SET name=$n, phone=$p, email=$e, address=$a, city=$ci, department=$d, designation=$g, joined_on=$j, salary_minor=$s, basic_minutes=$b, notes=$notes WHERE id=$id", t,
                    ("$n", name), ("$p", Blank(input.Phone)), ("$e", Blank(input.Email)), ("$a", Blank(input.Address)), ("$ci", Blank(input.City)), ("$d", Blank(input.Department)), ("$g", Blank(input.Designation)),
                    ("$j", input.JoinedOn is { } j ? DayText(j) : null), ("$s", input.SalaryMinor), ("$b", input.BasicMinutes), ("$notes", Blank(input.Notes)), ("$id", existing));
                id = existing;
            }
            else
            {
                id = Convert.ToInt64(HubDb.Scalar(c, "SELECT COALESCE(MAX(id), 0) + 1 FROM employees", t));
                HubDb.Exec(c, "INSERT INTO employees(id, code, name, phone, email, address, city, department, designation, joined_on, salary_minor, basic_minutes, notes, created_at) VALUES ($id, $code, $n, $p, $e, $a, $ci, $d, $g, $j, $s, $b, $notes, $at)", t,
                    ("$id", id), ("$code", "EMP-" + id), ("$n", name), ("$p", Blank(input.Phone)), ("$e", Blank(input.Email)), ("$a", Blank(input.Address)), ("$ci", Blank(input.City)), ("$d", Blank(input.Department)),
                    ("$g", Blank(input.Designation)), ("$j", input.JoinedOn is { } j ? DayText(j) : null), ("$s", input.SalaryMinor), ("$b", input.BasicMinutes), ("$notes", Blank(input.Notes)), ("$at", Iso.Text(clock.UtcNow)));
            }
            audit.Log(c, t, userId, input.Id is null ? "employee-add" : "employee-change", "employee", id, name);
            return HubDb.Query(c, $"SELECT {Columns} FROM employees WHERE id = $id", Map, t, ("$id", id)).Single();
        });
    }

    /// <summary>Switches a person off (a person who left) or on again. Nobody is deleted: their days, advances and slips stay.</summary>
    public void SetActive(long id, bool active, long? userId = null)
    {
        access.Require(Perm.Staff);
        db.InTransaction((c, t) =>
        {
            if (HubDb.Exec(c, "UPDATE employees SET active = $a WHERE id = $id", t, ("$a", active ? 1 : 0), ("$id", id)) == 0) throw new HubException("not-found", "That person was not found.");
            audit.Log(c, t, userId, active ? "employee-on" : "employee-off", "employee", id, null);
        });
    }

    // ---- the days ------------------------------------------------------------------------------------------------------------------------

    private static AttendanceDay MapDay(SqliteDataReader r) => new(r.Int("id"), r.Int("employee_id"), ParseDay(r.Text("day")), r.Text("status"), (int?)r.IntOrNull("in_minute"), (int?)r.IntOrNull("out_minute"), (int)r.Int("overtime_minutes"));

    /// <summary>The days written down for a person between two days (both included), oldest first.</summary>
    public IReadOnlyList<AttendanceDay> Days(long employeeId, DateOnly from, DateOnly to)
    {
        access.Require(Perm.Staff);
        return db.Query("SELECT id, employee_id, day, status, in_minute, out_minute, overtime_minutes FROM attendance WHERE employee_id = $e AND day >= $f AND day <= $t ORDER BY day",
            MapDay, ("$e", employeeId), ("$f", DayText(from)), ("$t", DayText(to)));
    }

    /// <summary>Writes down a person's day. A day can be written down once; <see cref="Change"/> corrects it. Times are both given or both left out.</summary>
    public AttendanceDay Mark(long employeeId, DateOnly day, bool present, TimeOnly? cameIn = null, TimeOnly? left = null, long? userId = null) =>
        Write(employeeId, day, present, cameIn, left, userId, correcting: false);

    /// <summary>Corrects a day that was written down.</summary>
    public AttendanceDay Change(long employeeId, DateOnly day, bool present, TimeOnly? cameIn = null, TimeOnly? left = null, long? userId = null) =>
        Write(employeeId, day, present, cameIn, left, userId, correcting: true);

    private AttendanceDay Write(long employeeId, DateOnly day, bool present, TimeOnly? cameIn, TimeOnly? left, long? userId, bool correcting)
    {
        access.Require(Perm.Staff);
        if (day > Today) throw new HubException("day-ahead", "That day has not come yet.");
        if ((cameIn is null) != (left is null)) throw new HubException("times", "Please give both the time they came and the time they left, or neither.");
        return db.InTransaction((c, t) =>
        {
            var person = HubDb.Query(c, $"SELECT {Columns} FROM employees WHERE id = $id", Map, t, ("$id", employeeId)).FirstOrDefault() ?? throw new HubException("not-found", "That person was not found.");
            if (!person.Active) throw new HubException("employee-off", $"{person.Name} is switched off.");
            RequireNotPaid(c, t, person, day);
            var exists = HubDb.Scalar(c, "SELECT id FROM attendance WHERE employee_id = $e AND day = $d", t, ("$e", employeeId), ("$d", DayText(day))) is not null;
            if (exists && !correcting) throw new HubException("day-saved", $"{person.Name}'s day on {day:d MMM yyyy} is already written down.");
            if (!exists && correcting) throw new HubException("not-found", $"Nothing is written down for {person.Name} on {day:d MMM yyyy}.");
            int? inMinute = null, outMinute = null;
            var overtime = 0;
            if (present && cameIn is { } a && left is { } b)
            {
                inMinute = a.Hour * 60 + a.Minute;
                outMinute = b.Hour * 60 + b.Minute;
                if (inMinute == outMinute) throw new HubException("times", "They cannot have come and left at the same minute.");
                var worked = outMinute.Value - inMinute.Value + (outMinute < inMinute ? 1440 : 0);   // left after midnight
                overtime = worked - person.BasicMinutes;
            }
            if (exists)
                HubDb.Exec(c, "UPDATE attendance SET status=$s, in_minute=$i, out_minute=$o, overtime_minutes=$ot, user_id=$u WHERE employee_id=$e AND day=$d", t,
                    ("$s", present ? "P" : "A"), ("$i", inMinute), ("$o", outMinute), ("$ot", overtime), ("$u", userId), ("$e", employeeId), ("$d", DayText(day)));
            else
                HubDb.Exec(c, "INSERT INTO attendance(employee_id, day, status, in_minute, out_minute, overtime_minutes, user_id) VALUES ($e, $d, $s, $i, $o, $ot, $u)", t,
                    ("$e", employeeId), ("$d", DayText(day)), ("$s", present ? "P" : "A"), ("$i", inMinute), ("$o", outMinute), ("$ot", overtime), ("$u", userId));
            audit.Log(c, t, userId, correcting ? "attendance-change" : "attendance-add", "employee", employeeId, $"{DayText(day)} {(present ? "P" : "A")}");
            return HubDb.Query(c, "SELECT id, employee_id, day, status, in_minute, out_minute, overtime_minutes FROM attendance WHERE employee_id = $e AND day = $d", MapDay, t, ("$e", employeeId), ("$d", DayText(day))).Single();
        });
    }

    /// <summary>Takes a written-down day away (it was written by mistake).</summary>
    public void Remove(long employeeId, DateOnly day, long? userId = null)
    {
        access.Require(Perm.Staff);
        db.InTransaction((c, t) =>
        {
            var person = HubDb.Query(c, $"SELECT {Columns} FROM employees WHERE id = $id", Map, t, ("$id", employeeId)).FirstOrDefault() ?? throw new HubException("not-found", "That person was not found.");
            RequireNotPaid(c, t, person, day);
            if (HubDb.Exec(c, "DELETE FROM attendance WHERE employee_id = $e AND day = $d", t, ("$e", employeeId), ("$d", DayText(day))) == 0)
                throw new HubException("not-found", $"Nothing is written down for {person.Name} on {day:d MMM yyyy}.");
            audit.Log(c, t, userId, "attendance-remove", "employee", employeeId, DayText(day));
        });
    }

    private static void RequireNotPaid(SqliteConnection c, SqliteTransaction t, Employee person, DateOnly day)
    {
        if (HubDb.Scalar(c, "SELECT number FROM staff_payments WHERE employee_id = $e AND cancelled_at IS NULL AND from_day <= $d AND to_day >= $d", t, ("$e", person.Id), ("$d", DayText(day))) is string slip)
            throw new HubException("day-paid", $"{person.Name} was paid for {day:d MMM yyyy} (slip {slip}). Cancel the slip first to change the day.");
    }

    // ---- pay in advance ----------------------------------------------------------------------------------------------------------------------

    /// <summary>Gives a person money in advance, to be paid back out of their pay. The money goes out of the till (or the other way of paying) and is written in the books.</summary>
    public void GiveAdvance(long employeeId, long amountMinor, string method, DateOnly? day = null, string? note = null, long? userId = null)
    {
        access.Require(Perm.Staff);
        if (amountMinor <= 0) throw new HubException("advance-amount", "Please give the amount, above nothing.");
        var way = string.IsNullOrWhiteSpace(method) ? "cash" : method.Trim().ToLowerInvariant();
        var when = day ?? Today;
        if (when > Today) throw new HubException("day-ahead", "That day has not come yet.");
        db.InTransaction((c, t) =>
        {
            var name = HubDb.Scalar(c, "SELECT name FROM employees WHERE id = $id", t, ("$id", employeeId)) as string ?? throw new HubException("not-found", "That person was not found.");
            var at = clock.UtcNow;
            var id = HubDb.Insert(c, "INSERT INTO staff_advances(employee_id, day, kind, amount_minor, method, note, at, user_id) VALUES ($e, $d, 'given', $a, $m, $n, $at, $u)", t,
                ("$e", employeeId), ("$d", DayText(when)), ("$a", amountMinor), ("$m", way), ("$n", Blank(note)), ("$at", Iso.Text(at)), ("$u", userId));
            books.PostEntry(c, t, at, "staff-advance", id, $"Paid in advance to {name}", userId,
                [new("staff-advances", null, amountMinor, 0), way == "cash" ? new("cash", null, 0, amountMinor) : new("method", way, 0, amountMinor)]);
            audit.Log(c, t, userId, "staff-advance", "employee", employeeId, $"{amountMinor} by {way}");
        });
    }

    /// <summary>What a person has had in advance and not yet paid back.</summary>
    public long Outstanding(long employeeId)
    {
        access.Require(Perm.Staff);
        return OutstandingNow(employeeId);
    }

    private long OutstandingNow(long employeeId) => Convert.ToInt64(db.Scalar("SELECT COALESCE(SUM(amount_minor), 0) FROM staff_advances WHERE employee_id = $e", ("$e", employeeId)) ?? 0L);

    /// <summary>The advances of a person, oldest first, with what is still to be paid back after each line.</summary>
    public IReadOnlyList<AdvanceLine> Advances(long employeeId)
    {
        access.Require(Perm.Staff);
        var rows = db.Query("SELECT a.id, a.day, a.kind, a.amount_minor, a.method, a.note, p.number FROM staff_advances a LEFT JOIN staff_payments p ON p.id = a.payment_id WHERE a.employee_id = $e ORDER BY a.day, a.id",
            r => (Id: r.Int("id"), Day: ParseDay(r.Text("day")), Kind: r.Text("kind"), Amount: r.Int("amount_minor"), Method: r.TextOrNull("method"), Note: r.TextOrNull("note"), Slip: r.TextOrNull("number")), ("$e", employeeId));
        long balance = 0;
        var list = new List<AdvanceLine>();
        foreach (var r in rows)
        {
            balance += r.Amount;
            var memo = r.Kind switch
            {
                "given" => "Given in advance" + (r.Method is { Length: > 0 } m && m != "cash" ? " by " + m : "") + (r.Note is { Length: > 0 } n ? " (" + n + ")" : ""),
                "repaid" => "Paid back out of pay (slip " + r.Slip + ")",
                _ => "Given back: slip " + r.Slip + " was cancelled",
            };
            list.Add(new AdvanceLine(r.Id, r.Day, r.Kind, memo, r.Amount, balance));
        }
        return list;
    }

    // ---- the monthly pay ---------------------------------------------------------------------------------------------------------------------

    /// <summary>amount x numerator / denominator, rounded half up (the amount and the numerator are never negative).</summary>
    private static long Share(long amount, long numerator, long denominator)
    {
        var product = (BigInteger)amount * numerator * 2 + denominator;
        return (long)(product / (2 * (BigInteger)denominator));
    }

    // 28, 29, 30 and 31 all divide this, so a month's share can be added exactly before rounding once.
    private const long CalendarLcm = 377_580;

    /// <summary>
    /// The pay earned for the days present: the monthly pay for each day divided by the month's days (or by a fixed number the shop chose), added exactly and rounded half up once.
    /// </summary>
    internal static long Earned(long monthlyMinor, IEnumerable<DateOnly> presentDays, int basis)
    {
        if (basis > 0) return Share(monthlyMinor, presentDays.Count(), basis);
        BigInteger numerator = 0;
        foreach (var month in presentDays.GroupBy(d => (d.Year, d.Month)))
        {
            var length = DateTime.DaysInMonth(month.Key.Year, month.Key.Month);
            numerator += (BigInteger)monthlyMinor * month.Count() * (CalendarLcm / length);
        }
        return (long)((numerator * 2 + CalendarLcm) / (2 * (BigInteger)CalendarLcm));
    }

    private static long OvertimePay(long minutes, long rateMinor)
    {
        if (minutes == 0 || rateMinor == 0) return 0;
        var amount = Share(rateMinor, Math.Abs(minutes), 60);
        return minutes < 0 ? -amount : amount;
    }

    private PayPreview Work(SqliteConnection? c, SqliteTransaction? t, long employeeId, DateOnly from, DateOnly to, long overtimeRateMinor)
    {
        IReadOnlyList<T> Q<T>(string sql, Func<SqliteDataReader, T> map, params (string, object?)[] p) => c is null ? db.Query(sql, map, p) : HubDb.Query(c, sql, map, t, p);
        var person = Q($"SELECT {Columns} FROM employees WHERE id = $id", Map, ("$id", employeeId)).FirstOrDefault() ?? throw new HubException("not-found", "That person was not found.");
        if (overtimeRateMinor < 0) throw new HubException("overtime-rate", "The overtime rate cannot be less than nothing.");
        var settings = shop.Current.Settings;
        var days = Q("SELECT day, status, overtime_minutes FROM attendance WHERE employee_id = $e AND day >= $f AND day <= $t ORDER BY day",
            r => (Day: ParseDay(r.Text("day")), Present: r.Text("status") == "P", Overtime: (int)r.Int("overtime_minutes")), ("$e", employeeId), ("$f", DayText(from)), ("$t", DayText(to)));
        var present = days.Where(d => d.Present).ToList();
        var minutes = present.Sum(d => settings.PayrollPayShortTime ? d.Overtime : Math.Max(0, d.Overtime));
        var earned = Earned(person.SalaryMinor, present.Select(d => d.Day), settings.PayrollDaysBasis);
        var overtime = OvertimePay(minutes, overtimeRateMinor);
        var outstanding = Convert.ToInt64((c is null ? db.Scalar("SELECT COALESCE(SUM(amount_minor), 0) FROM staff_advances WHERE employee_id = $e", ("$e", employeeId))
            : HubDb.Scalar(c, "SELECT COALESCE(SUM(amount_minor), 0) FROM staff_advances WHERE employee_id = $e", t, ("$e", employeeId))) ?? 0L);
        string? problem = null;
        if (to < from) problem = "The last day cannot be before the first day.";
        else if (Q("SELECT number FROM staff_payments WHERE employee_id = $e AND cancelled_at IS NULL AND from_day <= $t AND to_day >= $f", r => r.Text("number"), ("$e", employeeId), ("$f", DayText(from)), ("$t", DayText(to))).FirstOrDefault() is { } slip)
            problem = $"{person.Name} was already paid for some of those days (slip {slip}).";
        else if (present.Count == 0) problem = $"No day is written down as present for {person.Name} in those days.";
        return new PayPreview(person.Id, person.Name, from, to, present.Count, earned, minutes, overtimeRateMinor, overtime, outstanding, settings.PayrollDaysBasis, problem);
    }

    /// <summary>Works out a pay slip for a person and a range of days (both included) without saving it. Overtime is paid at <paramref name="overtimeRateMinor"/> for each hour.</summary>
    public PayPreview Preview(long employeeId, DateOnly from, DateOnly to, long overtimeRateMinor = 0)
    {
        access.Require(Perm.Staff);
        return Work(null, null, employeeId, from, to, overtimeRateMinor);
    }

    /// <summary>
    /// Pays a person for a range of days. <paramref name="repaidMinor"/> is taken out of the pay to pay back an advance (never more than is outstanding); what is paid out is the pay and the overtime less that, and it must be
    /// more than nothing. A range already paid, in whole or part, is refused.
    /// </summary>
    public PaySlip Pay(long employeeId, DateOnly from, DateOnly to, long overtimeRateMinor, long repaidMinor, string method, string? note = null, long? userId = null)
    {
        access.Require(Perm.Staff);
        var way = string.IsNullOrWhiteSpace(method) ? "cash" : method.Trim().ToLowerInvariant();
        return db.InTransaction((c, t) =>
        {
            var work = Work(c, t, employeeId, from, to, overtimeRateMinor);
            if (work.Problem is { } problem) throw new HubException("pay-days", problem);
            if (repaidMinor < 0) throw new HubException("pay-repay", "The advance paid back cannot be less than nothing.");
            if (repaidMinor > work.OutstandingMinor) throw new HubException("pay-repay", $"{work.Name} has only {shop.Current.Money(Math.Max(0, work.OutstandingMinor))} still to pay back, not {shop.Current.Money(repaidMinor)}.");
            var net = work.NetFor(repaidMinor);
            if (net <= 0) throw new HubException("pay-net", "What is paid out must be more than nothing.");
            var at = clock.UtcNow;
            var id = Convert.ToInt64(HubDb.Scalar(c, "SELECT COALESCE(MAX(id), 0) + 1 FROM staff_payments", t));
            var number = "PAY-" + id;
            HubDb.Exec(c, "INSERT INTO staff_payments(id, number, employee_id, from_day, to_day, present_days, salary_minor, overtime_minutes, overtime_rate_minor, overtime_minor, repaid_minor, net_minor, method, note, paid_at, user_id) " +
                "VALUES ($id, $num, $e, $f, $t, $pd, $sal, $om, $or, $oa, $rep, $net, $m, $note, $at, $u)", t,
                ("$id", id), ("$num", number), ("$e", employeeId), ("$f", DayText(from)), ("$t", DayText(to)), ("$pd", work.PresentDays), ("$sal", work.EarnedMinor), ("$om", work.OvertimeMinutes), ("$or", overtimeRateMinor),
                ("$oa", work.OvertimeMinor), ("$rep", repaidMinor), ("$net", net), ("$m", way), ("$note", Blank(note)), ("$at", Iso.Text(at)), ("$u", userId));
            if (repaidMinor > 0)
                HubDb.Exec(c, "INSERT INTO staff_advances(employee_id, day, kind, amount_minor, payment_id, at, user_id) VALUES ($e, $d, 'repaid', $a, $p, $at, $u)", t,
                    ("$e", employeeId), ("$d", DayText(to)), ("$a", -repaidMinor), ("$p", id), ("$at", Iso.Text(at)), ("$u", userId));
            books.PostEntry(c, t, at, "staff-pay", id, $"Pay of {work.Name}, slip {number}", userId,
                [new("staff-pay", null, work.GrossMinor, 0), new("staff-advances", null, 0, repaidMinor), way == "cash" ? new("cash", null, 0, net) : new("method", way, 0, net)]);
            audit.Log(c, t, userId, "staff-pay", "employee", employeeId, $"{number}: {net} by {way}");
            return Slip(c, t, id)!;
        });
    }

    private const string SlipColumns = "p.id, p.number, p.employee_id, e.name, p.from_day, p.to_day, p.present_days, p.salary_minor, p.overtime_minutes, p.overtime_rate_minor, p.overtime_minor, p.repaid_minor, p.net_minor, p.method, p.note, p.paid_at, p.cancelled_at, p.cancel_reason";

    private static PaySlip MapSlip(SqliteDataReader r) => new(r.Int("id"), r.Text("number"), r.Int("employee_id"), r.Text("name"), ParseDay(r.Text("from_day")), ParseDay(r.Text("to_day")), (int)r.Int("present_days"), r.Int("salary_minor"),
        (int)r.Int("overtime_minutes"), r.Int("overtime_rate_minor"), r.Int("overtime_minor"), r.Int("repaid_minor"), r.Int("net_minor"), r.Text("method"), r.TextOrNull("note"), r.Time("paid_at"), r.TextOrNull("cancelled_at") is not null, r.TextOrNull("cancel_reason"));

    private static PaySlip? Slip(SqliteConnection c, SqliteTransaction t, long id) =>
        HubDb.Query(c, $"SELECT {SlipColumns} FROM staff_payments p JOIN employees e ON e.id = p.employee_id WHERE p.id = $id", MapSlip, t, ("$id", id)).FirstOrDefault();

    public PaySlip? Slip(long id)
    {
        access.Require(Perm.Staff);
        return db.QueryOne($"SELECT {SlipColumns} FROM staff_payments p JOIN employees e ON e.id = p.employee_id WHERE p.id = $id", MapSlip, ("$id", id));
    }

    /// <summary>The pay slips, newest first: one person's or everybody's, with the days they were paid for inside the range if one is given.</summary>
    public IReadOnlyList<PaySlip> Slips(long? employeeId = null, DateOnly? from = null, DateOnly? to = null)
    {
        access.Require(Perm.Staff);
        return db.Query(
            $"SELECT {SlipColumns} FROM staff_payments p JOIN employees e ON e.id = p.employee_id WHERE ($e IS NULL OR p.employee_id = $e) AND ($f IS NULL OR p.to_day >= $f) AND ($t IS NULL OR p.from_day <= $t) ORDER BY p.paid_at DESC, p.id DESC",
            MapSlip, ("$e", employeeId), ("$f", from is { } f ? DayText(f) : null), ("$t", to is { } x ? DayText(x) : null));
    }

    /// <summary>
    /// Cancels a pay slip that was written by mistake: it stays on record marked cancelled, its days can be changed and paid again, the advance paid back out of it is owed again, and the books get the opposite entry.
    /// </summary>
    public void CancelSlip(long id, string reason, long? userId = null)
    {
        access.Require(Perm.Staff);
        var why = (reason ?? "").Trim();
        if (why.Length == 0) throw new HubException("cancel-reason", "Please say why the slip is cancelled.");
        db.InTransaction((c, t) =>
        {
            var slip = Slip(c, t, id) ?? throw new HubException("not-found", "That pay slip was not found.");
            if (slip.Cancelled) throw new HubException("already-cancelled", $"Slip {slip.Number} is already cancelled.");
            var at = clock.UtcNow;
            HubDb.Exec(c, "UPDATE staff_payments SET cancelled_at = $at, cancel_reason = $r WHERE id = $id", t, ("$at", Iso.Text(at)), ("$r", why), ("$id", id));
            if (slip.RepaidMinor > 0)
                HubDb.Exec(c, "INSERT INTO staff_advances(employee_id, day, kind, amount_minor, payment_id, at, user_id) VALUES ($e, $d, 'repaid-back', $a, $p, $at, $u)", t,
                    ("$e", slip.EmployeeId), ("$d", DayText(Today)), ("$a", slip.RepaidMinor), ("$p", id), ("$at", Iso.Text(at)), ("$u", userId));
            books.PostEntry(c, t, at, "staff-pay-back", id, $"Pay slip {slip.Number} of {slip.EmployeeName} cancelled: {why}", userId,
                [new("staff-pay", null, 0, slip.GrossMinor), new("staff-advances", null, slip.RepaidMinor, 0), slip.Method == "cash" ? new("cash", null, slip.NetMinor, 0) : new("method", slip.Method, slip.NetMinor, 0)]);
            audit.Log(c, t, userId, "staff-pay-cancel", "employee", slip.EmployeeId, $"{slip.Number}: {why}");
        });
    }
}
