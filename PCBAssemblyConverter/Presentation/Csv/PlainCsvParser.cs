using CsvHelper;
using PCBAssemblyConverter.Core.Serializers.Csv;

namespace PCBAssemblyConverter.Presentation.Csv
{
    public class PlainCsvParser
    {
        private readonly CsvOptions _options;

        public PlainCsvParser()
        {
            this._options = new CsvOptions();
        }

        public PlainCsvParser(CsvOptions options)
        {
            this._options = options;
        }

        private CsvTable ParseInternal(TextReader reader)
        {
            var config = this._options.ToCsvConfiguration();

            using var csvReader = new CsvReader(reader, config);

            var csv = new CsvTable();

            var header = null as string[];

            if (config.HasHeaderRecord)
            {
                csvReader.Read();
                csvReader.ReadHeader();

                header = csvReader.HeaderRecord;
            }

            while (csvReader.Read())
            {
                var row = new CsvRow();
                for (var i = 0; i < csvReader.Parser.Count; i++)
                {
                    var value = csvReader.GetField(i) ?? string.Empty;
                    row.AddColumn(value);
                }
                csv.AddRow(row);
            }

            if (header is null)
            {
                var count = csv.Rows.DefaultIfEmpty().Max(r => r?.ColumnCount ?? 0);
                header = Enumerable.Range(0, count).Select(i => $"Column {i}").ToArray();
            }

            csv.SetHeaders(header);

            return csv;
        }

        public CsvTable Parse(string csvContent)
        {
            using var reader = new StringReader(csvContent);
            return this.ParseInternal(reader);
        }

        public CsvTable Parse(Stream stream)
        {
            using var reader = new StreamReader(stream, leaveOpen: true);

            var csv = this.ParseInternal(reader);

            if (stream.CanSeek)
            {
                stream.Seek(0, SeekOrigin.Begin); // Reset stream position after reading
            }

            return csv;
        }

        public async Task<CsvTable> ParseAsync(string csvContent)
        {
            return await Task.FromResult(this.Parse(csvContent));
        }

        public async Task<CsvTable> ParseAsync(Stream stream)
        {
            return await Task.FromResult(this.Parse(stream));
        }
    }
}
