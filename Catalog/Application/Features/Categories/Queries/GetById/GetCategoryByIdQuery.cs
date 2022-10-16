using AutoMapper;
using Catalog.Application.Interfaces.Repositories;
using Catalog.Shared.Wrapper;
using Domain.Entities.Catalog;
using MediatR;

namespace Catalog.Application.Features.Categories.Queries.GetById
{
    public class GetCategoryByIdQuery : IRequest<Result<GetCategoryByIdResponse>>
    {
        public int Id { get; set; }
    }

    internal class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Result<GetCategoryByIdResponse>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(IUnitOfWork<int> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetCategoryByIdResponse>> Handle(GetCategoryByIdQuery query, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.Repository<Category>().GetByIdAsync(query.Id);
            var mappedCategory = _mapper.Map<GetCategoryByIdResponse>(category);
            return await Result<GetCategoryByIdResponse>.SuccessAsync(mappedCategory);
        }
    }
}
