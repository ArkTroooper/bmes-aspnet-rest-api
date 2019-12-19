namespace BmesRestApi.Messages.Request.Checkout
{
    using DataTransferObjects.Address;
    using DataTransferObjects.Cart;
    using DataTransferObjects.Customer;
    public class CheckoutRequest
    {
        public CustomerDto Customer { get; set; }

        public AddressDto Address { get; set; }

        public CartDto Cart { get; set; }
    }
}
