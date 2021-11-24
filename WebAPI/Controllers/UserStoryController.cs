using System;
using System.Collections.Generic;
using Application.UseCases.UserStory;
using Application.UseCases.UserStory.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/userStories")]
    public class UserStoryController : ControllerBase
    {
        // Use cases
        private readonly UseCaseGetAllUserStories _useCaseGetAllUserStories;
        private readonly UseCaseCreateUserStory _useCaseCreateUserStory;
        
        // Constructor
        public UserStoryController(
            UseCaseGetAllUserStories useCaseGetAllUserStories,
            UseCaseCreateUserStory useCaseCreateUserStory)
        {
            _useCaseGetAllUserStories = useCaseGetAllUserStories;
            _useCaseCreateUserStory = useCaseCreateUserStory;
        }
        
        // Get requests
        [HttpGet]
        public ActionResult<List<OutputDtoUserStory>> GetAll()
        {
            return _useCaseGetAllUserStories.Execute();
        }

        // TODO : implement
        [HttpGet]
        [Route("{idSprint:int}")]
        public ActionResult<List<OutputDtoUserStory>> GetByIdSprint(int idSprint)
        {
            throw new NotImplementedException();
        }
        
        // TODO : implement
        [HttpGet]
        [Route("{idProject:int}")]
        public ActionResult<List<OutputDtoUserStory>> GetByIdProject(int idProject)
        {
            throw new NotImplementedException();
        }
        
        // TODO : implement
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<List<OutputDtoUserStory>> GetById(int id)
        {
            throw new NotImplementedException();
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
        // TODO : implement
        [HttpPut]
        [Route("{id:int}")]
        public ActionResult UpdateIsDone(int id, InputDtoUserStory inputDtoUserStory)
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