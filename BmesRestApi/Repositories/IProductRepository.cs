using System.Collections.Generic;
using BmesRestApi.Models.Product;

namespace BmesRestApi.Repositories
{
    public interface IProductRepository
    {
        Product FindProductById(long id);
        IEnumerable<Product> GetAllProducts();
        void SaveProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
