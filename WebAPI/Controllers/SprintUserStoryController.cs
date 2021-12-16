using System.Collections.Generic;
using Application.UseCases.SprintUserStory.Delete;
using Application.UseCases.SprintUserStory.Dtos;
using Application.UseCases.SprintUserStory.Get;
using Application.UseCases.SprintUserStory.Post;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/sprintsUserStories")]
    public class SprintUserStoryController : ControllerBase
    {
        // Use cases
        private readonly UseCaseGetAllSprintUserStory _useCaseGetAllSprintUserStory;
        private readonly UseCaseGetSprintByIdUserStory _useCaseGetSprintByIdUserStory;
        private readonly UseCaseGetUserStoriesByIdSprint _useCaseGetUserStoriesByIdSprint;

        private readonly UseCaseCreateSprintUserStory _useCaseCreateSprintUserStory;

        private readonly UseCaseDeleteSprintUserStory _useCaseDeleteSprintUserStory;
        
        // Constructor
        public SprintUserStoryController(
            UseCaseGetAllSprintUserStory useCaseGetAllSprintUserStory,
            UseCaseGetSprintByIdUserStory useCaseGetSprintByIdUserStory,
            UseCaseGetUserStoriesByIdSprint useCaseGetUserStoriesByIdSprint,
            UseCaseCreateSprintUserStory useCaseCreateSprintUserStory,
            UseCaseDeleteSprintUserStory useCaseDeleteSprintUserStory)
        {
            _useCaseGetAllSprintUserStory = useCaseGetAllSprintUserStory;
            _useCaseGetSprintByIdUserStory = useCaseGetSprintByIdUserStory;
            _useCaseGetUserStoriesByIdSprint = useCaseGetUserStoriesByIdSprint;

            _useCaseCreateSprintUserStory = useCaseCreateSprintUserStory;

            _useCaseDeleteSprintUserStory = useCaseDeleteSprintUserStory;
        }
        
        // Get requests
        [HttpGet]
        public ActionResult<List<OutputDtoSprintUserStory>> GetAll()
        {
            return _useCaseGetAllSprintUserStory.Execute();
        }

        [HttpGet]
        [Route("byIdSprint/{idSprint:int}")]
        public ActionResult<List<OutputDtoSprintUserStory>> GetByIdSprint(int idSprint)
        {
            return _useCaseGetUserStoriesByIdSprint.Execute(idSprint);
        }

        [HttpGet]
        [Route("byIdUserStory/{idUserStory}")]
        public ActionResult<List<OutputDtoSprintUserStory>> GetByIdUserStory(int idUserStory)
        {
            return _useCaseGetSprintByIdUserStory.Execute(idUserStory);
        }

        // Post requests
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<OutputDtoSprintUserStory> Create(InputDtoSprintUserStory inputDtoSprintUserStory)
        {
            return _useCaseCreateSprintUserStory.Execute(inputDtoSprintUserStory);
        }

        // Delete requests
        [HttpDelete]
        [Route("{idSprint:int}, {idUserStory:int}")]
        public bool Delete(int idSprint, int idUserStory)
        {
            return _useCaseDeleteSprintUserStory.Execute(idSprint, idUserStory);
        }
    }
}