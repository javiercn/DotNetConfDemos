using Microsoft.AspNetCore.Components;

namespace DotNetConfDemos.Components;

public partial class DisplayCard<TElement> : ComponentBase
{
    public IEnumerable<PropertyValue> GetPropertyDefinitions()
    {
        foreach (var info in typeof(TElement).GetProperties())
        {
            yield return new PropertyValue(info.Name, info.GetValue(Element));
        }
    }

    [Parameter][EditorRequired] public TElement Element { get; set; } = default!;

    public record struct PropertyValue(string Name, object? Value);
}