using Application.Interfaces.Repositories;
using Catalog.Application.Interfaces.Repositories;
using Catalog.Shared.Constants.Application;
using Catalog.Shared.Wrapper;
using Domain.Entities.Catalog;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Catalog.Application.Features.Categories.Commands.Delete
{
    public class DeleteCategoryCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    internal class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Result<int>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IStringLocalizer<DeleteCategoryCommandHandler> _localizer;
        private readonly IUnitOfWork<int> _unitOfWork;

        public DeleteCategoryCommandHandler(IUnitOfWork<int> unitOfWork, ICategoryRepository categoryRepository, IStringLocalizer<DeleteCategoryCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
        {
            var isCategoryUsed = await _categoryRepository.IsCategoryUsed(command.Id);
            if (!isCategoryUsed)
            {
                var category = await _unitOfWork.Repository<Category>().GetByIdAsync(command.Id);
                if (category != null)
                {
                    await _unitOfWork.Repository<Category>().DeleteAsync(category);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllCategoriesCacheKey);
                    return await Result<int>.SuccessAsync(category.Id, _localizer["Categoría eliminada"]);
                }
                else
                {
                    return await Result<int>.FailAsync(_localizer["Categoría no encontrada"]);
                }
            }
            else
            {
                return await Result<int>.FailAsync(_localizer["No se permite eliminar"]);
            }
        }
    }
}
