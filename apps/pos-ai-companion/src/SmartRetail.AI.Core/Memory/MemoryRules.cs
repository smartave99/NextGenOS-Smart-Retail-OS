using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SmartRetail.AI.Memory
{
    /// <summary>
    /// What the assistant's memory may hold and how it changes, after Hermes Agent's design: two small curated parts
    /// with fixed limits (so every conversation can carry all of it), entries added, replaced or removed by matching
    /// text, exact duplicates refused, and every entry checked before it is kept, because it goes into every prompt.
    /// </summary>
    public static class MemoryRules
    {
        /// <summary>Hermes Agent's limits: about 800 and 500 tokens.</summary>
        public const int ShopLimit = 2200;

        public const int OwnerLimit = 1375;

        public const int EntryLimit = 300;

        private static readonly Regex LooksLikeAnInstruction = new Regex(
            @"ignore\s+(all\s+|the\s+|any\s+)?(previous|prior|above|earlier)|disregard\s+(all|the|previous|prior|any)|forget\s+(all|everything|your)\s|system\s*prompt|you\s+are\s+now|developer\s+mode|jailbreak|act\s+as\s+(an?\s+)?(ai|assistant|system)|<\||\|>|```|begin\s+(system|prompt)|api[\s_-]?key|password|secret\s+key|run\s+this\s+command|curl\s+|powershell",
            RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private static readonly Regex Link = new Regex(@"https?://|www\.", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private static readonly Regex Email = new Regex(@"[\w.+-]+@[\w-]+\.[\w.]+", RegexOptions.Compiled);

        // Seven or more digits, with a single space or hyphen allowed between them: phone and account numbers.
        private static readonly Regex LongNumber = new Regex(@"\d(?:[ -]?\d){6,}", RegexOptions.Compiled);

        private static readonly Regex Spaces = new Regex(@"\s+", RegexOptions.Compiled);

        public static int Limit(MemoryPart part) => part == MemoryPart.Shop ? ShopLimit : OwnerLimit;

        /// <summary>Characters used by a part: its entries and a separator each.</summary>
        public static int Used(MemoryBook book, MemoryPart part) =>
            book.Entries(part).Sum(e => e.Text.Length + 1);

        /// <summary>One line, trimmed, without a leading bullet.</summary>
        public static string Normalize(string text)
        {
            var line = Spaces.Replace(text ?? "", " ").Trim();
            while (line.Length > 0 && (line[0] == '-' || line[0] == '*' || line[0] == '•'))
            {
                line = line.Substring(1).TrimStart();
            }

            return line;
        }

        /// <summary>Why <paramref name="text"/> cannot be kept, or null when it can.</summary>
        public static string Check(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return "There is nothing to remember.";
            }

            if (text.Any(IsHidden))
            {
                return "It has hidden characters.";
            }

            var line = Normalize(text);
            if (line.Length > EntryLimit)
            {
                return $"It is too long: keep one fact to under {EntryLimit} characters.";
            }

            if (LooksLikeAnInstruction.IsMatch(line))
            {
                return "It reads like an instruction to the AI, not a fact about the shop or the owner.";
            }

            if (Link.IsMatch(line))
            {
                return "Memory does not keep links.";
            }

            if (Email.IsMatch(line))
            {
                return "Memory does not keep e-mail addresses.";
            }

            if (LongNumber.IsMatch(line))
            {
                return "Memory does not keep phone or account numbers.";
            }

            return null;
        }

        /// <summary>
        /// Applies <paramref name="change"/> to <paramref name="book"/>, or says why it cannot be: a problem with the
        /// text, a duplicate, no room (merge or remove entries first), or old text that does not pick out exactly one
        /// entry. On success the change's <see cref="MemoryChange.Before"/> keeps what it replaced or removed.
        /// </summary>
        public static string Apply(MemoryBook book, MemoryChange change, DateTime now)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            if (change == null)
            {
                throw new ArgumentNullException(nameof(change));
            }

            var entries = book.Entries(change.Part);
            var text = Normalize(change.NewText);
            if (change.Op != MemoryOp.Remove)
            {
                var problem = Check(change.NewText);
                if (problem != null)
                {
                    return problem;
                }
            }

            var index = -1;
            if (change.Op != MemoryOp.Add)
            {
                var old = Normalize(change.OldText);
                if (old.Length == 0)
                {
                    return "It does not say which entry to change.";
                }

                var matches = entries
                    .Select((entry, i) => (entry, i))
                    .Where(x => x.entry.Text.IndexOf(old, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
                if (matches.Count == 0)
                {
                    return $"No entry says \"{old}\".";
                }

                if (matches.Count > 1)
                {
                    return $"More than one entry says \"{old}\": pick out just one.";
                }

                index = matches[0].i;
            }

            if (change.Op != MemoryOp.Remove
                && entries.Where((entry, i) => i != index).Any(entry => string.Equals(entry.Text, text, StringComparison.OrdinalIgnoreCase)))
            {
                return "It is remembered already.";
            }

            var used = Used(book, change.Part) - (index >= 0 ? entries[index].Text.Length + 1 : 0);
            if (change.Op != MemoryOp.Remove && used + text.Length + 1 > Limit(change.Part))
            {
                return string.Format(CultureInfo.InvariantCulture,
                    "Memory is full ({0:N0} of {1:N0} characters): merge or remove entries first.", used, Limit(change.Part));
            }

            switch (change.Op)
            {
                case MemoryOp.Add:
                    entries.Add(new MemoryEntry { Text = text, Added = now, Source = change.Source ?? "" });
                    break;
                case MemoryOp.Replace:
                    change.Before = entries[index].Text;
                    entries[index] = new MemoryEntry { Text = text, Added = now, Source = change.Source ?? "" };
                    break;
                case MemoryOp.Remove:
                    change.Before = entries[index].Text;
                    entries.RemoveAt(index);
                    break;
            }

            return null;
        }

        /// <summary>
        /// Checks the entries of a book as read from its file, which may have been copied or edited by hand: an entry
        /// that breaks the rules, repeats another, or does not fit in its part's limit is moved to
        /// <see cref="MemoryBook.SetAside"/>, so it never reaches a prompt. Returns how many were set aside.
        /// </summary>
        public static int Screen(MemoryBook book, DateTime now)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            var count = 0;
            foreach (var part in new[] { MemoryPart.Shop, MemoryPart.Owner })
            {
                var entries = book.Entries(part);
                var kept = new System.Collections.Generic.List<MemoryEntry>();
                var used = 0;
                foreach (var entry in entries)
                {
                    var text = Normalize(entry.Text);
                    var problem = Check(entry.Text)
                        ?? (kept.Any(k => string.Equals(k.Text, text, StringComparison.OrdinalIgnoreCase)) ? "It is remembered already." : null)
                        ?? (used + text.Length + 1 > Limit(part) ? "It did not fit in memory's limit." : null);
                    if (problem == null)
                    {
                        entry.Text = text;
                        kept.Add(entry);
                        used += text.Length + 1;
                        continue;
                    }

                    count++;
                    if (!book.SetAside.Any(s => s.Part == part && s.Text == entry.Text))
                    {
                        book.SetAside.Add(new SetAsideEntry { Part = part, Text = entry.Text, Reason = problem, At = now });
                    }
                }

                entries.Clear();
                entries.AddRange(kept);
            }

            return count;
        }

        /// <summary>The change that takes <paramref name="saved"/> back.</summary>
        public static MemoryChange Reverse(MemoryChange saved)
        {
            if (saved == null)
            {
                throw new ArgumentNullException(nameof(saved));
            }

            switch (saved.Op)
            {
                case MemoryOp.Add:
                    return new MemoryChange { Op = MemoryOp.Remove, Part = saved.Part, OldText = Normalize(saved.NewText), Source = "Undo" };
                case MemoryOp.Replace:
                    return new MemoryChange { Op = MemoryOp.Replace, Part = saved.Part, OldText = Normalize(saved.NewText), NewText = saved.Before, Source = "Undo" };
                default:
                    return new MemoryChange { Op = MemoryOp.Add, Part = saved.Part, NewText = saved.Before, Source = "Undo" };
            }
        }

        /// <summary>
        /// What goes into a conversation's prompt: all of memory, taken once when it starts (Hermes' frozen snapshot),
        /// or an empty string when there is nothing yet.
        /// </summary>
        public static string Snapshot(MemoryBook book)
        {
            if (book == null || (book.Shop.Count == 0 && book.Owner.Count == 0))
            {
                return "";
            }

            var text = new StringBuilder();
            text.Append("What you remember from earlier conversations and from what the shop tried (use it where it helps; the shop's figures always come from the POS):\n");
            if (book.Shop.Count > 0)
            {
                text.Append("About the shop:\n");
                foreach (var entry in book.Shop)
                {
                    text.Append("- ").Append(entry.Text).Append('\n');
                }
            }

            if (book.Owner.Count > 0)
            {
                text.Append("About the owner:\n");
                foreach (var entry in book.Owner)
                {
                    text.Append("- ").Append(entry.Text).Append('\n');
                }
            }

            return text.ToString();
        }

        private static bool IsHidden(char c) =>
            (c < ' ' && c != '\n' && c != '\r' && c != '\t')
            || (c >= '​' && c <= '‏')
            || (c >= '‪' && c <= '‮')
            || (c >= '⁠' && c <= '⁤')
            || c == '﻿';
    }
}
