using System.Collections.Generic;
using Application.UseCases.Comment.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Comment;

namespace Application.UseCases.Comment.Get
{
    public class UseCaseGetCommentsByIdUserStory : IQueryFiltering<List<OutputDtoComment>, int>
    {
        private readonly ICommentRepository _commentRepository;

        public UseCaseGetCommentsByIdUserStory(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        
        public List<OutputDtoComment> Execute(int filter)
        {
            var comments = _commentRepository.GetByIdUserStory(filter);

            return Mapper.GetInstance().Map<List<OutputDtoComment>>(comments);
        }
    }
}