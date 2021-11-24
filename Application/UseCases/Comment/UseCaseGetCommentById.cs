using Application.UseCases.Comment.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Comment;

namespace Application.UseCases.Comment
{
    public class UseCaseGetCommentById : IQuery<OutputDtoComment>
    {
        private readonly ICommentRepository _commentRepository;
        
        public UseCaseGetCommentById(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        
        public OutputDtoComment Execute()
        {
            var comment = _commentRepository.GetById();
            
            return Mapper.GetInstance().Map<OutputDtoComment>(comment);
        }
    }
}