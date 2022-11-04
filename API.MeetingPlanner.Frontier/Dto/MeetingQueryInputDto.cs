using System.Collections.Generic;
using System.Linq;

namespace API.MeetingPlanner.Dto
{
    public class MeetingQueryInputDto
    {
        public IEnumerable<int>? MeetingId { get; set; }
        public IEnumerable<int>? LocationId { get; set; }
        public IEnumerable<int>? RoomId { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? ResponsibleName { get; set; }
    }
}
