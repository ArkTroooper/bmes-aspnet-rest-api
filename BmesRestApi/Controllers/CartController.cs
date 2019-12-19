using BmesRestApi.Messages.Request.Cart;
using BmesRestApi.Messages.Response.Cart;
using BmesRestApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BmesRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public ActionResult<FetchCartResponse> GetCart()
        {
            var fetchCartResponse = _cartService.FetchCart();
            return fetchCartResponse;
        }

        [HttpPost]
        public ActionResult<AddItemToCartResponse> AddItemToCart(AddItemToCartRequest addItemToCartRequest)
        {
            var addItemToCartResponse = _cartService.AddItemToCart(addItemToCartRequest);
            return addItemToCartResponse;
        }

        [HttpDelete("{cartId}/{cartItemId}")]
        public ActionResult<RemoveItemFromCartResponse> RemoveItemFromCart(long cartId, long cartItemId)
        {
            var removeItemFromCartRequest = new RemoveItemFromCartRequest { CartId = cartId, CartItemId = cartItemId };
            var removeItemFromCartResponse = _cartService.RemoveItemFromCart(removeItemFromCartRequest);
            return removeItemFromCartResponse;
        }
    }
}