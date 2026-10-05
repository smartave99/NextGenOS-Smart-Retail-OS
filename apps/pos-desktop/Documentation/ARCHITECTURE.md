# Smart Retail OS - Architectural Documentation

## 1. System Overview
**Smart Retail OS** (by **NextGen OS**) is an enterprise-grade retail Point-of-Sale (POS) and ERP application built for Windows using Windows Forms, .NET Framework 4.8, ADO.NET, SQL Server, Crystal Reports, and a suite of companion integration services.

The solution is divided into two major tiers:
1. **Core Application (`Smart Retail OS`)**: Handles the WinForms graphical user interface, retail transactions, barcode generation and printing, billing engines, inventory management, customer tracking, loyalty programs, and accounting ledgers.
2. **Companion Libraries (`DevNet.*`, `MyDBLibrary`)**: Specialized helper modules for device communication, web automation, external payment integrations, cloud synchronization, and multi-language support.

---

## 2. Component Architecture

```
+---------------------------------------------------------------------------------+
|                         Smart Retail OS (by NextGen OS)                         |
|               (Main Application UI - WinForms, VB.NET, .NET 4.8 x86)            |
+---------------------------------------------------------------------------------+
          |                     |                      |                   |
          v                     v                      v                   v
+------------------+  +-------------------+  +------------------+  +---------------+
|     Billing &    |  |     Inventory     |  |     Hardware     |  |   Reporting   |
|   Transactions   |  |   & Stock Audit   |  |  (Printers, CAM) |  | CrystalReports|
+------------------+  +-------------------+  +------------------+  +---------------+
          |                     |                      |                   |
+---------------------------------------------------------------------------------+
|                                Integration Tier                                 |
+---------------------------------------------------------------------------------+
  |-- MyDBLibrary: High-performance ADO.NET SQL Server data layer
  |-- DevNetWP: WhatsApp notifications, bill sharing, and webhook integration
  |-- DevNetFB: Firebase Realtime Database bidirectional product & stock sync
  |-- DevNetLM: Machine hardware-bound activation, licensing & expiry checks
  |-- DevNetSR: Google Cloud Speech-to-Text engine for voice command navigation
  |-- DevNet.PhonePe: Dynamic UPI QR code generation and instant payment webhook
  |-- DevNet.ChromeDriverManager: Auto-update manager for headless Selenium WebDriver
  |-- DevNet.GS: Real-time GSTIN validation and business profile resolution
  |-- DevNet.Translitration: Indic script transliteration for bilingual bills
  |-- DevNetTRLN: Multi-language terminology translation dictionary
  |-- DevNet.QImage: Automated web product image search and catalog enrichment
```

---

## 3. Companion Library Roles & Descriptions

### `MyDBLibrary`
- **Purpose**: ADO.NET Database abstraction.
- **Key Classes**: Database connection manager, generic `SqlDataReader` wrappers, parameterized command executors, and transaction managers.

### `DevNetWP`
- **Purpose**: WhatsApp Messaging & Customer Notification Service.
- **Key Classes**:
  - `clsWhatsapp`: Direct API sender for transactional invoice receipts and promotional broadcasts.
  - `ApiRequestor`: WebClient-based REST caller for messaging gateway APIs.
  - `clsfun`: Encryption and token parsing helpers.

### `DevNetFB`
- **Purpose**: Cloud Synchronization Service via Google Firebase Realtime Database.
- **Key Classes**:
  - `FirebaseService`: Background service that queries local SQL Server tables (`Product`, `Temp_Stock`, `SubCategory`) and pushes stock levels, prices, and barcodes to cloud endpoints (`comp/{companyid}/Stock/{Barcode}`).

### `DevNetLM`
- **Purpose**: Hardware ID Binding & Cloud License Management.
- **Key Classes**:
  - `DevNet`: Hardware fingerprint extraction (motherboard, CPU serial, MAC address) and remote license validation.
  - `ActivationForm` (NextGenOS.Licensing.Windows, shared with the AI app): interactive dialog where the store owner enters the licence key (or activates without Internet).
  - `Encryption`: TripleDES / AES cipher routines protecting license tokens.

### `DevNetSR`
- **Purpose**: Voice Command & Speech Recognition Engine.
- **Key Classes**:
  - `AudioRecorder`: NAudio-based microphone capture buffer and audio stream aggregator.
  - `Listen`: WinForms audio visualizer that streams audio to `Google.Cloud.Speech.V1` and emits text transcripts.
  - `Languages`: Supported language lookup table (English, Hindi, regional dialects).

### `DevNet.PhonePe`
- **Purpose**: UPI Payment Integration & Dynamic QR Code Generation.
- **Key Classes**:
  - `PhonePe`: Core checkout orchestrator generating instant UPI QR codes for POS bills.
  - `Transaction`: Model encapsulating `txnId`, `amount`, `status`, and `timestamp`.
  - `FrmBrowser`: CefSharp Chromium browser container for embedded merchant payment portal sessions.

### `DevNet.ChromeDriverManager`
- **Purpose**: Automated ChromeDriver lifecycle management.
- **Key Classes**:
  - `ChromeDriverManager`: Queries installed Google Chrome version from registry, downloads matching ChromeDriver binaries, and extracts them.
  - `Utility`: Process management helpers (`DestroyAllChromeDrivers`, `IsFileReady`).

### `DevNet.GS`
- **Purpose**: GSTIN Verification & Tax Profile Enrichment.
- **Key Classes**:
  - `GSTINValidator`: Asynchronous validator for Indian 15-digit GSTIN tax identifiers.
  - `ResponseModel`, `ResponseDetails`, `AddressDetails`: Data transfer objects mapping taxpayer trade name, legal name, registration date, and registered address.

### `DevNet.Translitration`
- **Purpose**: Real-time Indic Transliteration for Retail Billing.
- **Key Classes**:
  - `Translitration`: Converts Latin phonetic input to 21 Indic scripts (Hindi, Bengali, Gujarati, Marathi, Tamil, Telugu, etc.).
  - `ControlOption` & `ControlOptions`: WinForms interactive popup candidates list for touchscreens.

### `DevNetTRLN`
- **Purpose**: Translation & Locale Mapping.
- **Key Classes**:
  - `Transliterator`: Language mapping and localized string substitution.

### `DevNet.QImage`
- **Purpose**: Product Catalog Image Search.
- **Key Classes**:
  - `QImage`: Image query engine fetching high-resolution product images for newly added inventory items.
  - `WebImage`: Encapsulated System.Drawing.Image wrapper.
