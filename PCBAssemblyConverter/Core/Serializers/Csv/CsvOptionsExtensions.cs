using System.Globalization;
using CsvHelper.Configuration;

namespace PCBAssemblyConverter.Core.Serializers.Csv
{
    public static class CsvOptionsExtensions
    {
        public static CsvConfiguration ToCsvConfiguration(this CsvOptions options)
        {
            return new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = options.Delimiter,
                HasHeaderRecord = options.HasHeader,
                IgnoreBlankLines = true,
                TrimOptions = TrimOptions.Trim,
            };
        }
    }
}
