using Microsoft.AspNetCore.Mvc;
using MvcCoreSeguridadPersonalizada.Filters;

namespace MvcCoreSeguridadPersonalizada.Controllers
{
    public class UsuariosController : Controller
    {
        [AuthorizeUsers]
        public IActionResult Perfil()
        {
            return View();
        }
    }
}
