namespace BookinSystemWebApi.Models
{
    public class Branch
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(11)")]
        [MinLength(11)]
        [MaxLength(11)]
        public string ContactNumber {get;set;}
        [Column(TypeName = "varchar(50)")]
        public string ContactEmail { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Street { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string City { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Country { get; set; }
        public virtual List<Room>? Rooms { get; set; }
        public virtual List<Banner>? Banners { get; set; }

    }
}
