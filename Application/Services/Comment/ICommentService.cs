using System.Collections.Generic;

namespace Application.Services.Comment
{
    public interface ICommentService
    {
        Domain.Comment GetCommentById(int id);
        List<Domain.Comment> GetCommentsByIdUserStory(int idUserStory);
    }
}