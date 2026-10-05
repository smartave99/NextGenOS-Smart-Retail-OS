# AI illustration assets — 1 October 2026

The built-in ChatGPT image-generation tool created these project assets. Its interface does not expose a selectable model named “Image 2.5”; no claim is made that this model was used. Images are bundled as embedded resources and do not call an AI service at runtime.

| Asset | Workspace file | Use |
|---|---|---|
| Storefront | [storefront-v1.png](../Source/SmartAvenue99_POS_VB/SmartAvenue99%20POS/Assets/Retail/storefront-v1.png) | Startup, sign-in, store connection, home welcome |
| Empty shopping bag | [empty-bag-v1.png](../Source/SmartAvenue99_POS_VB/SmartAvenue99%20POS/Assets/Retail/empty-bag-v1.png) | Checkout empty state only |

The original transparent PNGs are preserved. Native rendering fits them proportionally without stretching or cutting off the subject. The two decoded images are shared across screens. Artwork does not own keyboard focus or contain required instructions, and it is omitted in Windows high contrast. Checkout removes its empty-state overlay as soon as a real cart row exists and restores it when rows are cleared.

Home now begins with six existing everyday commands instead of the first twelve menu entries. Search matches both task captions and their menu paths, and each result exposes its category as visible secondary text and an accessible description. The original command and every menu ancestor still govern availability. No business permissions or new AI assistant features are introduced.

## Storefront generation prompt

```text
Use case: stylized-concept
Asset type: reusable transparent illustration for the existing Smart Retail OS desktop app welcome, startup, and sign-in screens.
Primary request: a beautifully restrained miniature neighborhood storefront, softly dimensional and sculptural, in a refined modern product illustration style.
Subject: one compact shop with an ivory rounded facade, a cobalt blue awning, a clear glass entrance and two understated display windows. No other objects.
Style/medium: premium 3D clay and satin-material render; thoughtful rounded geometry, precise edges, subtle believable depth, gentle studio light.
Composition/framing: square canvas, centered complete object, slight elevated three-quarter view, generous clean transparent padding on every side. Object fills roughly 78 percent of the canvas. Keep the silhouette readable at 64 pixels.
Color palette: the app uses cobalt blue accent, warm white, pale silver and charcoal neutrals. Awning blue, body warm ivory, subtle silver structure.
Scene/backdrop: genuinely transparent alpha background, no room, no ground plane, no opaque rectangle. Only a faint compact contact shadow immediately under the shop.
Constraints: no text, no signage lettering, no logos, no people, no UI, no gradients in the background, no Apple branding, no watermark. Friendly, calm, precise, not toy-like or busy.
```

## Empty bag generation prompt

The storefront image was supplied only as a reference for material, lighting and palette.

```text
Use case: stylized-concept
Asset type: transparent empty-cart illustration for the Smart Retail OS checkout.
Input image: reference image for material finish, soft studio lighting, blue and ivory palette only; do not reproduce the storefront.
Primary request: one beautifully simple empty shopping bag with a small open top and two rounded handles, made of warm ivory satin paper with a single cobalt blue side panel.
Style/medium: premium sculptural 3D render, precise soft corners and restrained product-design finish matching the reference. Clear empty-bag silhouette at small UI sizes.
Composition/framing: square canvas, centered complete bag, slight elevated three-quarter view, generous transparent padding on all sides, bag takes roughly 70 percent of canvas height.
Scene/backdrop: genuine transparent alpha background, no floor plane or room, only a tiny subtle contact shadow below the bag.
Constraints: one empty shopping bag only. No contents, no receipt, no cart, no text, no logo, no people, no UI, no watermark, no background decoration.
```

The source generation files remain under the Codex generated-images directory; the application consumes only the workspace copies above. See [FRONTEND_REVIEW.md](FRONTEND_REVIEW.md) for verification results and the remaining frontend scope.

