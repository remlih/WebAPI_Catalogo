using AutoMapper;
using Catalog.Application.Interfaces.Repositories;
using Catalog.Shared.Constants.Application;
using Catalog.Shared.Wrapper;
using Domain.Entities.Catalog;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Application.Features.Categories.Commands.AddEdit
{
    public class AddEditCategoryCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsEnabled { get; set; } = true;
    }


    internal class AddEditCategoryCommandHandler : IRequestHandler<AddEditCategoryCommand, Result<int>>
    {
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<AddEditCategoryCommandHandler> _localizer;
        private readonly IUnitOfWork<int> _unitOfWork;

        public AddEditCategoryCommandHandler(IUnitOfWork<int> unitOfWork, IMapper mapper, IStringLocalizer<AddEditCategoryCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(AddEditCategoryCommand command, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.Repository<Category>().Entities.Where(p => p.Id != command.Id)
                .AnyAsync(p => p.Name == command.Name, cancellationToken))
            {
                return await Result<int>.FailAsync(_localizer["Ya existe una categoría con este nombre."]);
            }

            if (command.Id == 0)
            {
                var section = _mapper.Map<Category>(command);
                await _unitOfWork.Repository<Category>().AddAsync(section);
                await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllCategoriesCacheKey);
                return await Result<int>.SuccessAsync(section.Id, _localizer["Categoría guardada"]);
            }
            else
            {
                var section = await _unitOfWork.Repository<Category>().GetByIdAsync(command.Id);
                if (section != null)
                {
                    section.Name = command.Name ?? section.Name;
                    section.Description = command.Description ?? section.Description;
                    await _unitOfWork.Repository<Category>().UpdateAsync(section);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllCategoriesCacheKey);
                    return await Result<int>.SuccessAsync(section.Id, _localizer["Categoría actualizada"]);
                }
                else
                {
                    return await Result<int>.FailAsync(_localizer["Categoría no encontrada"]);
                }
            }
        }
    }
}
