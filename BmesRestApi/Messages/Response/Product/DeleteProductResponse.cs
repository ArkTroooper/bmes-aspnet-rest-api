namespace BmesRestApi.Messages.Response.Product
{
    using DataTransferObjects.Product;
    public class DeleteProductResponse: ResponseBase
    {
        public ProductDto Product { get; set; }
    }
}
