using System.Collections.Generic;
using System.Web;
using Application.UseCases.Project;
using Application.UseCases.Project.Dtos;
using Application.UseCases.Project.Get;
using Application.UseCases.Project.Post;
using Application.UseCases.Project.Put;
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
    [Route("api/projects")]
    public class ProjectController : ControllerBase
    {
        // Use cases
        private readonly UseCaseGetAllProjects _useCaseGetAllProjects;
        private readonly UseCaseGetProjectById _useCaseGetProjectById;
        private readonly UseCaseGetProjectByName _useCaseGetProjectByName;
        private readonly UseCaseGetByIdUserActiveProject _useCaseGetByIdUserActiveProject;
        private readonly UseCaseGetActiveProjects _useCaseGetActiveProjects;

        private readonly UseCaseGetProjectByIdUserNotFinishedIsLinkedToUser
            _useCaseGetProjectByIdUserNotFinishedIsLinkedToUser;

        private readonly UseCaseCreateProject _useCaseCreateProject;

        private readonly UseCaseUpdateProjectStatus _useCaseUpdateProjectStatus;
        
        // Constructor
        public ProjectController(
            UseCaseGetAllProjects useCaseGetAllProjects,
            UseCaseGetProjectById useCaseGetProjectById,
            UseCaseGetProjectByName useCaseGetProjectByName,
            UseCaseCreateProject useCaseCreateProject,
            UseCaseUpdateProjectStatus useCaseUpdateProjectStatus,
            UseCaseGetByIdUserActiveProject caseGetByIdUserActiveProject,
            UseCaseGetProjectByIdUserNotFinishedIsLinkedToUser
                useCaseGetProjectByIdUserNotFinishedIsLinkedToUser,
            UseCaseGetActiveProjects useCaseGetActiveProjects)
        {
            _useCaseGetAllProjects = useCaseGetAllProjects;
            _useCaseGetProjectById = useCaseGetProjectById;
            _useCaseGetProjectByName = useCaseGetProjectByName;
            _useCaseGetByIdUserActiveProject = caseGetByIdUserActiveProject;
            _useCaseGetProjectByIdUserNotFinishedIsLinkedToUser
                = useCaseGetProjectByIdUserNotFinishedIsLinkedToUser;
            _useCaseGetActiveProjects = useCaseGetActiveProjects;
            
            _useCaseCreateProject = useCaseCreateProject;

            _useCaseUpdateProjectStatus = useCaseUpdateProjectStatus;
        }
        
        // Get requests
        [HttpGet]
        [Authorize(false, false, true)]
        public ActionResult<List<OutputDtoProject>> GetAll()
        {
            return _useCaseGetAllProjects.Execute();
        }

        // If routes would only have {id:int}, even if the name would change, the url would be for both :
        // swagger/data/xxx -> so multiple endpoints matches
        [HttpGet]
        [Route("byId/{id:int}")]
        [Authorize(true, true, true)]
        public ActionResult<OutputDtoProject> GetById(int id)
        {
            return _useCaseGetProjectById.Execute(id);
        }

        [HttpGet]
        [Route("byName/{name:required}")]
        [Authorize(true, true, true)]
        public ActionResult<OutputDtoProject> GetByName(string name)
        {
            var correctName = HttpUtility.UrlDecode(name);
            return _useCaseGetProjectByName.Execute(correctName);
        }
        
        // Get requests
        [HttpGet]
        [Route("activeByIdUser/{idUser:int}")]
        [Authorize(true, true, true)]
        public ActionResult<List<OutputDtoProject>> GetActiveProject(int idUser)
        {
            return _useCaseGetByIdUserActiveProject.Execute(idUser);
        }
        
        // Get requests
        [HttpGet]
        [Route("active/")]
        [Authorize(true, true, true)]
        public ActionResult<List<OutputDtoProject>> GetActiveProject()
        {
            return _useCaseGetActiveProjects.Execute();
        }
        
        
        // Get requests
        [HttpGet]
        [Route("byIdUserNotFinishedIsLinked/{idUser:int}")]
        [Authorize(true, true, true)]
        public ActionResult<List<OutputDtoProject>> GetIdUserNotFinishedIsLinked(int idUser)
        {
            return _useCaseGetProjectByIdUserNotFinishedIsLinkedToUser.Execute(idUser);
        }
        
        // Post requests
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(409)]
        [Authorize(false, false, true)]
        public ActionResult<OutputDtoProject> Create([FromBody] InputDtoProject inputDtoProject)
        {
            var result = _useCaseCreateProject.Execute(inputDtoProject);
            return result == null ? StatusCode(409, null) : StatusCode(201, result);
        }

        // Put requests
        [HttpPut]
        [Route("updateStatus/{idProjectUpdateState:int}")]
        [Authorize(true, true, true)]
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
    }
}