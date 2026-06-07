namespace PCBAssemblyConverter.Presentation.Enum
{
    public class EnumOptionSet<T>
        where T : struct, System.Enum
    {
        private readonly IReadOnlyList<EnumOption<T>> _options;

        public IReadOnlyList<EnumOption<T>> Options => this._options;

        public EnumOptionSet(params EnumOption<T>[] options)
        {
            this._options = options;
        }
    }
}
