using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.Participation
{
    public interface IParticipationRepository
    {
        // Get Requests
        List<Domain.Participation> GetAll();

        List<Domain.Participation> GetByIdUser(int userId);

        List<Domain.Participation> GetByIdMeeting(int meetingId);

        
        // Post Requests
        Domain.Participation Create(Domain.Participation participation);
    }
}