
namespace BookinSystemWebApi.Models
{
    public class Room
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(25)")]
        public string RoomNumber { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Details { get; set; }
        [Column(TypeName = "money")]
        public double Price { get; set; }
        public int NumberOfAdults { get; set; }
        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        [ForeignKey("RoomType")]
        public int RoomTypeId { get; set; }
        [JsonIgnore]
        public virtual Branch? Branch { get; set; }
        [JsonIgnore]
        public virtual RoomType? RoomType { get; set; }
        [JsonIgnore]
        public virtual List<Reservation>? Reservations { get; set; }
        [JsonIgnore]
        public virtual List<RoomGallary> RoomGallaries { get; set; }

    }
}
