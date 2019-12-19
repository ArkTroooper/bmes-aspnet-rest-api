using BmesRestApi.Messages.Request.Checkout;
using BmesRestApi.Messages.Response.Checkout;

namespace BmesRestApi.Services
{
    public interface ICheckoutService
    {
        CheckoutResponse ProcessCheckout(CheckoutRequest checkoutRequest);
    }
}
