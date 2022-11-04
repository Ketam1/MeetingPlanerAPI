using API.MeetingPlanner.Dto;
using API.MeetingPlanner.Frontier.Dto;
using API.MeetingPlanner.Frontier.Entities;

namespace API.MeetingPlanner.Frontier.Interfaces.Repository
{
    public interface IMeetingsRepository
    {
        public IEnumerable<MeetingEntity> QueryMeetings(
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

