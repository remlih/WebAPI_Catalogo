using System;
using Catalog.Domain.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Catalog.Infrastructure.Models.Identity
{
    public class CatalogRoleClaim : IdentityRoleClaim<string>, IAuditableEntity<int>
    {
        public string? Description { get; set; }
        public string? Group { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public virtual CatalogRole Role { get; set; }

        public CatalogRoleClaim() : base()
        {
        }

        public CatalogRoleClaim(string roleClaimDescription = null, string roleClaimGroup = null) : base()
        {
            Description = roleClaimDescription;
            Group = roleClaimGroup;
        }
    }
}