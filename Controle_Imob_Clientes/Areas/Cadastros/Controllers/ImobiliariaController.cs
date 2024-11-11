using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Controle_Imob_Clientes.Data;
using Controle_Imob_Clientes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Controle_Imob_Clientes.Areas.Cadastros.Controllers
{
    [Area("Cadastros")]
    [Authorize]
    public class ImobiliariaController : Controller
    {

        private ImobClienteContext _context;

        public ImobiliariaController(ImobClienteContext context)
        {
            _context = context;
        }



        public async Task<Imobiliaria> ObterImobiliariaPorId(long id)
        {
            var imobiliaria = await _context.Imobiliarias.SingleOrDefaultAsync(m => m.imobiliariaID == id);
            _context.Imobiliarias.Where(i => i.imobiliariaID == imobiliaria.imobiliariaID).Load(); ;
            return imobiliaria;
        }

        private async Task<bool> ImobiliariaExiste(long? id)
        {
            return _context.Imobiliarias.Any(e => e.imobiliariaID == id);
        }

        public async Task<Imobiliaria> Gravarimobiliaria(Imobiliaria imobiliaria)
        {
            if (imobiliaria.imobiliariaID == null)
            {
                _context.Imobiliarias.Add(imobiliaria);
            }
            else
            {

                _context.Update(imobiliaria);
            }
            await _context.SaveChangesAsync();
            return imobiliaria;
        }




        public IActionResult Index()
        {
            return View(_context.Imobiliarias.OrderBy(i => i.Nome));
        }



        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Endereco, Telefone,Responsavel,PaginaWeb,PerfilInstagram")] Imobiliaria imobiliaria)
        {


            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(imobiliaria);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (DbUpdateException)
            {

                ModelState.AddModelError("", "Não foi possível inserir os dados da Imobiliária");
            }

            return View(imobiliaria);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var imobiliaria = await _context.Imobiliarias.SingleOrDefaultAsync(m => m.imobiliariaID == id);
            if (imobiliaria == null)
            {
                return NotFound();
            }
            return View(imobiliaria);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("imobiliariaID,Nome,Endereco,Telefone,Responsavel,PaginaWeb,PerfilInstagram")] Imobiliaria imobiliaria)
        {

            if (id != imobiliaria.imobiliariaID)
            {
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imobiliaria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!await ImobiliariaExiste(imobiliaria.imobiliariaID))
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
            return View(imobiliaria);


        }


        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var imobiliaria = await _context.Imobiliarias.SingleOrDefaultAsync(m => m.imobiliariaID == id);
            if (imobiliaria == null)
            {
                return NotFound();
            }
            return View(imobiliaria);
        }



        [HttpGet]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var imobiliaria = await _context.Imobiliarias.SingleOrDefaultAsync(m => m.imobiliariaID == id);
            if (imobiliaria == null)
            {
                return NotFound();
            }
            return View(imobiliaria);
        }




        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var imobiliaria = await _context.Imobiliarias.SingleOrDefaultAsync(m => m.imobiliariaID == id);
            _context.Imobiliarias.Remove(imobiliaria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
