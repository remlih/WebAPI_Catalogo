using Catalog.Application.Extensions;
using Catalog.Application.Interfaces.Repositories;
using Catalog.Application.Interfaces.Services;
using Catalog.Application.Specifications.Catalog;
using Catalog.Domain.Entities.Catalog;
using Catalog.Shared.Wrapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Products.Queries.Export
{
    public class ExportProductsQuery : IRequest<Result<string>>
    {
        public string SearchString { get; set; }

        public ExportProductsQuery(string searchString = "")
        {
            SearchString = searchString;
        }
    }

    internal class ExportProductsQueryHandler : IRequestHandler<ExportProductsQuery, Result<string>>
    {
        private readonly IExcelService _excelService;
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IStringLocalizer<ExportProductsQueryHandler> _localizer;

        public ExportProductsQueryHandler(IExcelService excelService
            , IUnitOfWork<int> unitOfWork
            , IStringLocalizer<ExportProductsQueryHandler> localizer)
        {
            _excelService = excelService;
            _unitOfWork = unitOfWork;
            _localizer = localizer;
        }

        public async Task<Result<string>> Handle(ExportProductsQuery request, CancellationToken cancellationToken)
        {
            var productFilterSpec = new ProductFilterSpecification(request.SearchString);
            var products = await _unitOfWork.Repository<Product>().Entities
                .Specify(productFilterSpec)
                .Include(c => c.Category)
                .Include(b => b.Brand)
                .ToListAsync(cancellationToken);
            var data = await _excelService.ExportAsync(products, mappers: new Dictionary<string, Func<Product, object>>
            {
                { _localizer["Id"], item => item.Id },
                { _localizer["Nombre"], item => item.Name },
                { _localizer["Código de barras"], item => item.Barcode },
                { _localizer["Descripción"], item => item.Description },
                { _localizer["Categoría"], item => item.CategoryId != 0 ? item.Category.Name : String.Empty },
                { _localizer["Marca"], item => item.BrandId != 0 ? item.Brand.Name : String.Empty },
                { _localizer["Precio"], item => item.Rate }
            }, sheetName: _localizer["Productos"]);

            return await Result<string>.SuccessAsync(data: data);
        }
    }
}