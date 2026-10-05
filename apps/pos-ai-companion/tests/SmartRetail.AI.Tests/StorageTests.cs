using System;
using System.IO;
using SmartRetail.AI.Products;
using SmartRetail.AI.Storage;
using Xunit;

namespace SmartRetail.AI.Tests
{
    public class StorageTests : IDisposable
    {
        private readonly TempFolder _temp = new TempFolder();

        public void Dispose() => _temp.Dispose();

        private string Folder(string name) => Path.Combine(_temp.Path, name);

        /// <summary>A data folder with one product's photos and one growth plan.</summary>
        private string DataFolderWithData(string name)
        {
            var root = Folder(name);
            var product = Path.Combine(DataFolders.Products(root), "1006 Sunflower Oil 1 L");
            Directory.CreateDirectory(product);
            File.WriteAllBytes(Path.Combine(product, "white-20260924-100000.png"), ProductPhotoTests.Png);
            File.WriteAllText(Path.Combine(product, "product.json"), "{}");
            Directory.CreateDirectory(DataFolders.Plans(root));
            File.WriteAllText(Path.Combine(DataFolders.Plans(root), "plan-20260924-100000.md"), "# Plan");
            return root;
        }

        [Fact]
        public void The_default_folder_is_used_until_one_is_chosen_and_the_choice_is_kept()
        {
            var store = StorageSettingsStore.Beside(Path.Combine(_temp.Path, "settings.json"));
            Assert.Equal(Path.Combine(_temp.Path, "storage.json"), store.FilePath);
            Assert.Equal(DataFolders.Default, DataFolders.Resolve(store.Load()));

            store.Save(new StorageSettings { DataFolder = Folder("shop data") });

            Assert.Equal(Folder("shop data"), DataFolders.Resolve(store.Load()));
            File.WriteAllText(store.FilePath, "{ broken");
            Assert.Equal(DataFolders.Default, DataFolders.Resolve(store.Load()));
        }

        [Fact]
        public void A_new_folder_is_checked_before_it_is_used()
        {
            var current = DataFolderWithData("current");
            File.WriteAllText(Folder("a file"), "not a folder");

            Assert.Equal("Choose a folder.", DataFolderMover.Check(current, " ").Problem);
            Assert.Contains("full path", DataFolderMover.Check(current, "photos").Problem);
            Assert.Contains("not a network folder", DataFolderMover.Check(current, @"\\server\share").Problem);
            Assert.Contains("outside the current data folder", DataFolderMover.Check(current, Path.Combine(DataFolders.Products(current), "inside")).Problem);
            Assert.Contains("Cannot write to this folder", DataFolderMover.Check(current, Path.Combine(Folder("a file"), "sub")).Problem);
            Assert.True(DataFolderMover.Check(current, current + Path.DirectorySeparatorChar).IsCurrent);

            var check = DataFolderMover.Check(current, Folder("new place") + Path.DirectorySeparatorChar + "data");
            Assert.True(check.Ok, check.Problem);
            Assert.Equal(Path.Combine(Folder("new place"), "data"), check.Folder);
            Assert.Equal(DataFolders.Size(current).Bytes, check.NeededBytes);
            Assert.True(check.FreeBytes > 0);
            Assert.False(Directory.Exists(Folder("new place")), "checking leaves no folder behind");
        }

        [Fact]
        public void Moving_copies_everything_then_switches_then_deletes_the_old_copies()
        {
            var current = DataFolderWithData("current");
            var target = Folder("D drive data");
            var before = DataFolders.Size(current);
            var switched = false;

            var move = DataFolderMover.Move(current, target, () =>
            {
                // At the switch every file is in both places.
                Assert.Equal(before, DataFolders.Size(target));
                Assert.Equal(before, DataFolders.Size(current));
                switched = true;
            });

            Assert.True(switched);
            Assert.Equal(before.Files, move.Files);
            Assert.Equal(before.Bytes, move.Bytes);
            Assert.Null(move.Warning);
            Assert.Equal((0, 0L), DataFolders.Size(current));
            Assert.False(DataFolders.HasData(current));
            Assert.Equal(ProductPhotoTests.Png, File.ReadAllBytes(Path.Combine(DataFolders.Products(target), "1006 Sunflower Oil 1 L", "white-20260924-100000.png")));

            // The photo store follows the chosen folder at once.
            var chosen = current;
            var store = new ProductPhotoStore(() => DataFolders.Products(chosen));
            Assert.Null(store.PathOf(1006, "white-20260924-100000.png"));
            chosen = target;
            Assert.NotNull(store.PathOf(1006, "white-20260924-100000.png"));
        }

        [Fact]
        public void A_failed_switch_leaves_everything_as_it_was()
        {
            var current = DataFolderWithData("current");
            var target = Folder("new");
            var before = DataFolders.Size(current);

            Assert.Throws<IOException>(() => DataFolderMover.Move(current, target, () => throw new IOException("disk full")));

            Assert.Equal(before, DataFolders.Size(current));
            Assert.False(DataFolders.HasData(target));
        }

        [Fact]
        public void A_folder_that_already_has_data_is_used_as_it_is_and_is_never_merged_into()
        {
            var current = DataFolderWithData("current");
            var other = DataFolderWithData("other");

            var check = DataFolderMover.Check(current, other);

            Assert.True(check.Ok, check.Problem);
            Assert.True(check.HasData);
            Assert.Equal(0, check.NeededBytes);
            Assert.Throws<IOException>(() => DataFolderMover.Move(current, other, null));
            Assert.True(DataFolders.HasData(current));
        }

        [Theory]
        [InlineData(0, "0 bytes")]
        [InlineData(1536, "2 KB")]
        [InlineData(5L * 1024 * 1024, "5 MB")]
        [InlineData(12L * 1024 * 1024 * 1024 + 400L * 1024 * 1024, "12.4 GB")]
        [InlineData(250L * 1024 * 1024 * 1024, "250 GB")]
        public void Sizes_read_as_people_say_them(long bytes, string text)
        {
            Assert.Equal(text, DataFolderMover.Describe(bytes));
        }
    }
}
