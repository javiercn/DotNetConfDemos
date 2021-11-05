namespace DotNetConfDemos.Data;

public class Employee : IHaveChildren
{
    [Summary]
    public string? Name { get; set; }

    [Summary]
    public string? Title { get; set; }

    public string? Telephone { get; set; }

    public string? Country { get; set; }

    [Hidden]
    public string? Image { get; set; }

    [Hidden]
    public Employee? Manager { get; set; }

    [Hidden]
    public object? Parent => Manager;

    [Hidden]
    public IList<Employee> Reports { get; set; } = new List<Employee>();

    [Hidden]
    public IEnumerable<object> Children => Reports;
}
