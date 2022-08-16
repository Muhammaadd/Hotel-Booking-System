using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookinSystemWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService roomService;

        public RoomController(IRoomService roomService)
        {
            this.roomService = roomService;
        }
        [HttpGet]
        [Route("GetRoomsByBranchId/{BranchId}")]
        public IActionResult GetAll([FromRoute]int BranchId)
        {
            return Ok(roomService.GetRoomDtoByBranchId(BranchId));
        }
        [HttpPost]
        [Route("GetAvailableRooms")]
        public IActionResult GetAvailableRooms(SearchViewModel viewModel)
        {
            List<string> ErrorsList = roomService.CheckValidation(viewModel);
            if (ErrorsList.Count > 0)
            {
                foreach (string Error in ErrorsList)
                    ModelState.AddModelError("Error", Error);
                return BadRequest(ModelState);
            }
            List<AvailableRoomsDTO> AvailableRooms = roomService.GetAvailableRooms(viewModel);
            return Ok(AvailableRooms);
        }
    }
}
