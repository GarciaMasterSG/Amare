namespace Amare.Models
{
    public class GetGuestsDTO
    {
        public List<SpecificGuest> GuestsList { get; set; }

        public List<GropedTables> GroupedTables { get; set; }
    }
}
