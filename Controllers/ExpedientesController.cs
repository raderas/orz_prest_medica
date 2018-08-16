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
    public class ExpedientesController : Controller
    {
        private readonly PrestMedicaContext _context;

        public ExpedientesController(PrestMedicaContext context)
        {
            _context = context;
        }

        // GET: Expedientes
        public async Task<IActionResult> Index(int idEmpleado = 0)
        {
            var expedientes = from s in _context.Expediente
                select s;
            if (idEmpleado!=0){
                var empleado = await _context.Empleado
                .SingleOrDefaultAsync(m => m.IDempleado == idEmpleado);

                ViewBag.IDempleado = empleado.IDempleado;
                ViewBag.NombreEmpleado = empleado.Nombre + " " + empleado.Apellido;

                expedientes = expedientes.Where(s => s.Empleado == empleado);
            }    
            return View(await _context.Expediente.ToListAsync());
        }

        // GET: Expedientes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expediente = await _context.Expediente.Include(m=>m.Empleado)
                .SingleOrDefaultAsync(m => m.NumCarnet == id);
            if (expediente == null)
            {
                return NotFound();
            }

            /*var datosEmpleado = expediente.Empleado;

            var Empleado = await _context.Empleado
                .SingleOrDefaultAsync(n => n.IDempleado == datosEmpleado.IDempleado);*/

            return View(expediente);
        }

        // GET: Expedientes/Create
        public IActionResult Create(int idEmpleado)
        {
            //Generando lista de valores para los dropdown
            var listParentescos = new List<Expediente.Parentescos>();
            listParentescos.Add(Expediente.Parentescos.ASEGURADO);
            listParentescos.Add(Expediente.Parentescos.ESPOSA);
            listParentescos.Add(Expediente.Parentescos.HIJO);
            ViewBag.listParentescos = listParentescos;

            if (idEmpleado!=0){
                var empleado = _context.Empleado
                    .SingleOrDefault(m => m.IDempleado == idEmpleado);

                ViewBag.IDempleado = empleado.IDempleado;
                ViewBag.NombreEmpleado = empleado.Nombre + " " + empleado.Apellido;
                ViewBag.NoExisteEmpleado = false;
            }
            else {
                ViewBag.NoExisteEmpleado = true;
            }
            return View();
        }

        // POST: Expedientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumCarnet,Nombre,Beneficiario,Parentesco,FechaNacimiento,TipoDeducible,Activo")] Expediente expediente)
        {
            if (ModelState.IsValid)
            {
                int idEmpleado = Convert.ToInt32(Request.Form["Empleado.IDempleado"]);
                var empleado = _context.Empleado
                    .SingleOrDefault(m => m.IDempleado == idEmpleado);
               //expediente.Activo=true;
               expediente.Empleado = empleado;
                _context.Add(expediente);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index),new{idempleado = idEmpleado});
            }
            return View(expediente);
        }

        // GET: Expedientes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expediente = await _context.Expediente.SingleOrDefaultAsync(m => m.NumCarnet == id);
            if (expediente == null)
            {
                return NotFound();
            }
            return View(expediente);
        }

        // POST: Expedientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NumCarnet,Nombre,Beneficiario,Parentesco,FechaNacimiento,TipoDeducible,Activo")] Expediente expediente)
        {
            if (id != expediente.NumCarnet)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expediente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpedienteExists(expediente.NumCarnet))
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
            return View(expediente);
        }

        // GET: Expedientes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expediente = await _context.Expediente
                .SingleOrDefaultAsync(m => m.NumCarnet == id);
            if (expediente == null)
            {
                return NotFound();
            }

            return View(expediente);
        }

        // POST: Expedientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var expediente = await _context.Expediente.SingleOrDefaultAsync(m => m.NumCarnet == id);
            _context.Expediente.Remove(expediente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpedienteExists(string id)
        {
            return _context.Expediente.Any(e => e.NumCarnet == id);
        }
    }
}
