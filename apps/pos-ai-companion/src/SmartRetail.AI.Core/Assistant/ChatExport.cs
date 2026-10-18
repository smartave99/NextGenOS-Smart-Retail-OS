using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using SmartRetail.AI.Data;
using SmartRetail.AI.Memory;

namespace SmartRetail.AI.Assistant
{
    /// <summary>
    /// A chat as plain text, to copy or save: who said what, and when. As in the past chats, it is the words only: phone numbers and e-mail addresses are hidden,
    /// a result table is named in words ("A table of 12 rows: ..."), and a photo or voice note is named, not included. A problem the app reported is marked as one.
    /// </summary>
    public static class ChatExport
    {
        public static string ToText(string title, IReadOnlyList<ChatMessage> messages)
        {
            var all = messages ?? new ChatMessage[0];
            var text = new StringBuilder();
            text.AppendLine(string.IsNullOrWhiteSpace(title) ? "Chat" : title.Trim());
            if (all.Count > 0)
            {
                text.AppendLine(all[0].At.ToString("d MMMM yyyy, HH:mm", CultureInfo.InvariantCulture));
            }

            text.AppendLine();
            for (var i = 0; i < all.Count; i++)
            {
                var message = all[i];
                var words = ChatMessage.Words(all, i);
                var table = ChatHistory.Describe(message.Table);
                if (table != null)
                {
                    words = words.Length == 0 ? "[" + table + "]" : words + " [" + table + "]";
                }

                if (words.Length == 0)
                {
                    continue;
                }

                var who = message.Role == ChatRole.Owner ? "You" : message.IsProblem ? "Problem" : "Assistant" + (string.IsNullOrWhiteSpace(message.Source) ? "" : " (" + message.Source + ")");
                text.AppendLine(who + ", " + message.At.ToString("HH:mm", CultureInfo.InvariantCulture) + ":");
                text.AppendLine(PiiMasker.MaskText(words));
                text.AppendLine();
            }

            return text.ToString().TrimEnd() + Environment.NewLine;
        }
    }
}
