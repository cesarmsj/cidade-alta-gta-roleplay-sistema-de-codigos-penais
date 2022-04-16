#nullable disable

using Microsoft.AspNetCore.Mvc;
using cidade_alta_criminal_code.Data.Dtos.CriminalCodeDto;
using cidade_alta_criminal_code.Services;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Authorization;

namespace cidade_alta_criminal_code.Controllers
{
    public class CriminalCodeController : Controller
    {
        private CriminalCodeService _criminalCodeService;
        private IMapper _mapper;

        public CriminalCodeController(CriminalCodeService criminalCodeService, IMapper mapper)
        {       
            _criminalCodeService = criminalCodeService;
            _mapper = mapper;

         }

        // GET: CriminalCodes
        [Authorize]
        public async Task<IActionResult> Index()
        {
            List<ReadCriminalCodeDto> readDto = _criminalCodeService.ListCriminalCodes();
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        // GET: CriminalCodes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            ReadCriminalCodeDto readDto = _criminalCodeService.Details(id);
            if (readDto != null) return Ok(readDto);
            return NotFound();
           
        }

        // GET: CriminalCodes/Create
        public IActionResult Create()
        {
            //ViewData["CreateUserId"] = new SelectList(_context.Set<User>(), "Id", "Id");
            //ViewData["UpdateUserId"] = new SelectList(_context.Set<User>(), "Id", "Id");
            return View();
        }

        // POST: CriminalCodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] CreateCriminalCodeDto criminalCodeDto)
        {
            ReadCriminalCodeDto readDto = _criminalCodeService.CreateCriminalCode(criminalCodeDto);

            return View(readDto);
        }

        /*
        // GET: CriminalCodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var criminalCode = await _context.CriminalCode.FindAsync(id);
            if (criminalCode == null)
            {
                return NotFound();
            }
            ViewData["CreateUserId"] = new SelectList(_context.Set<User>(), "Id", "Id", criminalCode.CreateUserId);
            ViewData["UpdateUserId"] = new SelectList(_context.Set<User>(), "Id", "Id", criminalCode.UpdateUserId);
            
            return View(criminalCode);
        }
        */
        // POST: CriminalCodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromBody] UpdateCriminalCodeDto criminalCodeDto)
        {
            Result resultado = _criminalCodeService.UpdateCriminalCode(id, criminalCodeDto);
            
            if (resultado.IsFailed) return NotFound();
            return NoContent();

        }
        
        // GET: CriminalCodes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            Result resultado = _criminalCodeService.DeleteCriminalCode(id);
            if(resultado.IsFailed) return NotFound();
            return NoContent();

        }

    }
}
