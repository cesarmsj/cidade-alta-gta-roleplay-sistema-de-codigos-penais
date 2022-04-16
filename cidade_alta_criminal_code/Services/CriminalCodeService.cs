using AutoMapper;
using cidade_alta_criminal_code.Data;
using cidade_alta_criminal_code.Data.Dtos.CriminalCodeDto;
using cidade_alta_criminal_code.Models;
using FluentResults;

namespace cidade_alta_criminal_code.Services

{
    public class CriminalCodeService
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public CriminalCodeService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadCriminalCodeDto CreateCriminalCode(CreateCriminalCodeDto criminalCodeDto)
        {
            CriminalCode criminalCode = _mapper.Map<CriminalCode>(criminalCodeDto);
            _context.CriminalCodes.Add(criminalCode);
            _context.SaveChanges();

            return _mapper.Map<ReadCriminalCodeDto>(criminalCode);

        }

        public Result UpdateCriminalCode(int id, UpdateCriminalCodeDto criminalCodeDto)
        {
            CriminalCode criminalCode = _context.CriminalCodes.FirstOrDefault(criminalCode => criminalCode.Id == id);
            
            if(criminalCode == null)
            {
                return Result.Fail("Código Criminal não encontrado");
            }
            _mapper.Map(criminalCodeDto, criminalCode);
            _context.SaveChanges();
            return Result.Ok();
        }

        public List<ReadCriminalCodeDto> ListCriminalCodes()
        {
            List<CriminalCode> criminalCodes;

            criminalCodes = _context.CriminalCodes.ToList();

            if (criminalCodes != null)
            {
                List<ReadCriminalCodeDto> readDto = _mapper.Map<List<ReadCriminalCodeDto>>(criminalCodes);
                return readDto;
            }

            return null;
        }

        public ReadCriminalCodeDto Details(int id)
        {
            CriminalCode criminalCode = _context.CriminalCodes.FirstOrDefault(criminalCode => criminalCode.Id == id);
            if (criminalCode != null)
            {
                ReadCriminalCodeDto criminalCodeDto = _mapper.Map<ReadCriminalCodeDto>(criminalCode);

                return criminalCodeDto;
            }

            return null;
        }

        public Result DeleteCriminalCode(int id)
        {
            CriminalCode criminalCode = _context.CriminalCodes.FirstOrDefault(criminalCode => criminalCode.Id == id);
            if(criminalCode == null)
            {
                return Result.Fail("Código Criminal não encontrado");
            }
            _context.Remove(criminalCode);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
