# Smart Retail Suite - Unified Enterprise Platform

Welcome to the **Smart Retail Suite**, a complete, unified omnichannel retail platform created by combining the three core codebases of the **NextGen OS & Smart Avenue** ecosystem into a single unified monorepo.

---

## 1. Unified Architecture Overview

The suite bridges physical in-store checkout counters with AI-powered till assistance, modern cloud dashboards, and multi-platform digital storefronts.

```mermaid
flowchart TD
    subgraph ClientLayer["Frontend & Client Workstations"]
        DesktopPOS["Core WinForms POS Station\n(.NET 4.8 / VB.NET)\n[apps/pos-desktop]"]
        AIAssistant["Smart Retail AI Companion\n(WPF / WebView2)\n[apps/pos-ai-companion]"]
        DashboardUI["Web Dashboard & Photo Studio\n(ASP.NET Core .NET 8)\n[apps/pos-dashboard-service]"]
        WebStorefront["Smart Avenue Storefront\n(Next.js 15 / React 19)\n[apps/storefront-web-mobile]"]
        MobileClient["Mobile Apps (Android & iOS)\n(Capacitor)"]
        ElectronClient["Desktop Shopping App\n(Electron 42)"]
    end

    subgraph ServiceLayer["Local & Cloud Services"]
        LocalSQL[(Local SQL Server\nPOS Database)]
        SupabaseCloud[(Supabase Remote\nOwner Telemetry)]
        PrismaPostgres[(Prisma PostgreSQL\nStorefront Database)]
        FirebaseSync[(Firebase Realtime\nCatalog Sync)]
    end

    subgraph AIEngine["Omnichannel AI Intelligence"]
        GroqRouter["Groq API\n(Instant Chat & Deals)"]
        LightningRouter["Lightning AI DeepSeek-V4\n(Styling & Semantic Search)"]
        VisionModels["Gemma 4 31B & Nemotron 30B\n(Visual Product Search)"]
        LocalCLI["Codex / Claude / Antigravity CLI\n(In-Store POS Answering)"]
    end

    DesktopPOS <--> LocalSQL
    DesktopPOS <--> FirebaseSync
    AIAssistant -. Reads .-> LocalSQL
    AIAssistant <--> LocalCLI
    DashboardUI -. Reads .-> LocalSQL
    DashboardUI --> SupabaseCloud
    WebStorefront <--> PrismaPostgres
    WebStorefront --> MobileClient
    WebStorefront --> ElectronClient
    WebStorefront <--> GroqRouter
    WebStorefront <--> LightningRouter
    WebStorefront <--> VisionModels
```

---

## 2. Directory Layout & Subsystem Roles

```
smart-retail-suite/
│
├── apps/
│   ├── pos-desktop/             # [From Smart-Retail-POS-by-NextGen-OS-main.zip]
│   │   ├── Source/              # SmartAvenue99 Master Solution (13 WinForms & Library projects)
│   │   ├── Drivers/             # Receipt printers, barcode scanners, and peripheral drivers
│   │   ├── Fonts/               # Barcode (Code128/39) and receipt fonts
│   │   ├── Setup/               # SQL Server database restore files and deployment scripts
│   │   ├── Documentation/       # Comprehensive POS architecture and screen inventories
│   │   └── installer/           # Deployment packaging files
│   │
│   ├── pos-ai-companion/        # [From Test-main.zip -> SmartRetailAI]
│   │   ├── src/                 # SmartRetail.AI.Core and SmartRetail.AI.Desktop (WPF .NET 8)
│   │   ├── tests/               # Unit and integration test suites
│   │   ├── installer/           # InnoSetup and NSIS installer scripts
│   │   └── SmartRetailAI.sln    # Dedicated Visual Studio solution for the AI overlay
│   │
│   ├── pos-dashboard-service/   # [From Test-main.zip -> SmartRetailPOS]
│   │   ├── src/                 # SmartRetail.Pos (Core, Data, Vision, Web) in .NET 8
│   │   ├── owner-app/           # Supabase-backed owner remote dashboard web application
│   │   ├── tests/               # Dashboard and Vision test suites
│   │   └── SmartRetailPOS.sln   # Dedicated Visual Studio solution for web services
│   │
│   └── storefront-web-mobile/   # [From smart_avenue-master.zip]
│       ├── src/                 # Next.js 15, React 19, and Tailwind CSS app components
│       ├── android/             # Native Android project configuration for Capacitor
│       ├── prisma/              # Database schema (PostgreSQL) and Prisma client migrations
│       ├── main.js              # Electron 42 desktop application entry point
│       └── package.json         # Storefront dependencies, build configs, and scripts
│
├── docs/                        # Consolidated architecture, database, and AI documentation
│   ├── SYSTEM_ARCHITECTURE.md   # System component interaction and data flow
│   ├── DATABASE_GUIDE.md        # SQL Server, SQLite, Supabase, and Prisma guide
│   └── AI_INTEGRATION_GUIDE.md  # Multi-model routing (Groq, Lightning AI, Gemma, Codex)
│
├── scripts/                     # Master automation and launcher scripts
│   ├── start-suite-menu.bat     # Interactive master control panel launcher
│   ├── build-all.ps1            # Multi-target build script for .NET and Node.js
│   ├── start-pos-desktop.bat    # 1-Click launcher for WinForms desktop POS
│   ├── start-pos-ai.bat         # 1-Click launcher for AI side-panel companion
│   ├── start-pos-dashboard.bat  # 1-Click launcher for POS web dashboard & services
│   ├── start-storefront.bat     # 1-Click launcher for Next.js storefront dev server
│   └── start-storefront-desktop.bat # 1-Click launcher for Electron desktop storefront
│
├── SmartRetailSuite.sln         # Master Visual Studio 2022 Solution uniting all 21 .NET projects
├── package.json                 # Monorepo root npm orchestration configuration
├── .gitignore                   # Unified .gitignore covering .NET, Node, Next.js, and Capacitor
└── README.md                    # This document
```

---

## 3. Subsystem Breakdown

### 3.1. `apps/pos-desktop` - Core In-Store Billing & ERP Workstation
- **Purpose**: The primary workstation running at the retail counter.
- **Tech Stack**: Visual Basic .NET, C#, .NET Framework 4.8 x86, Windows Forms, Crystal Reports, ADO.NET SQL Server.
- **Components**:
  - `SmartAvenue99 POS`: Billing, batch tracking, inventory audits, cash drawer, and thermal printing.
  - 12 Companion Libraries:
    - `MyDBLibrary`: ADO.NET SQL Server connection and query optimization layer.
    - `DevNet.PhonePe`: UPI dynamic QR generation with webhook confirmation.
    - `DevNet.WhatsApp.V2` & `DevNetWP`: Direct WhatsApp invoice delivery.
    - `DevNetFB`: Firebase Realtime Database catalog sync.
    - `DevNetSR`: Google Cloud Speech-to-Text for cashier voice commands.
    - `DevNet.GS`: Real-time GSTIN validation and address verification.
    - `DevNet.Translitration`: Bilingual English and Hindi bill printing.
    - `DevNet.QImage`: Automatic web product photo enrichment.

### 3.2. `apps/pos-ai-companion` - Till AI Side-Panel
- **Purpose**: A floating desktop overlay docking beside the till screen to assist the cashier or store owner.
- **Tech Stack**: .NET 8.0, C#, WPF, Microsoft Edge WebView2.
- **Features**:
  - Answers stock, pricing, and sales questions in English or Hindi.
  - Interfaces with local AI engines (`codex`, `claude`, `antigravity`) or REST APIs.
  - Strict read-only database access to guarantee transactional safety.

### 3.3. `apps/pos-dashboard-service` - Modern POS Dashboard & Vision
- **Purpose**: Modern web interface for store analytics, product photography enhancement, and remote owner monitoring.
- **Tech Stack**: ASP.NET Core (.NET 8.0), C#, SQLite, Supabase.
- **Features**:
  - Sales forecasting, slow/fast-moving stock analysis, reorder alerts.
  - **AI Photo Studio**: Transforms standard smartphone photos into 5 studio-quality product photos for Amazon and web.
  - **A4 Poster Studio**: Creates promotional sale posters with strict pricing guardrails (offers never dip below cost).
  - **Owner Remote App (`owner-app/`)**: Pushes sanitized high-level turnover metrics to Supabase for mobile viewing from anywhere.

### 3.4. `apps/storefront-web-mobile` - Omnichannel Digital Storefront
- **Purpose**: Customer-facing web app, native mobile apps, and cross-platform desktop application.
- **Tech Stack**: Next.js 15, React 19, TypeScript, Tailwind CSS, Prisma ORM, Capacitor 8, Electron 42.
- **Features**:
  - **Multi-Provider AI Routing**:
    - **Groq**: High-speed customer chat, deals, and quick summaries.
    - **Lightning AI (DeepSeek-V4 Pro)**: Deep reasoning, styling advice, gift recommendations, and semantic filters.
    - **Vision (Gemma 4 31B & Nemotron 30B)**: Multi-modal camera search.
  - Multi-platform: Web (PWA), Android (Capacitor), iOS, and Windows/Mac Desktop (Electron).

---

## 4. Quick Start & Launching

### Interactive Master Menu
Launch the interactive command center from the root:
```cmd
scripts\start-suite-menu.bat
```
This menu lets you launch any of the four applications, run builds, or verify AI keys with a single keystroke.

### Starting Individual Applications

#### 1. Smart Avenue Web Storefront (Next.js)
```cmd
# Using root npm script
npm run dev:storefront

# Or using the direct batch launcher
scripts\start-storefront.bat
```
Visit [http://localhost:3000](http://localhost:3000) in your browser.

#### 2. Smart Avenue Desktop Shopping Client (Electron)
```cmd
# Using root npm script
npm run desktop:storefront

# Or using the direct batch launcher
scripts\start-storefront-desktop.bat
```

#### 3. Core Desktop POS (WinForms & SQL Server)
```cmd
scripts\start-pos-desktop.bat
```

#### 4. Smart Retail AI Companion (WPF .NET 8)
```cmd
scripts\start-pos-ai.bat
```

#### 5. POS Modern Web Dashboard (.NET 8)
```cmd
scripts\start-pos-dashboard.bat
```

---

## 5. Building the Suite

### Master Build Script
Run the automated PowerShell build script:
```powershell
powershell -ExecutionPolicy Bypass -File scripts\build-all.ps1
```
You can also target specific subsystems:
```powershell
# Build only the storefront
powershell -ExecutionPolicy Bypass -File scripts\build-all.ps1 -Storefront

# Build only the .NET 8 services
powershell -ExecutionPolicy Bypass -File scripts\build-all.ps1 -DashboardService -AiCompanion
```

### Visual Studio 2022
Open `SmartRetailSuite.sln` directly in Visual Studio 2022. All 21 projects across Desktop POS, AI Companion, and POS Dashboard Services are organized into distinct Solution Folders.

---

## 6. Environment & AI Key Configuration

Copy the example environment files where applicable:
```bash
# In apps/storefront-web-mobile
cd apps/storefront-web-mobile
cp .env.example .env.local
```
Add your `GROQ_API_KEY` and `LIGHTNING_API_KEY` values, then verify your keys:
```bash
npm run verify:ai
```

---

## 7. Licence

Smart Retail OS is **proprietary software** of NextGen OS. All rights reserved. It is not open source.

- [`LICENSE`](LICENSE): the terms that apply to this source code. Access to it grants no right to use, copy, share, sell, host or rebrand it.
- [`EULA.txt`](EULA.txt): the agreement under which a customer uses the program. It forbids resale, sublicensing, rebranding, reverse engineering and tampering with licence checks. Selling or white-labelling the software needs a separate written reseller agreement with NextGen OS.
- [`THIRD-PARTY-NOTICES.md`](THIRD-PARTY-NOTICES.md) and [`licenses/`](licenses): third-party components keep their own licences.
- [`docs/COMMERCIALIZATION_READINESS.md`](docs/COMMERCIALIZATION_READINESS.md): what has to be done before the suite is sold as a white-label platform in other countries.

Keep this repository private.
