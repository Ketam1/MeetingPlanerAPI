using API.MeetingPlanner.Frontier.Dto;

namespace API.MeetingPlanner.Frontier.Interfaces.Repository
{
    public interface IBaseRepository<TObject>
    {
        string LoadSqlStatement(string statementName);
        IEnumerable<TObject> List(string sql, object parameters = null, int? commandTimeout = null);
        int Execute(string sql, object parameters, int? commandTimeout = null);
    }
}

