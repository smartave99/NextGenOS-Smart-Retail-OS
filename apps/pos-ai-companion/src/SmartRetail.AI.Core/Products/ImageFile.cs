using System;
using System.IO;

namespace SmartRetail.AI.Products
{
    /// <summary>The format and size of an image, read from its first bytes. PNG, JPEG and WebP; no image library needed.</summary>
    public static class ImageFile
    {
        /// <summary>Amazon zooms only into images at least this many pixels on the longest side.</summary>
        public const int AmazonZoomPixels = 1000;

        /// <summary>The extension the bytes need: ".png", ".jpg" or ".webp"; null for anything else.</summary>
        public static string ExtensionOf(byte[] bytes)
        {
            if (bytes == null || bytes.Length < 12)
            {
                return null;
            }

            if (bytes[0] == 0x89 && bytes[1] == 0x50 && bytes[2] == 0x4E && bytes[3] == 0x47)
            {
                return ".png";
            }

            if (bytes[0] == 0xFF && bytes[1] == 0xD8 && bytes[2] == 0xFF)
            {
                return ".jpg";
            }

            return Ascii(bytes, 0, "RIFF") && Ascii(bytes, 8, "WEBP") ? ".webp" : null;
        }

        /// <summary>The width and height in pixels, or false when the file is not a PNG, JPEG or WebP it can read.</summary>
        public static bool TryReadSize(string path, out int width, out int height)
        {
            width = height = 0;
            try
            {
                using (var file = File.OpenRead(path))
                {
                    var head = new byte[(int)Math.Min(file.Length, 512 * 1024)];
                    var read = 0;
                    while (read < head.Length)
                    {
                        var n = file.Read(head, read, head.Length - read);
                        if (n == 0)
                        {
                            break;
                        }

                        read += n;
                    }

                    return TryReadSize(head, out width, out height);
                }
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                return false;
            }
        }

        /// <summary>
        /// The size of the picture as it is shown: a phone keeps a portrait photo as a landscape one with a turn noted in it
        /// (EXIF orientation 5 to 8), so for those the width and the height change places. False as <see cref="TryReadSize(string, out int, out int)"/>.
        /// </summary>
        public static bool TryReadShownSize(string path, out int width, out int height)
        {
            width = height = 0;
            try
            {
                using (var file = File.OpenRead(path))
                {
                    var head = new byte[(int)Math.Min(file.Length, 512 * 1024)];
                    var read = 0;
                    while (read < head.Length)
                    {
                        var n = file.Read(head, read, head.Length - read);
                        if (n == 0)
                        {
                            break;
                        }

                        read += n;
                    }

                    return TryReadShownSize(head, out width, out height);
                }
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                return false;
            }
        }

        public static bool TryReadShownSize(byte[] bytes, out int width, out int height)
        {
            if (!TryReadSize(bytes, out width, out height))
            {
                return false;
            }

            if (ExtensionOf(bytes) == ".jpg" && ExifOrientation(bytes) is int orientation && orientation >= 5 && orientation <= 8)
            {
                var stored = width;
                width = height;
                height = stored;
            }

            return true;
        }

        /// <summary>The turn a JPEG says to apply (1 to 8) from its EXIF part; null when it has none or it cannot be read.</summary>
        public static int? ExifOrientation(byte[] bytes)
        {
            if (bytes == null || bytes.Length < 14 || bytes[0] != 0xFF || bytes[1] != 0xD8)
            {
                return null;
            }

            var i = 2;
            while (i + 4 < bytes.Length)
            {
                if (bytes[i] != 0xFF)
                {
                    return null;
                }

                var marker = bytes[i + 1];
                if (marker == 0xFF)
                {
                    i++;
                    continue;
                }

                if (marker == 0xDA || marker == 0xD9)
                {
                    return null;
                }

                var length = (bytes[i + 2] << 8) | bytes[i + 3];
                if (marker == 0xE1 && length >= 14 && i + 4 + 6 < bytes.Length && Ascii(bytes, i + 4, "Exif"))
                {
                    return TiffOrientation(bytes, i + 10, Math.Min(bytes.Length, i + 2 + length));
                }

                i += 2 + length;
            }

            return null;
        }

        private static int? TiffOrientation(byte[] bytes, int tiff, int end)
        {
            if (tiff + 8 > end)
            {
                return null;
            }

            bool little;
            if (bytes[tiff] == 'I' && bytes[tiff + 1] == 'I')
            {
                little = true;
            }
            else if (bytes[tiff] == 'M' && bytes[tiff + 1] == 'M')
            {
                little = false;
            }
            else
            {
                return null;
            }

            int Short(int at) => little ? bytes[at] | (bytes[at + 1] << 8) : (bytes[at] << 8) | bytes[at + 1];
            long Long(int at) => little
                ? (uint)(bytes[at] | (bytes[at + 1] << 8) | (bytes[at + 2] << 16) | (bytes[at + 3] << 24))
                : (uint)((bytes[at] << 24) | (bytes[at + 1] << 16) | (bytes[at + 2] << 8) | bytes[at + 3]);

            var directory = Long(tiff + 4);
            if (directory < 8 || tiff + directory + 2 > end)
            {
                return null;
            }

            var at0 = tiff + (int)directory;
            var count = Short(at0);
            for (var n = 0; n < count && at0 + 2 + (n + 1) * 12 <= end; n++)
            {
                var entry = at0 + 2 + n * 12;
                if (Short(entry) == 0x0112)
                {
                    var value = Short(entry + 8);
                    return value >= 1 && value <= 8 ? value : (int?)null;
                }
            }

            return null;
        }

        public static bool TryReadSize(byte[] bytes, out int width, out int height)
        {
            width = height = 0;
            switch (ExtensionOf(bytes))
            {
                case ".png" when bytes.Length >= 24 && Ascii(bytes, 12, "IHDR"):
                    width = BigEndian(bytes, 16);
                    height = BigEndian(bytes, 20);
                    break;
                case ".jpg":
                    ReadJpegSize(bytes, out width, out height);
                    break;
                case ".webp":
                    ReadWebPSize(bytes, out width, out height);
                    break;
            }

            return width > 0 && height > 0;
        }

        private static void ReadJpegSize(byte[] bytes, out int width, out int height)
        {
            width = height = 0;
            var i = 2;
            while (i + 9 < bytes.Length)
            {
                if (bytes[i] != 0xFF)
                {
                    return;
                }

                var marker = bytes[i + 1];
                if (marker == 0xFF)
                {
                    i++;
                    continue;
                }

                var length = (bytes[i + 2] << 8) | bytes[i + 3];
                // Start-of-frame markers hold the size; C4, C8 and CC are other tables with numbers in the same range.
                if (marker >= 0xC0 && marker <= 0xCF && marker != 0xC4 && marker != 0xC8 && marker != 0xCC)
                {
                    height = (bytes[i + 5] << 8) | bytes[i + 6];
                    width = (bytes[i + 7] << 8) | bytes[i + 8];
                    return;
                }

                i += 2 + length;
            }
        }

        private static void ReadWebPSize(byte[] bytes, out int width, out int height)
        {
            width = height = 0;
            if (bytes.Length < 30)
            {
                return;
            }

            if (Ascii(bytes, 12, "VP8X"))
            {
                width = 1 + (bytes[24] | (bytes[25] << 8) | (bytes[26] << 16));
                height = 1 + (bytes[27] | (bytes[28] << 8) | (bytes[29] << 16));
            }
            else if (Ascii(bytes, 12, "VP8 "))
            {
                width = (bytes[26] | (bytes[27] << 8)) & 0x3FFF;
                height = (bytes[28] | (bytes[29] << 8)) & 0x3FFF;
            }
            else if (Ascii(bytes, 12, "VP8L"))
            {
                var bits = bytes[21] | (bytes[22] << 8) | (bytes[23] << 16) | (bytes[24] << 24);
                width = 1 + (bits & 0x3FFF);
                height = 1 + ((bits >> 14) & 0x3FFF);
            }
        }

        private static int BigEndian(byte[] bytes, int at) =>
            (bytes[at] << 24) | (bytes[at + 1] << 16) | (bytes[at + 2] << 8) | bytes[at + 3];

        private static bool Ascii(byte[] bytes, int at, string text)
        {
            if (bytes.Length < at + text.Length)
            {
                return false;
            }

            for (var i = 0; i < text.Length; i++)
            {
                if (bytes[at + i] != text[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
