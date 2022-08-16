namespace HotelBookingSystem.Services.RoomServ
{
    public interface IRoomService
    {
        Task<List<Room>> GetRoomByBranchId(int BranchId);
    }
}
