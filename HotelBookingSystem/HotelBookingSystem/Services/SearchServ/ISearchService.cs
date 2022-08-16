namespace HotelBookingSystem.Services.SearchServ
{
    public interface ISearchService
    {
        List<string> CheckValidation(SearchViewModel viewModel);
        Task<List<AvailableRoomsViewModel>> GetAvailableRooms(SearchViewModel searchViewModel);
    }
}
