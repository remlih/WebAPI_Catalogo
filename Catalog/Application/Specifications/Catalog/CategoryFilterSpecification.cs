using Catalog.Application.Specifications.Base;
using Domain.Entities.Catalog;

namespace Application.Specifications.Catalog
{
    public class CategoryFilterSpecification : CatalogSpecification<Category>
    {
        public CategoryFilterSpecification(string? searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                Criteria = p => p.Name.Contains(searchString) || p.Description.Contains(searchString);
            }
            else
            {
                Criteria = p => true;
            }
        }
    }
}
