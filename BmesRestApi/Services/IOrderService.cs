using BmesRestApi.Messages.Request.Order;
using BmesRestApi.Messages.Response.Order;

namespace BmesRestApi.Services
{
    public interface IOrderService
    {
        GetOrderResponse GetOrder(GetOrderRequest getOrderRequest);
        FetchOrdersResponse GetOrders(FetchOrdersRequest fetchOrdersRequest);
    }
}
