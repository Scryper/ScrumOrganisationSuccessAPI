using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.Comment
{
    public interface ICommentRepository
    {
        // Get requests
        List<Domain.Comment> GetByIdUserStory(int idUserStory);
        
        // Post requests
        Domain.Comment Create(Domain.Comment comment);
        
        // Put requests
        bool UpdateContent(int id, string content);

        // Delete requests
        bool Delete(int id);
    }
}