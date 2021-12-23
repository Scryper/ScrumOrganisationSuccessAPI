using System.Collections.Generic;
using Application.UseCases.Comment;
using Application.UseCases.Comment.Delete;
using Application.UseCases.Comment.Dtos;
using Application.UseCases.Comment.Get;
using Application.UseCases.Comment.Post;
using Application.UseCases.Comment.Put;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Security.Attributes;

/*
 * The controllers calls the usecases which calls the repositories
 * This allows to respect the architecture of the project and its different layers :
 * API -> Application -> Infrastructure -> Domain
 */
namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/comments")]
    public class CommentController : ControllerBase
    {
        // Use cases
        private readonly UseCaseGetCommentsByIdUserStory _useCaseGetCommentsByIdUserStory;
        
        private readonly UseCaseCreateComment _useCaseCreateComment;

        private readonly UseCaseUpdateCommentContent _useCaseUpdateCommentContent;

        private readonly UseCaseDeleteComment _useCaseDeleteComment;

        // Constructor
        public CommentController(
            UseCaseGetCommentsByIdUserStory useCaseGetCommentsByIdUserStory,
            UseCaseCreateComment useCaseCreateComment,
            UseCaseUpdateCommentContent useCaseUpdateCommentContent,
            UseCaseDeleteComment useCaseDeleteComment)
        {
            _useCaseGetCommentsByIdUserStory = useCaseGetCommentsByIdUserStory;
            
            _useCaseCreateComment = useCaseCreateComment;
            
            _useCaseUpdateCommentContent = useCaseUpdateCommentContent;
            
            _useCaseDeleteComment = useCaseDeleteComment;
        }

        // Get requests
        // If routes would only have {id:int}, even if the name would change, the url would be for both :
        // swagger/data/xxx -> so multiple endpoints matches
        [HttpGet]
        [Route("byUserStory/{idUserStory:int}")]
        [Authorize(true, true, true)]
        public ActionResult<List<OutputDtoComment>> GetByIdUserStory(int idUserStory)
        {
            return _useCaseGetCommentsByIdUserStory.Execute(idUserStory);
        }

        // Post requests
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [Authorize(true, true, true)]
        public ActionResult<OutputDtoComment> Create([FromBody] InputDtoComment inputDtoComment)
        {
            return StatusCode(201, _useCaseCreateComment.Execute(inputDtoComment));
        }

        // Put requests
        [HttpPut]
        [Route("{id:int}")]
        [Authorize(true, true, true)]
        public ActionResult UpdateContent(int id, InputDtoComment newComment)
        {
            var inputDtoUpdate = new InputDtoUpdateCommentContent
            {
                Id = id,
                InternComment = new InputDtoUpdateCommentContent.Comment
                {
                    Content = newComment.Content
                }
            };
            var result = _useCaseUpdateCommentContent.Execute(inputDtoUpdate);

            if (result) return Ok();
            return BadRequest();
        }

        //  Delete requests
        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(true, true, true)]
        public ActionResult Delete(int id)
        {
            var result = _useCaseDeleteComment.Execute(id);

            if (result) return Ok();
            return NotFound();
        }
    }
}