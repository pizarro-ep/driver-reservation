using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Transport.Models;

namespace Transport.Controllers
{
    public class RoadsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoadsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Roads
        public async Task<IActionResult> Index()
        {
            List<Road> roads = await _context.Roads.ToListAsync();

            var model = roads.Select(r => new RoadDTO {
                Id = r.Id,
                StartLocation = r.StartLocation,
                EndLocation = r.EndLocation,
                Distance = r.Distance,
                EstimatedDuration = r.EstimatedDuration,
            }).ToList();

            return View(model);
        }

        // GET: Roads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var road = await _context.Roads.FirstOrDefaultAsync(m => m.Id == id);
            if (road == null) return NotFound();

            var model = new RoadDTO { Id = road.Id, StartLocation = road.StartLocation, EndLocation = road.EndLocation, Distance = road.Distance, EstimatedDuration = road.EstimatedDuration };

            return View(model);
        }

        // GET: Roads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roads/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StartLocation,EndLocation,Distance,EstimatedDuration")] Road road)
        {
            if (ModelState.IsValid) {

                _context.Add(road);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(road);
        }

        // GET: Roads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var road = await _context.Roads.FindAsync(id);
            if (road == null) return NotFound();

            var model = new RoadDTO { Id = road.Id, StartLocation = road.StartLocation, EndLocation = road.EndLocation, Distance = road.Distance, EstimatedDuration = road.EstimatedDuration };

            return View(model);
        }

        // POST: Roads/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartLocation,EndLocation,Distance,EstimatedDuration")] Road road)
        {
            if (id != road.Id) return NotFound(); 

            if (ModelState.IsValid) {
                try {
                    _context.Update(road);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!RoadExists(road.Id)) return NotFound(); 
                    else throw; 
                }
                return RedirectToAction(nameof(Index));
            }
            return View(road);
        }

        // GET: Roads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound(); 

            var road = await _context.Roads.FirstOrDefaultAsync(m => m.Id == id);

            if (road == null) return NotFound(); 

            return View(road);
        }

        // POST: Roads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var road = await _context.Roads.FindAsync(id);
            if (road == null) { // El rol no fue encontrado
                ViewBag.ErrorMessage = $"El rol con ID {id} no fue encontrado.";
                return View("NotFound");
            }
            try {
                _context.Roads.Remove(road);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Roads");
            } catch (DbUpdateException ex) {
                // Log de la excepción a un archivo
                ViewBag.Error = ex.Message;
                // Pasa la información del título y del mensaje de error que deseas mostrar al usuario en la v
                // La vista Error recupera esta información de la vista y la muestra al usuario.
                ViewBag.ErrorTitle = $"La ruta de: {road.StartLocation} a: {road.EndLocation} está en uso";
                ViewBag.ErrorMessage = $"La ruta: {road.StartLocation} a: {road.EndLocation} no se puede eliminar porque hay horarios con esta ruta. Si desea eliminar esta ruta, elimine los horarios relacionados y luego intente eliminar.";
                return View("Error");
            }
        }

        private bool RoadExists(int id)
        {
            return _context.Roads.Any(e => e.Id == id);
        }
    }
}
