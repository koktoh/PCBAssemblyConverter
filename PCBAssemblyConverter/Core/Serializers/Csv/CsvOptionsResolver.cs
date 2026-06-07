using PCBAssemblyConverter.Core.Extensions;
using PCBAssemblyConverter.Core.Formats;

namespace PCBAssemblyConverter.Core.Serializers.Csv
{
    public static class CsvOptionsResolver
    {
        private static readonly IReadOnlyDictionary<Type, CsvOptions> _optionsMap = new Dictionary<Type, CsvOptions>()
        {
            { typeof(Formats.KiCad.BomEntry), new CsvOptions() { Delimiter = ";", HasHeader = true } },
            { typeof(Formats.KiCad.PosEntry), new CsvOptions() { Delimiter = ",", HasHeader = true } },
            { typeof(Formats.JLC.BomEntry), new CsvOptions() { Delimiter = ",", HasHeader = true } },
            { typeof(Formats.JLC.PosEntry), new CsvOptions() { Delimiter = ",", HasHeader = true } },
        };

        public static CsvOptions Resolve<T>()
            where T : IDataCategory, IModelRole
        {
            return Resolve(typeof(T));
        }

        public static CsvOptions Resolve(Type type)
        {
            if (_optionsMap.TryGetValue(type, out var options))
            {
                return options;
            }
            else
            {
                throw new InvalidOperationException($"No CSV options found for type {type.GetHierarchicalName(1)}");
            }
        }
    }
}
