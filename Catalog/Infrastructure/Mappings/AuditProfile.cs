using AutoMapper;
using Catalog.Infrastructure.Models.Audit;
using Catalog.Application.Responses.Audit;

namespace Catalog.Infrastructure.Mappings
{
    public class AuditProfile : Profile
    {
        public AuditProfile()
        {
            CreateMap<AuditResponse, Audit>().ReverseMap();
        }
    }
}