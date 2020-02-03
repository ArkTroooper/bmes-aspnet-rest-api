using BmesRestApi.Messages.Request.Brand;
using BmesRestApi.Messages.Response.Brand;
using BmesRestApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BmesRestApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<GetBrandResponse> GetBrand(long id)
        {
            var getBrandRequest = new GetBrandRequest
                                    {
                                        Id = id
                                    };
            var getBrandResponse = _brandService.GetBrand(getBrandRequest);
            return getBrandResponse;
        }

        [AllowAnonymous]
        [HttpGet()]
        public ActionResult<FetchBrandsResponse> GetBrands()
        {
            var fetchBrandsRequest = new FetchBrandsRequest { };
            var fetchBrandsResponse = _brandService.GetBrands(fetchBrandsRequest);
            return fetchBrandsResponse;
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<CreateBrandResponse> PostBrand(CreateBrandRequest createBrandRequest) //Model binding
        {
            var createBrandResponse = _brandService.SaveBrand(createBrandRequest);
            return createBrandResponse;
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut()]
        public ActionResult<UpdateBrandResponse> PutBrand(UpdateBrandRequest updateBrandRequest)
        {
            var updateBrandResponse = _brandService.EditBrand(updateBrandRequest);
            return updateBrandResponse;
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<DeleteBrandResponse> DeleteBrand(long id)
        {
            var deleteBrandRequest = new DeleteBrandRequest
                                            {
                                                Id = id
                                            };
            var deleteBrandResponse = _brandService.DeleteBrand(deleteBrandRequest);
            return deleteBrandResponse;
        }
    }
}