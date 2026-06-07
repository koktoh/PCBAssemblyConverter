using PCBAssemblyConverter.Localization;

namespace PCBAssemblyConverter.Presentation.Enum
{
    public static class EnumOptionExtensions
    {
        public static IEnumerable<EnumOption<T>> Localize<T>(this IEnumerable<EnumOption<T>> options, LocalizationService localization)
            where T : struct, System.Enum
        {
            return options.Select(x => x with { DisplayText = localization.GetEnumDisplayName(x.Value) });
        }
    }
}
