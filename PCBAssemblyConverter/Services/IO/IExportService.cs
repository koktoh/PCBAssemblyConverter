using PCBAssemblyConverter.Core.Rules;
using PCBAssemblyConverter.Presentation.Roles;

namespace PCBAssemblyConverter.Services.IO
{
    public interface IExportService
    {
        public void ExportBomEntries(Stream outputStream, Manufacturer manufacturer, IEnumerable<Core.Formats.Common.BomEntry> bomEntries, ConversionRuleSet? ruleSet = null);
        public Task ExportBomEntriesAsync(Stream outputStream, Manufacturer manufacturer, IEnumerable<Core.Formats.Common.BomEntry> bomEntries, ConversionRuleSet? ruleSet = null, CancellationToken cancellationToken = default);
        public void ExportPosEntries(Stream outputStream, Manufacturer manufacturer, IEnumerable<Core.Formats.Common.PosEntry> posEntries, ConversionRuleSet? ruleSet = null);
        public Task ExportPosEntriesAsync(Stream outputStream, Manufacturer manufacturer, IEnumerable<Core.Formats.Common.PosEntry> posEntries, ConversionRuleSet? ruleSet = null, CancellationToken cancellationToken = default);
    }
}
