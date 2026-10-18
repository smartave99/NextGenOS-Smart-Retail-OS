using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace SmartRetail.AI.Assistant
{
    /// <summary>What a message of the owner's asks for, so that only a question about the shop's figures goes to the
    /// shop's database.</summary>
    public enum RequestKind
    {
        /// <summary>Talk, advice, ideas, plans, drafts: answered from the chat and general business sense, with no query.</summary>
        General,

        /// <summary>A question about the shop's own figures: one read-only query, and the answer from its result.</summary>
        Data,

        /// <summary>Both: the shop's figures, and what to make of them (why sales fell, what to do).</summary>
        Hybrid,

        /// <summary>Work to be kept: a project, a task, a reminder, a plan to track (the assistant's own store, never the POS).</summary>
        Work,
    }

    public sealed class RouteDecision
    {
        public RouteDecision(RequestKind kind, string reason)
        {
            Kind = kind;
            Reason = reason ?? "";
        }

        public RequestKind Kind { get; }

        /// <summary>In a few words, for the log and the tests: why this route.</summary>
        public string Reason { get; }

        /// <summary>True when the shop's database is asked first.</summary>
        public bool NeedsData => Kind == RequestKind.Data || Kind == RequestKind.Hybrid;
    }

    /// <summary>
    /// Decides, without asking an AI, where a message goes. Nothing here guesses at what the owner "really" means: a
    /// message goes to the shop's database only when it asks about the shop's figures, and a message that is only "yes"
    /// or "continue" goes where the chat was going. A message that fits neither goes to the data path, where the AI may
    /// still say that no query is needed, and is then answered as a conversation (so a wrong turn there costs a moment,
    /// not an answer).
    /// </summary>
    public static class RequestRouter
    {
        private const RegexOptions Options = RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled;

        // The English words of this routing. The words of the customer's own language, money and trade are not here: they come from its profile (ChatVocabulary).

        // What the shop's own records hold: its sales, bills, stock, people and money.
        private static readonly Regex ShopFigures = new Regex(
            @"\b(sales?|sold|selling|bills?|billing|invoices?|stock|inventory|products?|items?|profit|margins?|revenue|turnover|income|cash|expenses?|dues?|balance|payable|receivable|suppliers?|vat|tax|discounts?|returns?|refunds?|footfall|transactions?|basket|categor(y|ies)|brands?|barcodes?|reorder|expiry|expired)\b",
            Options);

        // How much, when, which: the shape of a question about figures.
        private static readonly Regex AsksForFigures = new Regex(
            @"\b(how (many|much)|total|count|average|avg|sum|top\s*\d*|best[- ]?(sell|sold|selling)\w*|worst|lowest|highest|most|least|today|yesterday|tonight|this (week|month|year|quarter)|last (week|month|year|quarter|\d+ (days|weeks|months))|past \d+ (days|weeks|months)|so far|since|during|per (day|week|month|bill)|compar\w*|versus|vs\.?|before and after|growth|trend|reorder|running out|out of stock|expiring|dead stock|slow[- ]moving|dropped|declin\w*|falling|fell|decreas\w*|increas\w*|went (up|down)|list|show me|report|figures?|numbers?)\b",
            Options);

        // Asking for advice, ideas, a plan or a draft: a conversation, not a query.
        private static readonly Regex AsksForAdvice = new Regex(
            @"\b(why|should (we|i)|do you think|what do you think|your (view|opinion|advice|suggestion)s?|how (can|do|should|could) (we|i)|ideas?|suggest\w*|advice|advise|strateg\w*|plan|plans|planning|campaigns?|advertis\w*|marketing|promot\w*|posters?|pamphlets?|flyers?|leaflets?|banners?|signage|whatsapp|google business|social media|instagram|facebook|attract\w*|visibility|pilot|drafts?|write (a|an|me)|compose|message (to|for)|checklists?|help me (decide|plan|think)|worth (it|trying|testing)|pros and cons|compare (these|both|the two|them|it)|which (should|one)|brainstorm|tips?)\b",
            Options);

        // Work that is to be kept: a project, a task, a reminder, a number the owner gives.
        private static readonly Regex AsksToKeepWork = new Regex(
            @"\b(remind me|reminders?|add (a )?(task|todo|to-do)|create (a |an )?(project|task|plan|campaign|checklist|schedule)|make (a |an )?(project|task|plan|budget|schedule|campaign)|set (up )?(a )?(reminder|campaign)|save (this|the) (plan|campaign|budget|checklist)|track (this|the) (campaign|plan|budget)|start (a |an )?(new )?(project|campaign)|(log|record|enter|note down|write down|add) (an? |the |this |our )?(expense|quote|quotation|estimate|enquir(y|ies)|leads?|footfall)\b|we (counted|got an? (quote|quotation|estimate)|received an? (quote|quotation|estimate))|mark .* (done|complete)|what happened to our|status of (our|the) (plan|campaign|project))\b",
            Options);

        /// <summary>Where <paramref name="question"/> goes, given the chat so far.</summary>
        /// <param name="words">What the customer's profile adds to the English words; null for English only.</param>
        public static RouteDecision Decide(string question, ConversationContext context, bool hasAttachments = false, ChatVocabulary words = null)
        {
            words = words ?? ChatVocabulary.Neutral;
            context = context ?? ConversationContext.Empty;
            var text = (question ?? "").Trim();

            // A photo or a voice note is read by the AI, which may need the shop's data to say what it is.
            if (hasAttachments)
            {
                return new RouteDecision(RequestKind.Data, "a photo or a voice note comes with it");
            }

            if (Continuations.IsOnlyContinuing(text, words))
            {
                var last = context.LastAnswerRoute;
                return last.HasValue
                    ? new RouteDecision(last.Value, "only carries on: it goes where the chat was going")
                    : new RouteDecision(RequestKind.General, "only carries on, and the chat has no answer before it");
            }

            var figures = ShopFigures.IsMatch(text) || words.Matches(WordKind.Figures, text);
            var asks = AsksForFigures.IsMatch(text) || words.Matches(WordKind.AsksForFigures, text);
            var advice = AsksForAdvice.IsMatch(text) || words.Matches(WordKind.Advice, text);
            var work = AsksToKeepWork.IsMatch(text) || words.Matches(WordKind.Work, text);

            if (work)
            {
                return new RouteDecision(RequestKind.Work, "asks to keep a project, a task or a reminder");
            }

            // About the shop's figures AND asking what to do or why: both.
            if (figures && asks && advice)
            {
                return new RouteDecision(RequestKind.Hybrid, "asks about the shop's figures and what to make of them");
            }

            if (figures && asks)
            {
                return new RouteDecision(RequestKind.Data, "asks for the shop's figures");
            }

            // "Compare it with pamphlets", "which should we test first", "how much should we spend on posters", "make a 30-day plan for it":
            // a conversation, with the chat as its material. Without a word about the shop's own records there is nothing to query.
            if (advice)
            {
                return new RouteDecision(RequestKind.General, "asks for advice, an idea, a plan or a draft, and not for the shop's figures");
            }

            // A question with nothing that marks it as advice goes to the data path, which may still answer that no query is needed.
            return new RouteDecision(RequestKind.Data, "not clearly advice, so the data path may answer or say that no query is needed");
        }
    }
}
