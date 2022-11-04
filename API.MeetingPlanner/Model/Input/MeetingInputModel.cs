using API.MeetingPlanner.Dto;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace API.MeetingPlanner.Model
{
    public class MeetingInputModel
    {
        public int LocationId { get; set; }
        public int RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ResponsibleName { get; set; }
        public int CoffeQuantity { get; set; }
        public string Description { get; set; }

        public MeetingInputDto BuildDto()
        {
            return new MeetingInputDto()
            {
                LocationId = LocationId,
                RoomId = RoomId,
                StartDate = StartDate.ToString("yyyy-MM-dd hh:mm:ss"),
                EndDate = EndDate.ToString("yyyy-MM-dd hh:mm:ss"),
                ResponsibleName = ResponsibleName,
                CoffeQuantity = CoffeQuantity,
                Description = Description
            };
        }
    }
}
