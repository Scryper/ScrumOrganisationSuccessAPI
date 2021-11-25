using System;
using System.Collections.Generic;
using Application.UseCases.Comment;
using Application.UseCases.Comment.Delete;
using Application.UseCases.Comment.Dtos;
using Application.UseCases.Comment.Get;
using Application.UseCases.Comment.Put;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/comments")]
    public class CommentController : ControllerBase
    {
        // Use cases
        private readonly UseCaseGetAllComments _useCaseGetAllComments;
        private readonly UseCaseGetCommentById _useCaseGetCommentById;
        private readonly UseCaseGetCommentsByIdUserStory _useCaseGetCommentsByIdUserStory;
        
        private readonly UseCaseCreateComment _useCaseCreateComment;

        private readonly UseCaseUpdateContentOfComment _useCaseUpdateContentOfComment;

        private readonly UseCaseDeleteComment _useCaseDeleteComment;

        // Constructor
        public CommentController(
            UseCaseGetAllComments useCaseGetAllComments,
            UseCaseGetCommentById useCaseGetCommentById,
            UseCaseGetCommentsByIdUserStory useCaseGetCommentsByIdUserStory,
            UseCaseCreateComment useCaseCreateComment,
            UseCaseUpdateContentOfComment useCaseUpdateContentOfComment,
            UseCaseDeleteComment useCaseDeleteComment)
        {
            _useCaseGetAllComments = useCaseGetAllComments;
            _useCaseGetCommentById = useCaseGetCommentById;
            _useCaseGetCommentsByIdUserStory = useCaseGetCommentsByIdUserStory;
            
            _useCaseCreateComment = useCaseCreateComment;
            
            _useCaseUpdateContentOfComment = useCaseUpdateContentOfComment;
            
            _useCaseDeleteComment = useCaseDeleteComment;
        }

        // Get requests
        [HttpGet]
        public ActionResult<List<OutputDtoComment>> GetAll()
        {
            return _useCaseGetAllComments.Execute();
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<OutputDtoComment> GetById(int id)
        {
            return _useCaseGetCommentById.Execute(id);
        }
        
        [HttpGet]
        [Route("{idUserStory:int}")]
        public ActionResult<List<OutputDtoComment>> GetByIdUserStory(int idUserStory)
        {
            return _useCaseGetCommentsByIdUserStory.Execute(idUserStory);
        }

        // Post requests
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<OutputDtoComment> Create([FromBody] InputDtoComment inputDtoComment)
        {
            return StatusCode(201, _useCaseCreateComment.Execute(inputDtoComment));
        }

        // Put requests
        [HttpPut]
        [Route("{id:int}")]
        public ActionResult UpdateContent(int id, InputDtoComment newComment)
        {
            var inputDtoUpdate = new InputDtoUpdateComment
            {
                Id = id,
                InternComment = new InputDtoUpdateComment.Comment
                {
                    Content = newComment.Content
                }
            };
            var result = _useCaseUpdateContentOfComment.Execute(inputDtoUpdate);

            if (result) return Ok();
            return BadRequest();
        }

        //  Delete requests
        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _useCaseDeleteComment.Execute(id);

            if (result) return Ok();
            return NotFound();
        }
    }
}