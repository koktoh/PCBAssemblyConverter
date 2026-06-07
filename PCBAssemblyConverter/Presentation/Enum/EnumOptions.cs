using PCBAssemblyConverter.Core.Rules;
using PCBAssemblyConverter.Localization;

namespace PCBAssemblyConverter.Presentation.Enum
{
    public static class EnumOptions
    {
        public static EnumOptionSet<MatchingStrategy> MatchingStrategies { get; } =
            new(
                new(MatchingStrategy.Exact),
                new(MatchingStrategy.Contains),
                new(MatchingStrategy.Regex)
            );

        public static EnumOptionSet<ChangeSide> ChangeSides { get; } =
            new(
                new(ChangeSide.None),
                new(ChangeSide.Top),
                new(ChangeSide.Bottom),
                new(ChangeSide.Reverse)
            );

        public static EnumOptionSet<RotationAdjustment> RotationAdjustments { get; } =
            new(
                new(RotationAdjustment.None),
                new(RotationAdjustment.Rot90),
                new(RotationAdjustment.Rot180),
                new(RotationAdjustment.Rot270)
            );

        public static EnumOptionSet<RuleAction> RuleActions { get; } =
            new(
                new(RuleAction.Convert),
                new(RuleAction.Passthrough),
                new(RuleAction.Exclude)
            );

        public static EnumOptionSet<Language> Languages { get; } =
            new(
                new(Language.Japanese),
                new(Language.English)
            );
    }
}
