using Application.UseCases.Comment.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Comment;

namespace Application.UseCases.Comment.Put
{
    public class UseCaseUpdateCommentContent : IWriting<bool, InputDtoUpdateCommentContent>
    {
        private readonly ICommentRepository _commentRepository;

        public UseCaseUpdateCommentContent(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        
        public bool Execute(InputDtoUpdateCommentContent dto)
        {
            return _commentRepository.UpdateContent(dto.Id, dto.InternComment.Content);
        }
    }
}