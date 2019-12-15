using System.Collections.Generic;
using BmesRestApi.Models.Product;

namespace BmesRestApi.Repositories
{
    public interface ICategoryRepository
    {
        Category FindCategoryById(long id);
        IEnumerable<Category> GetAllCategories();
        void SaveCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
    }
}
