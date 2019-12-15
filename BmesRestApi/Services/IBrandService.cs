using BmesRestApi.Messages.Request.Brand;
using BmesRestApi.Messages.Response.Brand;

namespace BmesRestApi.Services
{
    public interface IBrandService
    {
        CreateBrandResponse SaveBrand(CreateBrandRequest brandRequest);
        UpdateBrandResponse EditBrand(UpdateBrandRequest updateBrandRequest);
        GetBrandResponse GetBrand(GetBrandRequest getBrandRequest);
        FetchBrandsResponse GetBrands(FetchBrandsRequest fetchBrandsRequest);
        DeleteBrandResponse DeleteBrand(DeleteBrandRequest deleteBrandRequest);
    }
}
