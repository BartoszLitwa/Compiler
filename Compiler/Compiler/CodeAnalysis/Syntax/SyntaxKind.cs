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

        BangToken, // !
        AmpersandAmpersandToken, // &&
        PipePipeToken, // ||

        OpenParenthesisToken,
        CloseParenthesisToken,

        // Keywords
        FalseKeyword,
        TrueKeyword,
        IdentifierKeyword,

        // Expressions
        LiteralExpression,
        UnaryExpression,
        BinaryExpression,
        ParenthesizedExpression,
    }

    public static class SyntaxFacts
    {
        public static int GetBinaryOperatorPrecedence(this SyntaxKind kind)
        {
            return kind switch
            {
                SyntaxKind.StarToken => 4,
                SyntaxKind.SlashToken => 4,

                SyntaxKind.PlusToken => 3,
                SyntaxKind.MinusToken => 3,

                SyntaxKind.AmpersandAmpersandToken => 2,

                SyntaxKind.PipePipeToken => 1,

                _ => 0
            };
        }

        public static int GetUnaryOperatorPrecedence(this SyntaxKind kind)
        {
            return kind switch
            {
                SyntaxKind.PlusToken => 5,
                SyntaxKind.MinusToken => 5,
                SyntaxKind.BangToken => 5,

                _ => 0
            };
        }

        public static SyntaxKind GetKeywordKind(string text)
        {
            return text switch
            {
                "true" => SyntaxKind.TrueKeyword,
                "false" => SyntaxKind.FalseKeyword,
                _ => SyntaxKind.IdentifierKeyword,
            };
        }
    }
}
