namespace PCBAssemblyConverter.Presentation.Web.Mime.Attributes
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    public class MediaTypeExtensionAttribute : Attribute
    {
        public string Extension { get; }

        public MediaTypeExtensionAttribute(string extension)
        {
            this.Extension = extension;
        }
    }
}
