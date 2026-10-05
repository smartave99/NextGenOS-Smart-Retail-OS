using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRetail.AI.Data
{
    public sealed class SqlGuardResult
    {
        private SqlGuardResult(bool isAllowed, string reason, string sql)
        {
            IsAllowed = isAllowed;
            Reason = reason;
            Sql = sql;
        }

        public bool IsAllowed { get; }

        /// <summary>Why the query was refused; worded so it can be sent back to the AI to fix the query.</summary>
        public string Reason { get; }

        /// <summary>The statement to run: comments and trailing semicolons removed.</summary>
        public string Sql { get; }

        internal static SqlGuardResult Allow(string sql) => new SqlGuardResult(true, null, sql);

        internal static SqlGuardResult Reject(string reason) => new SqlGuardResult(false, reason, null);
    }

    /// <summary>Accepts only a single read-only SELECT (optionally with CTEs) over approved tables.
    /// It is one layer of protection; the database login the assistant uses should also be read-only.</summary>
    public sealed class SqlGuard
    {
        private const int MaxLength = 20000;

        private static readonly HashSet<string> ForbiddenKeywords = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "INSERT", "UPDATE", "DELETE", "MERGE", "DROP", "ALTER", "CREATE", "TRUNCATE", "EXEC", "EXECUTE",
            "GRANT", "REVOKE", "DENY", "BACKUP", "RESTORE", "SHUTDOWN", "DBCC", "KILL", "RECONFIGURE",
            "OPENROWSET", "OPENQUERY", "OPENDATASOURCE", "OPENXML", "BULK", "INTO", "WAITFOR", "USE",
            "DECLARE", "SET", "GO", "RAISERROR", "THROW", "CHECKPOINT", "READTEXT", "WRITETEXT", "UPDATETEXT",
            "TRAN", "TRANSACTION", "COMMIT", "ROLLBACK", "SAVE", "REVERT", "SETUSER", "INFORMATION_SCHEMA",

            // Locking hints: a report must never hold locks that would stall billing in the POS.
            "UPDLOCK", "XLOCK", "TABLOCK", "TABLOCKX", "HOLDLOCK", "PAGLOCK", "ROWLOCK", "SERIALIZABLE",
            "REPEATABLEREAD", "READCOMMITTEDLOCK",
        };

        private readonly HashSet<string> _allowedTables;
        private readonly HashSet<string> _knownTables;
        private readonly HashSet<string> _deniedTables;
        private readonly Func<string, bool> _isDeniedColumn;

        public SqlGuard(IEnumerable<string> allowedTables, IEnumerable<string> knownTables, IEnumerable<string> deniedTables, Func<string, bool> isDeniedColumn)
        {
            _allowedTables = new HashSet<string>(allowedTables, StringComparer.OrdinalIgnoreCase);
            _knownTables = new HashSet<string>(knownTables, StringComparer.OrdinalIgnoreCase);
            _deniedTables = new HashSet<string>(deniedTables, StringComparer.OrdinalIgnoreCase);
            _isDeniedColumn = isDeniedColumn ?? (name => false);
        }

        public SqlGuardResult Check(string sql)
        {
            if (string.IsNullOrWhiteSpace(sql))
            {
                return SqlGuardResult.Reject("The query is empty.");
            }

            if (sql.Length > MaxLength)
            {
                return SqlGuardResult.Reject("The query is too long.");
            }

            if (!SqlLexer.TryTokenize(sql, out var tokens, out var withoutComments, out var lexError))
            {
                return SqlGuardResult.Reject(lexError);
            }

            while (tokens.Count > 0 && tokens[tokens.Count - 1].Is(";"))
            {
                tokens.RemoveAt(tokens.Count - 1);
            }

            withoutComments = withoutComments.Trim().TrimEnd(';').Trim();
            if (tokens.Count == 0)
            {
                return SqlGuardResult.Reject("The query is empty.");
            }

            if (tokens.Any(t => t.Is(";")))
            {
                return SqlGuardResult.Reject("Only one SQL statement is allowed.");
            }

            if (!tokens[0].IsWord("SELECT") && !tokens[0].IsWord("WITH"))
            {
                return SqlGuardResult.Reject("Only SELECT queries are allowed (the query must start with SELECT or WITH).");
            }

            var problem = CheckWords(tokens) ?? CheckMultiPartNames(tokens);
            if (problem != null)
            {
                return SqlGuardResult.Reject(problem);
            }

            var cteNames = ReadCteNames(tokens, out var cteProblem);
            if (cteProblem != null)
            {
                return SqlGuardResult.Reject(cteProblem);
            }

            problem = CheckTableReferences(tokens, cteNames);
            return problem != null ? SqlGuardResult.Reject(problem) : SqlGuardResult.Allow(withoutComments);
        }

        private string CheckWords(List<SqlToken> tokens)
        {
            for (var i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];
                if (token.Kind == SqlTokenKind.Symbol && token.Text == "::")
                {
                    return "The :: syntax is not allowed.";
                }

                // NEXT VALUE FOR advances a sequence, a write hidden inside a SELECT.
                if (token.IsWord("NEXT") && i + 2 < tokens.Count && tokens[i + 1].IsWord("VALUE") && tokens[i + 2].IsWord("FOR"))
                {
                    return "NEXT VALUE FOR is not allowed: it changes a sequence.";
                }

                if (token.Kind != SqlTokenKind.Word && token.Kind != SqlTokenKind.QuotedIdentifier)
                {
                    continue;
                }

                var name = token.Text;
                if (token.Kind == SqlTokenKind.Word)
                {
                    if (ForbiddenKeywords.Contains(name))
                    {
                        return "\"" + name.ToUpperInvariant() + "\" is not allowed: only read-only SELECT queries can run.";
                    }

                    if (name.StartsWith("@", StringComparison.Ordinal) || name.StartsWith("#", StringComparison.Ordinal))
                    {
                        return "Variables and temporary tables (" + name + ") are not allowed.";
                    }
                }

                if (name.StartsWith("xp_", StringComparison.OrdinalIgnoreCase)
                    || name.StartsWith("sp_", StringComparison.OrdinalIgnoreCase)
                    || name.StartsWith("fn_", StringComparison.OrdinalIgnoreCase))
                {
                    return "System procedures and functions (" + name + ") are not allowed.";
                }

                if (name.StartsWith("sys", StringComparison.OrdinalIgnoreCase) && !_knownTables.Contains(name))
                {
                    return "System tables and views (" + name + ") are not allowed.";
                }

                if (_deniedTables.Contains(name))
                {
                    return "The table " + name + " is not available to the assistant.";
                }

                if (_isDeniedColumn(name))
                {
                    return "The column " + name + " is private and not available to the assistant.";
                }
            }

            return null;
        }

        /// <summary>Blocks database- and server-qualified names (db.schema.table), keeping schema.table.</summary>
        private static string CheckMultiPartNames(List<SqlToken> tokens)
        {
            for (var i = 0; i + 1 < tokens.Count; i++)
            {
                if (tokens[i].Is(".") && tokens[i + 1].Is("."))
                {
                    return "Names with \"..\" (another database) are not allowed.";
                }
            }

            for (var i = 0; i + 4 < tokens.Count; i++)
            {
                if (tokens[i].IsName && tokens[i + 1].Is(".") && tokens[i + 2].IsName && tokens[i + 3].Is(".") && tokens[i + 4].IsName)
                {
                    return "Three-part names such as " + tokens[i].Text + "." + tokens[i + 2].Text + "." + tokens[i + 4].Text
                        + " are not allowed; refer to columns as alias.column.";
                }
            }

            return null;
        }

        private static HashSet<string> ReadCteNames(List<SqlToken> tokens, out string problem)
        {
            problem = null;
            var names = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            if (!tokens[0].IsWord("WITH"))
            {
                return names;
            }

            var i = 1;
            while (true)
            {
                if (i >= tokens.Count || !tokens[i].IsName)
                {
                    problem = "Could not read the WITH clause.";
                    return names;
                }

                names.Add(tokens[i].Text);
                i++;
                if (i < tokens.Count && tokens[i].Is("("))
                {
                    i = SkipParentheses(tokens, i);
                }

                if (i >= tokens.Count || !tokens[i].IsWord("AS") || i + 1 >= tokens.Count || !tokens[i + 1].Is("("))
                {
                    problem = "Could not read the WITH clause.";
                    return names;
                }

                i = SkipParentheses(tokens, i + 1);
                if (i < tokens.Count && tokens[i].Is(","))
                {
                    i++;
                    continue;
                }

                if (i >= tokens.Count || !tokens[i].IsWord("SELECT"))
                {
                    problem = "Only SELECT queries are allowed after WITH.";
                }

                return names;
            }
        }

        /// <summary>Every table after FROM, JOIN or APPLY (including comma-separated FROM lists) must be
        /// an approved table or a CTE; functions in those positions are refused.</summary>
        private string CheckTableReferences(List<SqlToken> tokens, HashSet<string> cteNames)
        {
            for (var i = 0; i < tokens.Count; i++)
            {
                var isFrom = tokens[i].IsWord("FROM");
                if (!isFrom && !tokens[i].IsWord("JOIN") && !tokens[i].IsWord("APPLY"))
                {
                    continue;
                }

                var j = i + 1;
                while (true)
                {
                    if (j >= tokens.Count)
                    {
                        return "A table name is missing after " + tokens[i].Text.ToUpperInvariant() + ".";
                    }

                    if (tokens[j].Is("("))
                    {
                        j = SkipParentheses(tokens, j);
                    }
                    else
                    {
                        if (!tokens[j].IsName)
                        {
                            return "Unexpected \"" + tokens[j].Text + "\" after " + tokens[i].Text.ToUpperInvariant() + ".";
                        }

                        var name = tokens[j].Text;
                        j++;
                        if (j + 1 < tokens.Count && tokens[j].Is(".") && tokens[j + 1].IsName)
                        {
                            if (!name.Equals("dbo", StringComparison.OrdinalIgnoreCase))
                            {
                                return "Only tables in the dbo schema are allowed (found " + name + ").";
                            }

                            name = tokens[j + 1].Text;
                            j += 2;
                        }

                        if (j < tokens.Count && tokens[j].Is("("))
                        {
                            return "Functions such as " + name + "(...) cannot be used as a table.";
                        }

                        if (!cteNames.Contains(name) && !_allowedTables.Contains(name))
                        {
                            return "The table " + name + " is not available to the assistant. Use only the tables listed in the schema.";
                        }
                    }

                    if (!isFrom)
                    {
                        break;
                    }

                    // FROM a, b: skip an optional alias and table hints, then continue after a comma.
                    j = SkipAliasAndHints(tokens, j);
                    if (j < tokens.Count && tokens[j].Is(","))
                    {
                        j++;
                        continue;
                    }

                    break;
                }
            }

            return null;
        }

        private static int SkipAliasAndHints(List<SqlToken> tokens, int j)
        {
            if (j < tokens.Count && tokens[j].IsWord("AS"))
            {
                j++;
            }

            if (j < tokens.Count && tokens[j].IsName && !SqlLexer.IsClauseKeyword(tokens[j].Text))
            {
                j++;
            }

            if (j + 1 < tokens.Count && tokens[j].IsWord("WITH") && tokens[j + 1].Is("("))
            {
                j = SkipParentheses(tokens, j + 1);
            }

            return j;
        }

        /// <summary>Given the index of "(", returns the index just after its matching ")".</summary>
        private static int SkipParentheses(List<SqlToken> tokens, int open)
        {
            var depth = 0;
            for (var i = open; i < tokens.Count; i++)
            {
                if (tokens[i].Is("("))
                {
                    depth++;
                }
                else if (tokens[i].Is(")"))
                {
                    depth--;
                    if (depth == 0)
                    {
                        return i + 1;
                    }
                }
            }

            return tokens.Count;
        }
    }

    internal enum SqlTokenKind
    {
        Word,
        QuotedIdentifier,
        String,
        Number,
        Symbol,
    }

    internal sealed class SqlToken
    {
        public SqlToken(SqlTokenKind kind, string text)
        {
            Kind = kind;
            Text = text;
        }

        public SqlTokenKind Kind { get; }

        public string Text { get; }

        public bool IsName => Kind == SqlTokenKind.Word || Kind == SqlTokenKind.QuotedIdentifier;

        public bool Is(string symbol) => Kind == SqlTokenKind.Symbol && Text == symbol;

        public bool IsWord(string word) => Kind == SqlTokenKind.Word && string.Equals(Text, word, StringComparison.OrdinalIgnoreCase);
    }

    internal static class SqlLexer
    {
        private static readonly HashSet<string> ClauseKeywords = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "WHERE", "GROUP", "ORDER", "HAVING", "JOIN", "INNER", "LEFT", "RIGHT", "FULL", "CROSS", "OUTER",
            "ON", "UNION", "EXCEPT", "INTERSECT", "WITH", "OPTION", "FOR", "APPLY", "PIVOT", "UNPIVOT",
        };

        public static bool IsClauseKeyword(string word) => ClauseKeywords.Contains(word);

        /// <summary>Splits T-SQL into tokens. Also returns the text with comments removed (strings and
        /// identifiers untouched). Fails on unterminated strings, identifiers or comments.</summary>
        public static bool TryTokenize(string sql, out List<SqlToken> tokens, out string withoutComments, out string error)
        {
            tokens = new List<SqlToken>();
            var clean = new StringBuilder(sql.Length);
            error = null;
            withoutComments = null;
            var i = 0;
            while (i < sql.Length)
            {
                var c = sql[i];
                var next = i + 1 < sql.Length ? sql[i + 1] : '\0';

                if (char.IsWhiteSpace(c))
                {
                    clean.Append(c);
                    i++;
                }
                else if (c == '-' && next == '-')
                {
                    while (i < sql.Length && sql[i] != '\n')
                    {
                        i++;
                    }

                    clean.Append(' ');
                }
                else if (c == '/' && next == '*')
                {
                    // T-SQL block comments nest.
                    var depth = 0;
                    do
                    {
                        if (i + 1 < sql.Length && sql[i] == '/' && sql[i + 1] == '*')
                        {
                            depth++;
                            i += 2;
                        }
                        else if (i + 1 < sql.Length && sql[i] == '*' && sql[i + 1] == '/')
                        {
                            depth--;
                            i += 2;
                        }
                        else
                        {
                            i++;
                        }
                    }
                    while (depth > 0 && i < sql.Length);

                    if (depth > 0)
                    {
                        error = "A /* comment is not closed.";
                        return false;
                    }

                    clean.Append(' ');
                }
                else if (c == '\'' || ((c == 'N' || c == 'n') && next == '\''))
                {
                    var start = i;
                    i = c == '\'' ? i + 1 : i + 2;
                    if (!ReadQuoted(sql, ref i, '\''))
                    {
                        error = "A text value in quotes is not closed.";
                        return false;
                    }

                    tokens.Add(new SqlToken(SqlTokenKind.String, sql.Substring(start, i - start)));
                    clean.Append(sql, start, i - start);
                }
                else if (c == '[' || c == '"')
                {
                    var start = i;
                    i++;
                    if (!ReadQuoted(sql, ref i, c == '[' ? ']' : '"'))
                    {
                        error = "A quoted name is not closed.";
                        return false;
                    }

                    var inner = sql.Substring(start + 1, i - start - 2);
                    inner = c == '[' ? inner.Replace("]]", "]") : inner.Replace("\"\"", "\"");
                    tokens.Add(new SqlToken(SqlTokenKind.QuotedIdentifier, inner));
                    clean.Append(sql, start, i - start);
                }
                else if (char.IsLetter(c) || c == '_' || c == '@' || c == '#')
                {
                    var start = i;
                    while (i < sql.Length && (char.IsLetterOrDigit(sql[i]) || sql[i] == '_' || sql[i] == '@' || sql[i] == '#' || sql[i] == '$'))
                    {
                        i++;
                    }

                    tokens.Add(new SqlToken(SqlTokenKind.Word, sql.Substring(start, i - start)));
                    clean.Append(sql, start, i - start);
                }
                else if (char.IsDigit(c) || (c == '.' && char.IsDigit(next)))
                {
                    var start = i;
                    while (i < sql.Length && (char.IsLetterOrDigit(sql[i]) || sql[i] == '.'))
                    {
                        i++;
                    }

                    tokens.Add(new SqlToken(SqlTokenKind.Number, sql.Substring(start, i - start)));
                    clean.Append(sql, start, i - start);
                }
                else
                {
                    var symbol = c == ':' && next == ':' ? "::" : c.ToString();
                    tokens.Add(new SqlToken(SqlTokenKind.Symbol, symbol));
                    clean.Append(symbol);
                    i += symbol.Length;
                }
            }

            withoutComments = clean.ToString();
            return true;
        }

        /// <summary>Reads to the closing quote; a doubled closing character is an escaped one.</summary>
        private static bool ReadQuoted(string sql, ref int i, char close)
        {
            while (i < sql.Length)
            {
                if (sql[i] == close)
                {
                    if (i + 1 < sql.Length && sql[i + 1] == close)
                    {
                        i += 2;
                        continue;
                    }

                    i++;
                    return true;
                }

                i++;
            }

            return false;
        }
    }
}
