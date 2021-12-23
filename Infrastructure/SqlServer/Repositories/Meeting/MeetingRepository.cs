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
        private readonly RequestHelper<Domain.Meeting> _requestHelper = new RequestHelper<Domain.Meeting>();

        // Get requests
        public List<Domain.Meeting> GetAll()
        {
            return _requestHelper.GetAll(ReqGetAll, _meetingFactory);
        }
        
        public Domain.Meeting GetById(int id)
        {
            return _requestHelper.GetById(id, ColId, ReqGetById, _meetingFactory);
        }

        public List<Domain.Meeting> GetByIdUser(int idUser)
        {
            return _requestHelper.GetByIdHelper(idUser, ColId, ReqGetByIdUser, _meetingFactory);
        }

        public List<Domain.Meeting> GetByIdSprint(int idSprint)
        {
            return _requestHelper.GetByIdHelper(idSprint, ColIdSprint, ReqGetByIdSprint, _meetingFactory);
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