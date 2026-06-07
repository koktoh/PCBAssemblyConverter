using System.Reflection;
using System.Runtime.CompilerServices;
using PCBAssemblyConverter.Core.Converters;
using PCBAssemblyConverter.Core.Formats;
using PCBAssemblyConverter.Core.Formats.Common;
using PCBAssemblyConverter.Core.Serializers.Csv;
using PCBAssemblyConverter.Presentation.Roles;

namespace PCBAssemblyConverter.Services.IO
{
    public class EdaFileImportService : IImportService
    {
        private readonly ConverterProvider _converterProvider;
        private readonly MethodInfo? _importEntriesMethod;
        private readonly MethodInfo? _asyncImportEntriesMethod;

        public EdaFileImportService(ConverterProvider provider)
        {
            this._converterProvider = provider;
            this._importEntriesMethod = this.GetType().GetMethod(nameof(this.ImportEntriesInternal), BindingFlags.NonPublic | BindingFlags.Instance);
            this._asyncImportEntriesMethod = this.GetType().GetMethod(nameof(this.ImportEntriesInternalAsync), BindingFlags.NonPublic | BindingFlags.Instance);
        }

        public IEnumerable<BomEntry> ImportBomEntries(Stream inputStream, EdaTool tool)
        {
            var genericMethod = this._importEntriesMethod?.MakeGenericMethod(typeof(IBomEntry), tool.ResolveDataCategory<IBomEntry>(), typeof(BomEntry));

            return (IEnumerable<BomEntry>)(genericMethod?.Invoke(this, [inputStream]) ?? Enumerable.Empty<BomEntry>());
        }

        public async IAsyncEnumerable<BomEntry> ImportBomEntriesAsync(Stream inputStream, EdaTool tool, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            var genericMethod = this._asyncImportEntriesMethod?.MakeGenericMethod(typeof(IBomEntry), tool.ResolveDataCategory<IBomEntry>(), typeof(BomEntry));

            await foreach (var entry in (IAsyncEnumerable<BomEntry>)(genericMethod?.Invoke(this, [inputStream, cancellationToken]) ?? AsyncEnumerable.Empty<BomEntry>()))
            {
                yield return entry;
            }
        }

        public IEnumerable<PosEntry> ImportPosEntries(Stream inputStream, EdaTool tool)
        {
            var genericMethod = this._importEntriesMethod?.MakeGenericMethod(typeof(IPosEntry), tool.ResolveDataCategory<IPosEntry>(), typeof(PosEntry));

            return (IEnumerable<PosEntry>)(genericMethod?.Invoke(this, [inputStream]) ?? Enumerable.Empty<PosEntry>());
        }

        public async IAsyncEnumerable<PosEntry> ImportPosEntriesAsync(Stream inputStream, EdaTool tool, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            var genericMethod = this._asyncImportEntriesMethod?.MakeGenericMethod(typeof(IPosEntry), tool.ResolveDataCategory<IPosEntry>(), typeof(PosEntry));
            await foreach (var entry in (IAsyncEnumerable<PosEntry>)(genericMethod?.Invoke(this, [inputStream, cancellationToken]) ?? AsyncEnumerable.Empty<PosEntry>()))
            {
                yield return entry;
            }
        }

        private IEnumerable<TDst> ImportEntriesInternal<TCategory, TSrc, TDst>(Stream stream)
            where TCategory : IDataCategory
            where TSrc : TCategory, IModelRole
            where TDst : TCategory, IModelRole
        {
            var options = CsvOptionsResolver.Resolve<TSrc>();
            var serializer = new CsvSerializer(options);
            var entries = serializer.Deserialize<TSrc>(stream);
            var converter = this._converterProvider.Resolve<TCategory, TSrc, TDst>();
            return converter.ConvertEntries(entries);
        }

        private async IAsyncEnumerable<TDst> ImportEntriesInternalAsync<TCategory, TSrc, TDst>(Stream stream, [EnumeratorCancellation] CancellationToken cancellationToken = default)
            where TCategory : IDataCategory
            where TSrc : TCategory, IModelRole
            where TDst : TCategory, IModelRole
        {
            var options = CsvOptionsResolver.Resolve<TSrc>();
            var serializer = new CsvSerializer(options);
            var converter = this._converterProvider.Resolve<TCategory, TSrc, TDst>();

            await foreach (var entry in serializer.DeserializeAsync<TSrc>(stream, cancellationToken))
            {
                yield return converter.ConvertEntry(entry);
            }
        }
    }
}
