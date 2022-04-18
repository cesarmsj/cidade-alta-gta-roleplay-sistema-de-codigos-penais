#nullable disable

using Microsoft.AspNetCore.Mvc;
using cidade_alta_criminal_code.Data.Dtos.CriminalCodeDto;
using cidade_alta_criminal_code.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using cidade_alta_criminal_code.Data.Dtos.StatusDto;
using Microsoft.AspNetCore.Identity;
using cidade_alta_criminal_code.Models;
using cidade_alta_criminal_code.Data;

namespace cidade_alta_criminal_code.Controllers
{
    public class CriminalCodeController : Controller
    {
        private ApplicationDbContext _context;
        private CriminalCodeService _criminalCodeService;
        private StatusService _statusService;
        private IMapper _mapper;
        private UserManager<ApplicationUser> _userManager;
        private ILogger _logger;


        public CriminalCodeController(CriminalCodeService criminalCodeService, IMapper mapper, StatusService statusService, UserManager<ApplicationUser> userManager, ILogger logger, ApplicationDbContext context)
        {
            _criminalCodeService = criminalCodeService;
            _mapper = mapper;
            _statusService = statusService;
            _userManager = userManager;
            _logger = logger;
            _context = context;
        }

        // GET: CriminalCodes
        [Authorize]
        public IEnumerable<CriminalCode> List()
        {
            return _context.CriminalCodes;
        }

        // GET: CriminalCodes/Details/5
        [Authorize]
        public IActionResult Details(int id)
        {
            CriminalCode criminalCode = _context.CriminalCodes.FirstOrDefault(c => c.Id == id);
            if(criminalCode == null)
            {
                ReadCriminalCodeDto criminalCodeDto = _mapper.Map<ReadCriminalCodeDto>(criminalCode);

                return Ok(criminalCodeDto);
            }

            return NotFound();

        }

        // GET: CriminalCodes/Create
        [Authorize]
        public IActionResult Create(string msg)
        {
            List<ReadStatusDto> readDto = _statusService.ListStatus();
            ViewBag.Status = readDto;
            ViewBag.Message = msg;

            return View();
        }

        // POST: CriminalCodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateCriminalCodeDto createDto)
        {
            CriminalCode criminalCode = _mapper.Map<CriminalCode>(createDto);
            _context.CriminalCodes.Add(criminalCode);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Details), new { Id = criminalCode.Id }, criminalCode);

        }

        
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCriminalCodeDto criminalCodeDto)
        {    

            CriminalCode criminalCode = _context.CriminalCodes.FirstOrDefault(c => c.Id == id);
            if (criminalCode == null)
            {
                return NotFound();
            }
            _mapper.Map(criminalCodeDto, criminalCode);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            CriminalCode criminalCode = _context.CriminalCodes.FirstOrDefault(criminalCode => criminalCode.Id == id);
            if(criminalCode == null)
            {
                return NotFound();
            }

            _context.Remove(criminalCode);
            _context.SaveChanges();
            return NoContent();

        }

    }
}
