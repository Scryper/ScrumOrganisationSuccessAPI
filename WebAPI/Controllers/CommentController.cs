using System;
using System.Collections.Generic;
using Application.UseCases.Comment;
using Application.UseCases.Comment.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ScrumOrganisationSuccessAPI.Controllers
{
    [ApiController]
    [Route("api/comments")]
    public class CommentController : ControllerBase
    {
        // Use cases
        private readonly UseCaseGetAllComments _useCaseGetAllComments;
        private readonly UseCaseCreateComment _useCaseCreateComment;

        // Constructor
        public CommentController(
            UseCaseGetAllComments useCaseGetAllComments,
            UseCaseCreateComment useCaseCreateComment)
        {
            _useCaseGetAllComments = useCaseGetAllComments;
            _useCaseCreateComment = useCaseCreateComment;
        }

        // Get requests
        [HttpGet]
        public ActionResult<List<OutputDtoComment>> GetAll()
        {
            return _useCaseGetAllComments.Execute();
        }

        // TODO : implement
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<OutputDtoComment> GetById(int id)
        {
            throw new NotImplementedException();
        }
        
        // TODO : implement
        [HttpGet]
        [Route("{idUserStory:int}")]
        public ActionResult<List<OutputDtoComment>> GetByIdUserStory(int idUserStory)
        {
            throw new NotImplementedException();
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
        // TODO : implement
        [HttpPut]
        [Route("{id:int}")]
        public ActionResult UpdateContent(int id, InputDtoComment newComment)
        {
            throw new NotImplementedException();
        }

        //  Delete requests
        // TODO : implement
        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}