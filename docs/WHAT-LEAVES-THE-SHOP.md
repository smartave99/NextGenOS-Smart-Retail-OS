# What can leave the shop for an AI service, and how that is controlled

Blueprint ticket AI-014. Code: `apps/business-hub/src/NextGenOS.Hub.Core/Ai/Egress.cs` and the gateway in `Ai/Gateway.cs`. The shop works in full without any AI service; everything here is off until the owner switches it on, and the default is local first (`docs/VERSION-2.md`, `CLAUDE.md` section 15).

## The rule in one paragraph

A feature cannot send "some text" to an AI service. It names one of a **short fixed list of reasons** (an *egress purpose*) and gives the values for that reason's **fields**. The program builds the text itself from the reason's fixed instruction and the allowed fields only. Anything else that was supplied is left out and its *name* is written down. A value that is not the shape its field allows, or that is a card number, an e-mail address, a telephone number, a link, an instruction to the service, or a name or address the shop keeps for a person, stops the **whole request** before anything is sent. The service chosen must still be allowed by the existing routing rules (card and biometric data never leave the computer; an online service needs the owner's switch and permission for that kind of data and that feature).

## What is written down (Settings, AI helpers, *What was sent*)

For every request made through a reason, also the refused ones: when; the reason and feature; the service and where it runs; the kind of data; **the date of the owner's permission it relied on** (so a later change of permission is a different version); **which fields were sent** (name, kind of data, length) and **which supplied fields were left out**; what it cost; how it ended. **Never** a value that was sent, never the reply, never a name, address or number of a person. A request that was refused or stopped by a limit is recorded as having sent nothing; one that reached a service that then failed is recorded as sent.

## The reasons that exist today

| Reason | Feature / switch | Fields (kind of data) |
|---|---|---|
| `low_stock_explain` — explain a running-low warning in one sentence | insights / Stock forecasts | item name, unit, on hand, sold, days looked at, delivery days, spare days (internal figures) |
| `product_description` — a short description for the shop's website | storefront / Business assistant | product name, category, tone (public) |

No screen calls either yet. They are the first two entries of the list and what the tests (`EgressTests`) use; a feature that wants to send something new adds a reason here, with its own tests, and fills the fields from the shop's records, never from what a person typed as a note.

## What the guard cannot know (said plainly)

A short name field cannot tell a product from a remark typed as one. That is why no reason has a field for a remark, a note or a message, and why a screen must fill a name field from the catalogue. The guard does catch names and addresses the shop keeps (customers, suppliers, staff), first names and surnames on their own, a street line on its own, contact details, card numbers (also written in groups with other digits beside them), links, and text that reads like an instruction. It is a safety net, not a replacement for choosing the fields well.

## Not built yet

A durable queue for AI jobs that must survive a restart (nothing needs one yet; the queue in front of the gateway is in memory and says so); a retention period for this log; a review of a reason by the owner before it is first used; the same list for the Setup Studio's design assistant (it sends only public brand material by its own rules, `docs/PLATFORM-DECISIONS.md`).
