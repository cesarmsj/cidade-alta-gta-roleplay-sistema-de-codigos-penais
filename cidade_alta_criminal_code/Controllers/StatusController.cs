#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cidade_alta_criminal_code.Data;
using cidade_alta_criminal_code.Models;
using FluentResults;
using cidade_alta_criminal_code.Services;
using AutoMapper;
using cidade_alta_criminal_code.Data.Dtos.StatusDto;

namespace cidade_alta_criminal_code.Controllers
{
    public class StatusController : Controller
    {
        private StatusService _statusService;
        private IMapper _mapper;

        public StatusController(StatusService statusService, IMapper mapper)
        {
            _statusService = statusService;
            _mapper = mapper;
        }

        // GET: Status
        public async Task<IActionResult> Index()
        {
            List<ReadStatusDto> readDto = _statusService.ListStatus();
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        // GET: Status/Details/5
        public async Task<IActionResult> Details(int id)
        {
            ReadStatusDto readDto = _statusService.Details(id);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        // GET: Status/Create
        public IActionResult Create()
        {
            return View();
        }

        /*
        // POST: Status/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Status status)
        {
            if (ModelState.IsValid)
            {
                _context.Add(status);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(status);
        }

        // GET: Status/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var status = await _context.Status.FindAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            return View(status);
        }

        // POST: Status/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Status status)
        {
            Result resultado = _statusService.UpdateStatus(id, statusDto);

            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        // GET: Status/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var status = await _context.Status
                .FirstOrDefaultAsync(m => m.Id == id);
            if (status == null)
            {
                return NotFound();
            }

            return View(status);
        }
        */
    }
}
