using PCBAssemblyConverter.Core.Formats;
using PCBAssemblyConverter.Core.Rules;

namespace PCBAssemblyConverter.Core.Converters
{
    public abstract class ConverterBase<TCategory, TSrc, TDst> : IConverter<TCategory, TSrc, TDst>
        where TCategory : IDataCategory
        where TSrc : TCategory, IModelRole
        where TDst : TCategory, IModelRole
    {
        public abstract TDst ConvertEntry(TSrc entry, ConversionRule? rule = null);

        public virtual IEnumerable<TDst> ConvertEntries(IEnumerable<TSrc> entries, ConversionRuleSet? rules = null)
        {
            foreach (var entry in entries)
            {
                var rule = this.GetConversionRule(entry, rules);

                if (this.IsExclude(entry, rule)) continue;

                yield return this.ConvertEntry(entry, rule);
            }
        }

        protected abstract ConversionRule? GetConversionRule(TSrc entry, ConversionRuleSet? rules);

        protected virtual bool IsExclude(TSrc entry, ConversionRule? rule)
        {
            if (rule is null) return false;
            return rule.RuleAction == RuleAction.Exclude;
        }

        protected virtual Side ConvertSide(Side side, ChangeSide changeSide)
        {
            return changeSide switch
            {
                ChangeSide.Top => Side.Top,
                ChangeSide.Bottom => Side.Bottom,
                ChangeSide.Reverse => side == Side.Top ? Side.Bottom : Side.Top,
                _ => side,
            };
        }
    }
}
