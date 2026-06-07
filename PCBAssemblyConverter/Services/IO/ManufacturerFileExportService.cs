using System.Reflection;
using PCBAssemblyConverter.Core.Converters;
using PCBAssemblyConverter.Core.Formats;
using PCBAssemblyConverter.Core.Formats.Common;
using PCBAssemblyConverter.Core.Rules;
using PCBAssemblyConverter.Core.Serializers.Csv;
using PCBAssemblyConverter.Presentation.Roles;

namespace PCBAssemblyConverter.Services.IO
{
    public class ManufacturerFileExportService : IExportService
    {

        private readonly ConverterProvider _converterProvider;
        private readonly MethodInfo? _exportEntriesMethod;
        private readonly MethodInfo? _asyncExportEntriesMethod;

        public ManufacturerFileExportService(ConverterProvider provider)
        {
            this._converterProvider = provider;
            this._exportEntriesMethod = this.GetType().GetMethod(nameof(this.ExportEntriesInternal), BindingFlags.NonPublic | BindingFlags.Instance);
            this._asyncExportEntriesMethod = this.GetType().GetMethod(nameof(this.ExportEntriesInternalAsync), BindingFlags.NonPublic | BindingFlags.Instance);
        }

        public void ExportBomEntries(Stream outputStream, Manufacturer manufacturer, IEnumerable<BomEntry> bomEntries, ConversionRuleSet? ruleSet = null)
        {
            var genericMethod = this._exportEntriesMethod?.MakeGenericMethod(typeof(IBomEntry), typeof(BomEntry), manufacturer.ResolveDataCategory<IBomEntry>());
            genericMethod?.Invoke(this, [outputStream, bomEntries, ruleSet]);
        }

        public async Task ExportBomEntriesAsync(Stream outputStream, Manufacturer manufacturer, IEnumerable<BomEntry> bomEntries, ConversionRuleSet? ruleSet = null, CancellationToken cancellationToken = default)
        {
            var genericMethod = this._asyncExportEntriesMethod?.MakeGenericMethod(typeof(IBomEntry), typeof(BomEntry), manufacturer.ResolveDataCategory<IBomEntry>());
            await (Task)(genericMethod?.Invoke(this, [outputStream, bomEntries, ruleSet, cancellationToken]) ?? Task.CompletedTask);
        }

        public void ExportPosEntries(Stream outputStream, Manufacturer manufacturer, IEnumerable<PosEntry> posEentries, ConversionRuleSet? ruleSet = null)
        {
            var genericMethod = this._exportEntriesMethod?.MakeGenericMethod(typeof(IPosEntry), typeof(PosEntry), manufacturer.ResolveDataCategory<IPosEntry>());
            genericMethod?.Invoke(this, [outputStream, posEentries, ruleSet]);
        }

        public async Task ExportPosEntriesAsync(Stream outputStream, Manufacturer manufacturer, IEnumerable<PosEntry> posEntries, ConversionRuleSet? ruleSet = null, CancellationToken cancellationToken = default)
        {
            var genericMethod = this._asyncExportEntriesMethod?.MakeGenericMethod(typeof(IPosEntry), typeof(PosEntry), manufacturer.ResolveDataCategory<IPosEntry>());
            await (Task)(genericMethod?.Invoke(this, [outputStream, posEntries, ruleSet, cancellationToken]) ?? Task.CompletedTask);
        }

        private void ExportEntriesInternal<TCategory, TSrc, TDst>(Stream stream, IEnumerable<TSrc> entries, ConversionRuleSet? ruleSet = null)
            where TCategory : IDataCategory
            where TSrc : TCategory, IModelRole
            where TDst : TCategory, IModelRole
        {
            var converter = this._converterProvider.Resolve<TCategory, TSrc, TDst>();
            var convertedEntries = converter.ConvertEntries(entries, ruleSet);
            var options = CsvOptionsResolver.Resolve<TDst>();
            var serializer = new CsvSerializer(options);
            serializer.Serialize(stream, convertedEntries);
        }

        private async Task ExportEntriesInternalAsync<TCategory, TSrc, TDst>(Stream stream, IEnumerable<TSrc> entries, ConversionRuleSet? ruleSet = null, CancellationToken cancellationToken = default)
            where TCategory : IDataCategory
            where TSrc : TCategory, IModelRole
            where TDst : TCategory, IModelRole
        {
            var converter = this._converterProvider.Resolve<TCategory, TSrc, TDst>();
            var convertedEntries = converter.ConvertEntries(entries, ruleSet);
            var options = CsvOptionsResolver.Resolve<TDst>();
            var serializer = new CsvSerializer(options);
            await serializer.SerializeAsync(stream, convertedEntries, cancellationToken);
        }
    }
}
