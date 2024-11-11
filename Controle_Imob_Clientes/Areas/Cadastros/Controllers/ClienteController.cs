using Controle_Imob_Clientes.Data;
using Controle_Imob_Clientes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Controle_Imob_Clientes.Areas.Cadastros.Controllers
{
    [Area("Cadastros")]
    public class ClienteController : Controller
    {

        private ImobClienteContext _context;

        public ClienteController(ImobClienteContext context)
        {
            _context = context;
        }


        public async Task<Cliente> ObterClientePorId(long id)
        {
            var cliente = await _context.Clientes.SingleOrDefaultAsync(m => m.ClienteID == id);
            _context.Clientes.Where(i => i.ClienteID == cliente.ClienteID).Load(); ;
            return cliente;
        }

        private async Task<bool> ClienteExiste(long? id)
        {
            return _context.Clientes.Any(e => e.ClienteID == id);
        }

        public async Task<Cliente> GravarCliente(Cliente cliente)
        {
            if (cliente.ClienteID == null)
            {
                _context.Clientes.Add(cliente);
            }
            else
            {

                _context.Update(cliente);
            }
            await _context.SaveChangesAsync();
            return cliente;
        }


        public async Task<IActionResult> Index()
        {
            return View(_context.Clientes.OrderBy(i => i.Nome));
        }


        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,CPF, Casa,Modalidade,DataInicio,DataFim,Observacoes,ImobiliariaID")] Cliente cliente)
        {


            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(cliente);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (DbUpdateException)
            {

                ModelState.AddModelError("", "Não foi possível inserir os dados do cliente");
            }

            return View(cliente);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cliente = await _context.Clientes.SingleOrDefaultAsync(m => m.ClienteID == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("ClienteID, Nome,CPF, Casa,Modalidade,DataInicio,DataFim,Observacoes,ImobiliariaID")] Cliente cliente)
        {

            

            if (id != cliente.ClienteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!await ClienteExiste(cliente.ClienteID))
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
            return View(cliente);


        }


        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cliente = await _context.Clientes.SingleOrDefaultAsync(m => m.ClienteID == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }



        [HttpGet]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cliente = await _context.Clientes.SingleOrDefaultAsync(m => m.ClienteID == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }




        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var cliente = await _context.Clientes.SingleOrDefaultAsync(m => m.ClienteID == id);
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}

