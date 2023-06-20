using Compiler.CodeAnalysis.Binding.Expression;
using Compiler.CodeAnalysis.Binding.Node;

namespace Compiler.CodeAnalysis.Binding.Binary
{
    internal sealed class BoundBinaryExpression : BoundExpression
    {

        public BoundBinaryExpression(BoundExpression left, BoundBinaryOperator op, BoundExpression right)
        {
            Left = left;
            Op = op;
            Right = right;
        }

        public BoundExpression Left { get; }
        public BoundBinaryOperator Op { get; }
        public BoundExpression Right { get; }

        public override Type Type => Op.Type;
        public override BoundNodeKind Kind => BoundNodeKind.BinaryExpression;

    }
}
