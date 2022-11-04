using API.MeetingPlanner.Dto;
using API.MeetingPlanner.Frontier.Dto;
using API.MeetingPlanner.Frontier.Interfaces.Business;
using API.MeetingPlanner.Frontier.Interfaces.Repository;

namespace API.MeetingPlanner.Business
{
    public class MeetingsBusiness : IMeetingsBusiness
    {
        private readonly IMeetingsRepository MeetingsRepository;

        public MeetingsBusiness(
            IMeetingsRepository meetingsRepository
        )
        {
            MeetingsRepository = meetingsRepository;
        }
        public IEnumerable<MeetingDto> QueryMeetings(
            MeetingQueryInputDto input
        )
        {
            var meetings = MeetingsRepository.QueryMeetings(input);
            return meetings.Select(meeting => new MeetingDto(meeting));
        }
        public void AddMeeting(
            MeetingInputDto meeting
        )
        {
            MeetingsRepository.AddMeeting(meeting);
        }

        public void EditMeetingById(
            MeetingUpdateInputDto meeting
        )
        {
            MeetingsRepository.EditMeetingById(meeting);
        }

        public void DeleteMeetingsById(
           IEnumerable<int> meetingIds
        )
        {
            MeetingsRepository.DeleteMeetingsById(
                meetingIds
            );
        }
    }
}

