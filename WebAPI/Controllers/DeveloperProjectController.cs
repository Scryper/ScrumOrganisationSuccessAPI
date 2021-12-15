using System.Collections.Generic;
using Application.UseCases.DeveloperProject.Dtos;
using Application.UseCases.DeveloperProject.Get;
using Application.UseCases.DeveloperProject.Post;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/developerProject")]
    public class DeveloperProjectController : ControllerBase
    {
        // Use cases
        private readonly UseCaseGetAllDeveloperProjects _useCaseGetAllDeveloperProjects;
        private readonly UseCaseGetDeveloperProjectsByIdDeveloper _useCaseGetDeveloperProjectsByIdDeveloper;
        private readonly UseCaseGetDeveloperProjectsByIdProject _useCaseGetDeveloperProjectsByIdProject;
        private readonly UseCaseCreateDeveloperProject _useCaseCreateDeveloperProject;
        
        // Constructor

        public DeveloperProjectController(
            UseCaseGetAllDeveloperProjects useCaseGetAllDeveloperProjects,
            UseCaseGetDeveloperProjectsByIdDeveloper useCaseGetDeveloperProjectsByIdDeveloper,
            UseCaseGetDeveloperProjectsByIdProject useCaseGetDeveloperProjectsByIdProject,
            UseCaseCreateDeveloperProject useCaseCreateDeveloperProject
        )
        {
            _useCaseGetAllDeveloperProjects = useCaseGetAllDeveloperProjects;
            _useCaseGetDeveloperProjectsByIdDeveloper = useCaseGetDeveloperProjectsByIdDeveloper;
            _useCaseGetDeveloperProjectsByIdProject = useCaseGetDeveloperProjectsByIdProject;
            _useCaseCreateDeveloperProject = useCaseCreateDeveloperProject;
        }
        
        // Get requests
        [HttpGet]
        public ActionResult<List<OutputDtoDeveloperProject>> GetAll()
        {
            return _useCaseGetAllDeveloperProjects.Execute();
        }

        [HttpGet]
        [Route("byIdDeveloper/{idDeveloper:int}")]
        public ActionResult<List<OutputDtoDeveloperProject>> GetByIdDeveloper(int idDeveloper)
        {
            return _useCaseGetDeveloperProjectsByIdDeveloper.Execute(idDeveloper);
        }

        [HttpGet]
        [Route("byIdProject/{idProject:int}")]
        public ActionResult<List<OutputDtoDeveloperProject>> GetByIdProject(int idProject)
        {
            return _useCaseGetDeveloperProjectsByIdProject.Execute(idProject);
        }
        
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<OutputDtoDeveloperProject> Create([FromBody] InputDtoDeveloperProject inputDtoDeveloperProject)
        {
            return StatusCode(201, _useCaseCreateDeveloperProject.Execute(inputDtoDeveloperProject));
        }

    }
}