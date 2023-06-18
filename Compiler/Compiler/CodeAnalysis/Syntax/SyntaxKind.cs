namespace Compiler.CodeAnalysis.Syntax
{
    public enum SyntaxKind
    {
        // Tokens
        BadToken,
        EndOfFileToken,
        WhitespaceToken,

        NumberToken,

        // Operators
        PlusToken,
        MinusToken,
        StarToken,
        SlashToken,

        OpenParenthesisToken,
        CloseParenthesisToken,

        // Expressions
        LiteralExpression,
        UnaryExpression,
        BinaryExpression,
        ParenthesizedExpression,
    }

    public static class SyntaxKindExtensions
    {
        public static int GetBinaryOperatorPrecedence(this SyntaxKind kind)
        {
            return kind switch
            {
                SyntaxKind.StarToken => 2,
                SyntaxKind.SlashToken => 2,

                SyntaxKind.PlusToken => 1,
                SyntaxKind.MinusToken => 1,

                _ => 0
            };
        }

        public static int GetUnaryOperatorPrecedence(this SyntaxKind kind)
        {
            return kind switch
            {
                SyntaxKind.PlusToken => 3,
                SyntaxKind.MinusToken => 3,

                _ => 0
            };
        }
    }
}
