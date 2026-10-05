using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic;

// Usage: VbSyntaxCheck <file.vb|folder> ...   Prints every syntax error; exit code 1 if there is any.
var errors = 0;
var files = new List<string>();
foreach (var a in args)
{
    if (Directory.Exists(a)) files.AddRange(Directory.GetFiles(a, "*.vb", SearchOption.AllDirectories));
    else files.Add(a);
}
foreach (var f in files)
{
    var tree = VisualBasicSyntaxTree.ParseText(File.ReadAllText(f), path: f);
    foreach (var d in tree.GetDiagnostics().Where(d => d.Severity == DiagnosticSeverity.Error))
    {
        errors++;
        Console.WriteLine($"{f}({d.Location.GetLineSpan().StartLinePosition.Line + 1}): {d.Id} {d.GetMessage()}");
    }
}
Console.WriteLine($"{files.Count} VB file(s) checked, {errors} syntax error(s).");
return errors == 0 ? 0 : 1;
