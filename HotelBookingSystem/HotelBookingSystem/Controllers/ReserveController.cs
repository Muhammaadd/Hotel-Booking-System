using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    public class ReserveController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
