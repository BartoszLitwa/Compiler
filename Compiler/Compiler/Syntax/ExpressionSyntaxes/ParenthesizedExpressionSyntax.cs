using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Syntax.ExpressionSyntaxes
{
    public sealed class ParenthesizedExpressionSyntax : ExpressionSyntax
    {
        public ParenthesizedExpressionSyntax(
            SyntaxToken openParethesisToken,
            ExpressionSyntax expression,
            SyntaxToken closeParenthesisToken)
        {
            OpenParethesisToken = openParethesisToken;
            Expression = expression;
            CloseParenthesisToken = closeParenthesisToken;
        }

        public SyntaxToken OpenParethesisToken { get; }
        public ExpressionSyntax Expression { get; }
        public SyntaxToken CloseParenthesisToken { get; }

        public override SyntaxKind Kind => SyntaxKind.ParenthesizedExpression;

        public override IEnumerable<SyntaxNode> GetChildren()
        {
            yield return OpenParethesisToken;
            yield return Expression;
            yield return CloseParenthesisToken;
        }
    }
}
