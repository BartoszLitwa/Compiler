using Compiler.CodeAnalysis.Binding.Expression;
using Compiler.CodeAnalysis.Binding.Node;

namespace Compiler.CodeAnalysis.Binding.Unary
{
    internal sealed class BoundUnaryExpression : BoundExpression
    {
        public BoundUnaryExpression(BoundUnaryOperator op, BoundExpression operand)
        {
            Op = op;
            Operand = operand;
        }

        public BoundUnaryOperator Op { get; }
        public BoundExpression Operand { get; }

        public override Type Type => Op.Type;
        public override BoundNodeKind Kind => BoundNodeKind.UnaryExpression;
    }
}
