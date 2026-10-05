# Design previews

Pictures of the new look for Smart Retail POS, made for approval before the screens are built: Today (light and dark), Ask AI, Product photos, Posters, Get started and the side panel beside the POS.

They use sample data only (a made-up shop), and the product pictures are drawings standing in for real AI photos.

```
node build.js                                               # writes the preview pages (1-today.html …)
NODE_PATH=/opt/node22/lib/node_modules node shoot.js        # renders each page to png/ with Playwright
```

`design.css` holds the colours (light and dark), type sizes and parts the app screens are built from.

Fonts, both under the SIL Open Font License (licences in `fonts/`): Inter 4.1 and Noto Sans Devanagari, for the Hindi lines on posters.
