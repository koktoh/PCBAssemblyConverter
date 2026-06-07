using PCBAssemblyConverter.Core.Formats;
using PCBAssemblyConverter.Core.Rules;

namespace PCBAssemblyConverter.Core.Converters
{
    public interface IConverter<TCategory, TSrc, TDst>
        where TCategory : IDataCategory
        where TSrc : TCategory, IModelRole
        where TDst : TCategory, IModelRole
    {
        TDst ConvertEntry(TSrc entry, ConversionRule? rule = null);

        IEnumerable<TDst> ConvertEntries(IEnumerable<TSrc> entries, ConversionRuleSet? rules = null);
    }
}
