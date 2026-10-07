# Licence Studio staff API, version 1

For NextGenOS staff tools only (the main Setup Studio). It is **not** for the programs a customer runs: those use `/api/v1/` (`LICENCE-FORMAT.md` section 8). The Licence Studio stays a private program on the owner's own server; this API lets the main Studio show a client's licence and press a few buttons, without ever holding or seeing a signing key. Decision 19 in `docs/PLATFORM-DECISIONS.md` is the reason it exists.

## Signing in

Every call carries `Authorization: Bearer <token>`.

- A token is made by an **administrator** in the Licence Studio, page **Service accounts**: a name (for example "Main Studio"), and a **role**. The token is shown **once**; the Studio keeps only a hash of it and cannot show it again. A token can be switched off at any time on the same page, and works no more from that moment.
- The role is one of the Studio's own roles, so a token can do only what a person with that role can do:

| Call | Needs | Roles that have it |
|---|---|---|
| list a client's licences | `licences.view` | Administrator, Sales, Support |
| make a licence | `licences.create` | Administrator, Sales |
| extend, convert a trial | `licences.change` | Administrator, Sales |
| free a PC | `devices.free` | Administrator, Sales, Support |
| revoke, restore | `licences.hold` | Administrator only |

  A Sales token also keeps the limits a salesperson has in the Studio: no more PCs, shops or people than the plan allows without an administrator, no changing what a plan includes, no "not tied to a PC or a website" licence, and no full re-brand.
- `X-Acting-User: <name>` is the name of the staff member in the main Studio who pressed the button. It is required on every call that changes something, and recommended on the others. It is written to the Studio's history ("History" page) with the token's name, the call and the address it came from. Names with letters outside plain ASCII must be URL-encoded (`encodeURIComponent`); the Studio decodes them.
- The Studio answers over HTTPS only (or on its own PC): a token must never travel in clear text.
- **Rate limits:** 120 calls a minute for each token, and 10 wrong tokens in 10 minutes for each address. Past a limit the answer is `429`.

## Answers and errors

JSON, UTF-8, `Cache-Control: no-store`. Times are Unix seconds (UTC), like the licence itself. An error is

```json
{ "error": "<code>", "message": "<what happened, in plain words>" }
```

| HTTP | `error` | When |
|---|---|---|
| 400 | `bad_request` | something in the call is missing or not right (the message says what) |
| 400 | `acting_user_required` | `X-Acting-User` is missing on a call that changes something |
| 400 | `idempotency_key_required` | `Idempotency-Key` is missing when making a licence |
| 401 | `unauthorized` | no token, a wrong token, or a token that was switched off |
| 403 | `forbidden` | the token's role may not do this |
| 404 | `not_found` | no such licence or PC |
| 409 | `conflict` | the licence is in a state where this cannot be done (for example extending a licence with no end date, converting a licence that is not a trial, restoring a licence that was withdrawn for good) |
| 413 | `too_large` | the call is bigger than 64 KB |
| 422 | `idempotency_conflict` | the same `Idempotency-Key` was used before with a different body |
| 429 | `rate_limited` | too many calls |
| 500 | `server_error` | something went wrong in the Studio |

## The calls

### `GET /api/staff/v1/customers/{externalCustomerId}/licences`

The licences of one client. `externalCustomerId` is the id the main Studio gave the client (its project id); the Studio stores it on its customer record when the first licence is made. A client with no licence yet answers `200` with `{"licences": []}`.

```json
{ "licences": [ {
  "lid": "L-7K3M9Q2X",
  "keyMasked": "NGOS-*****-*****-*****-AB12C",
  "plan": "business",
  "modules": ["pos", "hub", "ai", "dashboard", "owner-live"],
  "limits": { "devices": 3, "stores": 1, "users": 10 },
  "exp": null,
  "onEnd": "banner",
  "trial": false,
  "trialDaysLeft": null,
  "status": "active",
  "devices": [ { "id": 12, "label": "COUNTER-1", "activatedAt": 1790000000, "lastCheckIn": 1799000000, "version": "2.18.0" } ],
  "moves": { "used": 1, "allowed": 2, "windowDays": 365 }
} ] }
```

- `keyMasked`: only the last group of the key is shown. The full key is returned only when a licence is made.
- `exp`: the end date, or `null` for no end date. `onEnd`: `"banner"` (keeps working after `exp`, with a banner) or `"stop"`.
- `trial`: true for a trial. `trialDaysLeft`: whole days left (rounded up) for a trial, `0` once it has ended, `null` for a licence that is not a trial.
- `status` is one of: `active` (works; a trial that is still running is `active` with `trial: true`), `ended` (past `exp`, `onEnd` is `banner`: still works with a banner), `stopped` (past `exp`, `onEnd` is `stop`: does not work), `not_started`, `revoked` (switched off by staff; `restore` brings it back), `withdrawn` (withdrawn for good from the Studio's own pages; cannot be restored).
- `devices`: the PCs that use a seat now. `id` is what the free call needs. `label` is the PC's name. `activatedAt` is when this PC first took a seat; `lastCheckIn` the last time it reported in.
- `moves`: how many times the **customer** moved this licence to a new PC in the last 365 days (`used`), out of `allowed` (2). Staff freeing a PC is not counted here.

### `POST /api/staff/v1/licences`

Makes a licence. Header `Idempotency-Key: <unique text, 8 to 128 letters, digits, `.` `_` `:` `-`>` is **required**: the same key with the same body returns the licence that was already made (never a second one); the same key with a different body is `422`. Keys are kept for good and belong to one token.

```json
{ "externalCustomerId": "proj_8f3a", "customerName": "Green Mart", "country": "IN",
  "plan": "business", "modules": ["pos"], "limits": { "devices": 3 },
  "exp": null, "onEnd": "banner", "trialDays": 14, "brandId": 4, "white": "theme",
  "bindMode": "device", "domains": ["shop.example.com"] }
```

| Field | Meaning |
|---|---|
| `externalCustomerId` | **required.** The client's id in the main Studio (1 to 80 letters, digits, `.` `_` `:` `-`). The customer record is found by it; made if it is new. |
| `customerName` | **required.** The business name. Updated on the customer record when it differs. |
| `country` | optional text. |
| `plan` | **required.** A plan code from the Studio's Plans page (`hub`, `starter`, `business`, `growth`, `chain`, or one staff added). |
| `modules` | optional. Only an administrator token may change what the plan includes. Sales may send the plan's own list. |
| `limits` | optional `{devices, stores, users}`; what is missing comes from the plan. Beyond the plan's limit needs an administrator token (`403`). |
| `exp` | optional. A Unix time, a date `YYYY-MM-DD` (the end of that day, UTC), or `null` for no end date. **Left out: a paid licence has no end date** and a trial ends `trialDays` after today. Not allowed together with `trialDays`. |
| `trialDays` | optional whole number from 1 to 365. Makes a **trial** of that length. Left out, the licence is paid. |
| `onEnd` | optional `"banner"` or `"stop"`. Default: `"banner"` for a paid licence, `"stop"` for a trial. A trial is always `"stop"`: asking for `"banner"` is `400`. |
| `brandId` | optional. The id of a brand on the Licence Studio's Brands page. |
| `white` | optional: `"none"`, `"theme"` (default) or `"full"` (administrator only), or `{"level": "..."}`. |
| `bindMode`, `domains` | optional, for a licence that is not for Windows PCs: `"domain"` with the website address(es) the licence is for (a website licence), default `"device"`. `"none"` is administrator only. |

Answer, `201` when made and `200` when it is an answer to a repeated `Idempotency-Key`: `{ "lid": "L-7K3M9Q2X", "key": "NGOS-ABCDE-12345-FGHJK-67890" }`.

An online licence is written with check-in every 30 days and 60 days of warnings (`LICENCE-FORMAT.md` 13.2).

### `POST /api/staff/v1/licences/{lid}/devices/{deviceId}/free`

Body `{ "reason": "The old computer broke" }` (required, up to 200 letters). Frees the PC's seat so the client can activate another PC. Not limited (the 2-a-year limit is only for the customer's own button) and not counted in `moves`; written to the licence's history with the staff member's name and the reason. Answer `{ "ok": true, "licence": { ... } }` where `licence` is the same shape as in the list. A PC that is already free answers `200` too and changes nothing.

### `POST /api/staff/v1/licences/{lid}/extend`

Body `{ "days": 14 }` (a whole number, 1 to 3650). Adds the days to the end date, or to today when the licence has already ended (an ended trial runs again from today). `409 conflict` for a licence with no end date, or one withdrawn for good. Answer `{ "ok": true, "licence": { ... } }`. PCs learn it at their next check-in.

### `POST /api/staff/v1/licences/{lid}/convert`

Turns a trial into a paid licence: no end date, `onEnd: "banner"`. No body needed. `409 conflict` when the licence is not a trial. Answer `{ "ok": true, "licence": { ... } }`.

### `POST /api/staff/v1/licences/{lid}/revoke` and `.../restore`

`revoke` takes `{ "reason": "Payment overdue" }` (required) and **switches the licence off**: the PCs stop at their next check-in (about a month at most). It is the Studio's reversible "put on hold", so `restore` (no body) switches it on again; `status` is `revoked` in between. A licence withdrawn for good from the Studio's own pages (status `withdrawn`) cannot be restored (`409 conflict`) and cannot be revoked again. Only an administrator token may call these two. Answer `{ "ok": true, "licence": { ... } }`.

## What the Studio keeps

Every call, including the ones that were refused, is written to the History page: when, which token, which staff member (`X-Acting-User`), what, which licence, and the address it came from. Licence changes made through this API also appear in that licence's own history.
