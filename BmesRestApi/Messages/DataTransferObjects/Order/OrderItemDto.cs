using BmesRestApi.Messages.DataTransferObjects.Product;

namespace BmesRestApi.Messages.DataTransferObjects.Order
{
    public class OrderItemDto
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }
    }
}
