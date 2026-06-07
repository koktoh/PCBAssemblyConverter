namespace PCBAssemblyConverter.Core.Extensions
{
    public static class TypeExtensions
    {
        public static string GetHierarchicalName(this Type type, int count = 0)
        {
            var name = GetName(type);

            if (count == 0 || type.Namespace is null) return name;

            var hierarchicalNamespace = string.Join(".", type.Namespace.Split('.').Reverse().Take(count).Reverse());

            return $"{hierarchicalNamespace}.{name}";
        }

        private static string GetName(Type type)
        {
            if (type.IsGenericType)
            {
                var genericTypeName = type.GetGenericTypeDefinition().Name;
                var genericArgs = type.GetGenericArguments().Select(GetName);
                return $"{genericTypeName}[{string.Join(", ", genericArgs)}]";
            }
            return type.Name;
        }
    }
}
