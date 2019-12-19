namespace BmesRestApi.Messages.Request.Cart
{
    using DataTransferObjects.Cart;
    public class AddItemToCartRequest
    {
        public long CartId { get; set; }
        public CartItemDto CartItem { get; set; }
        public long ProductId { get; set; }
    }
}
