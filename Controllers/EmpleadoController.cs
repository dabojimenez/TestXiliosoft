using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestXiliosoft.Models;

namespace TestXiliosoft.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly TestXiliosoftContext _context;

        public EmpleadoController(TestXiliosoftContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Empleados.ToListAsync());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Empleado empleado)
        {
            if (!ModelState.IsValid)
            {
                return View(empleado);
            }
            _context.Add(empleado);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Editar(string id)
        {
            Empleado empleado = await _context.Empleados.Where(e => e.Cedula == id)
                .FirstOrDefaultAsync();
            return View(empleado);
        }

        [HttpPost]
        public IActionResult Editar(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Update(empleado);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empleado);
        }

        public IActionResult Delete(string id)
        {
            Empleado empleado = _context.Empleados.Where(e => e.Cedula == id).FirstOrDefault();
            _context.Remove(empleado);
            _context.SaveChanges(true);
            return RedirectToAction("Index");
        }
    }
}
