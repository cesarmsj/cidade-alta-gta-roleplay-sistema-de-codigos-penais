using AutoMapper;
using cidade_alta_criminal_code.Models;
using cidade_alta_criminal_code.Data.Dtos.StatusDto;

namespace cidade_alta_criminal_code.Profiles
{
    public class StatusProfile : Profile
    {
        public StatusProfile()
        {
            CreateMap<CreateStatusDto, Status>();
            CreateMap<UpdateStatusDto, Status>();
            CreateMap<Status, ReadStatusDto>();
        }
    }
}
