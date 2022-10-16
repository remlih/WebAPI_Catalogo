using Catalog.Domain.Constants.DataBase;
using Catalog.Domain.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Domain.Entities.Catalog
{
    [Table("Brands", Schema = SchemasConstants.Catalog)]
    public class Brand : AuditableEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }        
        public bool IsEnabled { get; set; } = true;
    }
}