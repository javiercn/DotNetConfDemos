namespace DotNetConfDemos.Data
{
    public static class HaveChildrenExtensions
    {
        public static IEnumerable<object> GetAncestry(this IHaveChildren hasChildren)
        {
            List<object> ancestors = new() { hasChildren };
            while (hasChildren.Parent != null)
            {
                ancestors.Add(hasChildren.Parent);
                hasChildren = (IHaveChildren)hasChildren.Parent;
            }
            return ancestors;
        }
    }
}
