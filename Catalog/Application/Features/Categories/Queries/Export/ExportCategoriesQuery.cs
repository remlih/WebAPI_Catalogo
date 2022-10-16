using Application.Specifications.Catalog;
using Catalog.Application.Extensions;
using Catalog.Application.Interfaces.Repositories;
using Catalog.Application.Interfaces.Services;
using Catalog.Shared.Wrapper;
using Domain.Entities.Catalog;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Catalog.Application.Features.Categories.Queries.Export
{
    public class ExportCategoriesQuery : IRequest<Result<string>>
    {
        public string? SearchString { get; set; }
        public ExportCategoriesQuery(string? searchString = "")
        {
            SearchString = searchString;
        }
    }

    internal class ExportCategoriesQueryHandler : IRequestHandler<ExportCategoriesQuery, Result<string>>
    {
        private readonly IExcelService _excelService;
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IStringLocalizer<ExportCategoriesQueryHandler> _localizer;

        public ExportCategoriesQueryHandler(IExcelService excelService
            , IUnitOfWork<int> unitOfWork
            , IStringLocalizer<ExportCategoriesQueryHandler> localizer)
        {
            _excelService = excelService;
            _unitOfWork = unitOfWork;
            _localizer = localizer;
        }

        public async Task<Result<string>> Handle(ExportCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categoryFilterSpec = new CategoryFilterSpecification(request.SearchString);
            var categories = await _unitOfWork.Repository<Category>().Entities
                .Specify(categoryFilterSpec)
                .ToListAsync(cancellationToken);
            var data = await _excelService.ExportAsync(categories, mappers: new Dictionary<string, Func<Category, object>>
            {
                { _localizer["Id"], item => item.Id },
                { _localizer["Nombre"], item => item.Name },
                { _localizer["Descripción"], item => item.Description },
                { _localizer["¿Esta activo?"], item => item.IsEnabled ? "SI" : "NO" }
            }, sheetName: _localizer["Categorías"]);

            return await Result<string>.SuccessAsync(data: data);
        }
    }
}
