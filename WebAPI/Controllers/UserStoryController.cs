using System.Collections.Generic;
using Application.UseCases.UserStory;
using Application.UseCases.UserStory.Delete;
using Application.UseCases.UserStory.Dtos;
using Application.UseCases.UserStory.Get;
using Application.UseCases.UserStory.Post;
using Application.UseCases.UserStory.Put;
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
    [Route("api/userStories")]
    public class UserStoryController : ControllerBase
    {
        // Use cases
        private readonly UseCaseGetAllUserStories _useCaseGetAllUserStories;
        private readonly UseCaseGetUserStoriesByIdProject _useCaseGetUserStoriesByIdProject;
        private readonly UseCaseGetUserStoriesByIdSprint _useCaseGetUserStoriesByIdSprint;
        private readonly UseCaseGetUserStoryById _useCaseGetUserStoryById;

        private readonly UseCaseUpdateUserStory _useCaseUpdateUserStory;
        
        private readonly UseCaseCreateUserStory _useCaseCreateUserStory;

        private readonly UseCaseDeleteUserStory _useCaseDeleteUserStory;
        
        // Constructor
        public UserStoryController(
            UseCaseGetAllUserStories useCaseGetAllUserStories,
            UseCaseGetUserStoriesByIdProject useCaseGetUserStoriesByIdProject,
            UseCaseGetUserStoriesByIdSprint useCaseGetUserStoriesByIdSprint,
            UseCaseGetUserStoryById useCaseGetUserStoryById,
            UseCaseCreateUserStory useCaseCreateUserStory,
            UseCaseDeleteUserStory useCaseDeleteUserStory,
            UseCaseUpdateUserStory useCaseUpdateUserStory)
        {
            _useCaseGetAllUserStories = useCaseGetAllUserStories;
            _useCaseGetUserStoryById = useCaseGetUserStoryById;
            _useCaseGetUserStoriesByIdProject = useCaseGetUserStoriesByIdProject;
            _useCaseGetUserStoriesByIdSprint = useCaseGetUserStoriesByIdSprint;

            _useCaseUpdateUserStory = useCaseUpdateUserStory;
            _useCaseCreateUserStory = useCaseCreateUserStory;

            _useCaseDeleteUserStory = useCaseDeleteUserStory;
        }
        
        // Get requests
        [HttpGet]
        [Authorize(true, true, true)]
        public ActionResult<List<OutputDtoUserStory>> GetAll()
        {
            return _useCaseGetAllUserStories.Execute();
        }

        // If routes would only have {id:int}, even if the name would change, the url would be for both :
        // swagger/data/xxx -> so multiple endpoints matches
        [HttpGet]
        [Route("byProject/{idProject:int}")]
        [Authorize(true, true, true)]
        public ActionResult<List<OutputDtoUserStory>> GetByIdProject(int idProject)
        {
            return _useCaseGetUserStoriesByIdProject.Execute(idProject);
        }
        
        [HttpGet]
        [Route("byId/{id:int}")]
        [Authorize(true, true, true)]
        public ActionResult<OutputDtoUserStory> GetById(int id)
        {
            return _useCaseGetUserStoryById.Execute(id);
        }
        
        [HttpGet]
        [Route("bySprint/{idSprint:int}")]
        [Authorize(true, true, true)]
        public ActionResult<List<OutputDtoUserStory>> GetByIdSprint(int idSprint)
        {
            return _useCaseGetUserStoriesByIdSprint.Execute(idSprint);
        }

        // Post requests
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(409)]
        [Authorize(false, false, true)]
        public ActionResult<OutputDtoUserStory> Create([FromBody] InputDtoUserStory inputDtoUserStory)
        {
            var result = _useCaseCreateUserStory.Execute(inputDtoUserStory);
            return result == null ? StatusCode(409, null) : StatusCode(201, result);
        }

        // Put requests
        [HttpPut]
        [Route("update/{id:int}")]
        [ProducesResponseType(409)]
        public ActionResult UpdateUserStory(int id, InputDtoUserStory inputDtoUserStory)
        {
            var inputDtoUpdate = new InputDtoUpdateUserStory
            {
                Id = id,
                InternUserStory = new InputDtoUpdateUserStory.UserStory
                {
                    IdProject = inputDtoUserStory.IdProject,
                    Name = inputDtoUserStory.Name,
                    Description = inputDtoUserStory.Description,
                    Priority = inputDtoUserStory.Priority
                }
            };
            
            var result = _useCaseUpdateUserStory.Execute(inputDtoUpdate);

            if (result) return Ok();
            return StatusCode(409, false);
        }

        //  Delete requests
        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(false, false, true)]
        public ActionResult Delete(int id)
        {
            var result = _useCaseDeleteUserStory.Execute(id);
            
            if (result) return Ok();
            return NotFound();
        }
    }
}