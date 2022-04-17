#nullable disable

using Microsoft.AspNetCore.Mvc;
using cidade_alta_criminal_code.Data.Dtos.CriminalCodeDto;
using cidade_alta_criminal_code.Services;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using cidade_alta_criminal_code.Data.Dtos.StatusDto;
using Microsoft.AspNetCore.Identity;
using cidade_alta_criminal_code.Models;

namespace cidade_alta_criminal_code.Controllers
{
    public class CriminalCodeController : Controller
    {
        private CriminalCodeService _criminalCodeService;
        private StatusService _statusService;
        private IMapper _mapper;
        private UserManager<ApplicationUser> _userManager;
        private ILogger _logger;


        public CriminalCodeController(CriminalCodeService criminalCodeService, IMapper mapper, StatusService statusService, UserManager<ApplicationUser> userManager, ILogger logger)
        {
            _criminalCodeService = criminalCodeService;
            _mapper = mapper;
            _statusService = statusService;
            _userManager = userManager;
            _logger = logger;
        }

        // GET: CriminalCodes
        [Authorize]
        public async Task<IActionResult> Index(string msg)
        {
            List<ReadCriminalCodeDto> readDto = _criminalCodeService.ListCriminalCodes();

            ViewBag.Message = msg;
            ViewBag.CriminalCodes = readDto;

            return View();
        }

        // GET: CriminalCodes/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            ReadCriminalCodeDto readDto = _criminalCodeService.Details(id);
            if (readDto == null)
            {
                _logger.LogInformation("Falha ao tentar recuperar código penal com id." + readDto.Id);
                return RedirectToAction("Index", "CriminalCode", new { msg = "fail" });

            };
            _logger.LogInformation("Código Penal recuperado com sucesso");
            ViewBag.CriminalCode = readDto;

            return View();

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
        public IActionResult CreateCriminalCode(CreateCriminalCodeDto createDto)
        {
            var userId = _userManager.GetUserId(User);

            Result result = _criminalCodeService.CreateCriminalCode(createDto, userId);

            if (result.IsFailed)
            {
                _logger.LogInformation("Falha ao tentar cadastrar novo código penal.");
                return RedirectToAction("Create", "CriminalCode", new { msg = "fail" });

            };
            _logger.LogInformation("Código Penal Cadastrado com Sucesso");
            return RedirectToAction("Create", "CriminalCode", new { msg = "success" });

        }

        
        // GET: CriminalCodes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {    

            var criminalCode = _criminalCodeService.Details(id);
            if (criminalCode == null)
            {
                return NotFound();
            }
            //ViewData["CreateUserId"] = new SelectList(_context.Set<User>(), "Id", "Id", criminalCode.CreateUserId);
            //ViewData["UpdateUserId"] = new SelectList(_context.Set<User>(), "Id", "Id", criminalCode.UpdateUserId);
            ViewBag.CriminalCode = criminalCode;

            return View();
        }
        
        // POST: CriminalCodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromBody] UpdateCriminalCodeDto criminalCodeDto)
        {
            Result resultado = _criminalCodeService.UpdateCriminalCode(id, criminalCodeDto);
            
            if (resultado.IsFailed) return NotFound();
            return NoContent();

        }

        // GET: CriminalCodes/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            Result result = _criminalCodeService.DeleteCriminalCode(id);

            if (result.IsFailed)
            {
                _logger.LogInformation("Falha ao tentar remover código penal.");
                return RedirectToAction("Index", "CriminalCode", new { msg = "delfail" });

            };
            _logger.LogInformation("Código Penal Removido com Sucesso");
            return RedirectToAction("Index", "CriminalCode", new { msg = "delsuccess" });

        }

    }
}
