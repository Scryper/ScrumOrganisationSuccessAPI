﻿using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.UserTechnology
{
    public interface IUserTechnologyRepository
    {
        // Get Requests
        List<Domain.UserTechnology> GetAll();

        List<Domain.UserTechnology> GetByUserId(int userId);

        List<Domain.UserTechnology> GetByTechnologyId(int technologyId);

        
        // Post Requests
        Domain.UserTechnology Create(Domain.UserTechnology userTechnology);
        
        // Delete Requests
       bool Delete(int idUser, int idTechnology);
    }
}