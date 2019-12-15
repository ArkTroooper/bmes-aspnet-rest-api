using BmesRestApi.Messages.DataTransferObjects.Product;

namespace BmesRestApi.Messages.Response.Brand
{
    public class GetBrandResponse : ResponseBase
    {
        public BrandDto Brand { get; set; }
    }
}
