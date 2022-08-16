namespace HotelBookingSystem.Services.BranchServ
{
    public class BranchService : IBranchService
    {
        private readonly IConfiguration configuration;

        public BranchService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<List<Branch>> GetAll()
        {

            string Baseurl = configuration.GetValue<string>("ApiUrl");
            List<Branch> Branches = new List<Branch>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllBranches using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/Branch");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Branch list
                    Branches = JsonConvert.DeserializeObject<List<Branch>>(Response);
                }
                //returning the employee list to view
                return Branches;
            }
        }
    }
}
