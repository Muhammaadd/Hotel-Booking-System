using System.Text;

namespace HotelBookingSystem.Services.SearchServ
{
    public class SearchService : ISearchService
    {
        private readonly IConfiguration configuration;

        public SearchService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public List<string> CheckValidation(SearchViewModel viewModel)
        {
            List<string> ErrorsList = new List<string>();
            if (viewModel.CheckInDate < DateTime.Now)
                ErrorsList.Add("Invalid Check in Date");
            if (viewModel.CheckInDate >= viewModel.CheckOutDate)
                ErrorsList.Add("Invalid Check out Date");
            if (viewModel.NumberOfSingleRooms<=0&&viewModel.NumberOfDoubleRooms<=0&&viewModel.NumberOfSuiteRooms<=0)
                ErrorsList.Add("You must at least select one Room");
            if (viewModel.NumberOfAdults<=0)
                ErrorsList.Add("Number of Adults is required");
            return ErrorsList;
        }

        public async Task<List<AvailableRoomsViewModel>> GetAvailableRooms(SearchViewModel searchViewModel)
        {
            string Baseurl = configuration.GetValue<string>("ApiUrl");
            List<AvailableRoomsViewModel> AvailableRooms = new List<AvailableRoomsViewModel>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllRooms By Branch Id using HttpClient
                string SerializedString = JsonConvert.SerializeObject(searchViewModel);
                var stringContent = new StringContent(SerializedString, UnicodeEncoding.UTF8, "application/json");
                HttpResponseMessage Res = await client.PostAsync($"api/Room/GetAvailableRooms",stringContent);
                    //($"api/Room/GetAvailableRooms", searchViewModel);   
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Room list
                    AvailableRooms = JsonConvert.DeserializeObject<List<AvailableRoomsViewModel>>(Response);
                }
                //returning the employee list to view
                return AvailableRooms;
            }
        }
    }
}
