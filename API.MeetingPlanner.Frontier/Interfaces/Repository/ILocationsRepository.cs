using API.MeetingPlanner.Frontier.Dto;
using API.MeetingPlanner.Frontier.Entities;

namespace API.MeetingPlanner.Frontier.Interfaces.Repository
{
    public interface ILocationsRepository
    {
        public IEnumerable<LocationEntity> GetLocations();
    }
}

