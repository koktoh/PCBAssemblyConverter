using System.IO.Compression;

namespace PCBAssemblyConverter.Core.Storage
{
    public class ZipStorage : IStorage, IDisposable
    {
        private readonly ZipArchive _archive;
        private bool _disposedValue;

        public ZipStorage(Stream stream, ZipArchiveMode mode)
        {
            this._archive = new ZipArchive(stream, mode, leaveOpen: true);
        }

        public Stream OpenRead(string path)
        {
            var entry = this._archive.GetEntry(path);

            if (entry is null) throw new FileNotFoundException(path);

            return entry.Open();
        }

        public Stream OpenWrite(string path)
        {
            var entry = this._archive.GetEntry(path);

            if (entry is not null)
            {
                entry.Delete();
            }

            entry = this._archive.CreateEntry(path);

            return entry.Open();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this._disposedValue) return;

            if (disposing)
            {
                this._archive?.Dispose();
            }

            this._disposedValue = true;
        }

        public void Dispose()
        {
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
