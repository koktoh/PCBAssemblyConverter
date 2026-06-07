namespace PCBAssemblyConverter.Presentation.Enum
{
    public record EnumOption<T>
        where T : struct, System.Enum
    {
        public T Value { get; init; }
        public string DisplayText { get; init; }

        public EnumOption(T value)
        {
            this.Value = value;
            this.DisplayText = value.ToString();
        }

        public EnumOption(T value, string displayText) : this(value)
        {
            this.DisplayText = string.IsNullOrEmpty(displayText) ? value.ToString() : displayText;
        }
    }
}
