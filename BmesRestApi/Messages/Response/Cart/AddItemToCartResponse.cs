namespace BmesRestApi.Messages.Response.Cart
{
    using DataTransferObjects.Cart;
    public class AddItemToCartResponse : ResponseBase
    {
        public CartItemDto CartItem { get; set; }
    }
}
