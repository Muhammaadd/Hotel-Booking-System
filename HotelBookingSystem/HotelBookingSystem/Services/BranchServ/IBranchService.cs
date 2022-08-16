namespace HotelBookingSystem.Services.BranchServ
{
    public interface IBranchService
    {
        Task<List<Branch>> GetAll();
    }
}
