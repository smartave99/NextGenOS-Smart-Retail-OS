# Trying the Version 2 parts on a real PC

What was built so far is the base of Version 2 (`docs/VERSION-2.md`): the AI helpers screen, the business event history and the business map. It was tested here with test programs, not on a real shop PC. These steps are for the owner and the team to see it work for real, and to tell us what is wrong. **Nothing in the shop's own screens uses any of it yet**, so the shop works exactly as before whatever you do here.

## What you need

- A PC with the Business Hub installed from the release page (`docs/RELEASE-GUIDE.md`), signed in as the **owner**.
- A licence that includes the **AI part**: in the Licence Studio, the plans *Business*, *Growth* and *Chain* have it. Without it, *Settings, AI helpers* says so and nothing can be switched on (try this first, it is a test too).

## 1. The AI helpers screen (Settings, AI helpers)

1. Everything starts **off**. Check that every switch is unticked and no service is connected.
2. Under **This computer**, compare what it says (memory, processor, graphics card, free disk space, and the kind it puts your PC in) with what your PC really has. **Tell us if it is wrong**: it has never been run on real graphics cards or on Windows.
3. Sign in as a **manager** or a cashier: they must not see "AI helpers" at all, and typing the address (`/settings/ai`) must say "This is not for your role".

## 2. A helper on this computer (optional, needs a free program of your choice)

Install a program that runs AI models on your PC and speaks the common web protocol, for example **Ollama** or **LM Studio** (not ours; we do not install or download models for you). Start it, and note the address it listens on (Ollama: `http://127.0.0.1:11434`) and the name of a model you have in it.

1. *Connect a service*: name it, choose **On this computer**, type the address and the model, tick **For writing and answering**, press **Connect**.
2. Try a wrong address first, such as `https://example.com`: it must be refused with "points to this computer".
3. Press **Test**. You should see "It answers and has N models". Press **Test** with the program stopped: you should see that it cannot be reached.
4. Switch the service on. Nothing in the shop uses it yet, so there is nothing more to see than the **What was used** list staying empty.

## 3. A key in the safe (needs an online AI account, optional)

1. Connect a service **An online service I have an account with**, with its address (https) and your key.
2. The key box must be empty after saving and must say "(one is kept)". Close the page and open it again: the key is never shown.
3. Restart the Hub's service (Windows: Services, "NextGenOSHub", Restart) and press **Test**: it must still work. On Windows, open **Credential Manager** (Windows Credentials): there must be an entry starting `NextGenOS.Hub/`. **Tell us if there is none, or if Test fails after the restart**: this is the part that has never run on Windows.
4. Under **What it may receive** there must be **no box** for card and payment details, or for biometric data (faces, fingerprints): they never leave the computer.
5. Remove the service: the entry in Credential Manager must go.

## 4. Business events (Settings, AI helpers, Business events)

1. Switch on **Business event history** under the AI helpers. The screen starts empty. From then on every sale, payment, return, purchase and stock change leaves a message that the program writes into the history within ten minutes (the *Waiting to be written down* box on the same screen shows them, and *Write the waiting ones down now* does it at once); cameras and sensors record nothing yet.
2. In **How long things are kept**, check that biometric data says **not kept** and that card and payment details have no row.
3. Press **Forget what is past its time now**: "Nothing is past its time."
4. Make one sale at the till, press **Write the waiting ones down now**, then in the box **What is true now** write `payment:1` (or `document:1`) and press **Show what is true**. It says when the newest confirmed event about it happened and how many there are. Write a name or an e-mail address instead: it is refused, because things are named by a short reference such as `item:12` or `zone:entrance`. Press **Show what was active in the last day** to list the things that had a confirmed event. This box only reads the history; it changes nothing.
5. Under **AI helpers** switch on **Advanced automatic rules**. In the box **Automatic rules** make a rule (for example: name *Back door forced*, events starting with `door.opened`, 3 events within 10 minutes, about the same thing, propose `alert.door_forced`) and press **Save the rule**. It is made switched off: press **Switch on**. A rule looks only at events recorded from that moment, so nothing is proposed from old history. No camera makes events yet (Phase 7 has only the list of cameras so far; nothing reads a camera), so to see a rule work, ask us to add three test events with the test program; then press **Look at the events now** and look in the list above under *Waiting to be checked*. **Why?** says which rule made the proposal. A rule can only propose; nothing else happens until you say *Yes, it happened* or *No, it was wrong*.

## 6. Notes to search (Settings, AI helpers, Notes to search)

1. Switch on **Search by meaning** under the AI helpers. Open **Notes to search** and write a note (for example *Rice supplier's terms: the supplier gives a cheap price for rice when we order ten bags*); choose the kind of information it holds. Write a second note about something else.
2. Under **Look for something** type *what price for rice*: the first note is found by its words, with where it came from (`note:1`). Type a word that is in no note: "Nothing found."
3. Press **Prepare the notes now**. With no AI service set up it says so in plain words and keeps the notes. If you have set up a service on this computer that makes embeddings (AI helpers, a service for "finding things by meaning"), the notes become "ready" and a question such as *an inexpensive supplier* finds the first note by its meaning; the table says "its meaning". Tell us which service and model you used and what it found.
4. **Change** a note and **Retire** a note: a retired note is gone from every search. Nothing is ever sent outside this computer unless you have allowed that service that kind of information.

## 5. Business map (Settings, AI helpers, Business map)

1. Switch on **Business map**. Add your shop, an area inside it ("Aisle 1"), a shelf inside the area, and a camera.
2. **Find the reference** of one of your products by typing part of its name, and connect it to the shelf ("is kept on").
3. **Look a thing up**: type the product's reference. You should see the shelf, and the bills that have a line for it, marked "from your records".
4. Rename the product in *Items*: the map shows the new name at once (it holds no copy).
5. Remove the area: its connections end and the check says all is in order.

## 6. Ask the shop (Settings, AI helpers; then the menu entry *Ask the shop*)

1. Switch on **Business assistant** under the AI helpers (and **Search by meaning**, so that notes can be written). A menu entry **Ask the shop** appears. Write a note about something you do (for example *Rice supplier's terms: cheap price when we order ten bags*).
2. With **no AI service connected**, ask *what price does the rice supplier give*. It says no answer could be written and shows the note it found, numbered, with where it came from. Ask something that is in no note and no report: it says nothing was found.
3. Connect an AI service that runs **on this computer** (AI helpers, *Connect a service*; the address of your local AI program and a model that can follow instructions), press **Test**, switch it on, and ask *how much did we sell in the last 30 days?*. The assistant should choose the sales lookup, write a short answer and point at a numbered fact below it ("used in the answer"). Check the answer against the fact: the assistant can make mistakes. **Tell us which program and model you used, how long it took, whether it chose the right lookup, and any answer that was wrong.**
4. Sign in as a **cashier** and ask about the best sellers or what is out of stock: the cashier is not offered those lookups. The cashier does not find notes marked confidential or financial.
5. Under **Settings, Activity**, every question is listed as `assistant.ask` with what was looked at, never with the words of the question. The AI helpers screen shows the use of the AI service and what was sent.
6. Nothing is changed by a question, whatever it asks for ("refund everything" only gets facts or a plain answer). Nothing leaves this computer unless you allowed that service that kind of information.
7. **A recommended order:** switch on **Stock forecasts** and **Suggested actions**, type a delivery time for something you stock (Buying, Delivery times), press **Check now**, then ask *what is running low?*. If the answer rests on a warning, a card **A next step you could take** shows the order the warning proposes. Press **Ask for approval**: a request appears under **Waiting for approval** on the Buying page, asked for by you. Nothing is ordered until someone who may buy presses **Approve and draft the order**; then one draft order exists and the warning is not offered again. A cashier is not offered the lookup. **Tell us whether the assistant chose the running-low lookup for your question, and whether the suggested order was one you would place.**

8. **Cameras (the list only):** switch on **Camera analytics** under the AI helpers, then open **Cameras** (a link on the same page). Add a camera: a name, *Network camera (video stream)* and an address on your shop's network such as `rtsp://192.168.1.50:554/stream1` (the camera's password is **not** written in the address: add the camera first, then press **Change** on it and type the password in its own box). Press **Test**: you should be told that the camera answered, and the camera is still not read (no picture is taken). Only after a good test can you press **Switch on**, and even then the program does not read the camera yet: this step only keeps the list. Try an address on the internet (it is refused), a password inside the address (refused), and look for a choice for faces (there is none). **Tell us whether the Test said the right thing for a real camera, a camera that is switched off, and a wrong address, and whether your camera needed anything other than its address.**

## What to tell us

Anything that is wrong, unclear or in words you would not use, with a screenshot. The list of what is **not** done is in `docs/OPEN-WORK.md`; the exact limits of each part are in `docs/V2-ARCHITECTURE-ASSESSMENT.md`, sections 6 to 12.

## Try running low (stock forecasts)
1. Switch on **Stock forecasts** under Settings, AI helpers (the licence must include the AI part).
2. Open **Buying**, press **Delivery times**, choose a thing you keep in stock and type who supplies it and how many days they take (for example 5, with 2 spare days).
3. Press **Check now**. A thing that sells fast and has little on the shelf is listed with the reasons; open *Why might this be wrong?*; press **Start an order** to fill in the order form (you still place it yourself) or **Set aside** to keep the warning quiet.
4. Nothing is judged without a delivery time, and a thing that has been in stock for less than a week is not judged.

## Try suggested actions
1. Switch on **Suggested actions** under Settings, AI helpers (and Stock forecasts, as above).
2. On a *Running low* warning press **Ask for approval**. A card **Waiting for approval** appears, saying in words what would be done.
3. As a manager or the owner press **Approve and draft the order**. A draft order appears under *To receive*; the warning is marked as acted on. Press **Decline** instead and nothing is done.
4. A request that nobody approves runs out after 48 hours. The rules are in `docs/SUGGESTED-ACTIONS.md`.

