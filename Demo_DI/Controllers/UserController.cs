using Microsoft.AspNetCore.Mvc;
using Services.User;

namespace Demo_DI.Controllers
{
    public class UserController : Controller
    {
        public readonly IUserServices Services;
        public UserController(IUserServices services)
        {
            Services = services;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
