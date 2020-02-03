using BmesRestApi.Messages.Request.Checkout;
using BmesRestApi.Messages.Response.Checkout;
using BmesRestApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BmesRestApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly ICheckoutService _checkoutService;
        public CheckoutController(ICheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
        }

        [HttpPost]
        public ActionResult<CheckoutResponse> Checkout(CheckoutRequest checkoutRequest)
        {
            var checkoutResponse = _checkoutService.ProcessCheckout(checkoutRequest);
            return checkoutResponse;
        }
    }
}