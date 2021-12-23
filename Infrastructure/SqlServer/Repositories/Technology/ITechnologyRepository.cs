using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.Technology
{
    public interface ITechnologyRepository
    {
        // Get Requests
        List<Domain.Technology> GetAll();
        Domain.Technology GetByName(string name);
    }
}