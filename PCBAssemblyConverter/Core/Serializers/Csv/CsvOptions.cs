namespace PCBAssemblyConverter.Core.Serializers.Csv
{
    public record CsvOptions
    {
        private const string DEFAULT_DELIMITER = ",";
        private const bool DEFAULT_HAS_HEADER = true;

        public string Delimiter { get; init; } = DEFAULT_DELIMITER;
        public bool HasHeader { get; init; } = DEFAULT_HAS_HEADER;
    }
}
