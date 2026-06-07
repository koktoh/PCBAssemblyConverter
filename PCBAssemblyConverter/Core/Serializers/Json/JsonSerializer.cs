using System.Text.Json;

namespace PCBAssemblyConverter.Core.Serializers.Json
{
    public class JsonSerializer
    {
        private readonly JsonSerializerOptions _options;

        public JsonSerializer()
        {
            this._options = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };
        }

        public void Serialize<T>(Stream outputStream, T data)
        {
            System.Text.Json.JsonSerializer.Serialize(outputStream, data, this._options);
        }

        public async Task SerializeAsync<T>(Stream outputStream, T data, CancellationToken cancellationToken = default)
        {
            await System.Text.Json.JsonSerializer.SerializeAsync(outputStream, data, this._options, cancellationToken);
        }

        public T? Deserialize<T>(Stream inputStream)
        {
            return System.Text.Json.JsonSerializer.Deserialize<T>(inputStream, this._options);
        }

        public async Task<T?> DeserializeAsync<T>(Stream inputStream, CancellationToken cancellationToken = default)
        {
            return await System.Text.Json.JsonSerializer.DeserializeAsync<T>(inputStream, this._options, cancellationToken);
        }
    }
}
