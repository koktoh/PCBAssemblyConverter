using PCBAssemblyConverter.Core.Extensions;
using PCBAssemblyConverter.Core.Formats;
using PCBAssemblyConverter.Core.Formats.Common;

namespace PCBAssemblyConverter.Core.Converters
{
    public class ConverterProvider
    {
        private readonly Dictionary<(Type category, Type srcType, Type dstType), object> _converters = [];

        private readonly IReadOnlyDictionary<Type, Type> _categoryMap = new Dictionary<Type, Type>
        {
            { typeof(IBomEntry), typeof(BomEntry) },
            { typeof(IPosEntry), typeof(PosEntry) }
        };

        public void Register<TCategory, TSrc, TDst>(IConverter<TCategory, TSrc, TDst> converter)
            where TCategory : IDataCategory
            where TSrc : TCategory, IModelRole
            where TDst : TCategory, IModelRole
        {
            this._converters[(typeof(TCategory), typeof(TSrc), typeof(TDst))] = converter;
        }

        public void Register(Type category, Type srcType, Type dstType, object converter)
        {
            if (!typeof(IConverter<,,>).MakeGenericType(category, srcType, dstType).IsInstanceOfType(converter))
            {
                throw new ArgumentException($"Converter must implement IConverter<{category.Name}, {srcType.GetHierarchicalName(1)}, {dstType.GetHierarchicalName(1)}>");
            }

            this._converters[(category, srcType, dstType)] = converter;
        }

        public IConverter<TCategory, TSrc, TDst> Resolve<TCategory, TSrc, TDst>()
            where TCategory : IDataCategory
            where TSrc : TCategory, IModelRole
            where TDst : TCategory, IModelRole
        {
            var category = typeof(TCategory);
            var srcType = typeof(TSrc);
            var dstType = typeof(TDst);

            if (this._converters.TryGetValue((category, srcType, dstType), out var converter))
            {
                return (IConverter<TCategory, TSrc, TDst>)converter;
            }
            else
            {
                throw new InvalidOperationException($"No converter registered for category {category.Name} from {srcType.GetHierarchicalName(1)} to {dstType.GetHierarchicalName(1)}");
            }
        }

        public object Resolve(Type category, Type srcType, Type dstType)
        {
            if (this._converters.TryGetValue((category, srcType, dstType), out var converter))
            {
                return converter;
            }
            else
            {
                throw new InvalidOperationException($"No converter registered for category {category.Name} from {srcType.GetHierarchicalName(1)} to {dstType.GetHierarchicalName(1)}");
            }
        }

        public object ResolveEdaToCommon(Type category, Type srcType)
        {
            if (this._categoryMap.TryGetValue(category, out var internalType))
            {
                return this.Resolve(category, srcType, internalType);
            }

            throw new InvalidOperationException($"No converter registered for category {category.Name} from {srcType.GetHierarchicalName(1)} to Common");
        }

        public object ResolveCommonToManufacturer(Type category, Type dstType)
        {
            if (this._categoryMap.TryGetValue(category, out var internalType))
            {
                return this.Resolve(category, internalType, dstType);
            }

            throw new InvalidOperationException($"No converter registered for category {category.Name} from Common to {dstType.GetHierarchicalName(1)}");
        }
    }
}
