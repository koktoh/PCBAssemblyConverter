using PCBAssemblyConverter.Core.Rules;
using PCBAssemblyConverter.Localization.Resources;

namespace PCBAssemblyConverter.Localization
{
    public class LocalizationService
    {
        private readonly IReadOnlyDictionary<Language, ILocalize> _map = new Dictionary<Language, ILocalize>()
        {
            { Language.Japanese, new LocalizeJP() },
            { Language.English, new LocalizeEN() },
        };

        private Language _currentLanguage = Language.Japanese;

        public event Action? OnLanguageChanged;

        public Language Language
        {
            get => this._currentLanguage;
            set
            {
                if (this._currentLanguage != value)
                {
                    this._currentLanguage = value;
                    this.OnLanguageChanged?.Invoke();
                }
            }
        }

        public ILocalize Localize => this.GetLocalize();

        private ILocalize GetLocalize()
        {
            if (this._map.TryGetValue(this.Language, out var localize))
            {
                return localize;
            }

            return this._map[Language.Japanese];
        }

        public string GetEnumDisplayName<T>(T value)
            where T : Enum
        {
            return value switch
            {
                MatchingStrategy.Exact => this.Localize.MatchingStrategy_Exact_Display_Text,
                MatchingStrategy.Contains => this.Localize.MatchingStrategy_Contains_Display_Text,
                MatchingStrategy.Regex => this.Localize.MatchingStrategy_Regex_Display_Text,

                ChangeSide.None => this.Localize.ChangeSide_None_Display_Text,
                ChangeSide.Top => this.Localize.ChangeSide_Top_Display_Text,
                ChangeSide.Bottom => this.Localize.ChangeSide_Bottom_Display_Text,
                ChangeSide.Reverse => this.Localize.ChangeSide_Reverse_Display_Text,

                RotationAdjustment.None => this.Localize.RotationAdjustment_None_Display_Text,
                RotationAdjustment.Rot90 => this.Localize.RotationAdjustment_Rot90_Display_Text,
                RotationAdjustment.Rot180 => this.Localize.RotationAdjustment_Rot180_Display_Text,
                RotationAdjustment.Rot270 => this.Localize.RotationAdjustment_Rot270_Display_Text,

                RuleAction.Convert => this.Localize.RuleAction_Convert_Display_Text,
                RuleAction.Exclude => this.Localize.RuleAction_Exclude_Display_Text,
                RuleAction.Passthrough => this.Localize.RuleAction_Passthrough_Display_Text,

                Language.Japanese => this.Localize.Language_Japanese_Display_Text,
                Language.English => this.Localize.Language_English_Display_Text,

                _ => value.ToString()
            };
        }

        public string GetEnumDisplayName(MatchingStrategy strategy)
        {
            return strategy switch
            {
                MatchingStrategy.Exact => this.Localize.MatchingStrategy_Exact_Display_Text,
                MatchingStrategy.Contains => this.Localize.MatchingStrategy_Contains_Display_Text,
                MatchingStrategy.Regex => this.Localize.MatchingStrategy_Regex_Display_Text,
                _ => string.Empty
            };
        }

        public string GetEnumDisplayName(ChangeSide changeSide)
        {
            return changeSide switch
            {
                ChangeSide.None => this.Localize.ChangeSide_None_Display_Text,
                ChangeSide.Top => this.Localize.ChangeSide_Top_Display_Text,
                ChangeSide.Bottom => this.Localize.ChangeSide_Bottom_Display_Text,
                ChangeSide.Reverse => this.Localize.ChangeSide_Reverse_Display_Text,
                _ => string.Empty
            };
        }

        public string GetEnumDisplayName(RotationAdjustment adjustment)
        {
            return adjustment switch
            {
                RotationAdjustment.None => this.Localize.RotationAdjustment_None_Display_Text,
                RotationAdjustment.Rot90 => this.Localize.RotationAdjustment_Rot90_Display_Text,
                RotationAdjustment.Rot180 => this.Localize.RotationAdjustment_Rot180_Display_Text,
                RotationAdjustment.Rot270 => this.Localize.RotationAdjustment_Rot270_Display_Text,
                _ => string.Empty
            };
        }

        public string GetEnumDisplayName(RuleAction ruleAction)
        {
            return ruleAction switch
            {
                RuleAction.Convert => this.Localize.RuleAction_Convert_Display_Text,
                RuleAction.Exclude => this.Localize.RuleAction_Exclude_Display_Text,
                RuleAction.Passthrough => this.Localize.RuleAction_Passthrough_Display_Text,
                _ => string.Empty
            };
        }

        public string GetEnumDisplayName(Language language)
        {
            return language switch
            {
                Language.Japanese => this.Localize.Language_Japanese_Display_Text,
                Language.English => this.Localize.Language_English_Display_Text,
                _ => string.Empty
            };
        }

        public string GetEnumDescription<T>(T value)
            where T : struct, Enum
        {
            return value switch
            {
                MatchingStrategy.Exact => this.Localize.MatchingStrategy_Exact_Description,
                MatchingStrategy.Contains => this.Localize.MatchingStrategy_Contains_Description,
                MatchingStrategy.Regex => this.Localize.MatchingStrategy_Regex_Description,

                ChangeSide.None => this.Localize.ChangeSide_None_Description,
                ChangeSide.Top => this.Localize.ChangeSide_Top_Description,
                ChangeSide.Bottom => this.Localize.ChangeSide_Bottom_Description,
                ChangeSide.Reverse => this.Localize.ChangeSide_Reverse_Description,

                RuleAction.Convert => this.Localize.RuleAction_Convert_Description,
                RuleAction.Exclude => this.Localize.RuleAction_Exclude_Description,
                RuleAction.Passthrough => this.Localize.RuleAction_Passthrough_Description,

                _ => string.Empty
            };
        }
    }
}
