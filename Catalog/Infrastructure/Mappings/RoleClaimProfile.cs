using AutoMapper;
using Catalog.Application.Requests.Identity;
using Catalog.Application.Responses.Identity;
using Catalog.Infrastructure.Models.Identity;

namespace Catalog.Infrastructure.Mappings
{
    public class RoleClaimProfile : Profile
    {
        public RoleClaimProfile()
        {
            CreateMap<RoleClaimResponse, CatalogRoleClaim>()
                .ForMember(nameof(CatalogRoleClaim.ClaimType), opt => opt.MapFrom(c => c.Type))
                .ForMember(nameof(CatalogRoleClaim.ClaimValue), opt => opt.MapFrom(c => c.Value))
                .ReverseMap();

            CreateMap<RoleClaimRequest, CatalogRoleClaim>()
                .ForMember(nameof(CatalogRoleClaim.ClaimType), opt => opt.MapFrom(c => c.Type))
                .ForMember(nameof(CatalogRoleClaim.ClaimValue), opt => opt.MapFrom(c => c.Value))
                .ReverseMap();
        }
    }
}