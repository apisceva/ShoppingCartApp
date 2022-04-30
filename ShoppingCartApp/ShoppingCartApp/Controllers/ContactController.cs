using Microsoft.AspNetCore.Mvc;

namespace ShoppingCartApp.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
