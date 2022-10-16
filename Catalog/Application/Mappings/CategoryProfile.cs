using AutoMapper;
using Catalog.Application.Features.Categories.Commands.AddEdit;
using Catalog.Application.Features.Categories.Queries.GetAll;
using Catalog.Application.Features.Categories.Queries.GetById;
using Domain.Entities.Catalog;

namespace Application.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<AddEditCategoryCommand, Category>().ReverseMap();
            CreateMap<GetCategoryByIdResponse, Category>().ReverseMap();
            CreateMap<GetAllCategoriesResponse, Category>().ReverseMap();
        }
    }
}
