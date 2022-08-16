namespace HotelBookingSystem.Models
{
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public override string ToString()
        {
            return $"{this.Street}, {this.City}, {this.Country}";
        }
    }
}
