using PCBAssemblyConverter.Presentation.Roles;

namespace PCBAssemblyConverter.Services.IO
{
    public interface IImportService
    {
        public IEnumerable<Core.Formats.Common.BomEntry> ImportBomEntries(Stream inputStream, EdaTool tool);
        public IAsyncEnumerable<Core.Formats.Common.BomEntry> ImportBomEntriesAsync(Stream inputStream, EdaTool tool, CancellationToken cancellationToken = default);
        public IEnumerable<Core.Formats.Common.PosEntry> ImportPosEntries(Stream inputStream, EdaTool tool);
        public IAsyncEnumerable<Core.Formats.Common.PosEntry> ImportPosEntriesAsync(Stream inputStream, EdaTool tool, CancellationToken cancellationToken = default);
    }
}
