namespace HotelBookingSystem.ViewModels
{
    public class AvailableRoomsViewModel
    {
        public Branch BranchInfo { get; set; }
        public List<Room> AvailableRooms { get; set; }
        public Dictionary<string,int> RoomsTypes { get; set; }
        public double TotalCost { get; set; }
    }
}
