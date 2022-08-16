namespace BookinSystemWebApi.DTO
{
    public class AvailableRoomsDTO
    {
        public BranchDto BranchInfo { get; set; }
        public List<RoomDto> AvailableRooms { get; set; }
        public Dictionary<string,int> RoomsTypes { get; set; }
        public double TotalCost { get; set; }
    }
}
