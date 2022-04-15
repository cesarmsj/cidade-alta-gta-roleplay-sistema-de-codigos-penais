#nullable disable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cidade_alta_criminal_code.Data.Dtos.CriminalCodeDto;
using cidade_alta_criminal_code.Models;
using cidade_alta_criminal_code.Services;

namespace cidade_alta_criminal_code.Controllers
{
    public class CriminalCodesController : Controller
    {
        private CriminalCodes _criminalCodesService;

        public CriminalCodesController(CriminalCodes criminalCodesService)
        {
            _criminalCodesService = criminalCodesService;
        }

        // GET: CriminalCodes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CriminalCode.Include(c => c.CreateUser).Include(c => c.UpdateUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CriminalCodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            CriminalCode criminalCode = _context.CriminalCodes.FirstOrDefault(criminalCode => criminalCode.Id == id);
            if(criminalCode != null)
            {
                ReadCriminalCodeDto criminalCodeDto = new ReadCriminalCodeDto
                {
                    Name = criminalCode.Name,
                    Description = criminalCode.Description,
                    Penalty = criminalCode.Penalty,
                    PrisionTime = criminalCode.PrisionTime,
                    StatusID = criminalCode.StatusID,
                    CreatedDate = criminalCode.CreatedDate,
                    UpdatedDate = criminalCode.UpdatedDate,
                    CreateUser = criminalCode.CreateUser,
                    UpdateUserId = criminalCode.UpdateUserId
                };
            }

            return View(criminalCode);
        }

        // GET: CriminalCodes/Create
        public IActionResult Create()
        {
            ViewData["CreateUserId"] = new SelectList(_context.Set<User>(), "Id", "Id");
            ViewData["UpdateUserId"] = new SelectList(_context.Set<User>(), "Id", "Id");
            return View();
        }

        // POST: CriminalCodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] CreateCriminalCodeDto criminalCodeDto)
        {
            CriminalCode criminalCode = new CriminalCode
            {
                Name = criminalCodeDto.Name,
                Description = criminalCodeDto.Description,
                Penalty = criminalCodeDto.Penalty,
                PrisionTime = criminalCodeDto.PrisionTime,
                StatusID = criminalCodeDto.StatusID,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                CreateUser = criminalCodeDto.CreateUser,
                UpdateUserId = criminalCodeDto.UpdateUserId

            };

            _context.CriminalCodes.Add(CriminalCode);
            _context.SaveChanges();

            return View(criminalCode);
        }

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

        // POST: CriminalCodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromBody] UpdateCriminalCodeDto criminalCodeDto)
        {
            CriminalCode criminalCode = _context.CriminalCodes.FirstOrDefault(criminalCode => criminalCode.Id = id);

            if(criminalCode == null)
            {
                return NotFound();
            }

            criminalCode.Name = criminalCodeDto.Name;
            criminalCode.Description = criminalCodeDto.Description;
            criminalCode.Penalty = criminalCodeDto.Penalty;
            criminalCode.PrisionTime = criminalCodeDto.PrisionTime;
            criminalCode.StatusID = criminalCodeDto.StatusID;
            criminalCode.UpdatedDate = DateTime.Now;
            criminalCode.UpdateUserId = criminalCodeDto.UpdateUserId;

            _context.SaveChanges();
            return NoContent();
        }

        // GET: CriminalCodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var criminalCode = await _context.CriminalCode
                .Include(c => c.CreateUser)
                .Include(c => c.UpdateUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (criminalCode == null)
            {
                return NotFound();
            }

            return View(criminalCode);
        }

        // POST: CriminalCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var criminalCode = await _context.CriminalCode.FindAsync(id);
            _context.CriminalCode.Remove(criminalCode);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CriminalCodeExists(int id)
        {
            return _context.CriminalCode.Any(e => e.Id == id);
        }
    }
}
