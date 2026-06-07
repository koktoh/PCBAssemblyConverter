using PCBAssemblyConverter.Core.Attributes;

namespace PCBAssemblyConverter.Core.Formats.KiCad
{
    public record BomEntry : IBomEntry, IEdaModel
    {
        [FieldIndex(0)]
        public int Id { get; init; }
        [FieldIndex(1)]
        public string Reference { get; init; } = string.Empty;
        [FieldIndex(2)]
        public string Footprint { get; init; } = string.Empty;
        [FieldIndex(3)]
        public int Qty { get; init; }
        [FieldIndex(4)]
        public string Name { get; init; } = string.Empty;
        [FieldIndex(5)]
        public string Comment { get; init; } = string.Empty;
    }
}
