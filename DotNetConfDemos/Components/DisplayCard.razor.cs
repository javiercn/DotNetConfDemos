using DotNetConfDemos.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace DotNetConfDemos.Components;

public partial class DisplayCard<TElement> : ComponentBase
{
    public IEnumerable<PropertyValue> GetSummaryProperties()
    {
        foreach (var info in typeof(TElement).GetProperties())
        {
            if (info.CustomAttributes.Any(a => a.AttributeType == typeof(SummaryAttribute)))
            {
                yield return new PropertyValue(info.Name, info.GetValue(Element), true);
            }
        }
    }

    public IEnumerable<PropertyValue> GetProperties()
    {
        foreach (var info in typeof(TElement).GetProperties())
        {
            if (!info.CustomAttributes.Any(a => a.AttributeType == typeof(HiddenAttribute)))
            {
                yield return new PropertyValue(
                    info.Name,
                    info.GetValue(Element),
                    info.CustomAttributes.Any(a => a.AttributeType == typeof(SummaryAttribute)));
            }
        }
    }

    protected override async Task OnInitializedAsync()
    {
        CardModule = await JS.InvokeAsync<IJSObjectReference>("import", "./Components/DisplayCard.razor.js");
    }

    [Parameter]
    [EditorRequired]
    public TElement Element { get; set; } = default!;

    [Parameter]
    [EditorRequired]
    public RenderFragment Heading { get; set; } = default!;

    [Parameter]
    [EditorRequired]
    public RenderFragment Body { get; set; } = default!;

    [Parameter]
    public EventCallback<TElement> OnClick { get; set; }

    [Inject]
    public IJSRuntime JS { get; set; } = default!;

    public IJSObjectReference CardModule { get; set; } = default!;

    public bool ShowingDetails { get; set; }

    public ElementReference Modal { get; set; }

    public void ShowDetails() => ShowingDetails = true;

    public void CloseDialog() => ShowingDetails = false;

    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
        if (ShowingDetails && Modal.Id != null)
        {
            await CardModule.InvokeVoidAsync("openDialog", Modal);
        }
    }

    public record struct PropertyValue(string Name, object? Value, bool Summary);
}