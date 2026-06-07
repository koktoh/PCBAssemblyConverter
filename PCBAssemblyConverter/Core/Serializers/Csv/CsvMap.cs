using System.Reflection;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using PCBAssemblyConverter.Core.Attributes;
using PCBAssemblyConverter.Core.Formats;

namespace PCBAssemblyConverter.Core.Serializers.Csv
{
    public class CsvMap<T> : ClassMap<T>
    {
        public CsvMap()
        {
            foreach (var prop in typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                var map = this.Map(typeof(T), prop);

                var nameAttr = prop.GetCustomAttribute<FieldNameAttribute>();
                var indexAttr = prop.GetCustomAttribute<FieldIndexAttribute>();

                if (nameAttr is not null && indexAttr is not null)
                {
                    map.Name(nameAttr.Name)
                        .Index(indexAttr.Index);
                }
                else if (nameAttr is not null)
                {
                    map.Name(nameAttr.Name);
                }
                else if (indexAttr is not null)
                {
                    map.Index(indexAttr.Index);
                }
                else
                {
                    map.Name(prop.Name);
                }

                if (prop.PropertyType == typeof(Side))
                {
                    map.TypeConverter<SideConverter>();
                }
            }
        }

        public class SideConverter : DefaultTypeConverter
        {
            public override object ConvertFromString(string? text, CsvHelper.IReaderRow row, MemberMapData memberMapData)
            {
                if (text is null) throw new TypeConverterException(this, memberMapData, text, row.Context, $"Invalid side value: {text}");

                return text.Trim().ToLowerInvariant() switch
                {
                    "top" => Side.Top,
                    "bottom" => Side.Bottom,
                    _ => throw new TypeConverterException(this, memberMapData, text, row.Context, $"Invalid side value: {text}"),
                };
            }

            public override string ConvertToString(object? value, CsvHelper.IWriterRow row, MemberMapData memberMapData)
            {
                if (value is Side side)
                {
                    return side.ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}
