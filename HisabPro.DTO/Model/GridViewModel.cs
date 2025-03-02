namespace HisabPro.DTO.Model
{
    public class GridViewModel<T>
    {
        public List<Column> Columns { get; set; }
        public IEnumerable<T> Data { get; set; }
        public int TotalRecords { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? SortBy { get; set; }
        public string? SortDirection { get; set; }
        //public List<BaseFilterModel>? Filters { get; set; }  
        public FilterViewModel? Filter { get; set; }
    }

    public class Column
    {
        public string Name { get; set; }
        public bool IsVisible { get; set; } = true;
        public Type Type { get; set; } = Type.Label;
        public Align Align { get; set; } = Align.Left;

        private string _width;
        public string Width
        {
            get => string.IsNullOrEmpty(_width) ? GetDefaultWidth(Type) : _width;
            set => _width = value;
        }

        public string CssName { get; set; }

        private string _title;
        public string Title
        {
            get => string.IsNullOrWhiteSpace(_title) ? Name : _title;
            set => _title = value;
        }

        private bool _sortable = true; //Default set to true for all the columns except Edit and Delete
        public bool IsSortable
        {
            get => (Type == Type.Edit || Type == Type.Delete) ? false : _sortable;
            set => _sortable = value;
        }

        private static string GetDefaultWidth(Type type)
        {
            return type switch
            {
                Type.Edit => "50px",
                Type.Delete => "65px",
                _ => "Auto"
            };
        }
    }

    public enum Type
    {
        Label = 1,
        Edit = 2,
        Delete = 3,
        Date = 4,
        Checkbox = 5
    }

    public enum Align
    {
        Left = 1,
        Center = 2,
        Right = 3
    }
}
