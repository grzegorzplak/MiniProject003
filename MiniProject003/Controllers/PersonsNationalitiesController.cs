using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiniProject003.Models;

namespace MiniProject003.Controllers
{
    public class PersonsNationalitiesController : Controller
    {
        private readonly Context _context;

        public PersonsNationalitiesController(Context context)
        {
            _context = context;
        }

        // GET: PersonsNationalities
        public async Task<IActionResult> Index()
        {
            var context = _context.PersonsNationalities.Include(p => p.Nationality).Include(p => p.Person);
            return View(await context.ToListAsync());
        }

        // GET: PersonsNationalities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personNationality = await _context.PersonsNationalities
                .Include(p => p.Nationality)
                .Include(p => p.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personNationality == null)
            {
                return NotFound();
            }

            return View(personNationality);
        }

        // GET: PersonsNationalities/Create
        public IActionResult Create()
        {
            ViewData["NationalityId"] = new SelectList(_context.Nationalities, "Id", "NationalityName");
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "PersonName");
            return View();
        }

        // POST: PersonsNationalities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonId,NationalityId")] PersonNationality personNationality)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personNationality);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NationalityId"] = new SelectList(_context.Nationalities, "Id", "NationalityName", personNationality.NationalityId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "PersonName", personNationality.PersonId);
            return View(personNationality);
        }

        // GET: PersonsNationalities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personNationality = await _context.PersonsNationalities.FindAsync(id);
            if (personNationality == null)
            {
                return NotFound();
            }
            ViewData["NationalityId"] = new SelectList(_context.Nationalities, "Id", "NationalityName", personNationality.NationalityId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "PersonName", personNationality.PersonId);
            return View(personNationality);
        }

        // POST: PersonsNationalities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonId,NationalityId")] PersonNationality personNationality)
        {
            if (id != personNationality.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personNationality);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonNationalityExists(personNationality.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["NationalityId"] = new SelectList(_context.Nationalities, "Id", "NationalityName", personNationality.NationalityId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "PersonName", personNationality.PersonId);
            return View(personNationality);
        }

        // GET: PersonsNationalities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personNationality = await _context.PersonsNationalities
                .Include(p => p.Nationality)
                .Include(p => p.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personNationality == null)
            {
                return NotFound();
            }

            return View(personNationality);
        }

        // POST: PersonsNationalities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personNationality = await _context.PersonsNationalities.FindAsync(id);
            if (personNationality != null)
            {
                _context.PersonsNationalities.Remove(personNationality);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonNationalityExists(int id)
        {
            return _context.PersonsNationalities.Any(e => e.Id == id);
        }
    }
}
