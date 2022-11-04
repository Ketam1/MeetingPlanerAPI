
using API.MeetingPlanner.Frontier.Entities;

namespace API.MeetingPlanner.Frontier.Dto
{
    public class LocationDto
    {
        public string LocationName { get; set; }
        public int LocationId { get; set; }
        public IEnumerable<RoomDto> Rooms { get; set; }
    }
}
