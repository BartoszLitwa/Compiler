namespace Compiler.CodeAnalysis.Binding
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
