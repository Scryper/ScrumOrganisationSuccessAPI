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
        private readonly UseCaseGetSprintUserStoryByIdUserStory _useCaseGetSprintUserStoryByIdUserStory;
        private readonly UseCaseGetSprintUserStoryByIdSprint _useCaseGetSprintUserStoryByIdSprint;

        private readonly UseCaseCreateSprintUserStory _useCaseCreateSprintUserStory;

        private readonly UseCaseDeleteSprintUserStory _useCaseDeleteSprintUserStory;
        
        // Constructor
        public SprintUserStoryController(
            UseCaseGetAllSprintUserStory useCaseGetAllSprintUserStory,
            UseCaseGetSprintUserStoryByIdUserStory caseGetSprintUserStoryByIdUserStory,
            UseCaseGetSprintUserStoryByIdSprint caseGetSprintUserStoryByIdSprint,
            UseCaseCreateSprintUserStory useCaseCreateSprintUserStory,
            UseCaseDeleteSprintUserStory useCaseDeleteSprintUserStory)
        {
            _useCaseGetAllSprintUserStory = useCaseGetAllSprintUserStory;
            _useCaseGetSprintUserStoryByIdUserStory = caseGetSprintUserStoryByIdUserStory;
            _useCaseGetSprintUserStoryByIdSprint = caseGetSprintUserStoryByIdSprint;

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
            return _useCaseGetSprintUserStoryByIdSprint.Execute(idSprint);
        }

        [HttpGet]
        [Route("byIdUserStory/{idUserStory}")]
        public ActionResult<List<OutputDtoSprintUserStory>> GetByIdUserStory(int idUserStory)
        {
            return _useCaseGetSprintUserStoryByIdUserStory.Execute(idUserStory);
        }

        // Post requests
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(409)]
        public ActionResult<OutputDtoSprintUserStory> Create(InputDtoSprintUserStory inputDtoSprintUserStory)
        {
            var result = _useCaseCreateSprintUserStory.Execute(inputDtoSprintUserStory);
            return result == null ? StatusCode(409, null) : StatusCode(201, result);
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