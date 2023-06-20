using Compiler.CodeAnalysis.Binding.Node;

namespace Compiler.CodeAnalysis.Binding.Expression
{
    internal abstract class BoundExpression : BoundNode
    {
        public abstract Type Type { get; }
    }
}
