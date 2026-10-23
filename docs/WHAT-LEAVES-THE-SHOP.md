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

## Ask the shop (free text, judged by the kind of information, not by a fixed reason)

*Ask the shop* (`docs/V2-ARCHITECTURE-ASSESSMENT.md`, section 11) is the one feature that sends **free text** to an AI service through the plain door (`AiGateway.GenerateAsync` with a context), not through a fixed reason from the list above, because the question is whatever the person types. So the guard above does not apply to it; these rules do, and they are the same as for every other AI work:

- It is off until the owner switches on **Business assistant**, and the licence must have the AI part.
- Two requests are made for a question. The first, *which lookups?*, carries the lookups the person's role allows and **the question** (counted as confidential business information; a telephone number or an e-mail address in it makes it personal data). The second, *the answer*, carries the program's rules, **the facts the lookups found** (numbered, one line each: for example the day's takings, the best sellers, the items out of stock, the pieces of notes the person may read) and the question, and is counted as the strictest kind of information among the facts (money is financial; a running-low warning, which names the supplier, is confidential; a note is whatever the owner marked it).
- A service **on this computer** may receive all of it. A service on the shop's network or online receives it **only if the owner allowed that service that kind of information** (and, online, switched on *Use online AI services*); the program can limit a permission to named features (this one is called `assistant`), but the AI helpers screen today allows a kind for every feature of that service. When no service may, nothing is sent and the screen shows the facts as they are.
- Card and payment details and biometric data never leave this computer; a question with a card number in it is refused before anything is done.
- It is written down in *What was used* (the use record: when, feature `assistant`, service and model, kind of information, tokens, cost, how it ended), **never the text**. It is **not** in the *What was sent* list, which belongs to the fixed reasons. The question record of the feature keeps the question (not the answer, not the figures) for 90 days, and does not keep a question that holds a telephone number or an e-mail address.

## Cameras (the register only)

The camera register (`docs/V2-ARCHITECTURE-ASSESSMENT.md`, section 12) sends **nothing** to any AI service or anywhere else. A camera must be on this computer or on the shop's own network (an internet address is refused, and so is a name that turns out to lead outside); the program only connects to a camera and lets go, and reads no picture or video; a camera's password is kept in the computer's safe place and is never written to the database, the activity list or a screen. Later steps that read pictures will keep video on this computer (`VIDEO` information never leaves the shop; `docs/VERSION-2.md`) and will be listed here before they exist.

## What the guard cannot know (said plainly)

A short name field cannot tell a product from a remark typed as one. That is why no reason has a field for a remark, a note or a message, and why a screen must fill a name field from the catalogue. The guard does catch names and addresses the shop keeps (customers, suppliers, staff), first names and surnames on their own, a street line on its own, contact details, card numbers (also written in groups with other digits beside them), links, and text that reads like an instruction. It is a safety net, not a replacement for choosing the fields well.

## Not built yet

A durable queue for AI jobs that must survive a restart (nothing needs one yet; the queue in front of the gateway is in memory and says so); a retention period for this log; a review of a reason by the owner before it is first used; the same list for the Setup Studio's design assistant (it sends only public brand material by its own rules, `docs/PLATFORM-DECISIONS.md`).
