using Compiler.CodeAnalysis.Syntax;

namespace Compiler.CodeAnalysis.Binding.Unary
{
    internal sealed class BoundUnaryOperator
    {
        private BoundUnaryOperator(SyntaxKind syntaxKind, BoundUnaryOperatorKind kind, Type operandType)
            : this(syntaxKind, kind, operandType, operandType) { }

        private BoundUnaryOperator(SyntaxKind syntaxKind, BoundUnaryOperatorKind kind, Type operandType, Type resultType)
        {
            ResultType = resultType;
            OperandType = operandType;
            Kind = kind;
            SyntaxKind = syntaxKind;
        }

        public SyntaxKind SyntaxKind { get; }
        public BoundUnaryOperatorKind Kind { get; }
        public Type OperandType { get; }
        public Type ResultType { get; }

        private static BoundUnaryOperator[] _operator =
        {
            new BoundUnaryOperator(SyntaxKind.BangToken, BoundUnaryOperatorKind.LogicalNegation, typeof(bool)),

            new BoundUnaryOperator(SyntaxKind.PlusToken, BoundUnaryOperatorKind.Identity, typeof(int)),
            new BoundUnaryOperator(SyntaxKind.MinusToken, BoundUnaryOperatorKind.Negation, typeof(int)),
        };

        public static BoundUnaryOperator Bind(SyntaxKind syntaxKind, Type operandType)
        {
            foreach (var operand in _operator)
            {
                if (operand.SyntaxKind == syntaxKind && operand.OperandType == operandType)
                    return operand;
            }

            return null;
        }
    }
}
