namespace WebAPICodeFirst.DTO
{
    public class PagedResponse<T>
    {
        public List<T> Data { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPage { get; set; }
        public int TotalItems { get; set; }

        public PagedResponse()
        {
            
        }

        public PagedResponse(List<T> data, int page, int pageSize, int totalPage, int totalItems)
        {
            Data = data;
            Page = page;
            PageSize = pageSize;
            TotalPage = totalPage;
            TotalItems = totalItems;
        }

    }
}
