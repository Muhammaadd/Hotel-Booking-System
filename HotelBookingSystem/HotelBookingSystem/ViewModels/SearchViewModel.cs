namespace HotelBookingSystem.ViewModels
{
    public class SearchViewModel
    {
        [DataType(DataType.Date)]
        [Remote("CheckStartDate","Search",ErrorMessage ="Invalid Date")]
        public DateTime CheckInDate { get; set; }
        [DataType(DataType.Date)]
        [Remote("CheckEndDate", "Search",AdditionalFields = "CheckInDate", ErrorMessage = "Invalid Date")]
        public DateTime CheckOutDate { get; set; }
        public int? NumberOfSingleRooms { get; set; } 
        public int? NumberOfDoubleRooms { get; set; } 
        public int? NumberOfSuiteRooms { get; set; }
        public int NumberOfAdults { get; set; }
    }
}
