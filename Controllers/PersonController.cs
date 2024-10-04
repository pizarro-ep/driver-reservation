using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Transport.Models;

namespace Transport.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public PersonController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Person
        public async Task<IActionResult> Index()
        {
            // Obtner la list de personas
            List<Person> persons = await _context.Persons.ToListAsync();
            // Crear el modelo para la vista
            var model = persons.Select(p => new PersonDTO
            {
                Dni = p.Dni,
                Name = p.Name,
                Surnames = p.Surnames,
            }).ToList();

            return View(model);
        }

        // GET: Person/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest("El ID no puede ser nulo o vacío.");

            var person = await _context.Persons.Include(p => p.Users)
                                               .AsNoTracking()
                                               .FirstOrDefaultAsync(p => p.Dni == id);
            if (person == null) NotFound();

            var model = new PersonDTO { 
                Dni = person?.Dni ?? id,
                Name = person?.Name ?? string.Empty,
                Surnames = person?.Surnames ?? string.Empty,
                UserName = person?.Users?.UserName ?? string.Empty,
                Email = person?.Users?.Email ?? string.Empty,
            };

            return View(model);
        }

        // GET: Person/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Dni,Name,Surnames")] Person person)
        {
            if (ModelState.IsValid) {
                if (PersonExists(person.Dni)) ModelState.AddModelError(string.Empty, "La persona ya existe.");
                else {
                    try {
                        _context.Add(person);   // Add the new person to the context
                        await _context.SaveChangesAsync();  // Save changes to the database
                        return RedirectToAction("Index", "Person");
                    }
                    catch (DbUpdateException ex) {
                        ModelState.AddModelError("", "No se pueden guardar los cambios. Inténtelo de nuevo y, si el problema persiste, consulte con el administrador del sistema.");
                        // Log de la excepción a un archivo
                        ViewBag.Error = ex.Message;
                        ViewBag.ErrorTitle = $"Dni: {person.Dni} en uso";
                        ViewBag.ErrorMessage = $"No se puede crear porque existe otra persona con el DNI {person.Dni}";
                        return View("Error");
                    }
                }
            }
            return View(person);
        }

        // GET: Person/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest("El ID no puede ser nulo o vacío."); //Verificar si hay ID
            var persons = await _context.Persons.FindAsync(id);// Verificar si existe la persona con ese id
            if (persons == null) { // El usuario no fue encontrado
                ViewBag.ErrorMessage = $"La persona con ID {id} no fue encontrado.";
                return View("NotFound");
            }
            // Crear un modelo de vista para mostrar los detalles de la persona y otras propiedades
            var users = await _userManager.FindByIdAsync(id);
            var model = new PersonDTO {
                Dni = persons.Dni,
                Name = persons.Name,
                Surnames = persons.Surnames,
            };
            return View(model);
        }

        // POST: Person/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Dni,Name,Surnames")] PersonDTO model)
        {
            if (id != model.Dni) return NotFound();

            if (ModelState.IsValid) {
                var person = await _context.Persons.FindAsync(model.Dni);
                if (person == null) {
                    ViewBag.ErrorMessage = $"La persona con DNI = {model.Dni} no fue encontrado.";
                    return View("NotFound");
                }
                person.Name = model.Name;
                person.Surnames = model.Surnames;
                try {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!PersonExists(person.Dni)) return NotFound(); 
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Person/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null) return NotFound(); 
            var person = await _context.Persons.FirstOrDefaultAsync(m => m.Dni == id);
            if (person == null) return NotFound(); 
            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person != null)
            {
                _context.Persons.Remove(person);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(string id)
        {
            return _context.Persons.Any(e => e.Dni == id);
        }
    }
}