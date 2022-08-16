using Microsoft.AspNetCore.Mvc;

namespace BookinSystemWebApi.DTO
{
    public class SearchViewModel
    {
        [Required]
        public DateTime CheckInDate { get; set; }
        [Required]
        public DateTime CheckOutDate { get; set; }
        public int? NumberOfSingleRooms { get; set; }
        public int? NumberOfDoubleRooms { get; set; }
        public int? NumberOfSuiteRooms { get; set; }
        [Required]
        public int NumberOfAdults { get; set; }
    }
}
