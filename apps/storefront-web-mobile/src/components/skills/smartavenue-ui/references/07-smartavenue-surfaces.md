# SmartAvenue surfaces and route map

## Contents

- Storefront and staff route maps
- Shared storefront language
- Screen-specific constraints
- Adding or revising a surface

Use the existing application and the live storefront as the source of truth. This repository does
not contain the copied project's approved PNG set, so never claim a mockup is authoritative when it
does not exist. Inspect the relevant route and its components before changing a surface.

## Storefront map

| Surface | Route | Archetype | Primary job |
|---|---|---|---|
| Home | `/` | Marketing home | Explain the store, highlight products/offers, and lead into discovery |
| Product catalogue | `/products` | Search/filter + product grid | Help a shopper find an available store item quickly |
| Product detail | `/products/[id]` | Media gallery + purchase information | Show enough evidence to decide whether to visit/buy in store |
| Offers | `/offers` | Offer feed + filters | Surface current in-store promotions |
| Offer detail | `/offers/[id]` | Detail with hero | Explain eligibility, dates, and relevant products |
| Departments | `/departments` | Department grid | Let shoppers browse the store by familiar category |
| Request product | `/request-product` | Focused request form | Capture a wanted item when the catalogue does not have it |
| Genie Stylist | `/stylist` | Guided AI flow | Recommend available products from style preferences |
| Genie Gift Finder | `/gift-finder` | Guided AI flow | Recommend available gifts from recipient, occasion, and budget |
| About | `/about` | Editorial/content page | Establish store identity and trust |
| Policies | `/privacy`, `/terms` | Readable content page | Explain obligations without visual noise |
| Site map | `/site-map` | Grouped link list | Provide complete navigation and discovery |

## Staff map

| Surface | Route | Archetype | Primary job |
|---|---|---|---|
| Admin home | `/admin` | Admin workspace | Summarize catalogue/storefront status and common actions |
| Product/content editors | `/admin/content/**` | Dense forms and tables | Maintain accurate products, offers, departments, and copy |
| Appearance/branding | `/admin/appearance`, `/admin/branding` | Settings form | Control the storefront without introducing invalid combinations |
| Product requests | `/admin/requests` | Review queue | Triage and update customer requests |
| Storefront preview/settings | `/admin/storefront`, `/admin/settings` | Settings workspace | Configure visible storefront behavior |
| Media | `/admin/media` | Asset library | Find, upload, and reuse product/store images safely |

Debug and test routes are not customer-facing patterns and must not be used as design precedents.

## Shared storefront language

- **Header:** fixed floating header with logo, primary routes, product request, search/barcode entry,
  and a mobile drawer. Maintain the same information architecture across breakpoints.
- **Retail truth banner:** keep the browse-online, purchase-in-store message prominent enough to
  prevent false expectations without overpowering every page.
- **Dark editorial hero:** used on catalogue, offers, and departments. Keep title hierarchy and
  vertical rhythm consistent across these routes.
- **Catalogue:** filters collapse appropriately on mobile; results count is announced; product
  cards preserve image quality, price clarity, availability, and a truthful next action.
- **Genie:** use a consistent sparkle/Genie marker, clearly state that results come from the Smart
  Avenue catalogue, and provide a non-AI path back to normal browsing.
- **Footer:** contact, store location, navigation, offers, policies, and real social links. Do not
  show placeholder social destinations.

## Screen-specific constraints

### Home

Order content by shopper value: hero proposition and primary discovery action, current
promotions/highlights, useful departments or features, then a final call to browse/visit. Do not
stack multiple equally loud carousels. Autoplay must pause for reduced motion and expose manual
controls.

### Product catalogue

- Preserve search terms and filters in the URL.
- Make selected filters obvious and individually removable.
- On mobile, use an accessible filter sheet/drawer instead of compressing a desktop sidebar.
- Distinguish no products, no filtered results, loading, stale results, and failure.
- An unavailable product may remain discoverable only when availability is unmistakable.

### Product detail

- Lead with the product name, accurate imagery, price, availability, and in-store purchase path.
- Thumbnails, zoom/gallery, variants, barcode, offer information, and WhatsApp/contact actions
  must not compete with the primary next step.
- Never phrase contact or WhatsApp as a completed online order.

### Offers

State the offer title, benefit, valid dates, eligibility/conditions, and in-store redemption path.
Expired offers must not look active. Avoid decorative urgency and perpetual pulsing.

### Product request

Keep the form short. Explain that a request is not a reservation or confirmed order. Preserve
entered details on failure, announce validation errors, and show what happens after submission.

### Genie flows

Ask only for information that improves recommendations. Show budget in INR, make suggested
products traceable to the catalogue, explain uncertainty in plain language, and let the shopper
edit inputs or browse manually. Never invent inventory, prices, delivery, or guarantees.

### Admin

Favor clarity and accuracy over storefront decoration. Use explicit labels, keyboard-accessible
tables/forms, stable column alignment, visible save state, confirmation for destructive actions,
and preview context for storefront-affecting changes.

## Adding or revising a surface

1. Find the closest route above.
2. Reuse its navigation and archetype.
3. Reuse relevant components from `src/components/**`.
4. Preserve store/business truth and accessibility states.
5. If a genuinely new reusable pattern is necessary, document it in
   `references/03-components.md` and implement it only within the repository's allowed scope.
