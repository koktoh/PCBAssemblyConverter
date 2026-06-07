namespace PCBAssemblyConverter.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class FieldNameAttribute : Attribute
    {
        public string Name { get; }

        public FieldNameAttribute(string name)
        {
            this.Name = name;
        }
    }
}
