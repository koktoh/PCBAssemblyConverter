using PCBAssemblyConverter.Core.Formats;
using PCBAssemblyConverter.Core.Rules;

namespace PCBAssemblyConverter.Core.Converters.KiCad
{
    public class KiCadToCommonPosConverter : EdaToCommonConverterBase<IPosEntry, Formats.KiCad.PosEntry, Formats.Common.PosEntry>
    {
        public override Formats.Common.PosEntry ConvertEntry(Formats.KiCad.PosEntry entry, ConversionRule? rule = null)
        {
            return new Formats.Common.PosEntry
            {
                Reference = entry.Reference,
                Value = entry.Value,
                Package = entry.Package,
                PosX = entry.PosX,
                PosY = entry.PosY,
                Rotation = entry.Rotation,
                Side = entry.Side
            };
        }
    }
}
