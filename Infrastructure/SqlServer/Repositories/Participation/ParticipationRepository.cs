using System.Collections.Generic;
using System.Linq;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Participation
{
    public partial class ParticipationRepository : IParticipationRepository
    {

        private readonly IDomainFactory<Domain.Participation> _participationFactory = new ParticipationFactory();
        private readonly RequestHelper<Domain.Participation> _requestHelper = new RequestHelper<Domain.Participation>();
        
        // Get requests
        public List<Domain.Participation> GetAll()
        {
            return _requestHelper.GetAll(ReqGetAll, _participationFactory);
        }

        public List<Domain.Participation> GetByIdUser(int idUser)
        {
            return _requestHelper.GetByIdHelper(idUser, ColIdUser, ReqGetByIdUser, _participationFactory);
        }

        public List<Domain.Participation> GetByIdMeeting(int idMeeting)
        {
            return _requestHelper.GetByIdHelper(idMeeting, ColIdMeeting, ReqGetByIdMeeting, _participationFactory);
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
    }
}