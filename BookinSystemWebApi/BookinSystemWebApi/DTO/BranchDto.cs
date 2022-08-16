namespace BookinSystemWebApi.DTO
{
    public class BranchDto
    {
        public int Id {get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public Address address { get; set; }
    }
}
