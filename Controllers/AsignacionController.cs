using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestXiliosoft.Models;
using TestXiliosoft.Models.DTO;

namespace TestXiliosoft.Controllers
{
    public class AsignacionController : Controller
    {
        private readonly TestXiliosoftContext _context;

        public AsignacionController(TestXiliosoftContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var taskListadoEmpleado = _context.Empleados.ToListAsync();
            var taskListadoMaquinaria = _context.Maquinaria.ToListAsync();
            AsignacionDTO asignacionDTO = new AsignacionDTO();
            asignacionDTO.Empleados = await taskListadoEmpleado;
            asignacionDTO.Maquinarias = await taskListadoMaquinaria;
            return View(asignacionDTO);
        }
    }
}
