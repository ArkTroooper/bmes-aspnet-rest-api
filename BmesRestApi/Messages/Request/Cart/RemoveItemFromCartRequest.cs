namespace BmesRestApi.Messages.Request.Cart
{
    public class RemoveItemFromCartRequest
    {
        public long CartId { get; set; }
        public long CartItemId { get; set; }
    }
}
