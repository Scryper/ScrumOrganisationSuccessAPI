using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Meeting
{
    public partial class MeetingRepository : IMeetingRepository
    {
        private readonly IDomainFactory<Domain.Meeting> _meetingFactory = new MeetingFactory();

        // Get requests
        public List<Domain.Meeting> GetAll()
        {
            var comments = new List<Domain.Meeting>();
            
            var command = Database.GetCommand(ReqGetAll);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            // Add all comments
            while(reader.Read()) comments.Add(_meetingFactory.CreateFromSqlReader(reader));

            return comments;
        }
        
        public Domain.Meeting GetById(int id)
        {
            var command = Database.GetCommand(ReqGetById);

            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColId, id);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            // Return the meeting if found, null if not
            return reader.Read() ? _meetingFactory.CreateFromSqlReader(reader) : null;
        }

        // Utils for GetByIdUser and GetByIdSprint
        // Both return a list of meetings, the only changing parameters are the request and the column on which 
        // the request base its verification
        private List<Domain.Meeting> GetByIdHelper(int id, string column, string request)
        {
            var meetings = new List<Domain.Meeting>();

            var command = Database.GetCommand(request);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + column, id);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            // Add all meetings
            while(reader.Read()) meetings.Add(_meetingFactory.CreateFromSqlReader(reader));

            return meetings;
        }

        public List<Domain.Meeting> GetByIdUser(int idUser)
        {
            return GetByIdHelper(idUser, ColId, ReqGetByIdUser);
        }

        public List<Domain.Meeting> GetByIdSprint(int idSprint)
        {
            return GetByIdHelper(idSprint, ColIdSprint, ReqGetByIdSprint);
        }

        // Post requests
        public Domain.Meeting Create(Domain.Meeting meeting)
        {
            if (Exists(meeting)) return null; // Avoid duplication
            
            var command = Database.GetCommand(ReqCreate);

            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColIdSprint, meeting.IdSprint);
            command.Parameters.AddWithValue("@" + ColSchedule, meeting.Schedule);
            command.Parameters.AddWithValue("@" + ColDescription, meeting.Description);
            command.Parameters.AddWithValue("@" + ColUrl, meeting.MeetingUrl);

            return new Domain.Meeting
            {
                Id = (int) command.ExecuteScalar(),
                IdSprint = meeting.IdSprint,
                Schedule = meeting.Schedule,
                Description = meeting.Description,
                MeetingUrl = meeting.MeetingUrl
            };
        }
        
        // Utils for post request
        private bool Exists(Domain.Meeting meeting)
        {
            var meetings = GetAll();

            return Enumerable.Contains(meetings, meeting); // Verify if the meeting already exists in database
        }

        // Put requests
        public bool UpdateSchedule(int id, DateTime newSchedule)
        {
            var command = Database.GetCommand(ReqUpdateSchedule);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColId, id);
            command.Parameters.AddWithValue("@" + ColSchedule, newSchedule);

            return command.ExecuteNonQuery() > 0;
        }

        // Delete requests
        public bool Delete(int id)
        {
            var command = Database.GetCommand(ReqDeleteById);

            command.Parameters.AddWithValue("@" + ColId, id);

            return command.ExecuteNonQuery() > 0;
        }
    }
}