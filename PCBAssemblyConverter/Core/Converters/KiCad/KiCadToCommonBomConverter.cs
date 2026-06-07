using PCBAssemblyConverter.Core.Formats;
using PCBAssemblyConverter.Core.Rules;

namespace PCBAssemblyConverter.Core.Converters.KiCad
{
    public class KiCadToCommonBomConverter : EdaToCommonConverterBase<IBomEntry, Formats.KiCad.BomEntry, Formats.Common.BomEntry>
    {
        public override Formats.Common.BomEntry ConvertEntry(Formats.KiCad.BomEntry entry, ConversionRule? rule = null)
        {
            return new Formats.Common.BomEntry
            {
                Id = entry.Id,
                Reference = entry.Reference,
                Footprint = entry.Footprint,
                Qty = entry.Qty,
                Name = entry.Name,
                Comment = entry.Comment
            };
        }
    }
}
