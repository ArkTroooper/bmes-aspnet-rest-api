namespace BmesRestApi.Messages.Response.Cart
{
    using DataTransferObjects.Cart;
    public class RemoveItemFromCartResponse: ResponseBase
    {
        public long CartItemId { get; set; }
    }
}
