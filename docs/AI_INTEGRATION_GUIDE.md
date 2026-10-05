# Smart Retail Suite - AI Integration & Provider Routing Guide

The **Smart Retail Suite** features specialized AI capabilities across desktop till assistance, automated creative marketing, and customer-facing intelligent shopping.

---

## 1. AI Architecture Overview

```
                      +---------------------------------------+
                      |       Smart Retail Suite AI Tier      |
                      +---------------------------------------+
                                          |
          +-------------------------------+-------------------------------+
          |                               |                               |
          v                               v                               v
[In-Store Billing AI]           [AI Creative Studio]          [Omnichannel AI Storefront]
- Apps: pos-ai-companion        - Apps: pos-dashboard-service - Apps: storefront-web-mobile
- Providers:                    - Providers:                  - Providers:
  * Codex CLI                     * ChatGPT Images              * Groq (Llama 3 / Mixtral)
  * Claude CLI                    * Vision API                  * Lightning AI (DeepSeek-V4)
  * Antigravity CLI               * Canvas Tag Engine           * Gemma 4 31B Vision
  * Direct API Keys               * Strict Pricing Guardrails   * Nemotron 30B Vision
```

---

## 2. Omnichannel Storefront AI Provider Routing (`apps/storefront-web-mobile`)

The digital storefront balances speed, reasoning depth, and cost efficiency using intelligent workload splitting:

### Workload Matrix
1. **Low Latency Workloads (Groq)**:
   - Real-time customer chat assistance.
   - Quick product summaries.
   - Short deal copy and discount notifications.
   - Fast fallback.
2. **Deep Reasoning Workloads (Lightning AI - DeepSeek-V4 Pro)**:
   - Complex customer intent and occasion interpretation.
   - Semantic product search and smart filtering.
   - Personal styling and gift recommendations.
   - Sentiment analysis over customer reviews.
3. **Multi-Modal Visual Search (Lightning AI Vision)**:
   - Primary model: `lightning-ai/gemma-4-31B-it`.
   - Fallback model: `lightning-ai/nvidia-nemotron-3-nano-omni-30b-a3b`.
   - Allows shoppers to photograph clothes or products to find matching inventory.

### API Key Rotation & Verification
To ensure high availability:
- Supports key rotation across multiple backup keys (`GROQ_API_KEY_1` to `_10`, `LIGHTNING_API_KEY_1` to `_10`).
- Automatic failover on HTTP 429 (rate limit) or 402 (payment required).
- Verification tool:
  ```bash
  cd apps/storefront-web-mobile
  npm run verify:ai
  ```
  The script performs a non-destructive 5-token ping test for every configured key without logging secret values.

---

## 3. In-Store POS AI Companion (`apps/pos-ai-companion`)

Designed to be operated directly by store cashiers and store owners on the counter workstation:
- **Languages**: Full bilingual support for **English** and **Hindi**.
- **Execution Modes**:
  - Command-line agent tools: `codex`, `claude`, or `antigravity`.
  - Direct REST API keys for OpenAI / Anthropic / Gemini.
- **Privacy & Safety Rules**:
  - The AI **only reads** from the local database; it never executes `UPDATE`, `INSERT`, or `DELETE` statements on POS tables.
  - POS transactions, credit card information, and customer phone numbers are sanitized before any external prompt generation.

---

## 4. Automated Marketing & Creative Studio (`apps/pos-dashboard-service`)

### Photo Studio
- Takes raw snapshots captured via phone camera and removes backgrounds, adjusts lighting, and generates 5 professional product angles suitable for Amazon, Shopify, or the Smart Avenue web catalog.

### Poster & Creative Studio
- Generates print-ready A4 promotional posters (Clearance, Festival, Seasonal).
- **Strict Pricing Guardrails**:
  - The AI only writes promotional copy and picks products.
  - The AI is **strictly forbidden** from generating or altering prices.
  - Price tags and discounts are calculated strictly from the POS purchase price + GST to guarantee offers never sell below store cost.
