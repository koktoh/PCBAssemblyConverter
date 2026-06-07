namespace PCBAssemblyConverter.Core.Storage
{
    public class FileStorage : IStorage
    {
        public Stream OpenRead(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException(nameof(path));
            if (!Path.Exists(path)) throw new FileNotFoundException(path);

            return new FileStream(path, FileMode.Open, FileAccess.Read);
        }

        public Stream OpenWrite(string path)
        {
            return new FileStream(path, FileMode.Create, FileAccess.Write);
        }
    }
}
