namespace PCBAssemblyConverter.Core.Formats
{
    public interface IDataCategory { }
    public interface IBomEntry : IDataCategory { }
    public interface IPosEntry : IDataCategory { }

    public interface IModelRole { }
    public interface IEdaModel : IModelRole { }
    public interface ICommonModel : IModelRole { }
    public interface IManufacturerModel : IModelRole { }
}
