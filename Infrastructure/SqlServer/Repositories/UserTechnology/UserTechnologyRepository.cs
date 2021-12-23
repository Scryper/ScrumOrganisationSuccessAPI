using System.Collections.Generic;
using System.Data;
using System.Linq;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.UserTechnology
{
    public partial class UserTechnologyRepository : IUserTechnologyRepository
    {
        private readonly IDomainFactory<Domain.UserTechnology> _userTechnologyFactory = new UserTechnologyFactory();
        private readonly RequestHelper<Domain.UserTechnology> _requestHelper = new RequestHelper<Domain.UserTechnology>();
        
        // Get requests
        public List<Domain.UserTechnology> GetAll()
        {
            return _requestHelper.GetAll(ReqGetAll, _userTechnologyFactory);
        }

        public List<Domain.UserTechnology> GetByIdUser(int idUser)
        {
            return _requestHelper.GetByIdHelper(idUser, ColIdUser, ReqGetByUserId, _userTechnologyFactory);
        }

        public List<Domain.UserTechnology> GetByIdTechnology(int idTechnology)
        {
            return _requestHelper.GetByIdHelper(idTechnology, ColIdTechnology, ReqGetByTechnology, _userTechnologyFactory);
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