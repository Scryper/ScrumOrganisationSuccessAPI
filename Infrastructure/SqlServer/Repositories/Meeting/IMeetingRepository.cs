using System;
using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.Meeting
{
    public interface IMeetingRepository
    {
        // Get requests
        List<Domain.Meeting> GetAll();
        List<Domain.Meeting> GetByIdUser(int idUser);
        
        // Post requests
        Domain.Meeting Create(Domain.Meeting meeting);
    }
}