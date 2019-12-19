namespace BmesRestApi.Messages.Request.Order
{
    public class FetchOrdersRequest
    {
        public int PageNumber { get; set; }
        public int OrdersPerPage { get; set; }
    }
}
