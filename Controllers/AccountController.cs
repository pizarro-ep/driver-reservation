using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Transport.Models;

namespace Transport.Controllers
{
    public class AccountController : Controller {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        // Constructor del controlador 
        public AccountController(
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context
        ){

            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult Login(string? ReturnUrl = null)
        {
            ViewData["ReturnUrl"] = ReturnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO model, string? ReturnUrl = null)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                    return Redirect(ReturnUrl);
                else
                    return RedirectToAction("Index", "Home");
            }
            if (result.RequiresTwoFactor) { }
            if(result.IsLockedOut) { }
            else
            {
                ModelState.AddModelError(string.Empty, "Correo o contraseña incorrectos");
                return View(model);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            if (ModelState.IsValid) {
                var user = new ApplicationUser {
                    UserName = model.Email,
                    Email = model.Email,
                    // CreatedDate = model.CreatedDate
                };
                // Crear el usuario en la base de datos
                var result = await _userManager.CreateAsync(user, model.Password);
                
                // Verificar si la creación del usuario fue exitosa
                if (result.Succeeded) {
                    // Crear la entidad persona
                    var persons = new Person
                    {
                        Dni = model.Dni,
                        Name = model.Name,
                        Surnames = model.Surnames,
                        UserID =user.Id, // Asociar el ID del usuario
                    };
                    // Guardar la entidad persona en la base de datos
                    _context.Persons.Add(persons);
                    await _context.SaveChangesAsync();

                    // Iniciar sesión para el usuario
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    // Redirigir según el rol del usuario
                    if (await _userManager.IsInRoleAsync(user, "Administrador")) 
                        return RedirectToAction("ListUsers", "Administration");
                    
                    return RedirectToAction("Index", "Home");
                }
                // Mostrar errores si hubo algún problema al crear el usuario
                foreach (var error in result.Errors) {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            // Cerrar la sesion actual
            await _signInManager.SignOutAsync();
            // redirigir a la página de inicio
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpPost]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailAvaible(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return Json(true);
            else return Json($"El correo electrónico {email} ya está en uso");
        }
    }
}
