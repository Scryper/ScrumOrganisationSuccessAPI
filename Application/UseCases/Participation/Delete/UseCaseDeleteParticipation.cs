using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Participation;

namespace Application.UseCases.Participation.Delete
{
    public class UseCaseDeleteParticipation : IWritingMultipleKeys<bool,int,int>
    {
        private readonly IParticipationRepository _participationRepository;

        public UseCaseDeleteParticipation(IParticipationRepository participationRepository)
        {
            _participationRepository = participationRepository;
        }
        
        public bool Execute(int idUser, int idMeeting)
        {
            return _participationRepository.Delete(idUser, idMeeting);
        }
    }
}