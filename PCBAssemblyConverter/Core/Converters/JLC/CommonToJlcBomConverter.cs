using PCBAssemblyConverter.Core.Formats;
using PCBAssemblyConverter.Core.Rules;

namespace PCBAssemblyConverter.Core.Converters.JLC
{
    public class CommonToJlcBomConverter : CommonToManufacturerConverterBase<IBomEntry, Formats.Common.BomEntry, Formats.JLC.BomEntry>
    {
        public override Formats.JLC.BomEntry ConvertEntry(Formats.Common.BomEntry entry, ConversionRule? rule = null)
        {
            var comment = entry.Name;
            var designator = entry.Reference;
            var footprint = entry.Footprint;
            var partNumber = string.Empty;

            if (rule is not null)
            {
                partNumber = rule.ManufacturerPartNumber;
            }

            return new Formats.JLC.BomEntry
            {
                Comment = comment,
                Designator = designator,
                Footprint = footprint,
                PartNumber = partNumber
            };
        }

        protected override ConversionRule? GetConversionRule(Formats.Common.BomEntry entry, ConversionRuleSet? rules)
        {
            return rules?.GetRule(entry.Footprint);
        }
    }
}
