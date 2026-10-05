# Smart Retail Suite - Unified Database Guide

This document describes the data persistence layers across the four subsystems of the **Smart Retail Suite**, how data synchronizes, and best practices for configuration.

---

## 1. Storage Topology Matrix

| Tier | Subsystem | Storage Engine | Location | Role |
|------|-----------|----------------|----------|------|
| **1. In-Store Primary** | `apps/pos-desktop` | Microsoft SQL Server (2014-2022 / Express) | In-store Workstation / Local LAN | Authoritative store ledger, inventory batches, barcodes, customer credit, and GST billing records. |
| **2. Local Companion Cache** | `apps/pos-dashboard-service` & `apps/pos-ai-companion` | SQLite (`SmartRetail.db`) | In-store Workstation AppData | Local configuration, AI cache, generated posters, photo metadata, and query history. |
| **3. Remote Owner Telemetry** | `apps/pos-dashboard-service/owner-app` | Supabase (PostgreSQL) | Cloud (Owner's Project) | Real-time aggregate sales, revenue metrics, and inventory alerts accessible via mobile/web anywhere. |
| **4. Omnichannel Commerce** | `apps/storefront-web-mobile` | PostgreSQL (via Prisma ORM) | Cloud (Neon / Supabase / Self-hosted) | Online product catalog, web orders, customer profiles, shopping cart state, and AI recommendation history. |
| **5. Live Catalog Sync** | `apps/pos-desktop` (`DevNetFB`) | Firebase Realtime Database | Cloud (Google Cloud) | Real-time catalog mirroring between desktop POS and mobile devices. |

---

## 2. In-Store Primary Database (SQL Server)

### Setup & Restoration
The database backup file or SQL creation scripts are located in:
```
apps/pos-desktop/Setup/
```
Refer to `apps/pos-desktop/Documentation/DATABASE_SETUP.md` for full restoration steps using SQL Server Management Studio (SSMS) or command-line `sqlcmd`.

### Key Tables
- `Item_Master`: Core product inventory records, HSN codes, GST tax rates, and base units.
- `Temp_Stock`: Batch-specific stock levels, expiration dates, purchase prices, and batch barcodes.
- `Bill_Master` & `Bill_Detail`: Complete transactional history for counter sales, discounts, and payment methods.
- `Customer_Master`: Customer contact information, loyalty points, and outstanding balances.
- `Vendor_Master`: Supplier details, purchase orders, and payment vouchers.

---

## 3. Remote Cloud Sync (Supabase)

To enable remote owner monitoring without exposing internal customer details:
1. Create a Supabase project at [supabase.com](https://supabase.com).
2. Configure credentials in `apps/pos-dashboard-service`:
   ```json
   {
     "Supabase": {
       "Url": "https://<your-project>.supabase.co",
       "ApiKey": "<your-anon-or-service-key>"
     }
   }
   ```
3. Only aggregated metrics (daily turnover, bill counts, top sellers, category margins) are pushed to Supabase. No customer phone numbers or confidential identifying records are ever uploaded to cloud instances.

---

## 4. Omnichannel Storefront Database (Prisma)

The digital storefront in `apps/storefront-web-mobile` uses Prisma ORM:
- **Schema File**: `apps/storefront-web-mobile/prisma/schema.prisma`
- **Migrations**:
  ```bash
  cd apps/storefront-web-mobile
  npx prisma migrate dev
  npx prisma generate
  ```
- **Connection String**: Defined in `apps/storefront-web-mobile/.env` as `DATABASE_URL`.
