-- The way back from 023_payroll.sql: drops the employees, their attendance, advances and pay slips. Sales and the other records are untouched (the entries the books already hold for staff pay
-- stay where they are). Used by HubDb.Rollback, which copies the database first.
DROP INDEX IF EXISTS ix_staff_advances_employee;
DROP TABLE IF EXISTS staff_advances;
DROP INDEX IF EXISTS ix_staff_payments_employee;
DROP INDEX IF EXISTS ux_staff_payments_number;
DROP TABLE IF EXISTS staff_payments;
DROP INDEX IF EXISTS ux_attendance_day;
DROP TABLE IF EXISTS attendance;
DROP INDEX IF EXISTS ux_employees_code;
DROP TABLE IF EXISTS employees;
