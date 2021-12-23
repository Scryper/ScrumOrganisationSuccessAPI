using System.Collections.Generic;
using System.Data;
using System.Linq;
using Infrastructure.SqlServer.Utils;
using NotImplementedException = System.NotImplementedException;

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
            command.Parameters.AddWithValue("@" + ColId, idProject);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            // Add all users
            while(reader.Read()) users.Add(_userFactory.CreateFromSqlReader(reader));

            return users;
        }

        public List<Domain.User> GetByIdProjectIsWorking(int idProject)
        {
            var users = new List<Domain.User>();

            var command = Database.GetCommand(ReqGetByIdProjectIsWorking);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColId, idProject);

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
            command.Parameters.AddWithValue("@" + ColId, idMeeting);

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

        public List<Domain.User> GetByIdProjectIsApplying(int idProject)
        {
            var users = new List<Domain.User>();

            var command = Database.GetCommand(ReqGetUserApplyingByIdProject);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColId, idProject);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            // Add all users
            while(reader.Read()) users.Add(_userFactory.CreateFromSqlReader(reader));

            return users;
        }

        // Post requests
        public Domain.User Create(Domain.User user)
        {
            if (Exists(user)) return null;
            
            var command = Database.GetCommand(ReqCreate);
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);

            command.Parameters.AddWithValue("@" + ColFirstName, user.Firstname);
            command.Parameters.AddWithValue("@" + ColLastName, user.Lastname);
            command.Parameters.AddWithValue("@" + ColPassword, hashedPassword);
            command.Parameters.AddWithValue("@" + ColEmail, user.Email);
            command.Parameters.AddWithValue("@" + ColRole, user.Role);
            command.Parameters.AddWithValue("@" + ColBirthdate, user.Birthdate);

            return new Domain.User
            {
                Id = (int) command.ExecuteScalar(),
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Password = hashedPassword,
                Email = user.Email,
                Role = user.Role,
                Birthdate = user.Birthdate
            };
        }
        
        // Utils for post requests
        private bool Exists(Domain.User user)
        {
            var users = GetAll();
            return Enumerable.Contains(users, user);
        }

        // Put requests
        // TODO : factorisation
        public bool UpdateRole(int id, int newRole)
        {
            var command = Database.GetCommand(ReqUpdateRole);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColId, id);
            command.Parameters.AddWithValue("@" + ColRole, newRole);

            return command.ExecuteNonQuery() > 0;
        }

        // TODO : factorisation
        public bool UpdatePassword(int id, string newPassword)
        {
            var command = Database.GetCommand(ReqUpdatePassword);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColId, id);
            command.Parameters.AddWithValue("@" + ColPassword, newPassword);

            return command.ExecuteNonQuery() > 0;
        }

        // TODO : factorisation
        public bool UpdateEmail(int id, string newEmail)
        {
            var command = Database.GetCommand(ReqUpdateEmail);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColId, id);
            command.Parameters.AddWithValue("@" + ColEmail, newEmail);

            return command.ExecuteNonQuery() > 0;
        }

        public bool UpdateFirstNameLastName(int id, string firstname, string lastname)
        {
            var command = Database.GetCommand(ReqUpdateFirstNameLastName);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColId, id);
            command.Parameters.AddWithValue("@" + ColFirstName, firstname);
            command.Parameters.AddWithValue("@" + ColLastName, lastname);

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