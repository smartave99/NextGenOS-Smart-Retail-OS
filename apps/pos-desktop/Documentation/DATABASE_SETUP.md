# Smart Retail OS - Database Setup & Restoration Guide

## 1. Overview
Smart Retail OS (by NextGen OS) utilizes Microsoft SQL Server (SQL Server 2012, 2014, 2016, 2019, 2022, or SQL Server Express) for local or networked database operations.

The application operates with two database structures:
1. **Master Database (`RaintechMaster_DB`)**: Tracks retail company profiles, active company ID, and database catalog names.
2. **Company Transaction Database (`DBscript.sql` / Company Database)**: Contains all product tables, stock tables, invoices, barcode history, user permissions, customer ledger, and loyalty points.

---

## 2. Setting Up `RaintechMaster_DB`

The script `CompanyMasterDBScript.sql` configures the master company directory database:

```sql
USE [master]
GO
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'RaintechMaster_DB')
BEGIN
    CREATE DATABASE [RaintechMaster_DB]
END
GO

USE [RaintechMaster_DB]
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RaintechMaster]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RaintechMaster](
    [Id] [int] NOT NULL,
    [CompanyName] [nchar](150) NULL,
    [DBName] [nchar](30) NULL,
    [Online_DBName] [nvarchar](250) NULL,
    [company_id] [nvarchar](100) NULL,
    [is_active] [bit] NOT NULL CONSTRAINT [DF_RaintechMaster_is_active] DEFAULT ((1)),
    CONSTRAINT [PK_CompanyMaster] PRIMARY KEY CLUSTERED ([Id] ASC)
) ON [PRIMARY]
END
GO
```

---

## 3. Company Database Architecture (`DBscript.sql`)

The company database contains approximately 60 core relational tables:

| Table Category | Key Tables | Purpose |
|---|---|---|
| **Company & Identity** | `Company`, `BranchMaster`, `Users`, `UserGrants`, `UserType` | Store settings, multi-branch tracking, operator credentials, role-based access control. |
| **Catalog & Products** | `Category`, `SubCategory`, `Product`, `Product_OpeningStock`, `Barcode` | Hierarchical category definitions, item SKU, HSN codes, barcode mappings, initial stock. |
| **Inventory & Stock** | `Temp_Stock`, `Stock`, `StockTransfer`, `StockTransfer_Join`, `Stock_Store` | Current inventory count, MRP, purchase price, wholesale/retail selling prices, inter-branch transfers. |
| **Sales & Billing** | `InvoiceInfo`, `Invoice_Product`, `Temp_Cash`, `RestaurantPOS_OrderInfo` | Point-of-sale customer bills, line items, discounts, tax breakdowns (CGST/SGST/IGST), payment modes. |
| **Purchases & Suppliers** | `Supplier`, `Purchase`, `Purchase_Join`, `PurchaseReturn` | Vendor directory, goods received notes, vendor payments, purchase returns. |
| **Financial & Ledger** | `Customer`, `CustomerLedger`, `Payment`, `Expense`, `DayBook` | Customer balances, credit sales, expense categorization, cash-in-drawer daily reconciliations. |
| **Loyalty & Promotions** | `CustomerOffer`, `CouponGenerate`, `CustomerMembership` | Discount coupons, loyalty points accrual, automated SMS/WhatsApp marketing targets. |

---

## 4. Connection Strings & Configuration

The connection configuration is managed in:
- `Source\SmartAvenue99_POS_VB\SmartAvenue99 POS\app.config`
- `ModCS.vb` (Runtime connection string builder)

Typical connection string format:
```xml
<connectionStrings>
    <add name="DefaultConnection"
         connectionString="Data Source=localhost;Initial Catalog=RaintechMaster_DB;Integrated Security=True"
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

When targeting a named instance (e.g., `SQLEXPRESS`):
```
Data Source=.\SQLEXPRESS;Initial Catalog=RaintechMaster_DB;Integrated Security=True
```
Or with SQL Authentication:
```
Data Source=localhost;Initial Catalog=RaintechMaster_DB;User Id=sa;Password=your_password;
```

---

## 5. Automated Migration & Backup Routines

The application includes built-in database maintenance forms:
- `frmAuto_Migrate.vb`: Runs topological dependency checks across foreign keys to migrate schema revisions seamlessly.
- `frmBackup.vb`: Invokes `BACKUP DATABASE` to local timestamped `.bak` files.
- `frmRestore.vb`: Restores databases with exclusive lock acquisition (`ALTER DATABASE ... SET SINGLE_USER WITH ROLLBACK IMMEDIATE`).
