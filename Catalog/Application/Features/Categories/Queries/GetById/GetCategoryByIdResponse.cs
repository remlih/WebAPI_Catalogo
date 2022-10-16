namespace Catalog.Application.Features.Categories.Queries.GetById
{
    public class GetCategoryByIdResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }
    }
}
