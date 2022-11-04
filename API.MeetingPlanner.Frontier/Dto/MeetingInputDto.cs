using System.Collections.Generic;
using System.Linq;

namespace API.MeetingPlanner.Dto
{
    public class MeetingInputDto
    {
        public int? LocationId { get; set; }
        public int? RoomId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ResponsibleName { get; set; }
        public int CoffeQuantity { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
}
