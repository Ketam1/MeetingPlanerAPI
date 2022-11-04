
using API.MeetingPlanner.Frontier.Entities;

namespace API.MeetingPlanner.Frontier.Dto
{
    public class MeetingDto
    {
        public int MeetingId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ResponsibleName { get; set; }
        public int CoffeQuantity { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public MeetingDto(MeetingEntity meeting)
        {
            MeetingId = meeting.MeetingId;
            StartDate = meeting.StartDate;
            EndDate = meeting.EndDate;
            ResponsibleName = meeting.ResponsibleName;
            CoffeQuantity = meeting.CoffeQuantity;
            Title = meeting.Title;
            Description = meeting.Description;
        }
    }
}
