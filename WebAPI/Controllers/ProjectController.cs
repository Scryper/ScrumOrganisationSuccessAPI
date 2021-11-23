using System;
using System.Collections.Generic;
using Application.UseCases.Project;
using Application.UseCases.Project.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ScrumOrganisationSuccessAPI.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectController : ControllerBase
    {
        // Use cases
        private readonly UseCaseGetAllProjects _useCaseGetAllProjects;
        private readonly UseCaseCreateProject _useCaseCreateProject;
        
        // Constructor
        public ProjectController(
            UseCaseGetAllProjects useCaseGetAllProjects,
            UseCaseCreateProject useCaseCreateProject)
        {
            _useCaseGetAllProjects = useCaseGetAllProjects;
            _useCaseCreateProject = useCaseCreateProject;
        }
        
        // Get requests
        [HttpGet]
        public ActionResult<List<OutputDtoProject>> GetAll()
        {
            return _useCaseGetAllProjects.Execute();
        }

        // TODO : implement
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<OutputDtoProject> GetById(int id)
        {
            throw new NotImplementedException();
        }
        
        // TODO : factorisation
        // TODO : implement
        [HttpGet]
        [Route("{idProductOwner:int}")]
        public ActionResult<OutputDtoProject> GetByIdProductOwner(int idProductOwner)
        {
            throw new NotImplementedException();
        }
        
        // TODO : factorisation
        // TODO : implement
        [HttpGet]
        [Route("{idScrumMaster:int}")]
        public ActionResult<OutputDtoProject> GetByIdScrumMaster(int idScrumMaster)
        {
            throw new NotImplementedException();
        }

        // Post requests
        // TODO : implement
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<OutputDtoProject> Create([FromBody] InputDtoProject inputDtoProject)
        {
            return StatusCode(201,_useCaseCreateProject.Execute(inputDtoProject));
        }

        // Put requests
        [HttpPut]
        [Route("{id:int}")]
        public ActionResult UpdateContent(int id, InputDtoProject newProject)
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