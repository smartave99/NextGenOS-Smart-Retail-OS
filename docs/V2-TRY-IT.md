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

## 5. Business map (Settings, AI helpers, Business map)

1. Switch on **Business map**. Add your shop, an area inside it ("Aisle 1"), a shelf inside the area, and a camera.
2. **Find the reference** of one of your products by typing part of its name, and connect it to the shelf ("is kept on").
3. **Look a thing up**: type the product's reference. You should see the shelf, and the bills that have a line for it, marked "from your records".
4. Rename the product in *Items*: the map shows the new name at once (it holds no copy).
5. Remove the area: its connections end and the check says all is in order.

## What to tell us

Anything that is wrong, unclear or in words you would not use, with a screenshot. The list of what is **not** done is in `docs/OPEN-WORK.md`; the exact limits of each part are in `docs/V2-ARCHITECTURE-ASSESSMENT.md`, sections 6 to 8.

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

