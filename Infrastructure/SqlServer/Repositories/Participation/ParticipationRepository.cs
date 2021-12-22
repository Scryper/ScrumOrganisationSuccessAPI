using System.Collections.Generic;
using System.Data;
using System.Linq;
using Infrastructure.SqlServer.Utils;
using NotImplementedException = System.NotImplementedException;

namespace Infrastructure.SqlServer.Repositories.Participation
{
    public partial class ParticipationRepository : IParticipationRepository
    {

        private readonly IDomainFactory<Domain.Participation> _participationFactory = new ParticipationFactory();
        
        // Get requests
        public List<Domain.Participation> GetAll()
        {
            var participations = new List<Domain.Participation>();

            var command = Database.GetCommand(ReqGetAll);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) participations.Add(_participationFactory.CreateFromSqlReader(reader));
            
            return participations;
        }

        public List<Domain.Participation> GetByUserId(int userId)
        {
            var participations = new List<Domain.Participation>();
            
            var command = Database.GetCommand(ReqGetByUserId);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColIdUser, userId);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) participations.Add(_participationFactory.CreateFromSqlReader(reader));
            
            return participations;
        }

        public List<Domain.Participation> GetByMeetingId(int meetingId)
        {
            var participations = new List<Domain.Participation>();
            
            var command = Database.GetCommand(ReqGetByMeetingId);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColIdMeeting, meetingId);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) participations.Add(_participationFactory.CreateFromSqlReader(reader));
            
            return participations;
        }

        // Post requests
        public Domain.Participation Create(Domain.Participation participation)
        {
            if (Exists(participation)) return null;
            
            var command = Database.GetCommand(ReqCreate);

            command.Parameters.AddWithValue("@" + ColIdUser, participation.IdUser);
            command.Parameters.AddWithValue("@" + ColIdMeeting, participation.IdMeeting);

            command.ExecuteNonQuery();
            
            return new Domain.Participation
            {
                IdMeeting = participation.IdMeeting,
                IdUser = participation.IdUser
            };
        }
        
        // Utils for post request
        private bool Exists(Domain.Participation participation)
        {
            var participations = GetAll();

            return Enumerable.Contains(participations, participation);
        }

        // Delete request
        public bool Delete(int idUser, int idMeeting)
        {
            var command = Database.GetCommand(ReqDelete);

            command.Parameters.AddWithValue("@" + ColIdUser, idUser);
            command.Parameters.AddWithValue("@" + ColIdMeeting, idMeeting);

            return command.ExecuteNonQuery() > 0;
        }
    }
}