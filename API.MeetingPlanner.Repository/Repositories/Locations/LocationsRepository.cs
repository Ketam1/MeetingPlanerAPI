using API.MeetingPlanner.Frontier.Dto;
using API.MeetingPlanner.Frontier.Entities;
using API.MeetingPlanner.Frontier.Interfaces.Repository;
using API.MeetingPlanner.Repository.Entities;
using API.MeetingPlanner.Util;
using System.Text;

namespace API.MeetingPlanner.Repository.Repositories.Locations
{
    public class LocationsRepository : ILocationsRepository
    {
        private readonly IBaseRepository<Location> LocationsDataRepository;
        public LocationsRepository()
        {
            LocationsDataRepository = new BaseRepository<Location>(Configuration.Get.ConnectionStrings.Database, this.GetType().Namespace);
        }

        public IEnumerable<LocationEntity> GetLocations()
        {
            var query = LocationsDataRepository.LoadSqlStatement("GetLocations.sql");

            return LocationsDataRepository.List(query);
        }
    }
}
