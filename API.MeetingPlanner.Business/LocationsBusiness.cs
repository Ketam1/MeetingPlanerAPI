using API.MeetingPlanner.Frontier.Dto;
using API.MeetingPlanner.Frontier.Entities;
using API.MeetingPlanner.Frontier.Interfaces.Business;
using API.MeetingPlanner.Frontier.Interfaces.Repository;

namespace API.MeetingPlanner.Business
{
    public class LocationsBusiness : ILocationsBusiness
    {
        private readonly ILocationsRepository LocationsRepository;

        public LocationsBusiness(
            ILocationsRepository locationsRepository
        )
        {
            LocationsRepository = locationsRepository;
        }
        public IEnumerable<LocationDto> GetLocations(
        )
        {
            var locationsEntity = LocationsRepository.GetLocations();
            return GroupByLocationAndRoom(locationsEntity);
        }

        private IEnumerable<LocationDto> GroupByLocationAndRoom(IEnumerable<LocationEntity> locationsEntity)
        {
            return locationsEntity.GroupBy(row => new { row.LocationId, row.LocationName })
                .Select(locations =>
                    new LocationDto
                    {
                        LocationId = locations.Key.LocationId,
                        LocationName = locations.Key.LocationName,
                        Rooms = locations.GroupBy(location => new { location.RoomId, location.RoomName })
                            .Select(rooms => new RoomDto
                            {
                                RoomId = rooms.Key.RoomId,
                                RoomName = rooms.Key.RoomName,
                            })
                    }
                );
        }
    }
}

