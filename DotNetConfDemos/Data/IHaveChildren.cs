namespace DotNetConfDemos.Data;

public interface IHaveChildren<TChildren>
{
    IEnumerable<TChildren> Children { get; }
}