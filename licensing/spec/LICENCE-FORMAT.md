# NextGenOS licence format and activation protocol (version 1)

This is the contract between the **Licence Studio** (the server that issues and signs licences) and every **client** (the POS, the AI add-on, the dashboard, the storefront). The Studio, the .NET library (`clients/dotnet`) and the Node library (`clients/node`) all follow it, and `testvectors/` holds signed examples that every client's tests must accept or refuse exactly as listed.

## 1. Principles

- A licence is a **signed statement**. Clients hold only the **public** key, so nobody can make a licence by reading the client.
- The signature uses **ECDSA with the P-256 curve and SHA-256**, in the fixed-length `r||s` form (64 bytes). It is available in .NET Framework 4.8, .NET 8 and Node without extra packages.
- Anything a client trusts must be inside a signed token. Unsigned envelopes (request and response codes) only carry signed tokens.
- A copy of the files on another PC must not work: a licence for a PC is **activated** for it, and the activation is bound to the PC's fingerprint.
- Work must not stop because the internet is down: a PC that cannot reach the Studio keeps working during a **grace period**, then asks for a check-in.

## 2. Encodings

- `b64u(x)` = base64url without padding (RFC 4648 section 5).
- Times are Unix seconds (UTC) as integers. `null` means "never".
- JSON is UTF-8. Unknown claims are ignored by clients, so the format can grow.

## 3. Token envelope

```
NGOS1.<b64u(payload JSON)>.<b64u(signature)>
```

`signature = ECDSA-P256-SHA256(private key, ASCII bytes of "NGOS1.<b64u(payload JSON)>")`

A client accepts a token only if all of this holds, in this order:

1. It has three parts separated by `.`, the first is `NGOS1`, and the other two decode.
2. The payload is a JSON object with `iss = "nextgenos"` and a `kid` that names one of the **public keys built into the client**.
3. The signature verifies with that public key.
4. `typ` is the type the caller asked for, and `v` is 1.

A **public key** is written as `b64u` of the 65-byte uncompressed point (`0x04 || X || Y`). Clients embed a list of `{kid, key}`; adding a new `kid` to the list is how keys are rotated.

## 4. Token types

### 4.1 `lic`, the licence (what the customer bought)

| Claim | Meaning |
|---|---|
| `typ` `v` `iss` `kid` | `"lic"`, `1`, `"nextgenos"`, the signing key id |
| `lid` | Licence id, e.g. `L-7K3M9Q2X` |
| `rev` | Revision, increased each time the Studio re-issues the licence |
| `iat` `nbf` `exp` | Issued at, valid from, valid until (`exp` may be `null`: perpetual) |
| `cust` | `{id, name, country, email}` |
| `product` | `"smart-retail-os"` |
| `edition` | Plan name, e.g. `"business"` |
| `modules` | List of enabled modules (see 6) |
| `limits` | `{devices, stores, users}` (integers, `0` = not limited) |
| `bind` | `{mode: "device" \| "domain" \| "none", domains: [..]}` |
| `brand` | The brand profile (see 5) or `null` for NextGenOS's own |
| `reseller` | `{id, name}` or `null` |
| `act` | `{online: bool, checkInDays, graceDays, offlineDays}` |
| `trial` | `true` for an evaluation licence |
| `white` | `{level}`: how much of the look the customer may change on their own PC (see 5.1) |

### 4.2 `act`, the activation certificate (this licence on this PC)

| Claim | Meaning |
|---|---|
| `typ` `v` `iss` `kid` | `"act"`, `1`, ... |
| `lid` `rev` | The licence it belongs to |
| `iat` | When the Studio issued it |
| `fp` | The PC's fingerprint parts (see 7): a sorted list of `kind:hash` strings |
| `fpMin` | How many of `fp` must still match this PC (the Studio sets it to 60% of the parts, rounded up) |
| `next` | When the next check-in is due |
| `until` | When the activation stops working if no check-in happened |

### 4.3 `crl`, the revocation list

`{typ:"crl", v:1, iss, kid, iat, next, revoked:[lid, ...]}`. Contains revoked and suspended licence ids. A cached list is used whether or not it is fresh; it only ever makes things stricter.

## 5. Brand profile

Carried inside `lic.brand` (so a partner can use only branding NextGenOS approved):

```
{ id, name, shortName, legalName, primaryColor, accentColor,
  supportEmail, supportPhone, supportUrl, websiteUrl, copyright,
  logo,            // data URI (PNG/SVG/JPEG), at most about 100 KB, or null
  poweredBy }      // true: show "Powered by NextGenOS"
```

Apps read the brand from the licence at start. With no licence, or `brand = null`, they show NextGenOS's own names.

### 5.1 White-label level

`white.level` says what the customer (or reseller) may change **locally**, with the Brand Studio, without asking NextGenOS:

| Level | May change on their own |
|---|---|
| `none` | Nothing. The apps show the licence's brand (or NextGenOS's). |
| `theme` | Shop name, logo, colours, fonts, light/dark, receipt and label headers and footers, poster styles, home-page texts. The product name and "Powered by" line stay. |
| `full` | Everything above, plus the product name, installer names and "Powered by" (a reseller licence). |

The licence brand is the starting point; the local brand kit is applied on top of it only as far as the level allows. The apps enforce this when they read the kit.

#### 5.2 How a local brand is applied (the rule every client implements)

The **local brand** is a small set of values a person chose on their own PC (the Hub's "Look" page, or a brand kit made with the Brand Studio):
`name`, `shortName`, `primaryColor`, `accentColor`, `logo`, `supportEmail`, `supportPhone`, `poweredBy`. The **effective brand** is made from the
licence's brand (or NextGenOS's own when there is none) and the local brand, field by field:

| Field | `none` | `theme` | `full` |
|---|---|---|---|
| `primaryColor`, `accentColor`, `logo`, `supportEmail`, `supportPhone` | licence | local, if valid | local, if valid |
| `name`, `shortName`, `poweredBy` | licence | licence | local, if valid |
| everything else (`id`, `legalName`, `supportUrl`, `websiteUrl`, `copyright`) | licence | licence | licence |

Rules, all of which the shared vectors in `testvectors/brand-policy.json` check in every implementation:

- A level that is missing or not exactly `none`, `theme` or `full` counts as `none`.
- A local value that is missing, empty or **invalid is ignored** (the licence value stays). It is never an error: a bad file must not stop the shop.
- Colours are `#rrggbb`. A colour whose contrast with white is below 3:1 is invalid (white text is written on it).
- `logo` is a data URI `data:image/png|jpeg|svg+xml;base64,...` of at most 140,000 characters; nothing else (no web address, no HTML).
- `name` and `shortName` have control characters removed, are trimmed, and are cut to 60 characters; `supportEmail` to 120, `supportPhone` to 40.
- `poweredBy` is a true/false value; any other value is ignored.
- Apps that cannot show a field (a printed receipt has no colour) ignore it. Fonts and a light/dark default are allowed at `theme` and `full` and are applied
  by the programs that support them; the Hub does not apply them yet.

#### 5.3 Theme: how a program looks and is laid out

Besides the brand (name, colours, logo), a program can be set up to look and be laid out in different ways, for a brand's own identity and for the device it runs on (a laptop, or a touch-screen counter). The **theme** is a small set of named choices, never free text and never code:

| Token | Values | Default | Kind |
|---|---|---|---|
| `density` | `compact`, `comfortable`, `touch` | `comfortable` | device |
| `fontScale` | a number from 0.85 to 1.35, rounded to the nearest 0.05 (half up) | `1` | device |
| `nav` | `left`, `top`, `bottom` | `left` | device |
| `navLabels` | `full`, `icons` | `full` | device |
| `cart` | `right`, `left`, `bottom` | `right` | device |
| `mode` | `auto`, `light`, `dark` | `auto` | identity |
| `surface` | `neutral`, `warm`, `cool`, `paper` | `neutral` | identity |
| `shape` | `square`, `soft`, `rounded`, `pill` | `rounded` | identity |
| `font` | `system`, `humanist`, `serif`, `rounded`, `mono` (system fonts only; nothing is downloaded) | `system` | identity |
| `depth` | `flat`, `soft`, `lifted` | `soft` | identity |

Two places can set a theme: the **profile** that NextGenOS ships with a customer's setup, and the **local** choice the owner makes on their own PC. Field by field, a local value wins over a profile value, which wins over the default. The licence's white-label level decides what counts:

| Level | Device tokens | Identity tokens |
|---|---|---|
| `none` | applied | ignored (the default look stays) |
| `theme`, `full` | applied | applied |

Device tokens are about the screen and the person at it (size of buttons, where the menu is), not about identity, so they work at every level. Rules, checked by `testvectors/theme-policy.json` in every implementation:

- A level that is missing or not exactly `none`, `theme` or `full` counts as `none`.
- A value that is missing, of the wrong kind, not in the list, or out of range is **ignored** (the next source, then the default, is used). It is never an error.
- The "by NextGenOS" line and the licence's brand name always stay visible whatever the theme is (a menu that shows icons only still shows them).

## 6. Modules

`pos`, `hub`, `ai`, `dashboard`, `storefront`, `owner-live`, `chain`, `api`. A client enables a feature only if its module is listed. The POS needs `pos`; the Business Hub (every industry, every country) `hub`; the AI add-on `ai`; the dashboard `dashboard`; the storefront `storefront`.

## 7. Device fingerprint

A PC reports a set of **parts**, each a salted hash of one hardware or system value:

```
part = hex(SHA-256(UTF8("ngos-fp-v1:" + kind + ":" + value)))  first 32 hex characters
kinds: bios, board, cpu, disk, os
```

On Windows the values come from WMI (`Win32_BIOS.SerialNumber`, `Win32_BaseBoard.SerialNumber`, `Win32_Processor.ProcessorId`, the first physical disk's serial number) and the registry `MachineGuid`; on Linux from `/etc/machine-id`. Empty or placeholder values (such as `To be filled by O.E.M.`) are skipped.

The activation stores the parts as a sorted list of `kind:hash` strings. A PC **matches** when both hold:

1. at least `fpMin` of the stored parts are among its current parts (the Studio sets `fpMin` to 60% of the stored parts, rounded up: 3 of 5, 2 of 3, 1 of 1), and
2. at least `min(2, number of stored strong parts)` of the **strong** parts match. Every kind except `cpu` is strong: identical CPU models report the same `cpu` value, so it can support a match but never carry one.

So replacing a disk, or reinstalling Windows, does not unlock the licence by itself. A **copied disk image on identical PCs** (same CPU model, same Windows machine id, different BIOS, board and disk) is a different PC, and so is a licence file copied to any other machine. Replacing most of a PC's hardware needs a new activation (the supplier frees the old seat). A virtual machine that is cloned with its virtual hardware cannot be told from the original by the PC alone; the seat count, the check-in history and the contract cover that case.

## 8. Online protocol (JSON over HTTPS)

Every response is JSON. Errors: `{"error": {"code", "message"}}` with an HTTP status (400, 403, 404, 409, 429).

| Call | Request | Success response |
|---|---|---|
| `POST /api/v1/activate` | `{key, product, version, fp:{kind:part}, host}` | `{lic, act, crl}` |
| `POST /api/v1/checkin` | `{lid, act, fp, version, usage:{stores, devices, users}}` | `{lic, act, crl}` |
| `POST /api/v1/deactivate` | `{lid, act, fp}` | `{ok:true}` |
| `GET /api/v1/crl` | | `{crl}` |
| `GET /api/v1/health` | | `{ok:true}` |

`key` is the human licence key, `NGOS-XXXXX-XXXXX-XXXXX-XXXXX` (Crockford base 32: no `I L O U`). Error codes: `unknown_key`, `revoked`, `suspended`, `expired`, `not_started`, `limit_reached`, `device_mismatch`, `bad_request`, `rate_limited`.

On `activate` the Studio counts devices: a licence with `limits.devices = 3` can be active on 3 PCs. `deactivate`, or "Free this PC" in the Studio, releases a seat.

## 9. Offline activation

For a PC with no internet:

1. The app shows a **request code**: `NGOSREQ1.` + `b64u({key, product, version, fp, host, ts})`.
2. The sales or support person pastes it into the Studio's **Offline activation** page, which answers with a **response code**: `NGOSRES1.` + `b64u({lic, act})`.
3. The customer pastes the response code into the app (or loads a `.ngosact` file).

Licences with `act.online = false` get an activation whose `next` and `until` are `offlineDays` away (default 365), always capped by `exp`.

## 10. What a client decides

Given a licence token, an optional activation token, an optional CRL and the clock, a client returns one status:

| Status | When | May the app run? |
|---|---|---|
| `Valid` | signatures good, `nbf <= now <= exp`, activation matches and `now <= next` | yes |
| `Grace` | as `Valid` but `next < now <= until` | yes, with a warning that shows the days left |
| `NotActivated` | licence good, no (matching) activation | no, show the activation screen |
| `NeedsCheckIn` | `now > until` | no, ask to connect to the Internet or use offline activation |
| `Expired` | `now > exp` | no |
| `NotYetValid` | `now < nbf` | no |
| `Revoked` | `lid` is in the CRL | no |
| `DeviceMismatch` | fewer than `fpMin` parts match | no |
| `ClockTampered` | the clock is earlier than the last time seen by more than 24 hours | no, until a check-in succeeds |
| `Invalid` | a signature, type or claim is wrong | no |
| `Missing` | no licence at all | no |
| `ModuleNotLicensed` | the licence does not list the module the app needs | no |
| `DomainMismatch` | a domain-bound licence is used on another web site address | no |

The app **fails closed**: any unexpected error is `Invalid`.

For `bind.mode = "domain"` (the storefront) no activation is needed: the licence is valid when the site's host name matches one of `bind.domains` (`example.com` matches itself and `*.example.com` matches any sub-domain). For `bind.mode = "none"` no activation or domain check is made.

## 11. Local storage in the client

The client keeps, in a machine-wide folder (`%ProgramData%\NextGenOS\<product>\` on Windows): `licence.ngos` (the `lic` token), `activation.ngos` (the `act` token), `crl.ngos` and `state.json` (`{lastSeen, lastCheckIn}`, with an HMAC keyed by the PC's fingerprint, to catch a rolled-back clock). The signed tokens cannot be edited; copying them to another PC fails the fingerprint match.

## 12. Key management

- The private key never leaves the Studio. It is stored encrypted (scrypt and AES-256-GCM) and unlocked with a passphrase held in the server's environment.
- Every client embeds the public key list; to rotate, add the new key to a client release first, then switch the Studio to sign with it.
- Never put a private key, a passphrase, a licence database or `studio/data/` in a code repository or a customer package.
