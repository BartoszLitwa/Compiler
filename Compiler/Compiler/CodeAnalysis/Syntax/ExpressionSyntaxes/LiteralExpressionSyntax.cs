using Compiler.CodeAnalysis.Syntax;

namespace Compiler.CodeAnalysis.Syntax.ExpressionSyntaxes
{
    internal sealed class LiteralExpressionSyntax : ExpressionSyntax
    {
        public LiteralExpressionSyntax(SyntaxToken literalToken)
        {
            LiteralToken = literalToken;
        }

        public SyntaxToken LiteralToken { get; set; }

        public override SyntaxKind Kind => SyntaxKind.LiteralExpression;

        public override IEnumerable<SyntaxNode> GetChildren()
        {
            yield return LiteralToken;
        }
    }
}
