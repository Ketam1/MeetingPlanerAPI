
namespace API.MeetingPlanner.Frontier.Entities
{
    public class MeetingEntity
    {
        public int MeetingId { get; set; }
        public int LocationId { get; set; }
        public int RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ResponsibleName { get; set; }
        public int CoffeQuantity { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
