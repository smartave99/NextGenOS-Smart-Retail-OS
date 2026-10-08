# Suggested actions: things the program prepares and a person approves

Blueprint tickets ACT-012 (the typed action registry) and ACT-013 (the draft order as the first action). Code: `apps/business-hub/src/NextGenOS.Hub.Core/Actions/`. Off until the owner switches on **Suggested actions** (Settings, AI helpers) and the licence has the AI part. The shop never needs it to sell.

## What it is, in plain words

The program (or, one day, an assistant) can *ask* for one of a short list of things. The request is checked, described in plain words, and waits. A person who is allowed to do that thing says yes or no. Only after a yes is it done, once, and every step is written down: who, what permission allowed it, and why. Nothing is bought, paid, deleted or sent by asking.

Today the list has one entry: **CreatePurchaseOrder, version 1**, "draft an order to a supplier". Anyone who works with stock (a cashier, a manager, the owner) can ask for it; only a person who may buy (a manager or the owner) can approve it. Approving makes an ordinary *draft order* on the Buying page, which is received and paid for as usual.

## The rules, and how each is kept

| Danger | What stops it | Where it is tested (`ActionTests`) |
|---|---|---|
| A made-up or generic action ("run this query", "call this address") | The list is closed in code; a name or version that is not on it is refused. No handler takes a query, a command or an address. | `The_list_of_requests_is_closed…` |
| Something done without a yes | The only road to the order-making command is the approval step; the status moves only along allowed lines; asking makes nothing. | `Approving_does_the_thing_once…`, `The_status_moves_only_along_the_lines…` |
| The wrong person asks or approves | Permissions are looked up from the shop's roles at every step, so a person who was switched off or changed role is judged as they are now. A kitchen screen cannot ask; a cashier cannot approve. | `Only_people_who_work_with_stock_can_ask…`, `A_person_switched_off_or_given_another_role…` |
| An old yes | A request runs out 48 hours after it was asked for. An approval is also refused if the facts it was given on have moved: the supplier is different, or the cost price of any item has changed by more than a tenth. | `A_request_runs_out_after_forty_eight_hours…`, `An_approval_does_not_survive_a_large_change…` |
| Doing it twice | The step into "being done" is one guarded update: two approvals at the same moment, or a second press, do it once. The same request asked for twice with one key is one request. | `Two_people_approving_at_the_same_moment…`, `Asking_again_with_the_same_key…` |
| An order that repeats one still open | A request for the same goods from the same supplier within three days of an open order is refused. | `An_order_that_repeats_one_still_open…` |
| A bad input | Input is read in the exact form version 1 expects (extra fields are refused); every fault is named in words. | `An_order_that_cannot_be_made_is_refused…` |
| A program that stopped half-way | A request left "being done" for 15 minutes is marked *not done* with a note to check; it is never done again by itself. | `A_request_left_being_done_by_a_program_that_stopped…` |

The whole story, from a cashier's sales to a running-low warning to a manager approving an order and the goods arriving, is one test: `From_a_cashiers_sales_to_a_running_low_warning…`.

## Adding another kind of request

A new request is a new handler in code (`IActionHandler`) with its own typed input, the permissions of who may ask and who may approve, a description in words, a check that the facts have not moved, and the one domain command that does it, added to the list in `HubApp`. It needs its own tests for the rules above. Candidates the blueprint names: adjusting stock (with a second approver above a limit), recording a customer payment, preparing a payment reminder (a draft only), approving a discount.

## Not built yet

An assistant that asks for things (it will use the same `Propose` and can never approve); the other four actions; a second approver above a limit; sending anything outside the shop (the order is a draft, nothing is sent to the supplier); measuring whether an approved order prevented a stock-out.
