using System.Collections.Generic;
using System.Numerics;
using Xunit;

namespace NextGenOS.Tax.Tests
{
    /// <summary>The total of a full tax invoice written in words (country-packs/SPEC.md section 4d): the words come from the pack, the counting is the same everywhere.</summary>
    public class NumberWordsTests
    {
        private static CurrencyInfo India() => PackCatalog.Get("IN").Currency;

        private static CurrencyInfo Dollars() => new CurrencyInfo
        {
            Code = "USD", Symbol = "$", Decimals = 2, Grouping = "standard",
            Words = new CurrencyWords { Major = new List<string> { "dollar", "dollars" }, Minor = new List<string> { "cent", "cents" } },
        };

        [Fact]
        public void The_India_pack_carries_the_words_and_nothing_else_does_the_counting_for_it()
        {
            var words = India().Words;
            Assert.NotNull(words);
            Assert.Equal(new[] { "thousand", "lakh", "crore" }, words.Scales);
            Assert.Equal("only", words.Ending);
        }

        [Theory]
        [InlineData(0L, "Zero rupees only")]
        [InlineData(100L, "One rupee only")]
        [InlineData(1L, "Zero rupees and one paisa only")]
        [InlineData(2L, "Zero rupees and two paise only")]
        [InlineData(11900L, "One hundred nineteen rupees only")]
        [InlineData(100000L, "One thousand rupees only")]
        [InlineData(125050L, "One thousand two hundred fifty rupees and fifty paise only")]
        [InlineData(10000000L, "One lakh rupees only")]
        [InlineData(123456750L, "Twelve lakh thirty-four thousand five hundred sixty-seven rupees and fifty paise only")]
        [InlineData(1000000000L, "One crore rupees only")]
        [InlineData(11000000000L, "Eleven crore rupees only")]
        [InlineData(100000000000L, "One hundred crore rupees only")]
        [InlineData(1000000000000L, "One thousand crore rupees only")]
        [InlineData(10000000000000L, "Ten thousand crore rupees only")]
        public void India_counts_in_thousands_lakhs_and_crores(long minor, string expected)
        {
            Assert.Equal(expected, NumberWords.AmountInWords(new BigInteger(minor), India()));
        }

        [Theory]
        [InlineData(0L, "Zero dollars")]
        [InlineData(101L, "One dollar and one cent")]
        [InlineData(2100L, "Twenty-one dollars")]
        [InlineData(123456789L, "One million two hundred thirty-four thousand five hundred sixty-seven dollars and eighty-nine cents")]
        [InlineData(100000000000L, "One billion dollars")]
        [InlineData(100000000000000L, "One trillion dollars")]
        [InlineData(100000000000000000L, "One thousand trillion dollars")]
        public void Other_countries_count_in_thousands_millions_and_billions(long minor, string expected)
        {
            Assert.Equal(expected, NumberWords.AmountInWords(new BigInteger(minor), Dollars()));
        }

        [Fact]
        public void A_pack_may_name_its_own_steps_and_words_between_and_at_the_end()
        {
            var c = Dollars();
            c.Words.Scales = new List<string> { "K", "M" };
            c.Words.Join = "with";
            c.Words.Ending = "exactly";
            Assert.Equal("Two M three hundred K dollars with five cents exactly", NumberWords.AmountInWords(new BigInteger(2300000 * 100 + 5), c));
        }

        [Fact]
        public void A_currency_without_decimals_has_no_small_part()
        {
            var yen = new CurrencyInfo { Code = "JPY", Symbol = "¥", Decimals = 0, Grouping = "standard", Words = new CurrencyWords { Major = new List<string> { "yen", "yen" } } };
            Assert.Equal("One thousand five hundred yen", NumberWords.AmountInWords(new BigInteger(1500), yen));
            Assert.Equal("One yen", NumberWords.AmountInWords(BigInteger.One, yen));
        }

        [Fact]
        public void A_negative_amount_says_minus()
        {
            Assert.Equal("Minus five hundred rupees only", NumberWords.AmountInWords(new BigInteger(-50000), India()));
        }

        [Fact]
        public void No_words_are_made_up_when_the_pack_does_not_give_them()
        {
            var plain = Dollars();
            plain.Words = null;
            Assert.Null(NumberWords.AmountInWords(new BigInteger(100), plain));
            Assert.Null(NumberWords.AmountInWords(new BigInteger(100), null));

            // grouping "indian" needs the names of its steps
            var noScales = India();
            var copy = new CurrencyInfo { Code = noScales.Code, Symbol = noScales.Symbol, Decimals = noScales.Decimals, Grouping = "indian", Words = new CurrencyWords { Major = noScales.Words.Major, Minor = noScales.Words.Minor } };
            Assert.Null(NumberWords.AmountInWords(new BigInteger(100), copy));

            // a small part cannot be said without the name of the small unit
            var noMinor = Dollars();
            noMinor.Words.Minor = null;
            Assert.Null(NumberWords.AmountInWords(new BigInteger(150), noMinor));
            Assert.Equal("One dollar", NumberWords.AmountInWords(new BigInteger(100), noMinor));
        }

        [Fact]
        public void Every_pack_that_gives_words_gives_an_answer_for_a_small_and_a_large_amount()
        {
            var tried = 0;
            foreach (var pack in PackCatalog.All())
            {
                if (pack.Currency.Words == null) continue;
                tried++;
                Assert.False(string.IsNullOrEmpty(NumberWords.AmountInWords(new BigInteger(12345), pack.Currency)), pack.Country);
                Assert.False(string.IsNullOrEmpty(NumberWords.AmountInWords(new BigInteger(987654321012345L), pack.Currency)), pack.Country);
            }
            Assert.True(tried >= 1);
        }
    }
}
