using System.Collections.Generic;
using Application.UseCases.SprintUserStory.Dtos;
using Application.UseCases.SprintUserStory.Get;
using Application.UseCases.SprintUserStory.Post;
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
    [Route("api/sprintsUserStories")]
    public class SprintUserStoryController : ControllerBase
    {
        // Use cases
        private readonly UseCaseGetAllSprintUserStory _useCaseGetAllSprintUserStory;
        private readonly UseCaseGetSprintUserStoryByIdSprint _useCaseGetSprintUserStoryByIdSprint;

        private readonly UseCaseCreateSprintUserStory _useCaseCreateSprintUserStory;
        
        // Constructor
        public SprintUserStoryController(
            UseCaseGetAllSprintUserStory useCaseGetAllSprintUserStory,
            UseCaseGetSprintUserStoryByIdSprint caseGetSprintUserStoryByIdSprint,
            UseCaseCreateSprintUserStory useCaseCreateSprintUserStory)
        {
            _useCaseGetAllSprintUserStory = useCaseGetAllSprintUserStory;
            _useCaseGetSprintUserStoryByIdSprint = caseGetSprintUserStoryByIdSprint;

            _useCaseCreateSprintUserStory = useCaseCreateSprintUserStory;
        }
        
        // Get requests
        [HttpGet]
        [Authorize(false, false, true)]
        public ActionResult<List<OutputDtoSprintUserStory>> GetAll()
        {
            return _useCaseGetAllSprintUserStory.Execute();
        }

        [HttpGet]
        [Route("byIdSprint/{idSprint:int}")]
        [Authorize(true, true, true)]
        public ActionResult<List<OutputDtoSprintUserStory>> GetByIdSprint(int idSprint)
        {
            return _useCaseGetSprintUserStoryByIdSprint.Execute(idSprint);
        }

        // Post requests
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(409)]
        [Authorize(false, true, true)]
        public ActionResult<OutputDtoSprintUserStory> Create(InputDtoSprintUserStory inputDtoSprintUserStory)
        {
            var result = _useCaseCreateSprintUserStory.Execute(inputDtoSprintUserStory);
            return result == null ? StatusCode(409, null) : StatusCode(201, result);
        }
    }
}