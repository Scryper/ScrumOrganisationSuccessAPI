using System;
using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.Meeting
{
    public interface IMeetingRepository
    {
        // Get requests
        List<Domain.Meeting> GetAll();
        List<Domain.Meeting> GetByIdSprint(int idSprint);
        List<Domain.Meeting> GetByIdUser(int idUser);
        Domain.Meeting GetById(int id);
        
        // Post requests
        Domain.Meeting Create(Domain.Meeting meeting);
        
        // Put requests
        bool UpdateSchedule(int id, DateTime newSchedule);

        // Delete requests
        bool Delete(int id);
    }
}