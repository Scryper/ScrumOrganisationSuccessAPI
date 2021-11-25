using Application.UseCases.Comment.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Comment;

namespace Application.UseCases.Comment.Put
{
    public class UseCaseUpdateCommentContent : IWriting<bool, InputDtoUpdateComment>
    {
        private readonly ICommentRepository _commentRepository;

        public UseCaseUpdateCommentContent(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        
        public bool Execute(InputDtoUpdateComment dto)
        {
            return _commentRepository.UpdateContent(dto.Id, dto.InternComment.Content);
        }
    }
}