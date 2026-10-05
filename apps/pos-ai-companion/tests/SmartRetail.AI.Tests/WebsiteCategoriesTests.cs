using System;
using System.IO;
using System.Linq;
using SmartRetail.AI.Products;
using Xunit;

namespace SmartRetail.AI.Tests
{
    /// <summary>The website's categories on the shop PC: read from what the website sent, matched to the AI's first guess, chosen from
    /// by the AI from the list and nothing else, and kept with the product.</summary>
    public class WebsiteCategoriesTests : IDisposable
    {
        // What the Supabase function get_site_categories answers.
        private const string Sent = "{\"updated_at\":\"2026-10-04T09:30:00+00:00\",\"categories\":["
            + "{\"id\":\"c-groc\",\"name\":\"Grocery\",\"parentId\":null},"
            + "{\"id\":\"c-oils\",\"name\":\"Oils\",\"parentId\":\"c-groc\"},"
            + "{\"id\":\"c-home\",\"name\":\"Home & Kitchen\",\"parentId\":null},"
            + "{\"id\":\"c-bott\",\"name\":\"Bottles\",\"parentId\":\"c-home\"},"
            + "{\"id\":\"c-tea\",\"name\":\"Tea\",\"parentId\":\"c-groc\"},"
            + "{\"id\":\"c-gifts\",\"name\":\"Gifts\",\"parentId\":null},"
            + "{\"id\":\"c-gtea\",\"name\":\"Tea\",\"parentId\":\"c-gifts\"}]}";

        private readonly TempFolder _temp = new TempFolder();

        public void Dispose() => _temp.Dispose();

        private static SiteCategoryList List() => SiteCategoryList.Parse(Sent);

        [Fact]
        public void The_list_is_read_as_the_website_sent_it_main_categories_with_their_subcategories()
        {
            var list = List();

            Assert.Equal(new DateTime(2026, 10, 4, 9, 30, 0, DateTimeKind.Utc), list.UpdatedAt!.Value.ToUniversalTime());
            Assert.Equal(new[] { "Grocery", "Home & Kitchen", "Gifts" }, list.Mains.Select(c => c.Name));
            Assert.Equal(new[] { "Oils", "Tea" }, list.SubsOf("c-groc").Select(c => c.Name));
            Assert.Equal(
                new[] { "Grocery", "Grocery › Oils", "Grocery › Tea", "Home & Kitchen", "Home & Kitchen › Bottles", "Gifts", "Gifts › Tea" },
                list.Options().Select(option => option.Path));
            Assert.Equal(new[] { false, true, true, false, true, false, true }, list.Options().Select(option => option.IsSub));
        }

        [Fact]
        public void A_bare_list_is_read_too_and_whatever_cannot_be_used_is_left_out_without_stopping_the_rest()
        {
            var list = SiteCategoryList.Parse("[{\"id\":\"a\",\"name\":\" Grocery \"},{\"id\":\"a\",\"name\":\"Again\"},{\"id\":\"\",\"name\":\"No id\"},"
                + "{\"id\":\"b\",\"name\":\"  \"},{\"id\":5,\"name\":\"Number\"},{\"id\":\"c\",\"name\":\"Orphan\",\"parentId\":\"nothing\"},"
                + "{\"id\":\"d\",\"name\":\"Oils\",\"parentId\":\"a\"},{\"id\":\"e\",\"name\":\"Too deep\",\"parentId\":\"d\"},\"text\",7,null]");

            Assert.Equal(new[] { "a", "d" }, list.All.Select(c => c.Id));
            Assert.Equal("Grocery", list.Find("a")!.Name);
            Assert.Null(list.UpdatedAt);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("not json")]
        [InlineData("{}")]
        [InlineData("{\"categories\":\"x\"}")]
        [InlineData("[]")]
        public void What_cannot_be_read_is_an_empty_list_never_a_failure(string json)
        {
            var list = SiteCategoryList.Parse(json);

            Assert.True(list.IsEmpty);
            Assert.Empty(list.Options());
        }

        [Fact]
        public void A_products_place_is_a_main_category_and_one_of_its_own_subcategories()
        {
            var list = List();

            Assert.True(list.IsValid("c-groc", ""));
            Assert.True(list.IsValid("c-groc", null));
            Assert.True(list.IsValid("c-groc", "c-oils"));
            Assert.False(list.IsValid("c-home", "c-oils")); // Oils is under Grocery
            Assert.False(list.IsValid("c-oils", ""));       // a subcategory is not a main category
            Assert.False(list.IsValid("nothing", ""));
            Assert.False(list.IsValid("", ""));
            Assert.Equal("Grocery › Oils", list.PathOf("c-groc", "c-oils"));
            Assert.Equal("Grocery", list.PathOf("c-groc", ""));
            Assert.Equal("Grocery", list.PathOf("c-groc", "c-bott")); // not its subcategory: only the main category counts
            Assert.Equal("", list.PathOf("nothing", ""));
        }

        [Fact]
        public void A_category_id_of_either_kind_gives_the_place_to_put_the_product()
        {
            var list = List();

            var main = list.Resolve("c-groc")!;
            var sub = list.Resolve("c-oils")!;
            Assert.Equal(("c-groc", ""), (main.CategoryId, main.SubcategoryId));
            Assert.Equal(("c-groc", "c-oils"), (sub.CategoryId, sub.SubcategoryId));
            Assert.Null(list.Resolve("nothing"));
            Assert.Null(list.Resolve(null));
        }

        [Fact]
        public void The_list_is_kept_as_text_and_read_back_the_same()
        {
            var list = List();

            var again = SiteCategoryList.Parse(list.ToJson());

            Assert.Equal(list.All.Select(c => (c.Id, c.Name, c.ParentId)), again.All.Select(c => (c.Id, c.Name, c.ParentId)));
            Assert.Equal(list.UpdatedAt, again.UpdatedAt);
        }

        [Theory]
        [InlineData("Home & Kitchen > Bottles", "c-bott")]
        [InlineData("home and kitchen / bottle", "c-bott")]
        [InlineData("Bottles", "c-bott")]
        [InlineData("Grocery > Oils", "c-oils")]
        [InlineData("Cooking oil, Oils", "c-oils")]
        [InlineData("GROCERY", "c-groc")]
        [InlineData("Gifts › Tea", "c-gtea")]
        [InlineData("Grocery › Tea", "c-tea")]
        public void The_AIs_first_guess_names_a_category_when_its_most_specific_part_is_one(string guess, string expected)
        {
            Assert.Equal(expected, CategoryMatcher.Find(List(), false, guess)?.Id);
        }

        [Theory]
        [InlineData("Tea")]                      // two subcategories are called Tea
        [InlineData("Kitchenware > Pots")]       // nothing like it on the website
        [InlineData("")]
        [InlineData(" > ")]
        public void A_guess_that_is_not_one_category_of_the_website_names_none(string guess)
        {
            Assert.Null(CategoryMatcher.Find(List(), false, guess));
        }

        [Fact]
        public void A_part_before_the_most_specific_one_counts_only_when_asked_and_the_next_phrase_is_tried()
        {
            var list = List();

            Assert.Null(CategoryMatcher.Find(list, false, "Home & Kitchen > Pots and pans"));
            Assert.Equal("c-home", CategoryMatcher.Find(list, true, "Home & Kitchen > Pots and pans")?.Id);
            Assert.Equal("c-oils", CategoryMatcher.Find(list, false, "Pots and pans", "Grocery > Oils")?.Id);
            // Never past a part that could mean two: Tea is in Grocery and in Gifts.
            Assert.Null(CategoryMatcher.Find(list, true, "Tea"));
            Assert.Null(CategoryMatcher.Find(SiteCategoryList.Empty, true, "Grocery"));
            Assert.Null(CategoryMatcher.Find(null, true, "Grocery"));
        }

        [Fact]
        public void The_AI_is_asked_about_one_product_with_the_websites_own_list_and_no_price()
        {
            var product = new CategoryProduct
            {
                Name = "Pink Flip-Top Water Bottle, 750 ml",
                WhatItIs = "a pink plastic water bottle with a flip-top lid",
                Description = "A light bottle\nfor school and the gym.",
                ProductType = "Water bottle",
                Keywords = new System.Collections.Generic.List<string> { "bottle", "flip top", "school" },
                SuggestedCategory = "Home & Kitchen > Bottles",
                PosCategory = "HOME",
            };

            var prompt = CategoryPrompt.UserPrompt(product, List());

            Assert.Contains("Product: Pink Flip-Top Water Bottle, 750 ml", prompt);
            Assert.Contains("What it is: a pink plastic water bottle with a flip-top lid", prompt);
            Assert.Contains("Description: A light bottle for school and the gym.", prompt);
            Assert.Contains("Search words: bottle, flip top, school", prompt);
            Assert.Contains("c-bott | Home & Kitchen › Bottles", prompt);
            Assert.Contains("c-groc | Grocery", prompt);
            Assert.Contains("{\"category_id\":", prompt);
            Assert.DoesNotContain("₹", prompt);
            Assert.DoesNotContain("price", prompt, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void A_long_product_text_is_cut_and_a_missing_one_leaves_its_line_out()
        {
            var prompt = CategoryPrompt.UserPrompt(new CategoryProduct { Name = new string('N', 500), Description = new string('D', 5000) }, List());

            Assert.Contains("Product: " + new string('N', 160) + "\n", prompt);
            Assert.Contains("Description: " + new string('D', 400) + "\n", prompt);
            Assert.DoesNotContain("What it is", prompt);
            Assert.DoesNotContain("Search words", prompt);
            Assert.DoesNotContain("first guess", prompt);
        }

        [Theory]
        [InlineData("{\"category_id\": \"c-bott\"}", "c-bott")]
        [InlineData("```json\n{\"category_id\": \" c-oils \"}\n```", "c-oils")]
        [InlineData("Here it is: {\"category_id\": \"c-groc\", \"why\": \"food\"} Done.", "c-groc")]
        [InlineData("{\"category_id\": \"Grocery › Oils\"}", "c-oils")]
        [InlineData("{\"category_id\": \"home & kitchen\"}", "c-home")]
        public void An_answer_that_names_a_category_of_the_list_is_used(string answer, string expected)
        {
            Assert.Equal(expected, CategoryPrompt.ReadAnswer(answer, List())?.Id);
        }

        [Theory]
        [InlineData("{\"category_id\": \"c-made-up\"}")]
        [InlineData("{\"category_id\": \"\"}")]
        [InlineData("{\"category_id\": null}")]
        [InlineData("{\"category_id\": 7}")]
        [InlineData("{\"category\": \"c-bott\"}")]
        [InlineData("{\"category_id\": \"Pots\"}")]
        [InlineData("c-bott")]
        [InlineData("")]
        [InlineData("{not json}")]
        public void An_answer_that_is_not_on_the_list_is_never_used(string answer)
        {
            Assert.Null(CategoryPrompt.ReadAnswer(answer, List()));
            Assert.Null(CategoryPrompt.ReadAnswer("{\"category_id\": \"c-bott\"}", SiteCategoryList.Empty));
        }

        [Fact]
        public void A_choice_remembers_where_the_product_goes_and_whether_the_websites_list_still_has_it()
        {
            var list = List();
            var now = new DateTime(2026, 10, 4, 11, 0, 0);

            var sub = WebsiteCategoryChoice.Of(list, "c-oils", WebsiteCategoryChoice.ByAi, now)!;
            var main = WebsiteCategoryChoice.Of(list, "c-home", WebsiteCategoryChoice.ByOwner, now)!;

            Assert.Equal(("c-groc", "c-oils", "ai", "Grocery › Oils"), (sub.CategoryId, sub.SubcategoryId, sub.Source, sub.Path));
            Assert.Equal(("c-home", "", "owner", "Home & Kitchen"), (main.CategoryId, main.SubcategoryId, main.Source, main.Path));
            Assert.True(sub.IsValidIn(list));
            Assert.Null(WebsiteCategoryChoice.Of(list, "nothing", WebsiteCategoryChoice.ByAi, now));

            // The website changed: Oils is gone, or Grocery was deleted.
            var changed = SiteCategoryList.Parse("[{\"id\":\"c-groc\",\"name\":\"Grocery\"},{\"id\":\"c-home\",\"name\":\"Home\"}]");
            Assert.False(sub.IsValidIn(changed));
            Assert.True(main.IsValidIn(changed));
            Assert.False(sub.IsValidIn(SiteCategoryList.Empty));
            Assert.False(sub.IsValidIn(null!));
        }

        [Fact]
        public void The_choice_is_kept_with_the_product_and_the_AIs_goes_with_its_listing_but_the_owners_stays()
        {
            var store = new ProductPhotoStore(Path.Combine(_temp.Path, "Product photos"));
            var now = new DateTime(2026, 10, 4, 10, 0, 0);
            string Raw(int id, string name)
            {
                using (var photo = new MemoryStream(System.Text.Encoding.UTF8.GetBytes("photo " + id)))
                {
                    return store.SaveRaw(id, photo, ".jpg", now, name);
                }
            }

            foreach (var (id, source) in new[] { (1193, WebsiteCategoryChoice.ByAi), (1194, WebsiteCategoryChoice.ByOwner) })
            {
                var set = store.StartSet(id, id.ToString(), "Bottle " + id, "Home", new[] { Raw(id, "Bottle " + id) }, now);
                var listing = ProductListing.Parse(ProductListingTests.Answer);
                listing.SetId = set.Id;
                store.SaveListing(id, listing, now);
                store.SaveWebsiteCategory(id, WebsiteCategoryChoice.Of(List(), "c-bott", source, now));
            }

            var kept = store.Load(1193)!.WebsiteCategory!;
            Assert.Equal(("c-home", "c-bott", "ai", "Home & Kitchen › Bottles"), (kept.CategoryId, kept.SubcategoryId, kept.Source, kept.Path));

            foreach (var id in new[] { 1193, 1194 })
            {
                store.RemoveSet(id, store.Load(id)!.LatestSet!.Id);
            }

            Assert.Null(store.Load(1193)!.WebsiteCategory);
            Assert.Equal("owner", store.Load(1194)!.WebsiteCategory!.Source);

            store.SaveWebsiteCategory(1194, null!);
            Assert.Null(store.Load(1194)!.WebsiteCategory);
            store.SaveWebsiteCategory(9999, WebsiteCategoryChoice.Of(List(), "c-bott", "ai", now)); // no such product: nothing happens
            Assert.Null(store.Load(9999));
        }

        [Fact]
        public void The_job_has_its_own_name_and_a_light_thinking_level()
        {
            Assert.Equal("Website category", SmartRetail.AI.Settings.AiJobs.Name(SmartRetail.AI.Settings.AiJob.WebsiteCategory));
            Assert.Equal("low", SmartRetail.AI.Settings.AiJobs.RecommendedEffort(SmartRetail.AI.Settings.AiJob.WebsiteCategory));
        }
    }
}
