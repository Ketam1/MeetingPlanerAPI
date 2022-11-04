
using API.MeetingPlanner.Frontier.Entities;

namespace API.MeetingPlanner.Frontier.Dto
{
    public class MeetingDto
    {
        public int MeetingId { get; set; }
        public string LocationName { get; set; }
        public int LocationId { get; set; }
        public string RoomName { get; set; }
        public int RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ResponsibleName { get; set; }
        public int CoffeQuantity { get; set; }

        public MeetingDto(LocationEntity meeting)
        {
            MeetingId = meeting.MeetingId;
            LocationName = meeting.LocationName;
            LocationId = meeting.LocationId;
            RoomName = meeting.RoomName;
            RoomId = meeting.RoomId;
            StartDate = meeting.StartDate;
            EndDate = meeting.EndDate;
            ResponsibleName = meeting.ResponsibleName;
            CoffeQuantity = meeting.CoffeQuantity;
        }

        public MeetingDto(MeetingEntity meeting)
        {
            MeetingId = meeting.MeetingId;
            LocationName = meeting.LocationName;
            LocationId = meeting.LocationId;
            RoomName = meeting.RoomName;
            RoomId = meeting.RoomId;
            StartDate = meeting.StartDate;
            EndDate = meeting.EndDate;
            ResponsibleName = meeting.ResponsibleName;
            CoffeQuantity = meeting.CoffeQuantity;
        }
    }
}
