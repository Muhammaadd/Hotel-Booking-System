namespace BookinSystemWebApi.Services.BranchServ
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository branchRepository;

        public BranchService(IBranchRepository branchRepository)
        {
            this.branchRepository = branchRepository;
        }
        public List<Branch> GetAll()
        {
            return branchRepository.GetAll();
        }

        public List<BranchDto> GetAllBranchesDto()
        {
            return GetAll().Select(n=>new BranchDto { 
                Id = n.Id,
                Name = n.Name,
                ContactEmail = n.ContactEmail,
                ContactNumber = n.ContactNumber,
                address = new Address
                {
                    Street = n.Street,
                    City = n.City,
                    Country = n.Country
                }
            }).ToList();
        }
    }
}
