using Controle_Imob_Clientes.Data;
using Controle_Imob_Clientes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Imob_Clientes.Areas.Administradores.Controllers
{
    [Area("Administradores")]
    public class AdministradorController : Controller
    {

        private ImobClienteContext _context;

        public AdministradorController(ImobClienteContext context)
        {
            _context = context;
        }




        public IQueryable<Administrador> ObterAdministradoresClassificadosPorNome()
        {
            return _context.Administradores.OrderBy(b => b.Nome);
        }


        public async Task<Administrador> ObterAdministradorPorId(long id)
        {
            return await _context.Administradores.FindAsync(id);
        }


        public async Task<Administrador> GravarAdministrador(Administrador administrador)
        {
            if (administrador.AdministradorID == null)
            {
                _context.Administradores.Add(administrador);
            }
            else
            {
                _context.Update(administrador);
            }
            await _context.SaveChangesAsync();
            return administrador;
        }
        public async Task<Administrador> EliminarAdministradorPorId(long
        id)
        {
            Administrador administrador = await ObterAdministradorPorId(id);
            _context.Administradores.Remove(administrador);
            await _context.SaveChangesAsync();
            return administrador;
        }


        // GET: AdministradoresController
        public async Task<ActionResult> Index()
        {
            return View(await ObterAdministradoresClassificadosPorNome().ToListAsync());
        }



        private async Task<IActionResult> ObterVisaoAdministradorPorId(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var administrador = await ObterAdministradorPorId((long)id);
            if (administrador == null)
            {
                return NotFound();
            }
            return View(administrador);
        }



        public async Task<IActionResult> Details(long? id)

        {
            return await ObterVisaoAdministradorPorId(id);
        }


        public async Task<IActionResult> Edit(long? id)
        {
            return await ObterVisaoAdministradorPorId(id);
        }


        public async Task<IActionResult> Delete(long? id)
        {
            return await ObterVisaoAdministradorPorId(id);
        }


        // GET: Administrador/Create
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,RegistroAdministrador,Nascimento")] Administrador administrador)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await GravarAdministrador(administrador)
                    ;
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível in serir os dados.");
            }
            return View(administrador);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("AdministradorID,Nome,RegistroAdministrador,Nascimento")] Administrador administrador)
        {
            if (id != administrador.AdministradorID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await GravarAdministrador(administrador)
                    ;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await AdministradorExists(administrador.AdministradorID))
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
            return View(administrador);
        }





        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id
        )
        {
            var administrador = await EliminarAdministradorPorId((long)id);
            TempData["Message"] = "Admninistrador " + administrador.Nome.ToUpper() + " foi removida";
            return RedirectToAction(nameof(Index));
        }
        private async Task<bool> AdministradorExists(long? id)

        {
            return await ObterAdministradorPorId((long)id) != null;
        }



        // GET: AdministradoresController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

    }
}
