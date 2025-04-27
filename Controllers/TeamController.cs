using Microsoft.AspNetCore.Mvc;
using SeleccionFutbol.Data;
using SeleccionFutbol.Models;

namespace SeleccionFutbol.Controllers
{
    public class TeamController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeamController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var equipos = _context.Teams.ToList();
            return View(equipos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Team team)
        {
            if (ModelState.IsValid)
            {
                _context.Teams.Add(team);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(team);
        }

        public IActionResult Edit(int id)
        {
            var equipo = _context.Teams.Find(id);
            if (equipo == null) return NotFound();

            return View(equipo);
        }

        [HttpPost]
        public IActionResult Edit(Team team)
        {
            if (ModelState.IsValid)
            {
                _context.Teams.Update(team);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(team);
        }

        public IActionResult Delete(int id)
        {
            var equipo = _context.Teams.Find(id);
            if (equipo == null) return NotFound();

            return View(equipo);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var equipo = _context.Teams.Find(id);
            if (equipo == null) return NotFound();

            _context.Teams.Remove(equipo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}