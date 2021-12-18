using System;
using System.Collections.Generic;
using System.Web;
using Application.UseCases.Project;
using Application.UseCases.Project.Delete;
using Application.UseCases.Project.Dtos;
using Application.UseCases.Project.Get;
using Application.UseCases.Project.Post;
using Application.UseCases.Project.Put;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectController : ControllerBase
    {
        // Use cases
        private readonly UseCaseGetAllProjects _useCaseGetAllProjects;
        private readonly UseCaseGetProjectById _useCaseGetProjectById;
        private readonly UseCaseGetProjectByName _useCaseGetProjectByName;

        private readonly UseCaseCreateProject _useCaseCreateProject;

        private readonly UseCaseUpdateProjectRepositoryUrl _useCaseUpdateProjectRepositoryUrl;
        private readonly UseCaseUpdateProjectStatus _useCaseUpdateProjectStatus;

        private readonly UseCaseDeleteProject _useCaseDeleteProject;
        
        // Constructor
        public ProjectController(
            UseCaseGetAllProjects useCaseGetAllProjects,
            UseCaseGetProjectById useCaseGetProjectById,
            UseCaseGetProjectByName useCaseGetProjectByName,
            UseCaseCreateProject useCaseCreateProject,
            UseCaseUpdateProjectRepositoryUrl useCaseUpdateProjectRepositoryUrl,
            UseCaseDeleteProject useCaseDeleteProject,
            UseCaseUpdateProjectStatus useCaseUpdateProjectStatus)
        {
            _useCaseGetAllProjects = useCaseGetAllProjects;
            _useCaseGetProjectById = useCaseGetProjectById;
            _useCaseGetProjectByName = useCaseGetProjectByName;
            
            _useCaseCreateProject = useCaseCreateProject;

            _useCaseUpdateProjectRepositoryUrl = useCaseUpdateProjectRepositoryUrl;
            _useCaseUpdateProjectStatus = useCaseUpdateProjectStatus;

            _useCaseDeleteProject = useCaseDeleteProject;
        }
        
        // Get requests
        [HttpGet]
        public ActionResult<List<OutputDtoProject>> GetAll()
        {
            return _useCaseGetAllProjects.Execute();
        }

        // If routes would only have {id:int}, even if the name would change, the url would be for both :
        // swagger/data/xxx -> so multiple endpoints matches
        [HttpGet]
        [Route("byId/{id:int}")]
        public ActionResult<OutputDtoProject> GetById(int id)
        {
            return _useCaseGetProjectById.Execute(id);
        }

        [HttpGet]
        [Route("byName/{name:required}")]
        public ActionResult<OutputDtoProject> GetByName(string name)
        {
            var correctName = HttpUtility.UrlDecode(name);
            return _useCaseGetProjectByName.Execute(correctName);
        }
        
        // Post requests
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
            var inputDtoUpdate = new InputDtoUpdateProjectRepositoryUrl
            {
                Id = id,
                InternProject = new InputDtoUpdateProjectRepositoryUrl.Project
                {
                    RepositoryUrl = newProject.RepositoryUrl
                }
            };
            
            var result = _useCaseUpdateProjectRepositoryUrl.Execute(inputDtoUpdate);

            if (result) return Ok();
            return NotFound();
        }
        
        // Put requests
        [HttpPut]
        [Route("updateStatus/{idProjectUpdateState:int}")]
        public ActionResult UpdateState(int idProjectUpdateState, InputDtoProject newProject)
        {
            var inputDtoUpdate = new InputDtoUpdateProjectStatus
            {
                Id = idProjectUpdateState,
                InternProject = new InputDtoUpdateProjectStatus.Project
                {
                    Status = newProject.Status
                }
            };
            
            var result = _useCaseUpdateProjectStatus.Execute(inputDtoUpdate);

            if (result) return Ok();
            return NotFound();
        }

        //  Delete requests
        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _useCaseDeleteProject.Execute(id);

            if (result) return Ok();
            return NotFound();
        }
    }
}