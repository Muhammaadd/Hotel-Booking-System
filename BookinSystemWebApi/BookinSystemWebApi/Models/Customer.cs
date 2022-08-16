namespace BookinSystemWebApi.Models
{
    public class Customer:ApplicationUser
    {
        [Column(TypeName = "varchar(100)")]
        public string Address { get; set; }
        public virtual List<Reservation>? Reservations { get; set; }
    }
}
