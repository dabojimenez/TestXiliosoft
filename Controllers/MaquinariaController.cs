using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using TestXiliosoft.Models;

namespace TestXiliosoft.Controllers
{
    public class MaquinariaController : Controller
    {
        private readonly TestXiliosoftContext _context;

        public MaquinariaController(TestXiliosoftContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Maquinaria.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Maquinarium maquinaria)
        {
            if (!ModelState.IsValid)
            {
                return View(maquinaria);
            }
            _context.Add(maquinaria);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            Maquinarium maquinaria = await _context.Maquinaria.Where(m => m.Serie == id).FirstOrDefaultAsync();
            return View(maquinaria);
        }

        [HttpPost]
        public IActionResult Edit(Maquinarium maquinaria)
        {
            if (ModelState.IsValid)
            {
                _context.Update(maquinaria);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(maquinaria);
        }

        public IActionResult Delete(string id)
        {
            Maquinarium maquinaria = _context.Maquinaria.Where(m => m.Serie == id).FirstOrDefault();
            _context.Remove(maquinaria);
            _context.SaveChanges(true);
            return RedirectToAction("Index");
        }
    }
}
