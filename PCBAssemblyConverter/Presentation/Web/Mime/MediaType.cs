using PCBAssemblyConverter.Presentation.Web.Mime.Definitions;

namespace PCBAssemblyConverter.Presentation.Web.Mime
{
    public interface IMediaType
    {
        public string MimeType { get; }
        public TopLevelMediaType TopLevelMediaType { get; }
        public System.Enum Subtype { get; }
        public IReadOnlyCollection<string> Extensions { get; }
    }

    public record MediaType : IMediaType
    {
        public string MimeType { get; }

        public TopLevelMediaType TopLevelMediaType { get; }

        public System.Enum Subtype { get; }

        public IReadOnlyCollection<string> Extensions { get; }

        public MediaType(System.Enum subtype)
        {
            if (!subtype.IsMediaType()) throw new NotSupportedException();

            this.TopLevelMediaType = subtype.GetTopLevelMediaType();
            this.Subtype = subtype;
            this.MimeType = this.TopLevelMediaType + (this.TopLevelMediaType == TopLevelMediaType.Example ? string.Empty : $"/{this.Subtype.GetMediaTypeName()}");
            this.Extensions = subtype.GetMediaTypeExtensions().ToArray();
        }
    }
}
