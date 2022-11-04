using API.MeetingPlanner.Dto;
using API.MeetingPlanner.Frontier.Dto;
using API.MeetingPlanner.Frontier.Entities;
using API.MeetingPlanner.Frontier.Interfaces.Repository;
using API.MeetingPlanner.Repository.Entities;
using API.MeetingPlanner.Util;
using Dapper;
using System.Data;
using System.Text;

namespace API.MeetingPlanner.Repository.Repositories.Meetings
{
    public class MeetingsRepository : IMeetingsRepository
    {
        private readonly IBaseRepository<Meeting> MeetingsDataRepository;
        
        public MeetingsRepository()
        {
            MeetingsDataRepository = new BaseRepository<Meeting>(Configuration.Get.ConnectionStrings.Database, this.GetType().Namespace);
        }

        public IEnumerable<MeetingEntity> QueryMeetings(
            MeetingQueryInputDto input
        )
        {
            var query = MeetingsDataRepository.LoadSqlStatement("GetMeetings.sql");
            DynamicParameters parameters = new DynamicParameters();
            if (input.MeetingId != null)
            {
                query += " AND meetingId IN @MeetingId";
                parameters.Add("@MeetingId", input.MeetingId);
            }
            if (input.LocationId != null)
            {
                query += " AND locationId IN @LocationId";
                parameters.Add("@LocationId", input.LocationId);
            }
            if (input.RoomId != null)
            {
                query += " AND roomId IN @RoomId";
                parameters.Add("@RoomId", input.RoomId, DbType.Int32);
            }
            if (input.StartDate != null && input.EndDate != null)
            {
                query += " AND startDate BETWEEN @StartDate AND @EndDate";
                parameters.Add("@StartDate", input.StartDate, DbType.String);
                parameters.Add("@EndDate", input.StartDate, DbType.String);
            }

            return MeetingsDataRepository.List(query, parameters);
        }

        public void AddMeeting(MeetingInputDto meeting)
        {
            var query = MeetingsDataRepository.LoadSqlStatement("InsertMeeting.sql");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@LocationId", meeting.LocationId, DbType.Int32);
            parameters.Add("@RoomId", meeting.RoomId, DbType.Int32);
            parameters.Add("@StartDate", meeting.StartDate, DbType.String);
            parameters.Add("@EndDate", meeting.EndDate, DbType.String);
            parameters.Add("@ResponsibleName", meeting.ResponsibleName, DbType.String);
            parameters.Add("@CoffeeQuantity", meeting.CoffeQuantity, DbType.Int16);
            parameters.Add("@Description", meeting.Description, DbType.String);

            MeetingsDataRepository.Execute(query, parameters);
        }

        public void EditMeetingById(
            MeetingUpdateInputDto meeting
        )
        {
            var query = MeetingsDataRepository.LoadSqlStatement("UpdateMeeting.sql");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@MeetingId", meeting.MeetingId, DbType.Int32);
            parameters.Add("@LocationId", meeting.MeetingData.LocationId, DbType.Int32);
            parameters.Add("@RoomId", meeting.MeetingData.RoomId, DbType.Int32);
            parameters.Add("@StartDate", meeting.MeetingData.StartDate, DbType.String);
            parameters.Add("@EndDate", meeting.MeetingData.EndDate, DbType.String);
            parameters.Add("@ResponsibleName", meeting.MeetingData.ResponsibleName, DbType.String);
            parameters.Add("@CoffeeQuantity", meeting.MeetingData.CoffeQuantity, DbType.Int16);
            parameters.Add("@Description", meeting.MeetingData.Description, DbType.String);

            MeetingsDataRepository.Execute(query, parameters);
        }

        public void DeleteMeetingsById(
           IEnumerable<int> meetingIds
        )
        {
            var query = MeetingsDataRepository.LoadSqlStatement("DeleteMeetings.sql");

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@MeetingIds", meetingIds);

            MeetingsDataRepository.Execute(query, parameters);
        }
    }
}