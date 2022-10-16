using AutoMapper;
using Catalog.Infrastructure.Models.Identity;
using Catalog.Application.Responses.Identity;

namespace Catalog.Infrastructure.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleResponse, CatalogRole>().ReverseMap();
        }
    }
}