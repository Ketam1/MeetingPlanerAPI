using Microsoft.Extensions.Configuration;

namespace API.MeetingPlanner.Util
{
    public class Configuration
    {
        #region Variables

        private static Configuration configuration;

        public ConnectionStringsConfig ConnectionStrings { get; }
        #endregion
        private Configuration(IConfiguration config)
        {
            ConnectionStrings = new ConnectionStringsConfig(config);
        }

        public static Configuration Get
        {
            get
            {
                if (configuration == null)
                {
                    configuration = GetCurrentConfigurations();
                }
                return configuration;
            }
        }

        private static Configuration GetCurrentConfigurations()
        {
            string path = Directory.GetCurrentDirectory();
            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration config = new Configuration(builder.Build());

            return config;
        }
    }
}