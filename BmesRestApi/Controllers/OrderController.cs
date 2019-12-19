using BmesRestApi.Messages.Request.Order;
using BmesRestApi.Messages.Response.Order;
using BmesRestApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BmesRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{id}")]
        public ActionResult<GetOrderResponse> GetOrder(long id)
        {
            var getOrderRequest = new GetOrderRequest
                                        {
                                            Id = id
                                        };
            var getOrderResponse = _orderService.GetOrder(getOrderRequest);
            return getOrderResponse;
        }

        [HttpGet()]
        public ActionResult<FetchOrdersResponse> GetOrders()
        {
            var fetchOrdersRequest = new FetchOrdersRequest { };
            var fetchOrdersResponse = _orderService.GetOrders(fetchOrdersRequest);
            return fetchOrdersResponse;
        }
    }
}