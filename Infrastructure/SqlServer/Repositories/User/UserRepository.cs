using System.Collections.Generic;
using System.Data;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.User
{
    public partial class UserRepository : IUserRepository
    {
        private readonly IDomainFactory<Domain.User> _userFactory = new UserFactory();
        
        // Get requests
        public List<Domain.User> GetAll()
        {
            var users = new List<Domain.User>();

            var command = Database.GetCommand(ReqGetAll);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            // Add all users
            while(reader.Read()) users.Add(_userFactory.CreateFromSqlReader(reader));

            return users;
        }

        // TODO : factorisation
        public List<Domain.User> GetByIdProject(int idProject)
        {
            var users = new List<Domain.User>();

            var command = Database.GetCommand(ReqGetByIdProject);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ProjectColId, idProject);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            // Add all users
            while(reader.Read()) users.Add(_userFactory.CreateFromSqlReader(reader));

            return users;
        }

        // TODO : factorisation
        public List<Domain.User> GetByIdMeeting(int idMeeting)
        {
            var users = new List<Domain.User>();

            var command = Database.GetCommand(ReqGetByIdMeeting);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + MeetingColId, idMeeting);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            // Add all users
            while(reader.Read()) users.Add(_userFactory.CreateFromSqlReader(reader));

            return users;
        }

        public Domain.User GetById(int id)
        {
            var command = Database.GetCommand(ReqGetById);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColId, id);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            // Return user if found, null if not
            return reader.Read() ? _userFactory.CreateFromSqlReader(reader) : null;
        }

        public Domain.User GetByEmail(string email)
        {
            var command = Database.GetCommand(ReqByEmail);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColEmail, email);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            // Return user if found, null if not
            return reader.Read() ? _userFactory.CreateFromSqlReader(reader) : null;
        }

        // Post requests
        public Domain.User Create(Domain.User user)
        {
            var command = Database.GetCommand(ReqCreate);

            command.Parameters.AddWithValue("@" + ColPseudo, user.Pseudo);
            command.Parameters.AddWithValue("@" + ColPassword, user.Password);
            command.Parameters.AddWithValue("@" + ColEmail, user.Email);
            command.Parameters.AddWithValue("@" + ColRole, user.Role);

            return new Domain.User
            {
                Id = (int) command.ExecuteScalar(),
                Pseudo = user.Pseudo,
                Password = user.Password,
                Email = user.Email,
                Role = user.Role
            };
        }

        // Put requests
        // TODO : factorisation
        public bool UpdateRole(int id, Domain.User newUser)
        {
            var command = Database.GetCommand(ReqUpdateRole);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColId, id);
            command.Parameters.AddWithValue("@" + ColRole, newUser.Role);

            return command.ExecuteNonQuery() > 0;
        }

        // TODO : factorisation
        public bool UpdatePassword(int id, Domain.User newUser)
        {
            var command = Database.GetCommand(ReqUpdatePassword);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColId, id);
            command.Parameters.AddWithValue("@" + ColPassword, newUser.Password);

            return command.ExecuteNonQuery() > 0;
        }

        // TODO : factorisation
        public bool UpdateEmail(int id, Domain.User newUser)
        {
            var command = Database.GetCommand(ReqUpdateEmail);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColId, id);
            command.Parameters.AddWithValue("@" + ColEmail, newUser.Email);

            return command.ExecuteNonQuery() > 0;
        }

        // TODO : factorisation
        public bool UpdatePseudo(int id, Domain.User newUser)
        {
            var command = Database.GetCommand(ReqUpdatePseudo);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColId, id);
            command.Parameters.AddWithValue("@" + ColPseudo, newUser.Pseudo);

            return command.ExecuteNonQuery() > 0;
        }

        // Delete requests
        public bool Delete(int id)
        {
            var command = Database.GetCommand(ReqDeleteById);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColId, id);

            return command.ExecuteNonQuery() > 0;
        }
    }
}