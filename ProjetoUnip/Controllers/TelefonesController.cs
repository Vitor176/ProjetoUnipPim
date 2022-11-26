using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoUnip.Models;

namespace ProjetoUnip.Controllers
{
    public class TelefonesController : Controller
    {
        private readonly Contexto _context;

        public TelefonesController(Contexto context)
        {
            _context = context;
        }

        // GET: Telefones
        public async Task<IActionResult> Index()
        {
              return View(await _context.Telefone.ToListAsync());
        }

        // GET: Telefones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Telefone == null)
            {
                return NotFound();
            }

            var telefone = await _context.Telefone
                .FirstOrDefaultAsync(m => m.Id == id);
            var TipoTelefone = await _context.TipoTelefone.FirstOrDefaultAsync(x => x.Id == telefone.Id_FKTipoTelefone);
            telefone.TipoTelefone = TipoTelefone;
            if (telefone == null)
            {
                return NotFound();
            }

            return View(telefone);
        }

        // GET: Telefones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Telefones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumeroDeTelefone,DDD,TipoTelefone")] Telefone telefone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telefone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(telefone);
        }

        // GET: Telefones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Telefone == null)
            {
                return NotFound();
            }

            var telefone = await _context.Telefone.FindAsync(id);
            if (telefone == null)
            {
                return NotFound();
            }
            return View(telefone);
        }

        // POST: Telefones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumeroDeTelefone,DDD")] Telefone telefone)
        {
            if (id != telefone.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telefone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelefoneExists(telefone.Id))
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
            return View(telefone);
        }

        // GET: Telefones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Telefone == null)
            {
                return NotFound();
            }

            var telefone = await _context.Telefone
                .FirstOrDefaultAsync(m => m.Id == id);
            if (telefone == null)
            {
                return NotFound();
            }

            return View(telefone);
        }

        // POST: Telefones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Telefone == null)
            {
                return Problem("Entity set 'Contexto.Telefone'  is null.");
            }
            var telefone = await _context.Telefone.FindAsync(id);
            if (telefone != null)
            {
                _context.Telefone.Remove(telefone);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelefoneExists(int id)
        {
          return _context.Telefone.Any(e => e.Id == id);
        }
    }
}
