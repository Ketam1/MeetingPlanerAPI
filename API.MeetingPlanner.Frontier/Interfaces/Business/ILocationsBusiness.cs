using API.MeetingPlanner.Frontier.Dto;

namespace API.MeetingPlanner.Frontier.Interfaces.Business
{
    public interface ILocationsBusiness
    {
        public IEnumerable<LocationDto> GetLocations();
    }
}

