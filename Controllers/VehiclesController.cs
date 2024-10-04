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
    public class VehiclesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehiclesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            List<Vehicle> vehicles = await _context.Vehicles.Include(d => d.Drivers).ToListAsync();

            var model = vehicles.Select(v => new VehicleDTO {
                Id = v.Id,
                Capacity = v.Capacity,
                DriverName = v.Drivers != null ? ($"{v.Drivers.Name} {v.Drivers.Surnames}") : "Sin conductor",
                License = v.License,
                Model = v.Model,
                Status = v.Status
            }).ToList();

            return View(model);
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)return NotFound();

            var vehicle = await _context.Vehicles
                                        .Include(v => v.Drivers)
                                        .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null) return NotFound();

            var model = new VehicleDTO {
                Id = vehicle.Id,
                Capacity = vehicle.Capacity,
                Model = vehicle.Model,
                License = vehicle.License,
                Status = vehicle.Status,
                DriverName = vehicle.Drivers != null ? $"{vehicle.Drivers.Name} {vehicle.Drivers.Surnames}" : string.Empty,
            };

            return View(model);
        }

        // GET: Vehicles/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            // Obtener valores para el select conductores
            var drivers = await _context.Persons
                                .Select(p => new SelectListItem { Value = p.Dni, Text = $"{p.Dni} | {p.Name} {p.Surnames}"})
                                .ToListAsync();
            // Obtener los valores de la enumeración
            var status = Enum.GetValues(typeof(Status))
                                    .Cast<Status>()
                                    .Select(s => new SelectListItem {Value = s.ToString(), Text = s.ToString()})
                                    .ToList();

            // Pasar los valores a la vista usando ViewBag
            ViewBag.drivers = drivers;
            ViewBag.status = status;
            return View();
        }

        // POST: Vehicles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("License,Model,Capacity,Status,DriverID")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DriverID"] = new SelectList(_context.Persons, "Dni", "Dni", vehicle.DriverID);
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound(); 

            // Obtener valores para el select conductores
            var drivers = await _context.Persons
                                .Select(p => new SelectListItem { Value = p.Dni, Text = $"{p.Dni} | {p.Name} {p.Surnames}" })
                                .ToListAsync();
            // Obtener los valores de la enumeración
            var status = Enum.GetValues(typeof(Status))
                                    .Cast<Status>()
                                    .Select(s => new SelectListItem { Value = s.ToString(), Text = s.ToString() })
                                    .ToList();

            // Pasar los valores a la vista usando ViewBag
            ViewBag.drivers = drivers;
            ViewBag.status = status;

            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null) return NotFound(); 

            var model = new EditVehicleDTO {
                Id = vehicle.Id,
                License = vehicle.License,
                ModelVehicle = vehicle.Model,
                Capacity = vehicle.Capacity,
                Status = vehicle.Status,
                DriverID = vehicle.DriverID,
            };

            return View(model);
        }

        // POST: Vehicles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,License,ModelVehicle,Capacity,Status,DriverID")] EditVehicleDTO model)
        {
            if (id != model.Id) return NotFound();

            if (ModelState.IsValid) {
                // Obtener los valores de la base de datos
                var vehicle = await _context.Vehicles.SingleOrDefaultAsync(p => p.Id == id);
                if (vehicle == null) return NotFound();
                // Actualizar los valores de la base de datos
                vehicle.License = model.License;
                vehicle.Model = model.ModelVehicle;
                vehicle.Capacity = model.Capacity;
                vehicle.Status = model.Status;
                vehicle.DriverID = model.DriverID;

                try {
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!VehicleExists(vehicle.Id)) return NotFound(); 
                    else throw; 
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DriverID"] = new SelectList(_context.Persons, "Dni", "Dni", model.DriverID);
            return View(model);
        }

        // GET: Vehicles/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound(); 
            var vehicle = await _context.Vehicles
                                        .Include(v => v.Drivers)
                                        .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null) return NotFound(); 

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle != null) _context.Vehicles.Remove(vehicle); 

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicles.Any(e => e.Id == id);
        }
    }
}
