using System;
using System.Collections.Generic;
using Application.UseCases.Sprint;
using Application.UseCases.Sprint.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/sprints")]
    public class SprintController : ControllerBase
    {
        // Use cases
        private readonly UseCaseGetAllSprints _useCaseGetAllSprints;
        private readonly UseCaseCreateSprint _useCaseCreateSprint;
        
        // Constructor
        public SprintController(
            UseCaseGetAllSprints useCaseGetAllSprints,
            UseCaseCreateSprint useCaseCreateSprint)
        {
            _useCaseGetAllSprints = useCaseGetAllSprints;
            _useCaseCreateSprint = useCaseCreateSprint;
        }
        
        // Get requests
        [HttpGet]
        public ActionResult<List<OutputDtoSprint>> GetAll()
        {
            return _useCaseGetAllSprints.Execute();
        }

        // TODO : implement
        [HttpGet]
        [Route("{id:int}")]
        public OutputDtoSprint GetById(int id)
        {
            throw new NotImplementedException();
        }
        
        // TODO : implement
        [HttpGet]
        [Route("{idProject:int}")]
        public OutputDtoSprint GetByIdProject(int idProject)
        {
            throw new NotImplementedException();
        }
        
        // Post requests
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<OutputDtoSprint> Create(InputDtoSprint inputDtoSprint)
        {
            return StatusCode(201, _useCaseCreateSprint.Execute(inputDtoSprint));
        }
        
        // Put requests
        // TODO : implement
        [HttpPut]
        [Route("{id:int}")]
        public ActionResult UpdateProgression(int id, InputDtoSprint inputDtoSprint)
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