using API.MeetingPlanner.Dto;
using API.MeetingPlanner.Frontier.Dto;

namespace API.MeetingPlanner.Frontier.Interfaces.Business
{
    public interface IMeetingsBusiness
    {
        public IEnumerable<MeetingDto> QueryMeetings(
            MeetingQueryInputDto input    
        );
        public void AddMeeting(
            MeetingInputDto meeting   
        );
        public void EditMeetingById(
            MeetingUpdateInputDto meeting
        );
        public void DeleteMeetingsById(
           IEnumerable<int> meetingIds
        );
    }
}

