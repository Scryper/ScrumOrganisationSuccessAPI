using System.Collections.Generic;
using Application.UseCases.UserStory;
using Application.UseCases.UserStory.Delete;
using Application.UseCases.UserStory.Dtos;
using Application.UseCases.UserStory.Get;
using Application.UseCases.UserStory.Post;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/userStories")]
    public class UserStoryController : ControllerBase
    {
        // Use cases
        private readonly UseCaseGetAllUserStories _useCaseGetAllUserStories;
        private readonly UseCaseGetUserStoriesByIdProject _useCaseGetUserStoriesByIdProject;
        private readonly UseCaseGetUserStoriesByIdSprint _useCaseGetUserStoriesByIdSprint;
        private readonly UseCaseGetUserStoryById _useCaseGetUserStoryById;
        
        private readonly UseCaseCreateUserStory _useCaseCreateUserStory;

        private readonly UseCaseDeleteUserStory _useCaseDeleteUserStory;
        
        // Constructor
        public UserStoryController(
            UseCaseGetAllUserStories useCaseGetAllUserStories,
            UseCaseGetUserStoriesByIdProject useCaseGetUserStoriesByIdProject,
            UseCaseGetUserStoriesByIdSprint useCaseGetUserStoriesByIdSprint,
            UseCaseGetUserStoryById useCaseGetUserStoryById,
            UseCaseCreateUserStory useCaseCreateUserStory,
            UseCaseDeleteUserStory useCaseDeleteUserStory)
        {
            _useCaseGetAllUserStories = useCaseGetAllUserStories;
            _useCaseGetUserStoryById = useCaseGetUserStoryById;
            _useCaseGetUserStoriesByIdProject = useCaseGetUserStoriesByIdProject;
            _useCaseGetUserStoriesByIdSprint = useCaseGetUserStoriesByIdSprint;
            
            _useCaseCreateUserStory = useCaseCreateUserStory;

            _useCaseDeleteUserStory = useCaseDeleteUserStory;
        }
        
        // Get requests
        [HttpGet]
        public ActionResult<List<OutputDtoUserStory>> GetAll()
        {
            return _useCaseGetAllUserStories.Execute();
        }

        // If routes would only have {id:int}, even if the name would change, the url would be for both :
        // swagger/data/xxx -> so multiple endpoints matches
        [HttpGet]
        [Route("bySprint/{idSprint:int}")]
        public ActionResult<List<OutputDtoUserStory>> GetByIdSprint(int idSprint)
        {
            return _useCaseGetUserStoriesByIdSprint.Execute(idSprint);
        }
        
        [HttpGet]
        [Route("byProject/{idProject:int}")]
        public ActionResult<List<OutputDtoUserStory>> GetByIdProject(int idProject)
        {
            return _useCaseGetUserStoriesByIdProject.Execute(idProject);
        }
        
        [HttpGet]
        [Route("byId/{id:int}")]
        public ActionResult<OutputDtoUserStory> GetById(int id)
        {
            return _useCaseGetUserStoryById.Execute(id);
        }

        // Post requests
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<OutputDtoUserStory> Create([FromBody] InputDtoUserStory inputDtoUserStory)
        {
            return StatusCode(201, _useCaseCreateUserStory.Execute(inputDtoUserStory));
        }

        // Put requests

        //  Delete requests
        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _useCaseDeleteUserStory.Execute(id);
            
            if (result) return Ok();
            return NotFound();
        }
    }
}