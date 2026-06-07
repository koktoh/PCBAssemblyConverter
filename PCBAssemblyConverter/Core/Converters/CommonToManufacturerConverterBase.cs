using PCBAssemblyConverter.Core.Formats;

namespace PCBAssemblyConverter.Core.Converters
{
    public abstract class CommonToManufacturerConverterBase<TCategory, TSrc, TDst> : ConverterBase<TCategory, TSrc, TDst>
        where TCategory : IDataCategory
        where TSrc : TCategory, ICommonModel
        where TDst : TCategory, IManufacturerModel
    {
    }
}
