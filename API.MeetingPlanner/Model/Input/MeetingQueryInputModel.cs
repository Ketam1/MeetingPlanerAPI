using API.MeetingPlanner.Dto;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace API.MeetingPlanner.Model
{
    public class MeetingQueryInputModel
    {
        public IEnumerable<int>? MeetingId { get; set; }
        public IEnumerable<int>? LocationId { get; set; }
        public IEnumerable<int>? RoomId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public MeetingQueryInputDto BuildDto()
        {
            return new MeetingQueryInputDto()
            {
                MeetingId = MeetingId,
                LocationId = LocationId,
                RoomId = RoomId,
                StartDate = StartDate?.ToString("yyyy-MM-dd hh:mm:ss"),
                EndDate = EndDate?.ToString("yyyy-MM-dd hh:mm:ss"),
            };
        }
    }
}
