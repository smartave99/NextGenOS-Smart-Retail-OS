/*
  Smart Retail POS AI Assistant: read-only SQL Server login

  Run once in SQL Server Management Studio (or sqlcmd) while signed in as an administrator.
  Before running:
    1. Replace CHANGE-ME-... below with a strong password (keep it; the assistant needs it).
    2. Set @CompanyDatabases to the company database(s) the assistant may read.
       The POS names them Raintech_DB1, Raintech_DB2, ... (see Settings > Database > Pick company).
  Then, in the assistant: Settings > Database > untick "Windows authentication",
  SQL login = smartretail_ai, Password = the password you chose.

  The login can only read. It cannot see the tables that hold passwords, API keys or licence data,
  nor bank-account and PAN columns. It can read the POS log (Logs), where the times of bills are;
  the AI assistant never reads that table. Run this script again after updating to 1.7 or later.
*/

USE [master];
GO

IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = N'smartretail_ai')
    CREATE LOGIN [smartretail_ai]
        WITH PASSWORD = N'CHANGE-ME-Use-A-Long-Password-2026!', CHECK_POLICY = ON, DEFAULT_DATABASE = [master];
GO

DECLARE @CompanyDatabases TABLE (name sysname);
INSERT INTO @CompanyDatabases (name) VALUES (N'Raintech_DB1');   -- add more rows for more companies

DECLARE @db sysname, @sql nvarchar(max);
DECLARE databases CURSOR LOCAL FAST_FORWARD FOR SELECT name FROM @CompanyDatabases WHERE DB_ID(name) IS NOT NULL;
OPEN databases;
FETCH NEXT FROM databases INTO @db;
WHILE @@FETCH_STATUS = 0
BEGIN
    SET @sql = N'USE ' + QUOTENAME(@db) + N';
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = N''smartretail_ai'')
    CREATE USER [smartretail_ai] FOR LOGIN [smartretail_ai];
ALTER ROLE [db_datareader] ADD MEMBER [smartretail_ai];

DECLARE @t sysname, @deny nvarchar(400);
DECLARE denied CURSOR LOCAL FAST_FORWARD FOR SELECT name FROM (VALUES
    (N''Registration''), (N''Activation''), (N''EmailSetting''), (N''EmailSetting_login''), (N''EwaybillAPISetting''),
    (N''FTP_Category''), (N''WappApi''), (N''tbl_api_setting''), (N''SMSSetting''), (N''GSheet_setting''),
    (N''Autobackup''), (N''UserControl''), (N''RaintechMaster''), (N''AutoMigrationControl''), (N''DataMigration_Logs''),
    (N''CustomerSupportForm''), (N''Android_Apps''), (N''ExtDB''), (N''ExtDB1''), (N''ExtDB2'')) AS v(name);
OPEN denied;
FETCH NEXT FROM denied INTO @t;
WHILE @@FETCH_STATUS = 0
BEGIN
    IF OBJECT_ID(N''dbo.'' + QUOTENAME(@t), N''U'') IS NOT NULL
    BEGIN
        SET @deny = N''DENY SELECT ON dbo.'' + QUOTENAME(@t) + N'' TO [smartretail_ai];'';
        EXEC sys.sp_executesql @deny;
    END
    FETCH NEXT FROM denied INTO @t;
END
CLOSE denied;
DEALLOCATE denied;
-- The POS log says when each bill was saved: the dashboard reads the times of bills from it (the AI never can).
-- Earlier versions of this script denied it; this lifts that.
IF OBJECT_ID(N''dbo.Logs'', N''U'') IS NOT NULL
    REVOKE SELECT ON dbo.Logs FROM [smartretail_ai];

-- Bank details and tax identity numbers.
DECLARE @c sysname, @table sysname;
DECLARE columns_to_hide CURSOR LOCAL FAST_FORWARD FOR
    SELECT TABLE_NAME, COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_SCHEMA = N''dbo'' AND TABLE_NAME IN (N''Customer'', N''Supplier'', N''Company'')
      AND COLUMN_NAME IN (N''AccountNumber'', N''AccountName'', N''Bank'', N''Branch'', N''IFSCCode'', N''PAN'', N''CIN'',
                          N''Bankholder'', N''Bankacno'', N''Bankname'', N''Bankifsc'', N''AdminCode'', N''AndroidID'', N''BCode'');
OPEN columns_to_hide;
FETCH NEXT FROM columns_to_hide INTO @table, @c;
WHILE @@FETCH_STATUS = 0
BEGIN
    SET @deny = N''DENY SELECT ('' + QUOTENAME(@c) + N'') ON dbo.'' + QUOTENAME(@table) + N'' TO [smartretail_ai];'';
    EXEC sys.sp_executesql @deny;
    FETCH NEXT FROM columns_to_hide INTO @table, @c;
END
CLOSE columns_to_hide;
DEALLOCATE columns_to_hide;';
    EXEC sys.sp_executesql @sql;
    PRINT N'Read-only access set up in ' + @db;
    FETCH NEXT FROM databases INTO @db;
END
CLOSE databases;
DEALLOCATE databases;
GO

/* Optional: let "Pick company" in the assistant list the POS companies (names only). */
IF DB_ID(N'RaintechMaster_DB') IS NOT NULL
BEGIN
    EXEC (N'USE [RaintechMaster_DB];
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = N''smartretail_ai'')
    CREATE USER [smartretail_ai] FOR LOGIN [smartretail_ai];
GRANT SELECT ON dbo.RaintechMaster (CompanyName, DBName, is_active) TO [smartretail_ai];');
END
GO
