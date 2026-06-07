using System.Collections;

namespace PCBAssemblyConverter.Presentation.Csv
{
    public class CsvRow : IEnumerable<string>
    {
        private readonly List<string> _columns = new();

        public string this[int index] => this._columns[index];

        public int ColumnCount => this._columns.Count;

        public IReadOnlyList<string> Columns => this._columns;

        public CsvRow() { }
        public CsvRow(IEnumerable<string> data)
        {
            this._columns.AddRange(data);
        }

        public void SetColumns(IEnumerable<string> columns)
        {
            this._columns.Clear();
            this._columns.AddRange(columns);
        }

        public void AddColumn(string column)
        {
            this._columns.Add(column);
        }

        public void AddColumns(IEnumerable<string> columns)
        {
            this._columns.AddRange(columns);
        }

        public void Clear()
        {
            this._columns.Clear();
        }

        public IEnumerator<string> GetEnumerator()
        {
            return ((IEnumerable<string>)this._columns).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this._columns).GetEnumerator();
        }
    }
}
