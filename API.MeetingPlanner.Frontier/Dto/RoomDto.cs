
using API.MeetingPlanner.Frontier.Entities;

namespace API.MeetingPlanner.Frontier.Dto
{
    public class RoomDto
    {
        public string RoomName { get; set; }
        public int RoomId { get; set; }
        public IEnumerable<MeetingDto> Meetings { get; set; }
    }
}
