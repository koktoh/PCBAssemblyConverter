using PCBAssemblyConverter.Core.Attributes;

namespace PCBAssemblyConverter.Core.Formats.KiCad
{
    public record PosEntry : IPosEntry, IEdaModel
    {
        [FieldName("Ref")]
        [FieldIndex(0)]
        public string Reference { get; init; } = string.Empty;
        [FieldName("Val")]
        [FieldIndex(1)]
        public string Value { get; init; } = string.Empty;
        [FieldIndex(2)]
        public string Package { get; init; } = string.Empty;
        [FieldIndex(3)]
        public double PosX { get; init; }
        [FieldIndex(4)]
        public double PosY { get; init; }
        [FieldName("Rot")]
        [FieldIndex(5)]
        public double Rotation { get; init; }
        [FieldIndex(6)]
        public Side Side { get; init; }
    }
}
