using Catalog.Domain.Constants.DataBase;
using Catalog.Domain.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Catalog
{
    [Table("Categories", Schema = SchemasConstants.Catalog)]
    public class Category : AuditableEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; } = true;
    }
}
