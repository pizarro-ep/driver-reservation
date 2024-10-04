using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Transport.Models;

namespace Transport.Controllers
{
    public class SchedulesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SchedulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Schedules
        public async Task<IActionResult> Index()
        {
            List<Schedule> schedule = await _context.Schedules.Include(s => s.Roads).Include(s => s.Vehicles).ToListAsync();
            var model = schedule.Select(s => new ScheduleDTO {
                Id = s.Id, DepartureTime = s.DepartureTime, ArrivalTime = s.ArrivalTime, RoadName = s.Roads != null ? $"{s.Roads.StartLocation} a {s.Roads.EndLocation}" : "string.Empty", VehicleName = s.Vehicles != null ? $"{s.Vehicles.License} - {s.Vehicles.Model}" : string.Empty
            });
            return View(model);
        }

        // GET: Schedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound(); 

            var schedule = await _context.Schedules
                .Include(s => s.Roads)
                .Include(s => s.Vehicles)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schedule == null) return NotFound();

            var model = new ScheduleDTO
            {
                Id = schedule.Id,
                DepartureTime = schedule.DepartureTime,
                ArrivalTime = schedule.ArrivalTime,
                RoadName = schedule.Roads != null ?  $"{schedule.Roads.StartLocation} a {schedule.Roads.EndLocation}" : string.Empty,
                VehicleName = schedule.Vehicles != null ? $"{schedule.Vehicles.License} - {schedule.Vehicles.Model}" : string.Empty
            };

            return View(model);
        }

        // GET: Schedules/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.vehicles = await _context.Vehicles
                              .Select(v => new SelectListItem{Value = v.Id.ToString(), Text = $"{v.Model} - {v.License}" })
                              .ToListAsync();
            ViewBag.roads = await _context.Roads
                              .Select(r => new {
                                  Value = r.Id.ToString(),
                                  Text = $"{r.StartLocation} a {r.EndLocation}", 
                                  EstimatedDuration = r.EstimatedDuration.ToString()})
                              .ToListAsync();
            return View();
        }

        // POST: Schedules/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartureTime,ArrivalTime,VehicleID,RoadID")] CreateScheduleDTO model)
        {
            if (ModelState.IsValid){
                Schedule schedule = new Schedule{
                    DepartureTime = model.DepartureTime,
                    ArrivalTime = model.ArrivalTime,
                    VehicleID = model.VehicleID,
                    RoadID = model.RoadID,
                };

                _context.Add(schedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.vehicles = await _context.Vehicles
                              .Select(v => new SelectListItem { Value = v.Id.ToString(), Text = $"{v.Model} - {v.License}" })
                              .ToListAsync();
            ViewBag.roads = await _context.Roads
                              .Select(r => new {
                                  Value = r.Id.ToString(),
                                  Text = $"{r.StartLocation} a {r.EndLocation}",
                                  EstimatedDuration = r.EstimatedDuration.ToString()
                              })
                              .ToListAsync();
            return View();
        }

        // GET: Schedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null) return NotFound();

            var model = new EditScheduleDTO {
                Id = schedule.Id,
                DepartureTime = schedule.DepartureTime,
                ArrivalTime = schedule.ArrivalTime,
                VehicleID = schedule.VehicleID,
                RoadID = schedule.RoadID,
            };

            ViewBag.vehicles = await _context.Vehicles
                              .Select(v => new SelectListItem { Value = v.Id.ToString(), Text = $"{v.Model} - {v.License}" })
                              .ToListAsync();
            ViewBag.roads = await _context.Roads
                              .Select(r => new {
                                  Value = r.Id.ToString(),
                                  Text = $"{r.StartLocation} a {r.EndLocation}",
                                  EstimatedDuration = r.EstimatedDuration.ToString()
                              })
                              .ToListAsync();

            return View(model);
        }

        // POST: Schedules/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DepartureTime,ArrivalTime,VehicleID,RoadID")] EditScheduleDTO model)
        {
            if (id != model.Id) return NotFound(); 

            if (ModelState.IsValid) {
                // Obtener los valores de la base de datos y verificar que existen
                var schedule = await _context.Schedules.SingleOrDefaultAsync(s => s.Id == id);
                if (schedule == null) return NotFound();
                // Actualizar con los nuevos valores
                schedule.DepartureTime = model.DepartureTime;
                schedule.ArrivalTime = model.ArrivalTime;
                schedule.VehicleID = model.VehicleID;
                schedule.RoadID = model.RoadID;

                try {
                    _context.Update(schedule);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleExists(schedule.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Schedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules
                .Include(s => s.Roads)
                .Include(s => s.Vehicles)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule != null)
            {
                _context.Schedules.Remove(schedule);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduleExists(int id)
        {
            return _context.Schedules.Any(e => e.Id == id);
        }
    }
}
