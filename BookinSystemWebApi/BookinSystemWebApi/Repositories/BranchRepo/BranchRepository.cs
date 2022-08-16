namespace BookinSystemWebApi.Repositories.BranchRepo
{
    public class BranchRepository : IBranchRepository
    {
        private readonly HotelContext hotelContext;

        public BranchRepository(HotelContext hotelContext)
        {
            this.hotelContext = hotelContext;
        }
        public List<Branch> GetAll()
        {
            return hotelContext.Branch.ToList();
        }
    }
}
