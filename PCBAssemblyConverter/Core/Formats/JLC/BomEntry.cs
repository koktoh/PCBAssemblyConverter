using PCBAssemblyConverter.Core.Attributes;

namespace PCBAssemblyConverter.Core.Formats.JLC
{
    public record BomEntry : IBomEntry, IManufacturerModel
    {
        [FieldIndex(0)]
        public string Comment { get; init; } = string.Empty;
        [FieldIndex(1)]
        public string Designator { get; init; } = string.Empty;
        [FieldIndex(2)]
        public string Footprint { get; init; } = string.Empty;
        [FieldName("LCSC Part Number")]
        [FieldIndex(3)]
        public string PartNumber { get; init; } = string.Empty;
    }
}
