﻿using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.Project
{
    public interface IProjectRepository
    {
        // Get requests
        List<Domain.Project> GetAll();
        Domain.Project GetById(int id);
        Domain.Project GetByName(string name);
        List<Domain.Project> GetActiveProject(int idUser);

        // Post requests
        Domain.Project Create(Domain.Project project);
        
        // Put requests
        bool UpdateRepositoryUrl(int id, string newRepositoryUrl);
        
        bool UpdateStatus(int id, int state);

        // Delete requests
        bool Delete(int id);
    }
}