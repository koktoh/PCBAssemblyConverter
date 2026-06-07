using PCBAssemblyConverter.Core.Extensions;
using PCBAssemblyConverter.Core.Formats;

namespace PCBAssemblyConverter.Presentation.Roles
{
    public static class ManufacturerExtensions
    {
        private static readonly IReadOnlyDictionary<(Manufacturer, Type), Type> _dataCategoryMap = new Dictionary<(Manufacturer, Type), Type>
        {
            { (Manufacturer.JLC, typeof(IBomEntry)), typeof(Core.Formats.JLC.BomEntry) },
            { (Manufacturer.JLC, typeof(IPosEntry)), typeof(Core.Formats.JLC.PosEntry) },
        };

        public static Type ResolveDataCategory<TCategory>(this Manufacturer manufacturer)
        where TCategory : IDataCategory
        {
            return manufacturer.ResolveDataCategory(typeof(TCategory));
        }

        public static Type ResolveDataCategory(this Manufacturer manufacturer, Type category)
        {
            if (_dataCategoryMap.TryGetValue((manufacturer, category), out var dataCategory))
            {
                return dataCategory;
            }
            else
            {
                throw new InvalidOperationException($"No data category found for manufacturer {manufacturer} and role {category.GetHierarchicalName(1)}");
            }
        }
    }
}
