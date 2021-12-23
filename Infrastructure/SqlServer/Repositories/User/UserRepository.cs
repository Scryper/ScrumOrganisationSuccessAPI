using System.Collections.Generic;
using System.Data;
using System.Linq;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.User
{
    public partial class UserRepository : IUserRepository
    {
        private readonly IDomainFactory<Domain.User> _userFactory = new UserFactory();
        private readonly RequestHelper<Domain.User> _requestHelper = new RequestHelper<Domain.User>();
        
        // Get requests
        public List<Domain.User> GetAll()
        {
            return _requestHelper.GetAll(ReqGetAll, _userFactory);
        }

        public List<Domain.User> GetByIdProject(int idProject)
        {
            return _requestHelper.GetByIdHelper(idProject, ColId, ReqGetByIdProject, _userFactory);
        }

        public List<Domain.User> GetByIdProjectIsWorking(int idProject)
        {
            return _requestHelper.GetByIdHelper(idProject, ColId, ReqGetByIdProjectIsWorking, _userFactory);
        }

        public List<Domain.User> GetByIdMeeting(int idMeeting)
        {
            return _requestHelper.GetByIdHelper(idMeeting, ColId, ReqGetByIdMeeting, _userFactory);
        }

        public List<Domain.User> GetUserByCommentOnUserStory(int idUserStory)
        {
            return _requestHelper.GetByIdHelper(idUserStory, ColIdUserStory, ReqGetUserByCommentOnUserStory, _userFactory);
        }

        public List<Domain.User> GetByIdProjectIsApplying(int idProject)
        {
            return _requestHelper.GetByIdHelper(idProject, ColId, ReqGetUserApplyingByIdProject, _userFactory);
        }
        
        public Domain.User GetById(int id)
        {
            return _requestHelper.GetById(id, ColId, ReqGetById, _userFactory);
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