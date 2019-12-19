namespace BmesRestApi.Messages.Response.Cart
{
    using DataTransferObjects.Cart;

    public class FetchCartResponse:ResponseBase
    {
        public CartDto Cart { get; set; }
    }
}
