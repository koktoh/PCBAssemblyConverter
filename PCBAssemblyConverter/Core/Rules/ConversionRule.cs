namespace PCBAssemblyConverter.Core.Rules
{
    public record ConversionRule
    {
        public string Name { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public MatchingStrategy MatchingStrategy { get; set; } = MatchingStrategy.Exact;
        public double OffsetX { get; set; }
        public double OffsetY { get; set; }
        public ChangeSide ChangeSide { get; set; } = ChangeSide.None;
        public RotationAdjustment RotationAdjustment { get; set; } = RotationAdjustment.None;
        public string ManufacturerPartNumber { get; set; } = string.Empty;
        public string ManufacturerPartNotes { get; set; } = string.Empty;
        public RuleAction RuleAction { get; set; } = RuleAction.Convert;
    }
}
