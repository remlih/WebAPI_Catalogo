using System;
using System.Collections.Generic;
using Catalog.Domain.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Catalog.Infrastructure.Models.Identity
{
    public class CatalogRole : IdentityRole, IAuditableEntity<string>
    {
        public string? Description { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public virtual ICollection<CatalogRoleClaim> RoleClaims { get; set; }

        public CatalogRole() : base()
        {
            RoleClaims = new HashSet<CatalogRoleClaim>();
        }

        public CatalogRole(string roleName, string roleDescription = null) : base(roleName)
        {
            RoleClaims = new HashSet<CatalogRoleClaim>();
            Description = roleDescription;
        }
    }
}