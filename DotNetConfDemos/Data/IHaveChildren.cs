
public interface IHaveChildren
{
    object? Parent { get; }

    IEnumerable<object> Children { get; }
}