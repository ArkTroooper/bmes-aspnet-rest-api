namespace BmesRestApi.Messages.Response.Order
{
    using DataTransferObjects.Order;
    public class GetOrderResponse : ResponseBase
    {
        public OrderDto Order { get; set; }
    }
}
