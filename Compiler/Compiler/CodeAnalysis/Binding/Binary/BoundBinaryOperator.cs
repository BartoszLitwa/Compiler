using Compiler.CodeAnalysis.Syntax;

namespace Compiler.CodeAnalysis.Binding.Binary
{
    internal sealed class BoundBinaryOperator
    {
        private BoundBinaryOperator(SyntaxKind syntaxKind, BoundBinaryOperatorKind kind, Type type)
            : this(syntaxKind, kind, type, type, type) { }

        private BoundBinaryOperator(SyntaxKind syntaxKind, BoundBinaryOperatorKind kind, Type leftType, Type rightType, Type resultType)
        {
            LeftType = leftType;
            RightType = rightType;
            ResultType = resultType;
            Kind = kind;
            SyntaxKind = syntaxKind;
        }

        public SyntaxKind SyntaxKind { get; }
        public BoundBinaryOperatorKind Kind { get; }
        public Type LeftType { get; set; }
        public Type RightType { get; set; }
        public Type ResultType { get; }

        private static BoundBinaryOperator[] _operator =
        {
            new BoundBinaryOperator(SyntaxKind.PlusToken, BoundBinaryOperatorKind.Addition, typeof(int)),
            new BoundBinaryOperator(SyntaxKind.MinusToken, BoundBinaryOperatorKind.Subtraction, typeof(int)),
            new BoundBinaryOperator(SyntaxKind.StarToken, BoundBinaryOperatorKind.Multiplication, typeof(int)),
            new BoundBinaryOperator(SyntaxKind.SlashToken, BoundBinaryOperatorKind.Division, typeof(int)),

            new BoundBinaryOperator(SyntaxKind.AmpersandAmpersandToken, BoundBinaryOperatorKind.LogicalAnd, typeof(bool)),
            new BoundBinaryOperator(SyntaxKind.PipePipeToken, BoundBinaryOperatorKind.LogicalOr, typeof(bool)),
        };

        public static BoundBinaryOperator Bind(SyntaxKind syntaxKind, Type leftType, Type rightType)
        {
            foreach (var operand in _operator)
            {
                if (operand.SyntaxKind == syntaxKind && operand.LeftType == leftType && operand.RightType == rightType)
                    return operand;
            }

            return null;
        }
    }
}
