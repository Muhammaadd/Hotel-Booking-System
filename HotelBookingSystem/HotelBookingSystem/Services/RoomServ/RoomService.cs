namespace HotelBookingSystem.Services.RoomServ
{
    public class RoomService : IRoomService
    {
        private readonly IConfiguration configuration;

        public RoomService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<List<Room>> GetRoomByBranchId(int BranchId)
        {
            string Baseurl = configuration.GetValue<string>("ApiUrl");
            List<Room> Rooms = new List<Room>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllRooms By Branch Id using HttpClient
                HttpResponseMessage Res = await client.GetAsync($"api/Room/GetRoomsByBranchId/{BranchId}");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Room list
                    Rooms = JsonConvert.DeserializeObject<List<Room>>(Response);
                }
                //returning the employee list to view
                return Rooms;
            }
        }
    }
}
