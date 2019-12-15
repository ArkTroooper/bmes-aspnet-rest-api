using BmesRestApi.Messages.DataTransferObjects.Product;

namespace BmesRestApi.Messages.Response.Brand
{
    public class DeleteBrandResponse: ResponseBase
    {
        public BrandDto Brand { get; set; }
    }
}
