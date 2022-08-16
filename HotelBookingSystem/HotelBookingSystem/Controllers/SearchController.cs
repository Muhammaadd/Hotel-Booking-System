using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }
        public async Task<IActionResult> Index(SearchViewModel viewModel)
        {
            List<string> ErrorsList =  searchService.CheckValidation(viewModel);
            if(ErrorsList.Count>0)
            {
                ViewBag.ErrorsList = ErrorsList;
                return View();
            }
            List<AvailableRoomsViewModel> AvailableRooms = await searchService.GetAvailableRooms(viewModel);
            if(AvailableRooms.Count==0)
                ViewBag.Availability = "We Are very Sorry, There are no rooms available in this date";
            return View(AvailableRooms);
        }
        
        
    }
}
