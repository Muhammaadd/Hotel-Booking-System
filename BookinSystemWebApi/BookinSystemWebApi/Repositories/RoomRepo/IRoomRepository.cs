namespace BookinSystemWebApi.Repositories.RoomRepo
{
    public interface IRoomRepository
    {
        List<Room> GetAll();
        List<Room> GetRoomByBranchId(int BranchId);
        List<Room> GetRoomAndReservationByBranchID(int BranchId);
        List<Reservation> GetAllReservedRooms();
        List<AvailableRoomsDTO> GetAvailableRooms(SearchViewModel searchViewModel);
    }
}
