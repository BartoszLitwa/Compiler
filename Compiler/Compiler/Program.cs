using Compiler.CodeAnalysis.Syntax;
using Compiler.CodeAnalysis.Evaluate;
using System.Text;
using Compiler.CodeAnalysis.Binding;

namespace Compiler
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var showTree = true;
            while(true)
            {
                Console.Write("> ");
                var line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                    return;

                if (line == "#showTree")
                {
                    showTree = !showTree;
                    Console.WriteLine(showTree ? "Showing parse trees." : "Not showing parse trees.");
                    continue;
                }
                if(line == "#cls" || line == "#clear")
                {
                    Console.Clear();
                    continue;
                }

                var syntaxTree = SyntaxTree.Parse(line);
                var binder = new Binder();
                var boundExpression = binder.BindExpression(syntaxTree.Root);

                var diagnostics = syntaxTree.Diagnostics.Concat(binder.Diagnostics).ToArray();

                if (showTree)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                    PrettyPrint(syntaxTree.Root);

                    Console.ResetColor();
                }

                if (!diagnostics.Any())
                {
                    var e = new Evaluator(boundExpression);
                    var result = e.Evaluate();
                    Console.WriteLine(result);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;

                    foreach (var diagnostic in syntaxTree.Diagnostics)
                        Console.WriteLine(diagnostic);

                    Console.ResetColor();
                }
            }
        }

        static void PrettyPrint(SyntaxNode node, string indent = "", bool isLast = true)
        {
            var marker = isLast ? "└──" : "├──";

            var sb = new StringBuilder();
            sb.Append(indent)
                .Append(marker)
                .Append(node.Kind);

            if(node is SyntaxToken token && token.Value != null)
            {
                sb.Append(" ").Append(token.Value);
            }

            Console.WriteLine(sb.ToString());
            indent += isLast ? "   " : "│  ";

            var lastChild = node.GetChildren().LastOrDefault();
            foreach (var child in node.GetChildren())
                PrettyPrint(child, indent, child == lastChild);
        }
    }
}