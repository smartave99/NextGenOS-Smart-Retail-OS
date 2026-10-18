using System;
using System.IO;
using System.Linq;
using SmartRetail.AI.Assistant;

namespace SmartRetail.AI.Work
{
    /// <summary>
    /// What a chat does with the work its AI suggested (a project, a task, a reminder): proposes it to the assistant's own plan, and adds to the answer what really
    /// happened (waiting for the owner, saved, or not saved and why), so that the chat never says more than is true. The same for the chat on the shop's database and
    /// the chat on the demo shop.
    /// </summary>
    public static class WorkKeeper
    {
        /// <summary>The plan in words, for the prompts; empty when there is none or it cannot be read now.</summary>
        public static string PlanText(IWork work, DateTime now)
        {
            if (work == null)
            {
                return "";
            }

            try
            {
                return WorkRules.ForPrompt(work.Load(), now);
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                return "";
            }
        }

        /// <summary>
        /// Proposes <paramref name="answer"/>'s suggested work to <paramref name="work"/> and changes the answer's words to say what came of it.
        /// Returns the id of the proposal that waits or was saved; null when none.
        /// </summary>
        public static string Keep(AssistantAnswer answer, IWork work, bool askFirst)
        {
            var suggestion = answer?.Work;
            if (suggestion == null)
            {
                return null;
            }

            if (work == null)
            {
                if (suggestion.Changes.Count > 0)
                {
                    answer.Answer = (answer.Answer ?? "").TrimEnd() + "\n\n**Not saved:** this chat has no plan to keep them in. Suggested entries:\n"
                        + string.Join("\n", suggestion.Changes.Select(c => "- " + WorkExtraction.Line(c)));
                }

                return null;
            }

            WorkProposal proposal = null;
            try
            {
                if (suggestion.Changes.Count > 0)
                {
                    proposal = work.Propose(suggestion.Changes, answer.Answer, askFirst);
                }
            }
            catch (InvalidOperationException ex)
            {
                // E.g. the data folder is being moved.
                answer.Answer = (answer.Answer ?? "").TrimEnd() + "\n\n**Not saved:** " + ex.Message;
                return null;
            }
            catch (IOException ex)
            {
                answer.Answer = (answer.Answer ?? "").TrimEnd() + "\n\n**Not saved:** the plan could not be written (" + ex.Message + ").";
                return null;
            }

            answer.Answer = (answer.Answer ?? "").TrimEnd() + WorkExtraction.Note(proposal, askFirst, suggestion.Unreadable);
            return proposal != null && proposal.Changes.Count > 0 ? proposal.Id : null;
        }
    }
}
