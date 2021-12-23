﻿using System.Collections.Generic;
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

        // Post requests
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(409)]
        public ActionResult<OutputDtoSprintUserStory> Create(InputDtoSprintUserStory inputDtoSprintUserStory)
        {
            var result = _useCaseCreateSprintUserStory.Execute(inputDtoSprintUserStory);
            return result == null ? StatusCode(409, null) : StatusCode(201, result);
        }
    }
}