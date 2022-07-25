using API.RegisterScreen.Business;
using API.RegisterScreen.Frontier.Interfaces.Business;
using API.RegisterScreen.Frontier.Interfaces.Repository;
using API.RegisterScreen.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace API.RegisterScreen.Map
{
    public static class Map
    {
        public static void SetupDependenceInjection(IServiceCollection services)
        {

            #region Business
            services.AddTransient<IUsersBusiness, UsersBusiness>();
            services.AddTransient<IContactsBusiness, ContactsBusiness>();
            #endregion Business

            #region Repository
            services.AddTransient<IContactListRepository, ContactListRepository>();
            #endregion Repository
        }
    }
}