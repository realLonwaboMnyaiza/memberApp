using app.Dtos;
using app.Models;
using AutoMapper;

namespace app.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Member, MemberDto>();
        }
    }
}
