using Catalog.Domain.Constants.DataBase;
using Catalog.Domain.Contracts;
using Domain.Entities.Catalog;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Domain.Entities.Catalog
{
    [Table("Products", Schema = SchemasConstants.Catalog)]
    public class Product : AuditableEntity<int>
    {
        public string Name { get; set; }
        public string Barcode { get; set; }

        [Column(TypeName = "text")]
        public string ImageDataURL { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        public decimal Rate { get; set; }
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}