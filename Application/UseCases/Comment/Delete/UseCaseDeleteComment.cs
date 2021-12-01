using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Comment;

namespace Application.UseCases.Comment.Delete
{
    public class UseCaseDeleteComment : IWriting<bool, int>
    {
        private readonly ICommentRepository _commentRepository;

        public UseCaseDeleteComment(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        
        public bool Execute(int data)
        {
            return _commentRepository.Delete(data);
        }
    }
}