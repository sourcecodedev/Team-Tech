 

namespace TeamTech.Common
{
    public class PaginationParameter<T>
    {
        public string OrderBy { get; set; }
        public T Start { get; set; }
        public T CurrentPage { get; set; }
        public T AmountRows { get; set; }
        public string WhereFilter { get; set; }
    }
}
