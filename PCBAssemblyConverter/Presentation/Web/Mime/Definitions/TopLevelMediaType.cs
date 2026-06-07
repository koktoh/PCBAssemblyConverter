using PCBAssemblyConverter.Presentation.Web.Mime.Attributes;

namespace PCBAssemblyConverter.Presentation.Web.Mime.Definitions
{
    public enum TopLevelMediaType
    {
        [MediaTypeName("application")]
        Application,
        [MediaTypeName("audio")]
        Audio,
        [MediaTypeName("font")]
        Font,
        [MediaTypeName("example")]
        Example,
        [MediaTypeName("haptics")]
        Haptics,
        [MediaTypeName("image")]
        Image,
        [MediaTypeName("message")]
        Message,
        [MediaTypeName("model")]
        Model,
        [MediaTypeName("multipart")]
        Multipart,
        [MediaTypeName("text")]
        Text,
        [MediaTypeName("video")]
        Video,
    }
}
