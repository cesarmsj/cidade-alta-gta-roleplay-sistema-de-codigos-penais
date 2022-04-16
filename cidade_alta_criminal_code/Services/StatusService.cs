using AutoMapper;
using cidade_alta_criminal_code.Data;
using cidade_alta_criminal_code.Data.Dtos.StatusDto;
using cidade_alta_criminal_code.Models;
using FluentResults;

namespace cidade_alta_criminal_code.Services

{
    public class StatusService
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public StatusService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadStatusDto CreateStatus(CreateStatusDto statusDto)
        {
            Status status = _mapper.Map<Status>(statusDto);
            _context.Status.Add(status);
            _context.SaveChanges();

            return _mapper.Map<ReadStatusDto>(status);

        }

        public Result UpdateStatus(int id, UpdateStatusDto statusDto)
        {
            Status status = _context.Status.FirstOrDefault(status => status.Id == id);
            
            if(status == null)
            {
                return Result.Fail("Código Criminal não encontrado");
            }
            _mapper.Map(statusDto, status);
            _context.SaveChanges();
            return Result.Ok();
        }

        public List<ReadStatusDto> ListStatus()
        {
            List<Status> status;

            status = _context.Status.ToList();

            if (status != null)
            {
                List<ReadStatusDto> readDto = _mapper.Map<List<ReadStatusDto>>(status);
                return readDto;
            }

            return null;
        }

        public ReadStatusDto Details(int id)
        {
            Status status = _context.Status.FirstOrDefault(status => status.Id == id);
            if (status != null)
            {
                ReadStatusDto statusDto = _mapper.Map<ReadStatusDto>(status);

                return statusDto;
            }

            return null;
        }

        public Result DeleteStatus(int id)
        {
            Status status = _context.Status.FirstOrDefault(status => status.Id == id);
            if(status == null)
            {
                return Result.Fail("Código Criminal não encontrado");
            }
            _context.Remove(status);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
