namespace BmesRestApi.Models.Cart
{
    using System.Collections.Generic;
    using Shared;

    public class Cart:BaseObject
    {
        public Cart()
        {
            CartItems = new List<CartItem>();
        }

        public string UniqueCartId { get; set; }
        public CartStatus CartStatus { get; set; }
        public IEnumerable<CartItem> CartItems { get; set; }
    }
}
