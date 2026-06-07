using PCBAssemblyConverter.Core.Formats;
using PCBAssemblyConverter.Core.Rules;

namespace PCBAssemblyConverter.Core.Converters
{
    public abstract class EdaToCommonConverterBase<TCategory, TSrc, TDst> : ConverterBase<TCategory, TSrc, TDst>
        where TCategory : IDataCategory
        where TSrc : TCategory, IEdaModel
        where TDst : TCategory, ICommonModel
    {
        protected override ConversionRule? GetConversionRule(TSrc entry, ConversionRuleSet? rules)
        {
            return null;
        }
    }
}
