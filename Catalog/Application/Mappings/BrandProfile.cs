using AutoMapper;
using Catalog.Application.Features.Brands.Commands.AddEdit;
using Catalog.Application.Features.Brands.Queries.GetAll;
using Catalog.Application.Features.Brands.Queries.GetById;
using Catalog.Domain.Entities.Catalog;

namespace Catalog.Application.Mappings
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<AddEditBrandCommand, Brand>().ReverseMap();
            CreateMap<GetBrandByIdResponse, Brand>().ReverseMap();
            CreateMap<GetAllBrandsResponse, Brand>().ReverseMap();
        }
    }
}