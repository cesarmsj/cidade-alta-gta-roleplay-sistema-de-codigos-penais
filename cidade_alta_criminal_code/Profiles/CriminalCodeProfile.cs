using AutoMapper;
using cidade_alta_criminal_code.Models;
using cidade_alta_criminal_code.Data.Dtos.CriminalCodeDto;

namespace cidade_alta_criminal_code.Profiles
{
    public class CriminalCodeProfile : Profile
    {
        public CriminalCodeProfile()
        {
            CreateMap<CreateCriminalCodeDto, CriminalCode>();
            CreateMap<UpdateCriminalCodeDto, CriminalCode>();
            CreateMap<CriminalCode, ReadCriminalCodeDto>();
        }
    }
}
