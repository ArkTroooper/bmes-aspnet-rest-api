using BmesRestApi.Messages.Request.Product;
using BmesRestApi.Messages.Response.Product;
using BmesRestApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BmesRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public ActionResult<GetProductResponse> GetProduct(long id)
        {
            var getProductRequest = new GetProductRequest
            {
                Id = id
            };
            var getProductResponse = _productService.GetProduct(getProductRequest);
            return getProductResponse;
        }

        [HttpGet("{categorySlug}/{brandSlug}/{page}/{productsPerPage}")]
        public ActionResult<FetchProductsResponse> GetProducts(string categorySlug, string brandSlug, int page, int productsPerPage)
        {
            var fetchProductsRequest = new FetchProductsRequest
                                                    {
                                                        PageNumber = page, 
                                                        ProductsPerPage = productsPerPage, 
                                                        CategorySlug = categorySlug, 
                                                        BrandSlug = brandSlug
                                                    };
            var fetchProductsResponse = _productService.GetProducts(fetchProductsRequest);
            return fetchProductsResponse;
        }

        [HttpPost]
        public ActionResult<CreateProductResponse> PostProduct(CreateProductRequest createProductRequest)
        {
            var createProductResponse = _productService.SaveProduct(createProductRequest);
            return createProductResponse;
        }

        [HttpPut()]
        public ActionResult<UpdateProductResponse> PutProduct(UpdateProductRequest updateProductRequest)
        {

            var updateProductResponse = _productService.EditProduct(updateProductRequest);

            return updateProductResponse;
        }

        [HttpDelete("{id}")]
        public ActionResult<DeleteProductResponse> DeleteProduct(long id)
        {
            var deleteProductRequest = new DeleteProductRequest
            {
                Id = id
            };
            var deleteProductResponse = _productService.DeleteProduct(deleteProductRequest);
            return deleteProductResponse;
        }
    }
}