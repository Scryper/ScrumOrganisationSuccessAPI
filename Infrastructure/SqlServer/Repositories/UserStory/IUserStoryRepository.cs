﻿using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.UserStory
{
    public interface IUserStoryRepository
    {
        // Get requests
        List<Domain.UserStory> GetAll();
        List<Domain.UserStory> GetByIdSprint(int idSprint);
        List<Domain.UserStory> GetByIdProject(int idProject);
        Domain.UserStory GetById(int id);
        
        // Post requests
        Domain.UserStory Create(Domain.UserStory userStory);
        
        // Put requests
        bool UpdateIsDone(int id, Domain.UserStory newUserStory);
        
        // Delete requests
        bool Delete(int id);
    }
}