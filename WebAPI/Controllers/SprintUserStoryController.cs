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
        // [HttpGet]
        // public ActionResult<List<OutputDtoSprintUserStory>> GetAll()
        // {
        //     
        // }

        // Post requests
        
        // Delete requests
    }
}