using System.Text.RegularExpressions;

namespace PCBAssemblyConverter.Core.Rules
{
    public class ConversionRuleSet
    {
        private readonly Dictionary<string, ConversionRule> _exactRules;
        private readonly List<ConversionRule> _containsRules;
        private readonly List<RegexRule> _regexRules;

        public ConversionRuleSet(IEnumerable<ConversionRule> rules)
        {
            var validRules = rules.Where(r => r.RuleAction != RuleAction.Passthrough)
                .ToList();

            this._exactRules = validRules.Where(r => r.MatchingStrategy == MatchingStrategy.Exact)
                .ToDictionary(r => r.Key, r => r);

            this._containsRules = validRules.Where(r => r.MatchingStrategy == MatchingStrategy.Contains)
                .OrderByDescending(r => r.Key.Length) // Longer keys should be checked first for "Contains" strategy
                .ToList();

            this._regexRules = validRules.Where(r => r.MatchingStrategy == MatchingStrategy.Regex)
                .Select(r => new RegexRule(r))
                .ToList();
        }

        public ConversionRule? GetRule(string key)
        {
            // Check for exact match first, then regex, and finally contains

            var rule = this.GetRuleByExact(key);
            if (rule is not null) return rule;

            rule = this.GetRuleByRegex(key);
            if (rule is not null) return rule;

            return this.GetRuleByContains(key);
        }

        private ConversionRule? GetRuleByExact(string key)
        {
            if (string.IsNullOrEmpty(key)) return null;
            if (this._exactRules.Count == 0) return null;

            return this._exactRules.TryGetValue(key, out var rule) ? rule : null;
        }

        private ConversionRule? GetRuleByContains(string key)
        {
            if (string.IsNullOrEmpty(key)) return null;
            if (this._containsRules.Count == 0) return null;

            return this._containsRules.FirstOrDefault(r => key.Contains(r.Key));
        }

        private ConversionRule? GetRuleByRegex(string key)
        {
            if (string.IsNullOrEmpty(key)) return null;
            if (this._regexRules.Count == 0) return null;

            return this._regexRules.FirstOrDefault(r => r.CompiledRegex.IsMatch(key))?.Rule;
        }

        private class RegexRule
        {
            public ConversionRule Rule { get; init; }
            public Regex CompiledRegex { get; init; }

            public RegexRule(ConversionRule rule)
            {
                this.Rule = rule;
                this.CompiledRegex = new Regex(rule.Key, RegexOptions.Compiled);
            }
        }
    }
}
