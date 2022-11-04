using API.MeetingPlanner.Dto;
using System.Collections.Generic;
using System.Linq;

namespace API.MeetingPlanner.Model
{
    public class MeetingUpdateInputModel
    {
        public int MeetingId { get; set; }
        public MeetingInputModel MeetingData { get; set; }

        public MeetingUpdateInputDto BuildDto()
        {
            return new MeetingUpdateInputDto()
            {
                MeetingId = MeetingId,
                MeetingData = MeetingData.BuildDto()
            };
        }
    }
}
