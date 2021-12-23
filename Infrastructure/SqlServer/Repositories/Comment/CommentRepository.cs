using System.Collections.Generic;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Comment
{
    public partial class CommentRepository : ICommentRepository
    {
        private readonly IDomainFactory<Domain.Comment> _commentFactory = new CommentFactory();
        private readonly RequestHelper<Domain.Comment> _requestHelper = new RequestHelper<Domain.Comment>();

        // Get requests
        public List<Domain.Comment> GetByIdUserStory(int idUserStory)
        {
            return _requestHelper.GetByIdHelper(idUserStory, ColIdUserStory, ReqGetByIdUserStory, _commentFactory);
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

            var returnId = (int) command.ExecuteScalar();
            
            command.Connection.Close();
            
            return new Domain.Comment
            {
                Id = returnId,
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