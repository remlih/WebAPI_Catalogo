namespace Catalog.Application.Features.Categories.Queries.GetAll
{
    public class GetAllCategoriesResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }
    }
}
