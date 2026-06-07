namespace PCBAssemblyConverter.Presentation.Csv
{
    public class CsvTable
    {
        private readonly List<string> _headers = new();
        private readonly List<CsvRow> _rows = new();

        public IReadOnlyList<string> Headers => this._headers;
        public IReadOnlyList<CsvRow> Rows => this._rows;

        public CsvTable() { }
        public CsvTable(IEnumerable<string> headers, IEnumerable<CsvRow> rows)
        {
            this._headers.AddRange(headers);
            this._rows.AddRange(rows);
        }

        public void SetHeaders(IEnumerable<string> headers)
        {
            this._headers.Clear();
            this._headers.AddRange(headers);
        }

        public void SetRows(IEnumerable<CsvRow> rows)
        {
            this._rows.Clear();
            this._rows.AddRange(rows);
        }

        public void AddHeader(string header)
        {
            this._headers.Add(header);
        }

        public void AddHeaders(IEnumerable<string> headers)
        {
            this._headers.AddRange(headers);
        }

        public void AddRow(CsvRow row)
        {
            this._rows.Add(row);
        }

        public void AddRows(IEnumerable<CsvRow> rows)
        {
            this._rows.AddRange(rows);
        }

        public void Clear()
        {
            this._headers.Clear();
            this._rows.Clear();
        }
    }
}
