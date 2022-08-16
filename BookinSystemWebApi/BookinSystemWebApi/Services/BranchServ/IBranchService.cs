namespace BookinSystemWebApi.Services.BranchServ
{
    public interface IBranchService:IBranchRepository
    {
        List<BranchDto> GetAllBranchesDto();
    }
}
