using System.Collections.Generic;
using Application.UseCases.Sprint;
using Application.UseCases.Sprint.Delete;
using Application.UseCases.Sprint.Dtos;
using Application.UseCases.Sprint.Get;
using Application.UseCases.Sprint.Post;
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

        private readonly UseCaseDeleteSprint _useCaseDeleteSprint;
        
        // Constructor
        public SprintController(
            UseCaseGetAllSprints useCaseGetAllSprints,
            UseCaseGetSprintById useCaseGetSprintById,
            UseCaseGetSprintsByIdProject useCaseGetSprintsByIdProject,
            UseCaseCreateSprint useCaseCreateSprint,
            UseCaseDeleteSprint useCaseDeleteSprint)
        {
            _useCaseGetAllSprints = useCaseGetAllSprints;
            _useCaseGetSprintById = useCaseGetSprintById;
            _useCaseGetSprintsByIdProject = useCaseGetSprintsByIdProject;
            
            _useCaseCreateSprint = useCaseCreateSprint;

            _useCaseDeleteSprint = useCaseDeleteSprint;
        }
        
        // Get requests
        [HttpGet]
        public ActionResult<List<OutputDtoSprint>> GetAll()
        {
            return _useCaseGetAllSprints.Execute();
        }

        // If routes would only have {id:int}, even if the name would change, the url would be for both :
        // swagger/data/xxx -> so multiple endpoints matches
        [HttpGet]
        [Route("byId/{id:int}")]
        public OutputDtoSprint GetById(int id)
        {
            return _useCaseGetSprintById.Execute(id);
        }
        
        [HttpGet]
        [Route("byProject/{idProject:int}")]
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