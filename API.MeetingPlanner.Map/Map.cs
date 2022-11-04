using API.MeetingPlanner.Business;
using API.MeetingPlanner.Frontier.Interfaces.Business;
using API.MeetingPlanner.Frontier.Interfaces.Repository;
using API.MeetingPlanner.Repository.Repositories.Locations;
using API.MeetingPlanner.Repository.Repositories.Meetings;
using Microsoft.Extensions.DependencyInjection;

namespace API.MeetingPlanner.Map
{
    public static class Map
    {
        public static void SetupDependenceInjection(IServiceCollection services)
        {

            #region Business
            services.AddTransient<IMeetingsBusiness, MeetingsBusiness>();
            services.AddTransient<ILocationsBusiness, LocationsBusiness>();
            #endregion Business

            #region Repository
            services.AddTransient<IMeetingsRepository, MeetingsRepository>();
            services.AddTransient<ILocationsRepository, LocationsRepository>();
            #endregion Repository
        }
    }
}