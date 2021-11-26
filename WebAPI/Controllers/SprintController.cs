using System.Collections.Generic;
using Application.UseCases.Sprint;
using Application.UseCases.Sprint.Delete;
using Application.UseCases.Sprint.Dtos;
using Application.UseCases.Sprint.Get;
using Application.UseCases.Sprint.Put;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/sprints")]
    public class SprintController : ControllerBase
    {
        // Use cases
        private readonly UseCaseGetAllSprints _useCaseGetAllSprints;
        private readonly UseCaseGetSprintById _useCaseGetSprintById;
        private readonly UseCaseGetSprintsByIdProject _useCaseGetSprintsByIdProject;
        
        private readonly UseCaseCreateSprint _useCaseCreateSprint;

        private readonly UseCaseUpdateSprintProgression _useCaseUpdateSprintProgression;

        private readonly UseCaseDeleteSprint _useCaseDeleteSprint;
        
        // Constructor
        public SprintController(
            UseCaseGetAllSprints useCaseGetAllSprints,
            UseCaseGetSprintById useCaseGetSprintById,
            UseCaseGetSprintsByIdProject useCaseGetSprintsByIdProject,
            UseCaseCreateSprint useCaseCreateSprint,
            UseCaseUpdateSprintProgression useCaseUpdateSprintProgression,
            UseCaseDeleteSprint useCaseDeleteSprint)
        {
            _useCaseGetAllSprints = useCaseGetAllSprints;
            _useCaseGetSprintById = useCaseGetSprintById;
            _useCaseGetSprintsByIdProject = useCaseGetSprintsByIdProject;
            
            _useCaseCreateSprint = useCaseCreateSprint;

            _useCaseUpdateSprintProgression = useCaseUpdateSprintProgression;

            _useCaseDeleteSprint = useCaseDeleteSprint;
        }
        
        // Get requests
        [HttpGet]
        public ActionResult<List<OutputDtoSprint>> GetAll()
        {
            return _useCaseGetAllSprints.Execute();
        }

        [HttpGet]
        [Route("{id:int}")]
        public OutputDtoSprint GetById(int id)
        {
            return _useCaseGetSprintById.Execute(id);
        }
        
        [HttpGet]
        [Route("{idProject:int}")]
        public List<OutputDtoSprint> GetByIdProject(int idProject)
        {
            return _useCaseGetSprintsByIdProject.Execute(idProject);
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
        [HttpPut]
        [Route("{id:int}")]
        public ActionResult UpdateProgression(int id, InputDtoSprint inputDtoSprint)
        {
            var inputDtoUpdate = new InputDtoUpdateSprintProgression
            {
                Id = id,
                InternSprint = new InputDtoUpdateSprintProgression.Sprint
                {
                    Progression = inputDtoSprint.Progression
                }
            };

            var result = _useCaseUpdateSprintProgression.Execute(inputDtoUpdate);

            if (result) return Ok();
            return NotFound();
        }

        //  Delete requests
        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _useCaseDeleteSprint.Execute(id);

            if (result) return Ok();
            return NotFound();
        }
    }
}