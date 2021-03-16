using AutoMapper;
using URLShortener.DataAccess.Dtos;
using URLShortener.Web.Dtos;

namespace URLShortener.Web.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LinkTicketDto, LinkTicketReportDto>();
        }
    }
}
