namespace BmesRestApi.Messages.Request.Brand
{
    public class FetchBrandsRequest
    {
        public int PageNumber { get; set; }
        public int BrandsPerPage { get; set; }
    }
}
