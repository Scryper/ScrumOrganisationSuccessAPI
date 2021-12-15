using System.Collections.Generic;
using Application.UseCases.DeveloperProject.Dtos;
using Application.UseCases.DeveloperProject.Get;
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
        
        // Constructor

        public DeveloperProjectController(
            UseCaseGetAllDeveloperProjects useCaseGetAllDeveloperProjects,
            UseCaseGetDeveloperProjectsByIdDeveloper useCaseGetDeveloperProjectsByIdDeveloper,
            UseCaseGetDeveloperProjectsByIdProject useCaseGetDeveloperProjectsByIdProject
        )
        {
            _useCaseGetAllDeveloperProjects = useCaseGetAllDeveloperProjects;
            _useCaseGetDeveloperProjectsByIdDeveloper = useCaseGetDeveloperProjectsByIdDeveloper;
            _useCaseGetDeveloperProjectsByIdProject = useCaseGetDeveloperProjectsByIdProject;
        }
        
        // Get requests
        [HttpGet]
        public ActionResult<List<OutputDtoDeveloperProject>> GetAll()
        {
            return _useCaseGetAllDeveloperProjects.Execute();
        }
        
        
    }
}