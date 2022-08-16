using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomService roomService;

        public RoomController(IRoomService roomService)
        {
            this.roomService = roomService;
        }
        public async Task<IActionResult> Index([FromForm]int Id,[FromForm]string BranchName)
        {
            List<Room> Rooms = await roomService.GetRoomByBranchId(Id);
            if (Rooms.Count==0)
                return NotFound();
            ViewBag.BranchName = BranchName;
            return View(Rooms);
        }
    }
}
