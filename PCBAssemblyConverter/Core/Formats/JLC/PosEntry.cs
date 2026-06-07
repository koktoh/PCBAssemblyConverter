using PCBAssemblyConverter.Core.Attributes;

namespace PCBAssemblyConverter.Core.Formats.JLC
{
    public record PosEntry : IPosEntry, IManufacturerModel
    {
        [FieldIndex(0)]
        public string Designator { get; init; } = string.Empty;
        [FieldName("Val")]
        [FieldIndex(1)]
        public string Value { get; init; } = string.Empty;
        [FieldIndex(2)]
        public string Package { get; init; } = string.Empty;
        [FieldName("Mid X")]
        [FieldIndex(3)]
        public double MidX { get; init; }
        [FieldName("Mid Y")]
        [FieldIndex(4)]
        public double MidY { get; init; }
        [FieldIndex(5)]
        public double Rotation { get; init; }
        [FieldName("Layer")]
        [FieldIndex(6)]
        public Side Side { get; init; }
    }
}
