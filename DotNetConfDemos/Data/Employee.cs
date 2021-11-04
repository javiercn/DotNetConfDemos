namespace DotNetConfDemos.Data
{
    public class Employee : IHaveChildren<Employee>
    {
        [Summary] public string? Name { get; set; }

        [Summary] public string? Title { get; set; }

        public string? Telephone { get; set; }

        public string? Country { get; set; }

        [Hidden] public IList<Employee> Reports { get; set; } = new List<Employee>();

        [Hidden] public IEnumerable<Employee> Children => Reports;
    }
}
