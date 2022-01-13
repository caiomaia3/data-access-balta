namespace Blog.Extensions
{
    public static class ExtensionMethod
    {
        public static bool HasProperty(this object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName) != null;
        }
    }
}