using PCBAssemblyConverter.Core.Extensions;
using PCBAssemblyConverter.Core.Formats;
using PCBAssemblyConverter.Presentation.Web.Mime;

namespace PCBAssemblyConverter.Presentation.Roles
{
    public static class EdaToolExtensions
    {
        private static readonly IReadOnlyDictionary<(EdaTool, Type), IEnumerable<IMediaType>> _mediaTypeMap = new Dictionary<(EdaTool, Type), IEnumerable<IMediaType>>
        {
            { (EdaTool.KiCad, typeof(IBomEntry)), [ MediaTypes.Csv ] },
            { (EdaTool.KiCad, typeof(IPosEntry)), [ MediaTypes.Csv ] },
        };

        private static readonly IReadOnlyDictionary<(EdaTool, Type), Type> _dataCategoryMap = new Dictionary<(EdaTool, Type), Type>
        {
            { (EdaTool.KiCad, typeof(IBomEntry)), typeof(Core.Formats.KiCad.BomEntry) },
            { (EdaTool.KiCad, typeof(IPosEntry)), typeof(Core.Formats.KiCad.PosEntry) },
        };


        public static IEnumerable<IMediaType> ResolveMediaType<TCategory>(this EdaTool tool)
            where TCategory : IDataCategory
        {
            return tool.ResolveMediaType(typeof(TCategory));
        }

        public static IEnumerable<IMediaType> ResolveMediaType(this EdaTool tool, Type category)
        {
            if (_mediaTypeMap.TryGetValue((tool, category), out var mediaTypes))
            {
                return mediaTypes;
            }

            throw new InvalidOperationException($"No data category found for EDA tool {tool} and role {category.GetHierarchicalName(1)}");
        }

        public static Type ResolveDataCategory<TCategory>(this EdaTool tool)
            where TCategory : IDataCategory
        {
            return tool.ResolveDataCategory(typeof(TCategory));
        }

        public static Type ResolveDataCategory(this EdaTool tool, Type category)
        {
            if (_dataCategoryMap.TryGetValue((tool, category), out var dataCategory))
            {
                return dataCategory;
            }

            throw new InvalidOperationException($"No data category found for EDA tool {tool} and role {category.GetHierarchicalName(1)}");
        }
    }
}
