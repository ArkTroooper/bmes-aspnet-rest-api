using System.Net;
using BmesRestApi.Messages;
using BmesRestApi.Messages.Request.Checkout;
using BmesRestApi.Messages.Response.Checkout;
using BmesRestApi.Models.Order;
using BmesRestApi.Repositories;

namespace BmesRestApi.Services.Implementations
{
    public class CheckoutService : ICheckoutService
    {

        private readonly IOrderRepository _orderRepository;
        private MessageMapper _messageMapper;
        private ICustomerRepository _customerRepository;
        private IPersonRepository _personRepository;
        private IAddressRepository _addressRepository;
        private IOrderItemRepository _orderItemRepository;
        private ICartRepository _cartRepository;
        private ICartItemRepository _cartItemRepository;
        private ICartService _cartService;

        public CheckoutService(
            ICustomerRepository customerRepository,
            IPersonRepository personRepository,
            IAddressRepository addressRepository,
            IOrderRepository orderRepository,
            IOrderItemRepository orderItemRepository,
            ICartRepository cartRepository,
            ICartItemRepository cartItemRepository,
            ICartService cartService
        )
        {
            _orderRepository = orderRepository;
            _messageMapper = new MessageMapper();
            _customerRepository = customerRepository;
            _personRepository = personRepository;
            _addressRepository = addressRepository;
            _orderItemRepository = orderItemRepository;
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _cartService = cartService;
        }

        public CheckoutResponse ProcessCheckout(CheckoutRequest checkoutRequest)
        {
            CheckoutResponse response = new CheckoutResponse();
            var customer = _messageMapper.MapToCustomer(checkoutRequest.Customer);

            var person = customer.Person;

            _personRepository.SavePerson(person);

            var address = _messageMapper.MapToAddress(checkoutRequest.Address);

            _addressRepository.SaveAddress(address);

            customer.PersonId = person.Id;
            customer.Person = person;

            _customerRepository.SaveCustomer(customer);

            var cart = _cartService.GetCart();

            if (cart != null)
            {
                var cartItems = _cartItemRepository.FindCartItemsByCartId(cart.Id);
                var cartTotal = _cartService.GetCartTotal();
                decimal shippingCharge = 0;
                var orderTotal = cartTotal + shippingCharge;

                var order = new Order
                {
                    OrderTotal = orderTotal,
                    OrderItemTotal = cartTotal,
                    ShippingCharge = shippingCharge,
                    AddressId = address.Id,
                    DeliveryAddress = address,
                    CustomerId = customer.Id,
                    Customer = customer,
                    OrderStatus = OrderStatus.Submitted
                };

                _orderRepository.SaveOrder(order);

                foreach (var cartItem in cartItems)
                {
                    var orderItem = new OrderItem
                    {
                        Quantity = cartItem.Quantity,
                        Order = order,
                        OrderId = order.Id,
                        Product = cartItem.Product,
                        ProductId = cartItem.ProductId
                    };

                    _orderItemRepository.SaveOrderItem(orderItem);
                }

                _cartRepository.DeleteCart(cart);

                response.StatusCode = HttpStatusCode.Created;
                response.Messages.Add("Order created");
            }
            else
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Messages.Add("There is a problem creating the order");
            }

            return response;
        }
    }
}
