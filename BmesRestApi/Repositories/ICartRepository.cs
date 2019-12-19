using System.Collections.Generic;
using BmesRestApi.Models.Cart;

namespace BmesRestApi.Repositories
{
    public interface ICartRepository
    {
        Cart FindCartById(long id);
        IEnumerable<Cart> GetAllCarts();
        void SaveCart(Cart cart);
        void UpdateCart(Cart cart);
        void DeleteCart(Cart cart);
    }
}
