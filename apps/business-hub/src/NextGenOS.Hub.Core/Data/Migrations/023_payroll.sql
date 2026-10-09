-- Employees, their attendance, advances and monthly pay (docs/old-programs/03-india-tax-and-staff.md, B3). NEW TABLES only; nothing that exists is changed.
--   employees           the people who work for the shop: name, how to reach them, department, the monthly pay and the usual working time of a day, in minutes. Never deleted, only switched off.
--   attendance          one row for each person and day: present or absent, and when they came and left (minutes since midnight, both optional). The overtime of the day (minutes, may be below
--                       nothing when they left early) is worked out when it is written. A day that falls inside a period already paid cannot be changed (the older program let it).
--   staff_advances      money given to a person in advance (+) and paid back out of their pay (-). What is still to be paid back is the sum. Rows are only ever added.
--   staff_payments      one pay slip for a person and a range of days: the days present, the pay earned, the overtime, the advance paid back, what was paid out. A slip can be cancelled (kept, marked),
--                       never changed or deleted; a cancelled slip frees its days and gives the advance back.
-- The tables carry tenant_id and site_id ('local', 'main'). The way back is Data/Rollbacks/023_payroll.sql.
CREATE TABLE employees (
  id INTEGER PRIMARY KEY, tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main',
  code TEXT NOT NULL, name TEXT NOT NULL, phone TEXT, email TEXT, address TEXT, city TEXT, department TEXT, designation TEXT,
  joined_on TEXT, salary_minor INTEGER NOT NULL CHECK (salary_minor >= 0), basic_minutes INTEGER NOT NULL DEFAULT 480 CHECK (basic_minutes BETWEEN 1 AND 1440),
  active INTEGER NOT NULL DEFAULT 1, notes TEXT, created_at TEXT NOT NULL);
CREATE UNIQUE INDEX ux_employees_code ON employees(tenant_id, site_id, code);

CREATE TABLE attendance (
  id INTEGER PRIMARY KEY, tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main',
  employee_id INTEGER NOT NULL REFERENCES employees(id), day TEXT NOT NULL,
  status TEXT NOT NULL CHECK (status IN ('P', 'A')),
  in_minute INTEGER CHECK (in_minute IS NULL OR in_minute BETWEEN 0 AND 1439), out_minute INTEGER CHECK (out_minute IS NULL OR out_minute BETWEEN 0 AND 1439),
  overtime_minutes INTEGER NOT NULL DEFAULT 0, user_id INTEGER);
CREATE UNIQUE INDEX ux_attendance_day ON attendance(employee_id, day);

CREATE TABLE staff_payments (
  id INTEGER PRIMARY KEY, tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main',
  number TEXT NOT NULL, employee_id INTEGER NOT NULL REFERENCES employees(id),
  from_day TEXT NOT NULL, to_day TEXT NOT NULL,
  present_days INTEGER NOT NULL, salary_minor INTEGER NOT NULL, overtime_minutes INTEGER NOT NULL DEFAULT 0, overtime_rate_minor INTEGER NOT NULL DEFAULT 0, overtime_minor INTEGER NOT NULL DEFAULT 0,
  repaid_minor INTEGER NOT NULL DEFAULT 0 CHECK (repaid_minor >= 0), net_minor INTEGER NOT NULL, method TEXT NOT NULL, note TEXT,
  paid_at TEXT NOT NULL, user_id INTEGER, cancelled_at TEXT, cancel_reason TEXT);
CREATE UNIQUE INDEX ux_staff_payments_number ON staff_payments(tenant_id, site_id, number);
CREATE INDEX ix_staff_payments_employee ON staff_payments(employee_id, from_day);

CREATE TABLE staff_advances (
  id INTEGER PRIMARY KEY, tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main',
  employee_id INTEGER NOT NULL REFERENCES employees(id), day TEXT NOT NULL,
  kind TEXT NOT NULL CHECK (kind IN ('given', 'repaid', 'repaid-back')),
  amount_minor INTEGER NOT NULL, payment_id INTEGER REFERENCES staff_payments(id), method TEXT, note TEXT, at TEXT NOT NULL, user_id INTEGER);
CREATE INDEX ix_staff_advances_employee ON staff_advances(employee_id, day);
