using AutoMapper;
using Catalog.Application.Interfaces.Repositories;
using Catalog.Shared.Constants.Application;
using Catalog.Shared.Wrapper;
using Domain.Entities.Catalog;
using LazyCache;
using MediatR;

namespace Catalog.Application.Features.Categories.Queries.GetAll
{
    public class GetAllCategoriesQuery : IRequest<Result<List<GetAllCategoriesResponse>>>
    {
        public GetAllCategoriesQuery()
        {
        }
    }

    internal class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, Result<List<GetAllCategoriesResponse>>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppCache _cache;

        public GetAllCategoriesQueryHandler(IUnitOfWork<int> unitOfWork, IMapper mapper, IAppCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<Result<List<GetAllCategoriesResponse>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            Func<Task<List<Category>>> getAllCategories = () => _unitOfWork.Repository<Category>().GetAllAsync();
            var categoryList = await _cache.GetOrAddAsync(ApplicationConstants.Cache.GetAllCategoriesCacheKey, getAllCategories);
            var mappedCategories = _mapper.Map<List<GetAllCategoriesResponse>>(categoryList);
            return await Result<List<GetAllCategoriesResponse>>.SuccessAsync(mappedCategories);
        }
    }
}
