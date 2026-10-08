# Counter PCs: connecting the other PCs of the shop to the main PC (for the owner of a shop)

A shop can have more than one counter. The Business Hub keeps all the shop's information on **one PC, the main PC**. The other PCs, tablets and phones are **counter PCs**: they open the shop's screens from the main PC, over the shop's own network (the cable or the Wi-Fi of the shop). There is one true copy of the shop, so stock and bill numbers cannot clash. Nothing goes to the internet, and nothing is kept on a counter PC.

**A counter PC cannot work when the main PC is switched off or off the network**, because there is nothing else for it to show. Keep the main PC on while the shop is open. A standby copy of the main PC is not built yet.

## 1. Switch it on (once, on the main PC)

1. Sign in as the owner on the main PC. Open **Settings**, then **Store network**.
2. Tick **Let counter PCs connect** and press **Save**.
3. **Restart the main PC** (or the Hub's service). A program cannot start listening on the network while it runs, so this is needed once. A restart button inside the Hub is not built yet.
4. Open **Settings, Store network** again. It says **Counter PCs can connect now**, and shows the addresses a counter PC will use, and **check letters** (see below).

The first time, the main PC makes the **shop's own certificate**. It is kept on the main PC only; nothing is bought or fetched from outside. The certificate lets a counter PC be sure that it is talking to your main PC and that nobody on the network can read what is sent. It is valid for the main PC's name and its network addresses; if the address changes (some routers give out new ones), use the main PC's name instead, or restart the Hub so that the certificate follows the new address.

If something is wrong (the port is used by another program, or the certificate could not be made) the Hub still starts, as it always did, on the main PC alone, and the Store network page says in plain words what to do.

## 2. Open the door of the main PC's firewall (Windows)

Windows may stop counter PCs from reaching the main PC. On the main PC: *Windows Security, Firewall and network protection, Advanced settings, Inbound Rules, New Rule*: choose **Port**, **TCP**, the port shown on the Store network page (5281 unless you changed it), **Allow the connection**, for **Private** and **Domain** networks. **The Hub's setup does not do this for you yet.**

## 3. Add a counter PC

1. On the main PC, in **Settings, Store network**, press **Make a pairing code**. The code works **once** and runs out after **10 minutes**. A new code replaces the old one.
2. On the counter PC, open the browser and go to one of the addresses shown (for example `https://MAIN-PC:5281/pair`).
3. The first time, the browser warns that the connection is not private. That is expected until the counter PC trusts the shop's own certificate, once. The page it shows (**How to do that**) explains it step by step for Windows (Edge or Chrome) and Firefox. **Check that the "check letters" on that page are exactly the same as on the main PC.** If they are not, do not go on, and tell the owner. Tablets and phones: the steps depend on the make and are not described yet.
4. Type the code and a name for the counter PC (for example "Counter 2"), and press **Connect**. The page says "This computer is connected to the shop".
5. Open `/login` on the counter PC and sign in with your own user name and password. People see only what their role allows, as on the main PC.

A computer that has not been paired sees only a plain page that says so. It cannot see the sign-in page, the licence page, or anything about the shop. After five wrong codes from one address, pairing is locked for that address for ten minutes.

## 4. See and remove counter PCs

The list in **Settings, Store network** shows each counter PC, when it was paired, when it was last seen, and from which address. **Remove** sends a counter PC away **at once**: its open screen is closed, and its next request is refused. It can only come back with a new code. The history of removed counter PCs stays.

**Switch off** (untick the box, **Save**) refuses every counter PC at once, and the main PC carries on. Every request from the network is refused from then on, and the network door closes completely the next time the Hub starts.

## 5. How many PCs

Your licence says how many PCs it is for: the main PC counts as one. With a licence for 3 PCs, the main PC and two counter PCs can work. When all are in use, the page says so, and a new code is not made until you remove one or ask your supplier for a larger licence.

## What stays in the shop

- The shop's information stays on the main PC. A counter PC only shows it and sends what the person at it types.
- Nothing is sent to the internet because of this. No outside service is used for the certificate or the connection.
- A counter PC's pass is a long random token kept in the browser; the main PC keeps only a fingerprint of it, never the token itself. It cannot be read by a script on a page, is sent only over the secure connection, and never to another site.
- Every pairing, removal and refusal is written to **Settings, Activity** ("What people did").

## What is not built yet

- A restart button for the Hub, and opening the firewall during setup.
- Steps for trusting the certificate on tablets and phones; a counter that is a program of its own (the first counter is the browser).
- What a counter PC shows when the main PC is off (it shows the browser's own error), and retrying a sale after the connection came back (the main PC already makes a repeated request one sale; see `docs/ENGINEERING-BLUEPRINT.md`, NET-007).
- Moving the certificate's private key into the system's credential store, and renewing it by itself.

## What has and has not been checked

Tested here on one computer: pairing, the plain refusal, removal, switching off, the licence's number of PCs, the certificate against the main PC's network address with Node's own TLS, and a real browser reaching the main PC by its network address over TLS (`StoreNetwork*Tests`, `StoreNetworkWebTests`, `e2e/network.e2e.mjs`). **Not checked:** a second real PC, a real router and Wi-Fi, Windows Firewall, and a real browser with the shop's authority installed as a trusted certificate (the test tells the browser to accept the main PC's certificate directly).
