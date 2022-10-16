using AutoMapper;
using Catalog.Application.Features.Products.Commands.AddEdit;
using Catalog.Domain.Entities.Catalog;

namespace Catalog.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<AddEditProductCommand, Product>().ReverseMap();
        }
    }
}