using System.Reflection;
using Microsoft.AspNetCore.Components.Forms;
using PCBAssemblyConverter.Presentation.Web.Mime.Attributes;
using PCBAssemblyConverter.Presentation.Web.Mime.Definitions;

namespace PCBAssemblyConverter.Presentation.Web.Mime
{
    public static class MediaTypeExtensions
    {
        private static readonly IReadOnlyDictionary<Type, TopLevelMediaType> _map = new Dictionary<Type, TopLevelMediaType>()
        {
            { typeof(ApplicationSubtype), TopLevelMediaType.Application },
            { typeof(AudioSubtype), TopLevelMediaType.Audio },
            { typeof(ExampleSubtype), TopLevelMediaType.Example },
            { typeof(FontSubtype), TopLevelMediaType.Font },
            { typeof(HapticsSubtype), TopLevelMediaType.Haptics },
            { typeof(ImageSubtype), TopLevelMediaType.Image },
            { typeof(MessageSubtype), TopLevelMediaType.Message },
            { typeof(ModelSubtype), TopLevelMediaType.Model },
            { typeof(MultipartSubtype), TopLevelMediaType.Multipart },
            { typeof(TextSubtype), TopLevelMediaType.Text },
            { typeof(VideoSubtype), TopLevelMediaType.Video },
        };

        public static string GetMediaTypeName(this System.Enum e)
        {
            var field = e.GetType().GetField(e.ToString());
            var attr = field?.GetCustomAttribute<MediaTypeNameAttribute>();

            return attr?.Name ?? string.Empty;
        }

        public static IEnumerable<string> GetMediaTypeExtensions(this System.Enum e)
        {
            var field = e.GetType().GetField(e.ToString());
            var attrs = field?.GetCustomAttributes<MediaTypeExtensionAttribute>();

            return attrs?.Select(x => x.Extension.Trim()).Select(x => x.StartsWith('.') ? x : $".{x}") ?? Enumerable.Empty<string>();
        }

        public static TopLevelMediaType GetTopLevelMediaType(this System.Enum e)
        {
            if (_map.TryGetValue(e.GetType(), out var topLevelMediaType))
            {
                return topLevelMediaType;
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        public static bool IsMediaType(this System.Enum e)
        {
            return _map.ContainsKey(e.GetType());
        }

        public static bool IsAllowedExtension(this IBrowserFile browserFile, params IMediaType[] mediaTypes)
        {
            if (mediaTypes.Length == 0) return false;

            var extension = Path.GetExtension(browserFile.Name);

            var allowedExtensions = mediaTypes.SelectMany(x => x.Extensions);

            if (!allowedExtensions.Any()) return true; // If no extensions are registered, always true.

            return allowedExtensions.Any(x => x.Equals(extension, StringComparison.OrdinalIgnoreCase));
        }

        public static bool IsTopLevelMediaTypeOf(this string contentType, TopLevelMediaType topLevelMediaType)
        {
            var target = topLevelMediaType.GetMediaTypeName() + (topLevelMediaType == TopLevelMediaType.Example ? string.Empty : "/");

            return contentType.StartsWith(target, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsTopLevelMediaTypeOf(this string contentType, IMediaType mediaType)
        {
            return contentType.IsTopLevelMediaTypeOf(mediaType.TopLevelMediaType);
        }

        public static bool IsMediaTypeOf(this string contentType, IMediaType mediaType)
        {
            var elems = contentType.Split(';');
            return elems[0].Trim().Equals(mediaType.MimeType, StringComparison.OrdinalIgnoreCase);
        }
    }
}
