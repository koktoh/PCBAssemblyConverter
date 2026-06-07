namespace PCBAssemblyConverter.Core.Formats.Common
{
    public record PosEntry : IPosEntry, ICommonModel
    {
        public string Reference { get; init; } = string.Empty;
        public string Value { get; init; } = string.Empty;
        public string Package { get; init; } = string.Empty;
        public double PosX { get; init; }
        public double PosY { get; init; }
        public double Rotation { get; init; }
        public Side Side { get; init; }
    }
}
