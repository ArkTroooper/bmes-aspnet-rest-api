using BmesRestApi.Messages.Request.Product;
using BmesRestApi.Messages.Response.Product;

namespace BmesRestApi.Services
{
    public interface ICatalogueService
    {
        FetchProductsResponse FetchProducts(FetchProductsRequest fetchProductsRequest);
    }
}
