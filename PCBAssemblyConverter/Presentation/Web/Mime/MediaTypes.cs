using PCBAssemblyConverter.Presentation.Web.Mime.Definitions;

namespace PCBAssemblyConverter.Presentation.Web.Mime
{
    public static class MediaTypes
    {
        public static readonly IMediaType Json = new MediaType(ApplicationSubtype.Json);
        public static readonly IMediaType Csv = new MediaType(TextSubtype.Csv);
        public static readonly IMediaType TextPlain = new MediaType(TextSubtype.Plain);
    }
}
