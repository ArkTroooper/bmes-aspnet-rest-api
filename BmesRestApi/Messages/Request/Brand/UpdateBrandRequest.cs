using BmesRestApi.Messages.DataTransferObjects.Product;

namespace BmesRestApi.Messages.Request.Brand
{
    public class UpdateBrandRequest
    {
        public int Id { get; set; }
        public BrandDto Brand { get; set; }
    }
}
