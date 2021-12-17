using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Comment
{
    public partial class CommentRepository : ICommentRepository
    {
        private readonly IDomainFactory<Domain.Comment> _commentFactory = new CommentFactory();

        // Get requests
        public List<Domain.Comment> GetAll()
        {
            var comments = new List<Domain.Comment>();
            
            var command = Database.GetCommand(ReqGetAll);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            // Add all comments
            while(reader.Read()) comments.Add(_commentFactory.CreateFromSqlReader(reader));
            
            command.Connection.Close();
            
            return comments;
        }

        public List<Domain.Comment> GetByIdUserStory(int idUserStory)
        {
            var comments = new List<Domain.Comment>();
            
            var command = Database.GetCommand(ReqGetByIdUserStory);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColIdUserStory, idUserStory);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            // Add all comments
            while(reader.Read()) comments.Add(_commentFactory.CreateFromSqlReader(reader));
            
            command.Connection.Close();
            
            return comments;
        }

        public Domain.Comment GetById(int id)
        {
            var command = Database.GetCommand(ReqGetById);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColId, id);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            var returnData = reader.Read() ? _commentFactory.CreateFromSqlReader(reader) : null;
            
            command.Connection.Close();
            
            // Return the comment if found, null if not
            return returnData ;
        }

        // Post requests
        public Domain.Comment Create(Domain.Comment comment)
        {
            var command = Database.GetCommand(ReqCreate);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColIdUserStory, comment.IdUserStory);
            command.Parameters.AddWithValue("@" + ColIdUser, comment.IdUser);
            command.Parameters.AddWithValue("@" + ColPostedAt, comment.PostedAt);
            command.Parameters.AddWithValue("@" + ColContent, comment.Content);

            int returnID = (int)command.ExecuteScalar();
            
            command.Connection.Close();
            
            return new Domain.Comment
            {
                Id = returnID,
                IdUserStory = comment.IdUserStory,
                IdUser = comment.IdUser,
                PostedAt = comment.PostedAt,
                Content = comment.Content
            };
        }

        // Put requests
        public bool UpdateContent(int id, string newComment)
        {
            var command = Database.GetCommand(ReqUpdateContent);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + ColContent, newComment);
            command.Parameters.AddWithValue("@" + ColId, id);

            return command.ExecuteNonQuery() > 0; // Non-query because we don't ask for data
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