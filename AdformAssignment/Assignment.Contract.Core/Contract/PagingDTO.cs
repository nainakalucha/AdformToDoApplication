namespace Assignment.Contract.Core.Contract
{
    public class PagingDTO
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
    }
}
