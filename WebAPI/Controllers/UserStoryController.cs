using System.Collections.Generic;
using Application.UseCases.UserStory;
using Application.UseCases.UserStory.Delete;
using Application.UseCases.UserStory.Dtos;
using Application.UseCases.UserStory.Get;
using Application.UseCases.UserStory.Put;
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

        private readonly UseCaseUpdateUserStoryIsDone _useCaseUpdateUserStoryIsDone;

        private readonly UseCaseDeleteUserStory _useCaseDeleteUserStory;
        
        // Constructor
        public UserStoryController(
            UseCaseGetAllUserStories useCaseGetAllUserStories,
            UseCaseGetUserStoriesByIdProject useCaseGetUserStoriesByIdProject,
            UseCaseGetUserStoriesByIdSprint useCaseGetUserStoriesByIdSprint,
            UseCaseGetUserStoryById useCaseGetUserStoryById,
            UseCaseCreateUserStory useCaseCreateUserStory,
            UseCaseUpdateUserStoryIsDone useCaseUpdateUserStoryIsDone,
            UseCaseDeleteUserStory useCaseDeleteUserStory)
        {
            _useCaseGetAllUserStories = useCaseGetAllUserStories;
            _useCaseGetUserStoryById = useCaseGetUserStoryById;
            _useCaseGetUserStoriesByIdProject = useCaseGetUserStoriesByIdProject;
            _useCaseGetUserStoriesByIdSprint = useCaseGetUserStoriesByIdSprint;
            
            _useCaseCreateUserStory = useCaseCreateUserStory;

            _useCaseUpdateUserStoryIsDone = useCaseUpdateUserStoryIsDone;

            _useCaseDeleteUserStory = useCaseDeleteUserStory;
        }
        
        // Get requests
        [HttpGet]
        public ActionResult<List<OutputDtoUserStory>> GetAll()
        {
            return _useCaseGetAllUserStories.Execute();
        }

        [HttpGet]
        [Route("{idSprint:int}")]
        public ActionResult<List<OutputDtoUserStory>> GetByIdSprint(int idSprint)
        {
            return _useCaseGetUserStoriesByIdSprint.Execute(idSprint);
        }
        
        [HttpGet]
        [Route("{idProject:int}")]
        public ActionResult<List<OutputDtoUserStory>> GetByIdProject(int idProject)
        {
            return _useCaseGetUserStoriesByIdProject.Execute(idProject);
        }
        
        [HttpGet]
        [Route("{id:int}")]
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
        [HttpPut]
        [Route("{id:int}")]
        public ActionResult UpdateIsDone(int id, InputDtoUserStory inputDtoUserStory)
        {
            var inputDtoUpdate = new InputDtoUpdateUserStoryIsDone
            {
                Id = id,
                InternUserStory = new InputDtoUpdateUserStoryIsDone.UserStory
                {
                    IsDone = inputDtoUserStory.IsDone
                }
            };

            var result = _useCaseUpdateUserStoryIsDone.Execute(inputDtoUpdate);

            if (result) return Ok();
            return NotFound();
        }

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