using System.Globalization;
using System.Runtime.CompilerServices;
using CsvHelper.Configuration;

namespace PCBAssemblyConverter.Core.Serializers.Csv
{
    public class CsvSerializer
    {
        private readonly CsvConfiguration _config;
        public CsvOptions Options { get; }

        public CsvSerializer()
        {
            this.Options = new CsvOptions();
            this._config = this.CreateConfig();
        }

        public CsvSerializer(CsvOptions options)
        {
            this.Options = options;
            this._config = this.CreateConfig();
        }

        private CsvConfiguration CreateConfig()
        {
            return new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = this.Options.Delimiter,
                HasHeaderRecord = this.Options.HasHeader,
                IgnoreBlankLines = true,
                TrimOptions = TrimOptions.Trim,
            };
        }

        public void Serialize<T>(Stream outputStream, IEnumerable<T> data)
        {
            using var writer = new StreamWriter(outputStream, leaveOpen: true);
            using var csvWriter = new CsvHelper.CsvWriter(writer, this._config);

            csvWriter.Context.RegisterClassMap<CsvMap<T>>();
            csvWriter.WriteRecords(data);
        }

        public async Task SerializeAsync<T>(Stream outputStream, IEnumerable<T> data, CancellationToken cancellationToken = default)
        {
            using var writer = new StreamWriter(outputStream, leaveOpen: true);
            using var csvWriter = new CsvHelper.CsvWriter(writer, this._config);

            csvWriter.Context.RegisterClassMap<CsvMap<T>>();
            await csvWriter.WriteRecordsAsync(data, cancellationToken);
        }

        public IEnumerable<T> Deserialize<T>(Stream inputStream)
        {
            try
            {
                using var reader = new StreamReader(inputStream, leaveOpen: true);
                using var csvReader = new CsvHelper.CsvReader(reader, this._config);

                csvReader.Context.RegisterClassMap<CsvMap<T>>();

                foreach (var record in csvReader.GetRecords<T>())
                {
                    yield return record;
                }
            }
            finally
            {
                if (inputStream.CanSeek)
                {
                    inputStream.Seek(0, SeekOrigin.Begin);
                }
            }
        }

        public async IAsyncEnumerable<T> DeserializeAsync<T>(Stream inputStream, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            try
            {
                using var reader = new StreamReader(inputStream, leaveOpen: true);
                using var csvReader = new CsvHelper.CsvReader(reader, this._config);

                csvReader.Context.RegisterClassMap<CsvMap<T>>();

                await foreach (var record in csvReader.GetRecordsAsync<T>(cancellationToken))
                {
                    yield return record;
                }
            }
            finally
            {
                if (inputStream.CanSeek)
                {
                    inputStream.Seek(0, SeekOrigin.Begin);
                }
            }
        }
    }
}
