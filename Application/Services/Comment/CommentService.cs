using System.Collections.Generic;
using Infrastructure.SqlServer.Repositories.Comment;

namespace Application.Services.Comment
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public Domain.Comment GetCommentById(int id)
        {
            return _commentRepository.GetById(id);
        }

        public List<Domain.Comment> GetCommentsByIdUserStory(int idUserStory)
        {
            return _commentRepository.GetByIdUserStory(idUserStory);
        }
    }
}