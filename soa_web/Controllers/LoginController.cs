using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.DBContext;

namespace soa_web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDBContext _contexto;

        public LoginController(ApplicationDBContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string correo, string contraseña)
        {
            // Validación de credenciales utilizando Entity Framework
            var usuario = _contexto.personas.FirstOrDefault(u => u.email == correo && u.password == contraseña);

            if (usuario != null)
            {
                // Autenticación exitosa
                // Aquí puedes redirigir a la página de inicio o realizar otras acciones
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Credenciales inválidas, muestra un mensaje de error
                ModelState.AddModelError("", "Credenciales inválidas. Inténtalo de nuevo.");
                return View();
            }
        }
    }
}
