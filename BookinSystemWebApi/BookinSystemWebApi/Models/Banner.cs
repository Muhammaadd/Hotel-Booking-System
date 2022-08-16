namespace BookinSystemWebApi.Models
{
    public class Banner
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string ImageSrc { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string Description { get; set; }
        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public virtual Branch? Branch { get; set; }
    }
}
