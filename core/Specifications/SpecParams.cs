namespace core.Specifications
{
    public class SpecParams
    {
        public int MaxpageSize { get; set; }
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 6;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxpageSize) ? MaxpageSize : value;
        }

        private string _search ;
        public string Search
        {
            get => _search;
            set => _search = (value.ToLower() );
        }

        public int? BrandId { get; set; }
        public int? TypeId { get; set; }

        public string sort { get; set; }
    }
}