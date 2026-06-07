namespace PCBAssemblyConverter.Presentation.Web.Mime.Attributes
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    sealed class MediaTypeNameAttribute : Attribute
    {
        public string Name { get; }

        public MediaTypeNameAttribute(string name)
        {
            this.Name = name;
        }
    }
}
