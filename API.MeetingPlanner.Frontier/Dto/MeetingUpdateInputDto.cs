using System.Collections.Generic;
using System.Linq;

namespace API.MeetingPlanner.Dto
{
    public class MeetingUpdateInputDto
    {
        public int MeetingId { get; set; }
        public MeetingInputDto MeetingData { get; set; }
    }
}
