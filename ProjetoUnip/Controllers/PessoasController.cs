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
    public class PessoasController : Controller
    {
        private readonly Contexto _context;

        public PessoasController(Contexto context)
        {
            _context = context;
        }

        // GET: Pessoas
        public async Task<IActionResult> Index()
        {
            var pessoa = await _context.Pessoa
                .Include(p => p.Endereco)
                .Include(p => p.Telefone)
                .Include(p => p.Telefone.TipoTelefone)
                .ToListAsync();

            return View(pessoa);
        }

        // GET: Pessoas/Details/5
        public async Task<IActionResult> Consulte(long? cpf)
        {
            if (_context.Pessoa == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa
                .Include(p => p.Endereco)
                .Include(p => p.Telefone)
                .Include(p => p.Telefone.TipoTelefone)
                .FirstOrDefaultAsync(m => m.CPF == cpf);

            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        // GET: Pessoas/Create
        // Direcionamento para view/Criate
        public IActionResult Insira()
        {
            return View();
        }

        // POST: Pessoas/Create
        // Responsavel que faz create no banco
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Insira([Bind("Id,Nome,CPF,Endereco,Telefone")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pessoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pessoa);
        }

        // GET: Pessoas/Edit/5
        // Direcionamento para view/Edit
        public async Task<IActionResult> Altere(int? id)
        {
            if (_context.Pessoa == null)
            {
                return NotFound();
            }
            var pessoa = await _context.Pessoa
                .Include(p => p.Endereco)
                .Include(p => p.Telefone)
                .Include(p => p.Telefone.TipoTelefone)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (pessoa == null)
            {
                return NotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoas/Edit/5
        // Responsavel que faz update no banco
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Altere(int id, [Bind("Id,Nome,CPF,Endereco,Telefone")] Pessoa pessoa)
        {
            if (id != pessoa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaExists(pessoa.Id))
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
            return View(pessoa);
        }

        // GET: Pessoas/Delete/5
        // Direcionamento para view/Edit
        public async Task<IActionResult> Exclua(int? id)
        {
            if (id == null || _context.Pessoa == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        // POST: Pessoas/Delete/5
        // Responsavel que faz delete no banco
        [HttpPost, ActionName("Exclua")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExcluaConfirmed(int id)
        {
            if (_context.Pessoa == null)
            {
                return Problem("Entity set 'Contexto.Pessoa'  is null.");
            }
            var pessoa = await _context.Pessoa.FindAsync(id);
            if (pessoa != null)
            {
                _context.Pessoa.Remove(pessoa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoaExists(int id)
        {
            return _context.Pessoa.Any(e => e.Id == id);
        }
    }
}
