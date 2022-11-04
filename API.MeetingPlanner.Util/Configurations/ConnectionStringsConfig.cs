using Microsoft.Extensions.Configuration;

namespace API.MeetingPlanner.Util
{
    public class ConnectionStringsConfig
    {
        public string Database { get; }
        public ConnectionStringsConfig(IConfiguration config)
        {
            Database = config["ConnectionStrings:database"];
        }
    }
}