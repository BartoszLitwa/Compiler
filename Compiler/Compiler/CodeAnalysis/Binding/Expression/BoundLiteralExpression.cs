using Compiler.CodeAnalysis.Binding.Node;

namespace Compiler.CodeAnalysis.Binding.Expression
{
    internal sealed class BoundLiteralExpression : BoundExpression
    {
        public object Value { get; set; }

        public override Type Type => Value.GetType();
        public override BoundNodeKind Kind => BoundNodeKind.LiteralExpression;

        public BoundLiteralExpression(object value)
        {
            Value = value;
        }
    }
}
