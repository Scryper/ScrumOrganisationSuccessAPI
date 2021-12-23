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

        public List<Domain.Meeting> GetByIdUser(int idUser)
        {
            var meetings = new List<Domain.Meeting>();

            var command = Database.GetCommand(ReqGetByIdUser);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColId, idUser);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            // Add all meetings
            while(reader.Read()) meetings.Add(_meetingFactory.CreateFromSqlReader(reader));

            return meetings;
        }

        // TODO : factorisation with get by id user
        public List<Domain.Meeting> GetByIdSprint(int idSprint)
        {
            var meetings = new List<Domain.Meeting>();
            
            var command = Database.GetCommand(ReqGetByIdSprint);

            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColIdSprint, idSprint);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            // Add all meetings
            while(reader.Read()) meetings.Add(_meetingFactory.CreateFromSqlReader(reader));

            return meetings;
        }

        // Post requests
        public Domain.Meeting Create(Domain.Meeting meeting)
        {
            if (Exists(meeting)) return null;
            
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

            return Enumerable.Contains(meetings, meeting);
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