namespace BookinSystemWebApi.Models
{
    public class RoomGallary
    {
        [Column(TypeName = "varchar(75)")]
        public string ImageSrc { get; set; }
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public virtual Room? Room { get; set; }

    }
}
