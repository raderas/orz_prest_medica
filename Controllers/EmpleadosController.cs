using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrestacionMedicaMvc.Models;
using PrestacionMedicaMvc.Models.PrestacionMedicaViewControllers;

namespace PrestacionMedicaMvc.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly PrestMedicaContext _context;

        public EmpleadosController(PrestMedicaContext context)
        {
            _context = context;
        }

        // GET: Empleados
        public async Task<IActionResult> Index()
        {
            return View(await _context.Empleado.ToListAsync());
        }

        #region Index Empleados RADERAS
        /*public async Task<IActionResult> Index(bool IndexEmpleados)
        {
            var listaBancos = new BancosList();
            listaBancos.Bancos = await _context.Banco.ToListAsync();
            ViewBag.ListaBancos = listaBancos;


            return View(await _context.Empleado.ToListAsync());
        }*/
        #endregion

        // GET: Empleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado
                .SingleOrDefaultAsync(m => m.IDempleado == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            var empleado = new Empleado();

            empleado.ListaBancos = _context.Banco.ToList();
            
            empleado.OpcionesStatusEmpleado = new Dictionary<Empleado.StatusEmpleado,String>();
            empleado.OpcionesStatusEmpleado.Add(Empleado.StatusEmpleado.EVENTUAL,"Eventual");
            empleado.OpcionesStatusEmpleado.Add(Empleado.StatusEmpleado.INTERINO,"Interino");
            empleado.OpcionesStatusEmpleado.Add(Empleado.StatusEmpleado.PERMANENTE,"Permanente");
            empleado.OpcionesStatusEmpleado.Add(Empleado.StatusEmpleado.TERMINADO,"Terminado");

            empleado.ListaEmpresas = _context.Empresa.ToList();
            
            empleado.BancoCuenta = new Banco();
            empleado.BancoCuenta.TiposCuentas = new Dictionary<Banco.TipoCuenta,String>();
            empleado.BancoCuenta.TiposCuentas.Add(Banco.TipoCuenta.AHORRO,"Ahorros");
            empleado.BancoCuenta.TiposCuentas.Add(Banco.TipoCuenta.CORRIENTE,"Corriente");
            
            
            ViewBag.empleado = empleado;

            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDempleado,Status,Nombre,Apellido,NombrePlanilla,DUI,NumeroCuenta,TipoCuenta,CentroDeCosto")] Empleado empleado, int bancoSeleccionado, string seleccionStatus,int seleccionEmpresa,string seleccionTipoCuenta)
        {
            if (ModelState.IsValid)
            {
                empleado.Status = seleccionStatus;
                
                empleado.TipoCuenta = seleccionTipoCuenta;
                var bancoCuenta = await _context.Banco
                    .SingleOrDefaultAsync(m=> m.ID == bancoSeleccionado);

                empleado.BancoCuenta = bancoCuenta;
                var empresaEmpleado = await _context.Empresa
                    .SingleOrDefaultAsync(m => m.ID == seleccionEmpresa);                
                
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado.SingleOrDefaultAsync(m => m.IDempleado == id);
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDempleado,Status,Nombre,Apellido,NombrePlanilla,DUI,NumeroCuenta,TipoCuenta,CentroDeCosto")] Empleado empleado)
        {
            if (id != empleado.IDempleado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.IDempleado))
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
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado
                .SingleOrDefaultAsync(m => m.IDempleado == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _context.Empleado.SingleOrDefaultAsync(m => m.IDempleado == id);
            _context.Empleado.Remove(empleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleado.Any(e => e.IDempleado == id);
        }
    }
}
