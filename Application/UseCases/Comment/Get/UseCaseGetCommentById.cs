using Application.UseCases.Comment.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Comment;

namespace Application.UseCases.Comment.Get
{
    public class UseCaseGetCommentById : IQueryFiltering<OutputDtoComment, int>
    {
        private readonly ICommentRepository _commentRepository;
        
        public UseCaseGetCommentById(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public OutputDtoComment Execute(int filter)
        {
            var comment = _commentRepository.GetById(filter);
            
            return Mapper.GetInstance().Map<OutputDtoComment>(comment);
        }
    }
}