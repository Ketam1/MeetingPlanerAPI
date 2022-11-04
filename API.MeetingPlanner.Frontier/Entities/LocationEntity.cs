
namespace API.MeetingPlanner.Frontier.Entities
{
    public class LocationEntity
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public int MeetingId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ResponsibleName { get; set; }
        public int CoffeQuantity { get; set; }
    }
}
