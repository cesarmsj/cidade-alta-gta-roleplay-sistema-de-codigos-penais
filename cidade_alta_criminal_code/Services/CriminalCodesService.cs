using AutoMapper;
using cidade_alta_criminal_code.Data;
using cidade_alta_criminal_code.Data.Dtos.CriminalCodeDto;
using cidade_alta_criminal_code.Models;

namespace cidade_alta_criminal_code.Services

{
    public class CriminalCodes
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public CriminalCodes(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateCriminalCodesService(CreateCriminalCodeDto criminalCodeDto)
        {
            CriminalCode criminalCode = _mapper.Map<CriminalCode>(criminalCodeDto);
            _context.CriminalCode.Add(criminalCode);
            _context.SaveChanges();

        }
    }
