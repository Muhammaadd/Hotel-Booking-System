
namespace HotelBookingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBranchService branchService;

        public HomeController(IBranchService branchService)
        {
            this.branchService = branchService;
        }
        public async Task<IActionResult> Index()
        {
            List<Branch> branches = await branchService.GetAll();  
            return View(branches);
        }

    }
}