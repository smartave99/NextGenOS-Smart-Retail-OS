# Project rules (read first, every session)

These rules apply to every person and every AI assistant that changes this repository. They are not suggestions.

## 1. Who and what

- **Company:** NextGenOS.  **Product:** Smart Retail POS.  **The whole:** the Smart Retail AI Ecosystem, created by NextGenOS.
- **Smart Avenue 99 is a customer** of NextGenOS, not the product. Its name, address, logo, e-mail and colours must never appear as a default in product code. A customer's identity lives only in that customer's brand kit (`brand-kits/<customer>/`) or in a licence's brand profile.
- Contact for licensing and security: smartave99@gmail.com, +91 6123115368.
- The software is proprietary (`LICENSE`, `EULA.txt`). It is never published, never open-sourced, and never copied into a public place, including AI services that train on what they receive.

## 2. The "all complete" rule (Definition of Done)

**Never write that work is "complete", "done", "finished", "ready", "ready to sell", "bug-free" or "secure" unless all of this is true in the same session:**

1. `node scripts/verify-all.mjs --full` was run and **exited with code 0**, and its summary table is quoted in the answer.
2. Every item the gate marks **NOT VERIFIED** is listed in the answer, in plain words, with what a person must do to verify it (for example: run the Windows installer on a real PC, print on a real printer, build the APK in CI, have counsel review the EULA).
3. Nothing in the answer says "no bugs" or "no security issues". Say what was tested and what was checked, and what was not. Testing shows the presence of problems, never their absence.
4. If a check could not be run (no Windows, no hardware, blocked network), say so. A skipped check is not a passed check. The gate refuses runs with skipped tests.

If the gate fails, the work is not complete. Fix it, or say exactly what is failing.

## 3. Security rules

- No secret in the repository: no API key, password, token, connection string, private key, licence-signing key, passphrase, `.env`, database or licence file. `scripts/verify-all.mjs` scans for them. If one is found, rotate it first, then remove it.
- **No licence bypass, ever.** No hard-coded licence, no "demo" fallback that returns a valid licence, no activation script that writes a licence, no key generator, no environment variable or setting that makes a release build trust another key or skip the check. Development shortcuts must be impossible in a production build (`NODE_ENV=production`, Release configuration).
- The Licence Studio, its keys and its data are **private**. They are never packaged with a customer build. See `licensing/spec/LICENCE-FORMAT.md` section 12.
- **No source code in anything a customer receives**: installers, zips, APKs, Docker images or documentation folders must hold compiled/bundled code only: no `.cs`, `.vb`, `.ts`, `.tsx`, `.map`, `.pdb`, `.sln`, `.csproj`, test or script files from `licensing/studio`. `scripts/audit-package.mjs` enforces it and fails the release.
- New dependencies must allow proprietary redistribution (MIT, BSD, Apache-2.0, and the like). GPL, AGPL, SSPL and non-commercial licences are not allowed. Add the notice to `THIRD-PARTY-NOTICES.md`.
- Web code: every response carries the security headers set in `apps/storefront-web-mobile/src/middleware.ts`; no `dangerouslySetInnerHTML` with user data; every admin route checks the session; every input is validated on the server.
- Windows code: SQL is parameterised; the POS database is read-only for the AI and the dashboard; no secret in a connection string in source.

## 4. Licensing changes

The format is a contract between the Studio, the .NET library and the TypeScript library. Change `licensing/spec/LICENCE-FORMAT.md` first, regenerate `licensing/testvectors/vectors.json` (`node licensing/studio/scripts/make-testvectors.js`), and make **all three** implementations pass the vectors before you finish. A change in only one is a bug.

## 5. How to check your work

| What | Command |
|---|---|
| Everything (the gate) | `node scripts/verify-all.mjs --full` |
| Quick checks while working | `node scripts/verify-all.mjs` |
| Licence Studio | `cd licensing/studio && npm test` |
| .NET licence library incl. live Studio tests | `node licensing/e2e/with-studio.mjs -- dotnet test licensing/clients/dotnet/NextGenOS.Licensing.Tests` |
| Storefront | `cd apps/storefront-web-mobile && npx vitest run && npx tsc --noEmit` |
| Storefront against a real Studio (production build) | `node licensing/e2e/with-studio.mjs -- node licensing/e2e/storefront-e2e.mjs` |

## 6. Style

Plain words for the people who use the product: shop owners, cashiers, salespeople. No jargon in screens or messages. Match the code around you. Say what changed in `CHANGELOG.md` when a release is cut.
