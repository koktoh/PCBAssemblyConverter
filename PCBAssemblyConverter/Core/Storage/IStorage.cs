namespace PCBAssemblyConverter.Core.Storage
{
    public interface IStorage
    {
        Stream OpenRead(string path);
        Stream OpenWrite(string path);
    }
}
