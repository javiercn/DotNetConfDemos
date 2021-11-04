namespace DotNetConfDemos.Data
{
    public class Employee : IHaveChildren<Employee>
    {
        public string? Name { get; set; }

        public string? Title { get; set; }

        public IList<Employee> Reports { get; set; } = new List<Employee>();

        public IEnumerable<Employee> Children => Reports;
    }
}
