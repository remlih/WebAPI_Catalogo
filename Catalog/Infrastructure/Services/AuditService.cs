using AutoMapper;
using Catalog.Application.Extensions;
using Catalog.Application.Interfaces.Services;
using Catalog.Application.Responses.Audit;
using Catalog.Infrastructure.Contexts;
using Catalog.Infrastructure.Models.Audit;
using Catalog.Infrastructure.Specifications;
using Catalog.Shared.Wrapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace Catalog.Infrastructure.Services
{
    public class AuditService : IAuditService
    {
        private readonly CatalogContext _context;
        private readonly IMapper _mapper;
        private readonly IExcelService _excelService;
        private readonly IStringLocalizer<AuditService> _localizer;

        public AuditService(
            IMapper mapper,
            CatalogContext context,
            IExcelService excelService,
            IStringLocalizer<AuditService> localizer)
        {
            _mapper = mapper;
            _context = context;
            _excelService = excelService;
            _localizer = localizer;
        }

        public async Task<IResult<IEnumerable<AuditResponse>>> GetCurrentUserTrailsAsync(string userId)
        {
            var trails = await _context.AuditTrails.Where(a => a.UserId == userId).OrderByDescending(a => a.Id).Take(250).ToListAsync();
            var mappedLogs = _mapper.Map<List<AuditResponse>>(trails);
            return await Result<IEnumerable<AuditResponse>>.SuccessAsync(mappedLogs);
        }

        public async Task<IResult<string>> ExportToExcelAsync(string userId, string searchString = "", bool searchInOldValues = false, bool searchInNewValues = false)
        {
            var auditSpec = new AuditFilterSpecification(userId, searchString, searchInOldValues, searchInNewValues);
            var trails = await _context.AuditTrails
                .Specify(auditSpec)
                .OrderByDescending(a => a.DateTime)
                .ToListAsync();
            var data = await _excelService.ExportAsync(trails, sheetName: _localizer["Auditoría"],
                mappers: new Dictionary<string, Func<Audit, object>>
                {
                    { _localizer["Nombre de la tabla"], item => item.TableName },
                    { _localizer["Tipo"], item => item.Type },
                    { _localizer["Fecha y hora (Local)"], item => DateTime.SpecifyKind(item.DateTime, DateTimeKind.Utc).ToLocalTime().ToString("G", CultureInfo.CurrentCulture) },
                    { _localizer["Fecha y hora (UTC)"], item => item.DateTime.ToString("G", CultureInfo.CurrentCulture) },
                    { _localizer["Clave primaria"], item => item.PrimaryKey },
                    { _localizer["Valores antiguos"], item => item.OldValues },
                    { _localizer["Nuevos valores"], item => item.NewValues },
                });

            return await Result<string>.SuccessAsync(data: data);
        }
    }
}