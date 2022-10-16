using Catalog.Application.Specifications.Base;
using Catalog.Domain.Entities.Catalog;

namespace Catalog.Application.Specifications.Catalog
{
    public class BrandFilterSpecification : CatalogSpecification<Brand>
    {
        public BrandFilterSpecification(string searchString)
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
