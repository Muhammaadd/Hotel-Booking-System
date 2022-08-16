namespace BookinSystemWebApi.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int NumberOfAdults { get; set; }
        public DateTime ReservationDate { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string ReservationStatus { get; set; }
        public double TotalCost { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual Room? Room { get; set; }
    }
}
