﻿using System.Collections.Generic;
using System.Data;
using Infrastructure.SqlServer.Utils;
using NotImplementedException = System.NotImplementedException;

namespace Infrastructure.SqlServer.Repositories.UserTechnology
{
    public partial class UserTechnologyRepository : IUserTechnologyRepository
    {
        private readonly IDomainFactory<Domain.UserTechnology> _userTechnologyFactory = new UserTechnologyFactory();

        
        public List<Domain.UserTechnology> GetAll()
        {
            var userTechnologies = new List<Domain.UserTechnology>();

            var command = Database.GetCommand(ReqGetAll);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            // Add all user stories
            while(reader.Read()) userTechnologies.Add(_userTechnologyFactory.CreateFromSqlReader(reader));
            
            return userTechnologies;
        }

        public List<Domain.UserTechnology> GetByUserId(int userId)
        {
            var userTechnologies = new List<Domain.UserTechnology>();
            
            var command = Database.GetCommand(ReqGetByUserId);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColIdUser, userId);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            // Add all user stories
            while(reader.Read()) userTechnologies.Add(_userTechnologyFactory.CreateFromSqlReader(reader));
            
            return userTechnologies;
        }

        public List<Domain.UserTechnology> getByTechnologyId(int technologyId)
        {
            var userTechnologies = new List<Domain.UserTechnology>();
            
            var command = Database.GetCommand(ReqGetByTechnology);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColIdUser, technologyId);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            // Add all user stories
            while(reader.Read()) userTechnologies.Add(_userTechnologyFactory.CreateFromSqlReader(reader));
            
            return userTechnologies;
        }

        public Domain.UserTechnology Create(Domain.UserTechnology userTechnology)
        {
            var command = Database.GetCommand(ReqCreate);

            command.Parameters.AddWithValue("@" + ColIdUser, userTechnology.IdUser);
            command.Parameters.AddWithValue("@" + ColIdTechnology, userTechnology.IdTechnology);

            command.ExecuteNonQuery();
            
            return new Domain.UserTechnology
            {
                IdTechnology = userTechnology.IdTechnology,
                IdUser = userTechnology.IdUser
            };
        }

        public bool Delete(int idUser, int idTechnology)
        {
            var command = Database.GetCommand(ReqDelete);

            command.Parameters.AddWithValue("@" + ColIdUser, idUser);
            command.Parameters.AddWithValue("@" + ColIdTechnology, idTechnology);

            return command.ExecuteNonQuery() > 0;
        }
    }
}