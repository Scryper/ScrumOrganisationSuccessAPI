using System.Collections.Generic;
using System.Data;
using System.Linq;
using Infrastructure.SqlServer.Utils;
using NotImplementedException = System.NotImplementedException;

namespace Infrastructure.SqlServer.Repositories.UserTechnology
{
    public partial class UserTechnologyRepository : IUserTechnologyRepository
    {
        private readonly IDomainFactory<Domain.UserTechnology> _userTechnologyFactory = new UserTechnologyFactory();
        
        // Get requests
        public List<Domain.UserTechnology> GetAll()
        {
            var userTechnologies = new List<Domain.UserTechnology>();

            var command = Database.GetCommand(ReqGetAll);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) userTechnologies.Add(_userTechnologyFactory.CreateFromSqlReader(reader));
            
            return userTechnologies;
        }
        
        // Utils for GetByIdUser, GetByIdTechnology
        // Both return a list of user technologies, the only changing parameters are the request and the column on which 
        // the request base its verification
        private List<Domain.UserTechnology> GetByIdHelper(int id, string column, string request)
        {
            var userTechnologies = new List<Domain.UserTechnology>();
            
            var command = Database.GetCommand(request);
            
            command.Parameters.AddWithValue("@" + column, id);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) userTechnologies.Add(_userTechnologyFactory.CreateFromSqlReader(reader));
            
            return userTechnologies;
        }

        public List<Domain.UserTechnology> GetByIdUser(int idUser)
        {
            return GetByIdHelper(idUser, ColIdUser, ReqGetByUserId);
        }

        public List<Domain.UserTechnology> GetByIdTechnology(int idTechnology)
        {
            return GetByIdHelper(idTechnology, ColIdTechnology, ReqGetByTechnology);
        }

        public List<Domain.UserTechnology> GetByIdTechnologyIdUser(int idTechnology, int idUser)
        {
            var userTechnologies = new List<Domain.UserTechnology>();
            
            var command = Database.GetCommand(ReqGetByIdTechnologyIdUser);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColIdTechnology, idTechnology);
            command.Parameters.AddWithValue("@" + ColIdUser, idUser);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            // Add all user stories
            while(reader.Read()) userTechnologies.Add(_userTechnologyFactory.CreateFromSqlReader(reader));
            
            return userTechnologies;
        }

        // Post requests
        public Domain.UserTechnology Create(Domain.UserTechnology userTechnology)
        {
            if (Exists(userTechnology)) return null;
            
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
        
        // Utils for post requests
        private bool Exists(Domain.UserTechnology userTechnology)
        {
            var userTechnologies = GetAll();
            return Enumerable.Contains(userTechnologies, userTechnology);
        }

        // Delete requests
        public bool Delete(int idUser, int idTechnology)
        {
            var command = Database.GetCommand(ReqDelete);

            command.Parameters.AddWithValue("@" + ColIdUser, idUser);
            command.Parameters.AddWithValue("@" + ColIdTechnology, idTechnology);

            return command.ExecuteNonQuery() > 0;
        }
    }
}