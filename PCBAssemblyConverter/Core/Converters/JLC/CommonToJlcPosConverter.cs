using PCBAssemblyConverter.Core.Formats;
using PCBAssemblyConverter.Core.Geometry;
using PCBAssemblyConverter.Core.Rules;

namespace PCBAssemblyConverter.Core.Converters.JLC
{
    public class CommonToJlcPosConverter : CommonToManufacturerConverterBase<IPosEntry, Formats.Common.PosEntry, Formats.JLC.PosEntry>
    {
        public override Formats.JLC.PosEntry ConvertEntry(Formats.Common.PosEntry entry, ConversionRule? rule = null)
        {
            var designator = entry.Reference;
            var value = entry.Value;
            var package = entry.Package;
            var midX = entry.PosX;
            var midY = entry.PosY;
            var rotation = entry.Rotation;
            var side = entry.Side;

            if (rule is not null)
            {
                var vector = Transform2D.Rotate(rule.OffsetX, rule.OffsetY, entry.Rotation.ToRadians());

                midX += vector.X;
                midY += vector.Y;

                side = this.ConvertSide(side, rule.ChangeSide);

                rotation += (int)rule.RotationAdjustment;

                if (side == Side.Bottom)
                {
                    rotation = rotation.MirrorYDegrees();
                }

                rotation = rotation.NormalizeSignedDegrees();
            }

            return new Formats.JLC.PosEntry
            {
                Designator = designator,
                Value = value,
                Package = package,
                MidX = midX,
                MidY = midY,
                Rotation = rotation,
                Side = side
            };
        }

        protected override ConversionRule? GetConversionRule(Formats.Common.PosEntry entry, ConversionRuleSet? rules)
        {
            return rules?.GetRule(entry.Package);
        }
    }
}
