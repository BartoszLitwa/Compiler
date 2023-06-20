namespace Compiler.CodeAnalysis.Binding.Node
{
    internal abstract class BoundNode
    {
        public abstract BoundNodeKind Kind { get; }
    }
}
