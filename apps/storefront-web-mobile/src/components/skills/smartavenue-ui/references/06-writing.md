# Writing for Smart Avenue

## Contents

1. Voice and retail truth
2. Buttons and headings
3. Errors, empty states, and loading
4. INR, dates, labels, and metadata
5. Genie/AI and multilingual copy

The interface should sound plain, direct, useful, and trustworthy. Read every string aloud. If it
sounds like marketing, legal boilerplate, or a robot, rewrite it.

## 1. Voice

| Do | Avoid |
|---|---|
| “Browse products” | “Shop now” when checkout does not exist |
| “Purchase in store” | “Order now”, “Get delivery”, or “Buy online” |
| “12 products found” | “12 premium lifestyle solutions discovered” |
| “No products match these filters” | “No data available” |
| “Couldn’t load products. Check your connection and try again.” | “Something went wrong” |
| “Offer valid until 17 August” | “Hurry! Deal ending soon!” without evidence |

- Use sentence case except proper nouns and deliberate short eyebrow labels.
- Use active voice and contractions.
- Prefer “you” and the object/action over internal system language.
- Use familiar store terms: product, price, offer, department, available, out of stock, barcode,
  request, store, and visit.
- Avoid “entity”, “payload”, “inventory intelligence”, “seamless”, “leverage”, and other jargon.
- Use numerals for prices, counts, dates, and quantities.
- Treat “Smart Avenue 99” as the brand name and “Genie” as the AI-assistance family.

## 2. Retail truth

Smart Avenue's website supports discovery, not online fulfilment.

- At purchase decision points say “Purchase in store”, “Visit the store”, “Check availability”, or
  “Contact the store”.
- A product request is not an order, reservation, or stock guarantee. State what staff will do next.
- WhatsApp/contact actions begin a conversation; they do not place an order.
- Availability may change. If the data is not real time, show when it was last updated or say that
  the shopper should confirm with the store.
- Do not promise delivery, shipping time, online payment, returns, or reservation unless the
  product actually supports that behavior.

## 3. Buttons

A button label names its outcome with a short verb phrase.

| Good | Weak or misleading |
|---|---|
| Browse products | Shop now |
| View offer | Learn more |
| Clear filters | Reset |
| Request this product | Submit |
| Send request | Continue |
| Check availability | Buy now |
| Try gift finder | Get started |
| Delete “USB fan” | Delete item |

- Keep most labels to 1–4 words.
- Include the object when it removes ambiguity.
- “Cancel” is acceptable for cancelling a local action.
- A destructive label names the exact item.

## 4. Titles and headings

- Screen titles are concrete nouns: “Products”, “Weekly offers”, “Departments”, “Request a
  product”, “Gift finder”.
- Section titles describe their content: “Available products”, “Current offers”, “Popular
  departments”, “Request details”.
- Subtitles explain purpose or constraints in one short line.
- Avoid generic headlines such as “Experience the future of shopping”.
- Do not add colons or trailing punctuation to headings.

## 5. Errors

Use this order: **what happened → useful reason → next action**.

```
Couldn't send your product request.
Your connection dropped before it reached the store.
Try again
```

- Name the failed action.
- Do not blame the shopper.
- Do not expose stack traces or internal identifiers without a human explanation.
- Preserve entered form data.
- Distinguish offline failure from a store/server failure.
- Always provide the next useful action.

## 6. Empty states

| State | Title | Body | Action |
|---|---|---|---|
| Catalogue empty | “No products listed yet” | “The store catalogue is being updated.” | Contact store |
| No filtered results | “No products match” | “Try removing a filter or searching another term.” | Clear filters |
| No current offers | “No current offers” | “Browse the catalogue while the next offers are prepared.” | Browse products |
| Request history empty | “No product requests yet” | “Requests from shoppers will appear here.” | — |
| Failure | “Couldn’t load products” | “Check your connection and try again.” | Retry |

Never use a bare “No data”. Do not joke when someone is trying to complete a task.

## 7. Loading and progress

- Name the work: “Loading products…”, “Finding gifts…”, “Checking the catalogue…”.
- After roughly 3 seconds, add a specific status such as “Still checking available products…”.
- Do not show a percentage unless it is calculated honestly.
- Genie language must not claim certainty before catalogue results return.

## 8. Numbers, INR, and dates

- Use `Intl.NumberFormat('en-IN', { style: 'currency', currency: 'INR' })` for prices.
- Use full Indian grouping for product prices and requests: `₹1,90,000`.
- Use lakh/crore abbreviations only in compact summaries and never mix formats in one component.
- Use “17 August 2026” for absolute dates. Offers need an unambiguous start/end or validity date.
- Use relative time only for recent operational metadata, switching to absolute after seven days.
- Use tabular numerals in aligned columns and updating values.
- Use percentages only at meaningful precision.

## 9. Labels and metadata

- Use short visible labels: “Product name”, “Budget”, “Department”, “Phone number”, “Notes”.
- Mark optional fields as optional when most fields are required.
- Keep timestamps and barcodes secondary but readable.
- Truncate descriptions before product names, barcodes, prices, or offer validity.
- Alt text describes useful product/store information; decorative images use empty alt text.

## 10. Genie and AI copy

- Label the experience as Genie/AI-assisted without overexplaining the technology.
- Ground every recommendation in an actual catalogue product when available.
- State the reason in plain language: “Fits your ₹1,000 budget and the recipient's interest in
  stationery.”
- Use uncertainty honestly: “may suit”, “likely”, “based on your answers”.
- Never invent stock, price, review evidence, delivery, or guarantees.
- Let shoppers edit their answers and review products before contacting or visiting the store.
- Say “Genie found 7 matching products”, not “I found the perfect gifts”.

## 11. Multilingual content

- Keep copy short and translation-ready.
- Wrap non-English strings with the correct `lang` attribute.
- Design for at least 40% longer translated labels.
- Never bake important text into imagery.
- Do not machine-translate prices, barcodes, product identifiers, or legal terms.
