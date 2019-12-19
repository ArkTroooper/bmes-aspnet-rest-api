using System.Collections.Generic;
using System.Linq;
using BmesRestApi.Database;
using BmesRestApi.Models.Cart;
using Microsoft.EntityFrameworkCore;

namespace BmesRestApi.Repositories.Implementations
{
    public class CartItemRepository :ICartItemRepository
    {
        private BmesDbContext _context;

        public CartItemRepository(BmesDbContext context)
        {
            _context = context;
        }

        public CartItem FindCartItemById(long id)
        {
            var cartItem = _context.CartItems.Find(id);

            return cartItem;
        }

        public IEnumerable<CartItem> FindCartItemsByCartId(long cartId)
        {
            var cartItems = _context.CartItems.Where(cartItem => cartItem.CartId == cartId).Include(c => c.Product);
            return cartItems;
        }

        public void SaveCartItem(CartItem cartItem)
        {
            _context.CartItems.Add(cartItem);
            _context.SaveChanges();
        }

        public void UpdateCartItem(CartItem cartItem)
        {
            _context.CartItems.Update(cartItem);
            _context.SaveChanges();
        }

        public void DeleteCartItem(CartItem cartItem)
        {
            _context.CartItems.Remove(cartItem);
            _context.SaveChanges();
        }
    }
}
