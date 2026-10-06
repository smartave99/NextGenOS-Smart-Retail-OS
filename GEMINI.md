# Instructions for Gemini and other AI assistants

This repository has one set of rules, for every person and every assistant: **read [`CLAUDE.md`](CLAUDE.md) completely before you change anything**, then [`docs/OPEN-WORK.md`](docs/OPEN-WORK.md) (what is left, and what only the owner can do).

This file holds no rules of its own. If it ever disagrees with `CLAUDE.md`, `CLAUDE.md` is right.

The ones that are broken most often:

- Nothing is "complete", "done" or "ready" until `node scripts/verify-all.mjs --full` exits 0 and its table is quoted, with every NOT VERIFIED item listed (section 2).
- No secret, no licence bypass, no source code in anything a customer or staff member receives (section 3).
- A customer's name, country or look is never written in program code: it is a setting (sections 1 and 8).
- Programs open as windows, never as a terminal (section 10).
- The owner must never have to repeat a rule: write it into `CLAUDE.md` in the same session (section 13).
- Do your whole part; for what only the owner can do, write down exactly what and how (section 13).
