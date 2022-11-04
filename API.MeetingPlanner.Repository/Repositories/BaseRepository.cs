using API.MeetingPlanner.Frontier.Dto;
using API.MeetingPlanner.Frontier.Entities;
using API.MeetingPlanner.Frontier.Interfaces.Repository;
using System.Data.SqlClient;
using Dapper;
using System.Text;
using MySql.Data.MySqlClient;

namespace API.MeetingPlanner.Repository
{
    public class BaseRepository<TObject> : IBaseRepository<TObject>
    {
        private const int DEFAULT_TIMEOUT = 200;

        protected readonly string ConnectionString;
        protected readonly string SqlFilesLocation;

        public BaseRepository(string connectionString, string controllerNamespace = null)
        {
            ConnectionString = connectionString;
            SqlFilesLocation = string.Format("{0}.Queries", controllerNamespace ?? string.Empty);
        }

        public string LoadSqlStatement(string statementName)
        {
            return DatabaseUtils.LoadResourceFile(SqlFilesLocation, statementName);
        }

        public IEnumerable<TObject> List(string sql, object parameters = null, int? commandTimeout = null)
        {
            IEnumerable<TObject> returnList;
            using (var connection = new MySqlConnection(ConnectionString))
            {
                returnList = connection.Query<TObject>(sql, parameters, commandTimeout: commandTimeout ?? DEFAULT_TIMEOUT);
            }
            return returnList != null ? DatabaseUtils.TrimStrings(returnList) : returnList;
        }
        public int Execute(string sql, object parameters, int? commandTimeout = null)
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                return connection.Execute(sql, parameters, commandTimeout: commandTimeout ?? DEFAULT_TIMEOUT);
            }
        }
    }
}