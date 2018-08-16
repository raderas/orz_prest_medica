using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrestacionMedicaMvc.Models;

namespace PrestacionMedicaMvc.Controllers
{
    public class EmpresasController : Controller
    {
        private readonly PrestMedicaContext _context;

        public EmpresasController(PrestMedicaContext context)
        {
            _context = context;
        }

        // GET: Empresas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Empresa.ToListAsync());
        }

        // GET: Empresas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresa
                .SingleOrDefaultAsync(m => m.ID == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // GET: Empresas/Create
        public IActionResult Create()
        {
            var empresa = new Empresa();

            empresa.ListaBancos = _context.Banco.ToList();

            ViewBag.empresa = empresa;

            return View();
        }

        // POST: Empresas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NombreEmpresa,RazonSocial,NumPatronal,NIT,Telefono,Direccion,Municipio,Departamento,NumIva,IDBanco,NumCuentaBancaria")] Empresa empresa,int seleccionBanco)
        {
            if (ModelState.IsValid)
            {
                empresa.IDBanco = seleccionBanco;

                _context.Add(empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empresa);
        }

        // GET: Empresas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresa.SingleOrDefaultAsync(m => m.ID == id);
            if (empresa == null)
            {
                return NotFound();
            }
            return View(empresa);
        }

        // POST: Empresas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NombreEmpresa,RazonSocial,NumPatronal,NIT,Telefono,Direccion,Municipio,Departamento,NumIva,IDBanco,NumCuentaBancaria")] Empresa empresa)
        {
            if (id != empresa.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpresaExists(empresa.ID))
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
            return View(empresa);
        }

        #region ACCION DELETE ACTUALMENTE OCULTA
        /*
        // OCULTANDO LA ACCION DELETE
        // GET: Empresas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresa
                .SingleOrDefaultAsync(m => m.ID == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empresa = await _context.Empresa.SingleOrDefaultAsync(m => m.ID == id);
            _context.Empresa.Remove(empresa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        } 
        OCULTANDO LA ACCION DELETE */ 
        #endregion

        private bool EmpresaExists(int id)
        {
            return _context.Empresa.Any(e => e.ID == id);
        }
    }
}
