namespace PCBAssemblyConverter.Core.Formats.Common
{
    public record BomEntry : IBomEntry, ICommonModel
    {
        public int Id { get; init; }
        public string Reference { get; init; } = string.Empty;
        public string Footprint { get; init; } = string.Empty;
        public int Qty { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Comment { get; init; } = string.Empty;
    }
}
