namespace BookinSystemWebApi.Models
{
    public class RoomType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Room>? Rooms { get; set; }
    }
}
