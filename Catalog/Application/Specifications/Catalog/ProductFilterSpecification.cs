using Catalog.Application.Specifications.Base;
using Catalog.Domain.Entities.Catalog;

namespace Catalog.Application.Specifications.Catalog
{
    public class ProductFilterSpecification : CatalogSpecification<Product>
    {
        public ProductFilterSpecification(string searchString)
        {
            Includes.Add(a => a.Brand);
            Includes.Add(a => a.Category);

            if (!string.IsNullOrEmpty(searchString))
            {
                Criteria = p => p.Barcode != null && (p.Name.Contains(searchString) || p.Description.Contains(searchString) || p.Barcode.Contains(searchString) 
                || p.Brand.Name.Contains(searchString) || p.Category.Name.Contains(searchString));
            }
            else
            {
                Criteria = p => p.Barcode != null;
            }
        }
    }
}