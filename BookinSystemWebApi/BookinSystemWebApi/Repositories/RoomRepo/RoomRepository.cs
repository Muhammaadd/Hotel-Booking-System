namespace BookinSystemWebApi.Repositories.RoomRepo
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelContext hotelContext;

        public RoomRepository(HotelContext hotelContext)
        {
            this.hotelContext = hotelContext;
        }
        public List<Room> GetAll()
        {
            return hotelContext.Room.Include(n=>n.RoomType).ToList();
        }
    
        public List<Room> GetRoomByBranchId(int BranchId)
        {
            return hotelContext.Room.Include(n=>n.RoomType).Where(n => n.BranchId == BranchId).ToList();
        }
        public List<Room> GetRoomAndReservationByBranchID(int BranchId)
        {
            return hotelContext.Room.Include(n => n.RoomType).Include(n=>n.Reservations).Where(n => n.BranchId == BranchId).ToList();
        }
        public List<Reservation> GetAllReservedRooms()
        {
            return hotelContext.Reservation.ToList();
        }
        public List<RoomDto> MappingRoomToDto(List<Room> Rooms)
        {
            List<RoomDto> roomsDto = new List<RoomDto>();
            foreach (Room room in Rooms)
            {
                roomsDto.Add(new RoomDto
                {
                    Id = room.Id,
                    Details = room.Details,
                    Price = room.Price,
                    Type = room.RoomType.Name,
                    NumberOfAdults = room.NumberOfAdults
                });
            }
            return roomsDto;
        }
        public double CalculateTotalCost(List<RoomDto> Rooms,int NumberOfAdults)
        {
            double totalCost = 0;
            int allowedNumberOfAdults = 0;
            foreach (RoomDto room in Rooms)
            {
                totalCost += room.Price;
                allowedNumberOfAdults += room.NumberOfAdults;
            }
            if (allowedNumberOfAdults < NumberOfAdults)
                totalCost += (NumberOfAdults - allowedNumberOfAdults) * 500;
            return totalCost;
        }
        public List<AvailableRoomsDTO> GetAvailableRooms(SearchViewModel searchViewModel)
        {
            Dictionary<string,int> RoomsType = new Dictionary<string,int>();
            List<AvailableRoomsDTO> AvailableRooms = new List<AvailableRoomsDTO>();
            List<BranchDto> Branches = 
                hotelContext.Branch.Select(n => new BranchDto
                {
                    Id = n.Id,
                    Name = n.Name,
                    ContactEmail = n.ContactEmail,
                    ContactNumber = n.ContactNumber,
                    address = new Address
                    {
                        Street = n.Street,
                        City = n.City,
                        Country = n.Country
                    }
                }).ToList();
            List<int> ReservedRooms = 
                GetAllReservedRooms()
                .Where(n=>n.CheckIn>searchViewModel.CheckInDate&&n.CheckOut<searchViewModel.CheckOutDate)
                .Select(n=>n.RoomId).ToList();
            foreach(var Branch in Branches)
            {
                List<Room> NeededRooms = new List<Room>();
                List<Room> AvailableRoomsBerBranch = 
                    GetAll().Where(n => n.BranchId == Branch.Id && !ReservedRooms
                    .Any(r => r == n.Id)).ToList();
                List<Room> SingleRooms = AvailableRoomsBerBranch.Where(n => n.RoomType.Name == TypeRoom.Single.ToString())
                    .ToList();
                List<Room> DoubleRooms = AvailableRoomsBerBranch.Where(n => n.RoomType.Name == TypeRoom.Double.ToString())
                    .ToList();
                List<Room> SuiteRooms = AvailableRoomsBerBranch.Where(n => n.RoomType.Name == TypeRoom.Suite.ToString())
                    .ToList();
                if (SingleRooms.Count() < searchViewModel.NumberOfSingleRooms)
                    continue;
                else if(searchViewModel.NumberOfSingleRooms > 0)
                {
                    NeededRooms.AddRange(SingleRooms.Take((int)searchViewModel.NumberOfSingleRooms).ToList());
                    try
                    {
                        RoomsType.Add(TypeRoom.Single.ToString(), (int)searchViewModel.NumberOfSingleRooms);
                    }
                    catch { }
                }
                if (DoubleRooms.Count() < searchViewModel.NumberOfDoubleRooms)
                    continue;
                else if (searchViewModel.NumberOfDoubleRooms > 0)
                {
                    NeededRooms.AddRange(DoubleRooms.Take((int)searchViewModel.NumberOfDoubleRooms).ToList());
                    try
                    {
                        RoomsType.Add(TypeRoom.Double.ToString(), (int)searchViewModel.NumberOfDoubleRooms);
                    }
                    catch { } 
                }
                if (SuiteRooms.Count() < searchViewModel.NumberOfSuiteRooms)
                    continue;
                else if (searchViewModel.NumberOfSuiteRooms > 0)
                {
                    NeededRooms.AddRange(SuiteRooms.Take((int)searchViewModel.NumberOfSuiteRooms).ToList());
                    try
                    {
                        RoomsType.Add(TypeRoom.Suite.ToString(), (int)searchViewModel.NumberOfSuiteRooms);
                    }
                    catch { }
                }
                List<RoomDto> MappedRooms = MappingRoomToDto(NeededRooms);
                double totalCost = CalculateTotalCost(MappedRooms,searchViewModel.NumberOfAdults);
                AvailableRooms.Add(new AvailableRoomsDTO { BranchInfo = Branch, AvailableRooms = MappedRooms,RoomsTypes=RoomsType,TotalCost=totalCost });      
               }
            return AvailableRooms;
        }
    }
}
