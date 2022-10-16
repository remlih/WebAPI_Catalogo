using AutoMapper;
using Catalog.Infrastructure.Models.Identity;
using Catalog.Application.Responses.Identity;

namespace Catalog.Infrastructure.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserResponse, CatalogUser>().ReverseMap();            
        }
    }
}