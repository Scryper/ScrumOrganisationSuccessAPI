using Application.UseCases.Comment.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Comment;

namespace Application.UseCases.Comment.Post
{
    public class UseCaseCreateComment : IWriting<OutputDtoComment, InputDtoComment>
    {
        private readonly ICommentRepository _commentRepository;

        public UseCaseCreateComment(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        
        public OutputDtoComment Execute(InputDtoComment dto)
        {
            var commentFromDto = Mapper.GetInstance().Map<Domain.Comment>(dto);
            
            var comment = _commentRepository.Create(commentFromDto);
            
            return Mapper.GetInstance().Map<OutputDtoComment>(comment);
        }
    }
}