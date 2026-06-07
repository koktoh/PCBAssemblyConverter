namespace PCBAssemblyConverter.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class FieldIndexAttribute : Attribute
    {
        public int Index { get; }

        public FieldIndexAttribute(int index)
        {
            this.Index = index;
        }
    }
}
