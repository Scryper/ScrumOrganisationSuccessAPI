using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.Participation
{
    public interface IParticipationRepository
    {
        // Get Requests
        List<Domain.Participation> GetAll();

        List<Domain.Participation> GetByUserId(int userId);

        List<Domain.Participation> GetByMeetingId(int meetingId);

        
        // Post Requests
        Domain.Participation Create(Domain.Participation participation);
        
        // Delete Requests
        bool Delete(int idUser, int idMeeting);
    }
}