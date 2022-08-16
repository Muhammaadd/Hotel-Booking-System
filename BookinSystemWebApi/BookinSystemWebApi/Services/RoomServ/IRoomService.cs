namespace BookinSystemWebApi.Services.RoomServ
{
    public interface IRoomService:IRoomRepository
    {
        List<RoomDto> GetRoomDtoByBranchId(int BranchId);
        List<string> CheckValidation(SearchViewModel searchViewModel);
    }
}
