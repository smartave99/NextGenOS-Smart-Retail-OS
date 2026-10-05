using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using SmartRetail.AI.Products;
using SmartRetail.Pos.Core.Abstractions;

namespace SmartRetail.Pos.Web.Services;

/// <summary>
/// Searching Google Lens with a product's own photo, in one click, in the owner's browser. Nothing here runs an AI and
/// nothing is read back: the photo goes from the browser straight to Google, which shows similar products and the shops
/// that sell them, and the owner decides what a result means. A photo finds the same product more exactly than its name,
/// and costs none of Codex's limit.
/// </summary>
/// <remarks>
/// Google takes a photo as a plain form (what its own page does): a multipart POST with the file in "encoded_image", answered
/// by a redirect to the results. A form cannot carry a file from this PC, so the link opens a small page of the dashboard
/// (<see cref="PageUrl"/>) that makes the form in the browser and sends it. The photo is first made smaller (at most
/// <see cref="LongestSide"/> pixels) and drawn again, which also drops the place and camera details a phone puts in a photo.
/// </remarks>
public static class GoogleLens
{
    /// <summary>Where Google takes a photo sent as a form. Checked against Google on 3 October 2026: a POST with the photo in
    /// "encoded_image" is answered by a redirect to the results.</summary>
    public const string UploadUrl = "https://lens.google.com/v3/upload";

    /// <summary>Where a person can paste the photo by hand (Ctrl+V), when it cannot be sent by itself.</summary>
    public const string PasteUrl = "https://www.google.com/imghp";

    /// <summary>The longest side of the photo that is sent, in pixels: plenty for Google, and a small upload.</summary>
    public const int LongestSide = 1600;

    /// <summary>The dashboard page that sends the photo: a product's best photo, or one named photo of it.</summary>
    public static string PageUrl(int productId, string? photo = null) =>
        photo is { Length: > 0 } ? $"lens/{productId}?photo={Uri.EscapeDataString(photo)}" : $"lens/{productId}";

    /// <summary>
    /// The photo to search with when the owner does not pick one: the real packaging in the newest phone photo (it is what a
    /// shopper's photo looks like), else the white-background photo made from it. Null when the product has no photo.
    /// </summary>
    public static string? BestPhoto(ProductPhotoInfo? info)
    {
        if (info?.LatestSet is { } set && set.RawFiles.FirstOrDefault(ProductPhotoStore.IsPhotoFileName) is { } raw)
        {
            return raw;
        }

        return info?.Sets.SelectMany(s => s.Images).Where(image => ProductPhotoStore.IsPhotoFileName(image.File))
            .OrderBy(image => image.Kind != PhotoKind.WhiteBackground).ThenByDescending(image => image.Made)
            .Select(image => image.File).FirstOrDefault();
    }

    /// <summary>The page that sends the photo, with the fallbacks when it cannot: the photo is shown, said to be sent, and
    /// sent; "Copy the photo" and "Open Google Images" are for pasting it by hand.</summary>
    /// <param name="name">The product's name, only to say what is being searched.</param>
    /// <param name="photoUrl">The photo's address on this dashboard.</param>
    public static string Html(string name, string photoUrl)
    {
        // One pass over the fixed page: text that looks like a marker (in a product's name) is never filled in a second time.
        var values = new Dictionary<string, string>
        {
            ["NAME"] = WebUtility.HtmlEncode(name),
            ["PHOTO"] = WebUtility.HtmlEncode(photoUrl),
            ["UPLOAD"] = UploadUrl,
            ["PASTE"] = PasteUrl,
            ["SIDE"] = LongestSide.ToString(System.Globalization.CultureInfo.InvariantCulture),
        };
        return Marker.Replace(PageTemplate, match => values[match.Groups[1].Value]);
    }

    private static readonly Regex Marker = new(@"\{\{(NAME|PHOTO|UPLOAD|PASTE|SIDE)\}\}", RegexOptions.Compiled);

    /// <summary>The page for a product that has no photo to search with, or a photo that is not there.</summary>
    public static string NoPhotoHtml(string name, int productId)
    {
        var text = WebUtility.HtmlEncode(name);
        return $"<!doctype html><html lang=\"en\"><head><meta charset=\"utf-8\"><meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">"
            + $"<title>Google Lens · {text}</title><style>body{{font:16px/1.5 system-ui,sans-serif;margin:0;padding:32px 16px;max-width:560px;margin-inline:auto}}</style></head>"
            + $"<body><h1>No photo to search with</h1><p>{text} has no photo yet. Add one on its page in Smart Retail POS, then press Google Lens again.</p>"
            + $"<p><a href=\"/photos/{productId}\">Add photos of this product</a></p></body></html>";
    }

    /// <summary>The page is fixed: it holds no product text but what is put into the marked places (already encoded), and its
    /// script reads the photo's address from the page, never from a string it was built with.</summary>
    private const string PageTemplate = """
        <!doctype html>
        <html lang="en">
        <head>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <meta name="referrer" content="no-referrer">
        <meta name="robots" content="noindex">
        <title>Google Lens · {{NAME}}</title>
        <style>
        :root { color-scheme: light dark; --bg: #f5f5f7; --card: #fff; --ink: #1d1d1f; --muted: #6e6e73; --brand: #0071e3; --line: #d2d2d7; --bad: #c4281c; }
        @media (prefers-color-scheme: dark) { :root { --bg: #111113; --card: #1b1b1e; --ink: #f5f5f7; --muted: #a1a1a6; --brand: #2997ff; --line: #38383a; --bad: #ff6a5e; } }
        * { box-sizing: border-box; }
        body { margin: 0; background: var(--bg); color: var(--ink); font: 16px/1.5 system-ui, -apple-system, "Segoe UI", Roboto, sans-serif; }
        main { max-width: 620px; margin: 0 auto; padding: 28px 16px 40px; }
        h1 { font-size: 22px; line-height: 1.25; margin: 0 0 4px; }
        .sub { color: var(--muted); margin: 0 0 18px; }
        .card { background: var(--card); border: 1px solid var(--line); border-radius: 16px; padding: 16px; }
        img { display: block; max-width: 100%; max-height: 320px; margin: 0 auto 14px; border-radius: 10px; background: #fff; object-fit: contain; }
        #status { margin: 0 0 6px; font-weight: 600; }
        #status.problem { color: var(--bad); }
        .small { color: var(--muted); font-size: 14px; margin: 8px 0 0; }
        .row { display: flex; flex-wrap: wrap; gap: 8px; margin-top: 14px; }
        button, a.button { appearance: none; border: 1px solid var(--line); background: var(--card); color: var(--ink); font: inherit; font-size: 15px; padding: 8px 14px; border-radius: 999px; cursor: pointer; text-decoration: none; }
        button.primary { background: var(--brand); border-color: var(--brand); color: #fff; }
        </style>
        </head>
        <body data-photo="{{PHOTO}}" data-upload="{{UPLOAD}}" data-side="{{SIDE}}">
        <main>
        <h1>Google Lens: {{NAME}}</h1>
        <p class="sub">Searching with the product's photo finds the same product more exactly than its name.</p>
        <section class="card">
        <img id="shot" src="{{PHOTO}}" alt="The photo sent to Google Lens">
        <p id="status" role="status">Getting the photo ready…</p>
        <p class="small">This photo goes from this browser straight to Google, made smaller and without the place and camera details a phone puts in a photo. Nothing goes through an AI, and nothing about the shop's prices, sales or customers is sent. Google shows similar products and where they are sold: check a page before you rely on a price.</p>
        <div class="row">
        <button type="button" class="primary" id="again">Search again</button>
        <button type="button" id="copy">Copy the photo</button>
        <a class="button" id="paste" href="{{PASTE}}" target="_blank" rel="noopener noreferrer">Open Google Images</a>
        </div>
        <p class="small" id="help">If Google Lens does not open: press <b>Copy the photo</b>, open Google Images, click the camera icon and press Ctrl+V.</p>
        </section>
        </main>
        <script>
        (function () {
          var body = document.body;
          var photo = body.getAttribute('data-photo');
          var side = parseInt(body.getAttribute('data-side'), 10) || 1600;
          var status = document.getElementById('status');
          var key = 'lens-sent:' + photo;

          function say(text, problem) { status.textContent = text; status.className = problem ? 'problem' : ''; }

          // The photo, made smaller, drawn again (which drops its metadata) and as a canvas to save as JPEG or PNG.
          function prepare() {
            return fetch(photo, { cache: 'force-cache' }).then(function (response) {
              if (!response.ok) { throw new Error('The photo could not be read.'); }
              return response.blob();
            }).then(function (blob) {
              return createImageBitmap(blob, { imageOrientation: 'from-image' });
            }).then(function (bitmap) {
              var scale = Math.min(1, side / Math.max(bitmap.width, bitmap.height));
              var canvas = document.createElement('canvas');
              canvas.width = Math.max(1, Math.round(bitmap.width * scale));
              canvas.height = Math.max(1, Math.round(bitmap.height * scale));
              var context = canvas.getContext('2d');
              context.fillStyle = '#fff';
              context.fillRect(0, 0, canvas.width, canvas.height);
              context.drawImage(bitmap, 0, 0, canvas.width, canvas.height);
              return canvas;
            });
          }

          function blobOf(canvas, type, quality) {
            return new Promise(function (resolve, reject) {
              canvas.toBlob(function (result) { result ? resolve(result) : reject(new Error('The photo could not be prepared.')); }, type, quality);
            });
          }

          function send() {
            say('Sending this photo to Google Lens…');
            prepare().then(function (canvas) { return blobOf(canvas, 'image/jpeg', 0.9); }).then(function (jpeg) {
              var form = document.createElement('form');
              form.method = 'POST';
              form.action = body.getAttribute('data-upload');
              form.enctype = 'multipart/form-data';
              form.style.display = 'none';
              var input = document.createElement('input');
              input.type = 'file';
              input.name = 'encoded_image';
              var transfer = new DataTransfer();
              transfer.items.add(new File([jpeg], 'product.jpg', { type: 'image/jpeg' }));
              input.files = transfer.files;
              form.appendChild(input);
              document.body.appendChild(form);
              try { sessionStorage.setItem(key, String(Date.now())); } catch (e) { /* private window: it just sends again on Back */ }
              form.submit();
            }).catch(function (error) {
              say('The photo could not be sent by itself (' + (error && error.message ? error.message : 'an error') + '). Use Copy the photo, then paste it in Google Images.', true);
            });
          }

          document.getElementById('again').addEventListener('click', send);
          document.getElementById('copy').addEventListener('click', function () {
            prepare().then(function (canvas) { return blobOf(canvas, 'image/png'); }).then(function (png) {
              return navigator.clipboard.write([new ClipboardItem({ 'image/png': png })]);
            }).then(function () {
              say('The photo is copied. Open Google Images, click the camera icon and press Ctrl+V.');
            }).catch(function () {
              say('The photo could not be copied. Save it from the picture above (right click) and add it in Google Images.', true);
            });
          });

          // Coming back from Google's results (Back) must not send the photo again by itself.
          var before = null;
          try { before = sessionStorage.getItem(key); } catch (e) { before = null; }
          if (before && Date.now() - Number(before) < 30 * 60 * 1000) {
            say('This photo was already sent to Google Lens. Press Search again to send it once more.');
          } else {
            send();
          }
        })();
        </script>
        </body>
        </html>
        """;

    /// <summary>Serves the page for a product: <c>/lens/{productId}</c>, or <c>/lens/{productId}?photo={file}</c> for one of its photos.</summary>
    public static void MapGoogleLens(this IEndpointRouteBuilder app) =>
        app.MapGet("/lens/{productId:int}", async (int productId, string? photo, ProductPhotoService photos, ISalesFactsRepository facts, HttpContext http) =>
        {
            var info = photos.Info(productId);
            var file = photo is { Length: > 0 } ? photo : BestPhoto(info);

            http.Response.Headers.CacheControl = "no-store";
            http.Response.Headers.XContentTypeOptions = "nosniff";
            http.Response.Headers["Referrer-Policy"] = "no-referrer";
            // Nothing but this dashboard's own photo is loaded; the form is the only thing that leaves.
            http.Response.Headers.ContentSecurityPolicy =
                "default-src 'none'; img-src 'self' blob: data:; style-src 'unsafe-inline'; script-src 'unsafe-inline'; connect-src 'self'; base-uri 'none'; frame-ancestors 'none'";

            // Only a photo the store made for this product: any other name is "no photo", never a file read.
            if (file is null || photos.Store.PathOf(productId, file) is null)
            {
                var product = (await facts.GetProductsAsync(http.RequestAborted)).FirstOrDefault(p => p.Id == productId)?.Name;
                var missing = product is { Length: > 0 } ? product : info?.Name is { Length: > 0 } kept ? kept : $"Product {productId}";
                return Results.Content(NoPhotoHtml(missing, productId), "text/html; charset=utf-8", Encoding.UTF8, StatusCodes.Status404NotFound);
            }

            var name = info?.Name is { Length: > 0 } known ? known : $"Product {productId}";
            return Results.Content(Html(name, "/" + ProductPhotoService.Url(productId, file)), "text/html; charset=utf-8", Encoding.UTF8);
        });
}
