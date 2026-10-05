using System;

namespace SmartRetail.AI.Posters
{
    /// <summary>What the artwork of an A4 poster should look like.</summary>
    public sealed class PosterArtworkRequest
    {
        /// <summary>The poster's theme and colours, e.g. "a clearance sale: energetic red, coral and orange".</summary>
        public string Theme { get; set; } = "";
    }

    public sealed class PosterArtworkResult
    {
        public byte[] Image { get; set; }

        public string ProviderName { get; set; } = "";

        public TimeSpan Duration { get; set; }
    }

    /// <summary>
    /// The task for Codex's image tool: artwork only. Words, product photos and prices are placed on it by the app,
    /// so the image must hold no text, numbers, products or people, and leave calm space where they go.
    /// </summary>
    public static class PosterArtworkPrompt
    {
        public const string ResultFileName = "poster-art.png";

        public static string CodexPrompt(PosterArtworkRequest request)
        {
            if (string.IsNullOrWhiteSpace(request?.Theme))
            {
                throw new ArgumentException("The poster needs a theme.", nameof(request));
            }

            return "You are making the artwork for an A4 shop poster, for a small shop in India.\n"
                + "Use your image generation tool to make one tall portrait image (2:3, for example 1024 x 1536) with this theme: "
                + request.Theme.Trim().TrimEnd('.') + ".\n"
                + "Layout: the top 40% is a bold, rich area where a big white headline will be printed, so keep it dark enough "
                + "for white text. The lower 60% is soft, light and calm, almost plain, where product cards with photos and prices "
                + "will be placed. Keep decoration to the edges and corners there.\n"
                + "Strictly no text of any kind: no letters, words, numbers, prices, percent signs, logos, watermarks or signatures. "
                + "No products, packages, bottles, food or people: the shop adds real product photos itself.\n"
                + "Style: modern, cheerful and professional, like a well-designed supermarket sale poster, with smooth gradients "
                + "and gentle light. Print quality.\n"
                + "Save the image as " + ResultFileName + " in the current folder. Then reply with one word: done.";
        }
    }
}
