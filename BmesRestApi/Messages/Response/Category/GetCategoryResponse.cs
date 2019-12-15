namespace BmesRestApi.Messages.Response.Category
{
    using DataTransferObjects.Product;
    public class GetCategoryResponse:ResponseBase
    {
        public CategoryDto Category { get; set; }
    }
}
