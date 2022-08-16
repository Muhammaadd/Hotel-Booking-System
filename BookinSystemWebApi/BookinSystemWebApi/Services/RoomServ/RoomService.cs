using System.Linq;
namespace BookinSystemWebApi.Services.RoomServ
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }
        public List<Room> GetAll()
        {
            return roomRepository.GetAll();
        }

        public List<Room> GetRoomByBranchId(int BranchId)
        {
            return roomRepository.GetRoomByBranchId(BranchId);
        }

        public List<RoomDto> GetRoomDtoByBranchId(int BranchId)
        {
            return GetRoomByBranchId(BranchId).Select(n => new RoomDto
            {
                Id = n.Id,
                Details = n.Details,
                Price = n.Price,
                Type = n.RoomType.Name,
                NumberOfAdults = n.NumberOfAdults
            }).ToList();
        }
        public List<string> CheckValidation(SearchViewModel viewModel)
        {
            List<string> ErrorsList = new List<string>();
            if (viewModel.CheckInDate < DateTime.Now)
                ErrorsList.Add("Invalid Check in Date");
            if (viewModel.CheckInDate >= viewModel.CheckOutDate)
                ErrorsList.Add("Invalid Check out Date");
            if (viewModel.NumberOfSingleRooms <= 0 && viewModel.NumberOfDoubleRooms <= 0 && viewModel.NumberOfSuiteRooms <= 0)
                ErrorsList.Add("You must at least select one Room");
            if (viewModel.NumberOfAdults <= 0)
                ErrorsList.Add("Number of Adults is required");
            return ErrorsList;
        }

        public List<Room> GetRoomAndReservationByBranchID(int BranchId)
        {
            return roomRepository.GetRoomAndReservationByBranchID(BranchId);
        }

        public List<Reservation> GetAllReservedRooms()
        {
            return roomRepository.GetAllReservedRooms();
        }

        public List<AvailableRoomsDTO> GetAvailableRooms(SearchViewModel searchViewModel)
        {
            return roomRepository.GetAvailableRooms(searchViewModel);
        }
    }
}
