using BmesRestApi.Messages.DataTransferObjects.Product;

namespace BmesRestApi.Messages.Response.Brand
{
    public class CreateBrandResponse : ResponseBase
    {
        public BrandDto Brand { get; set; }
    }
}
