using System.Collections.Generic;
using Application.UseCases.DeveloperProject.Post;
using Application.UseCases.DeveloperProject.Put;
using Application.UseCases.UserProject.Delete;
using Application.UseCases.UserProject.Dtos;
using Application.UseCases.UserProject.Get;
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
    [Route("api/userProject")]
    public class UserProjectController : ControllerBase
    {
        // Use cases
        private readonly UseCaseGetAllUserProjects _useCaseGetAllUserProjects;
        private readonly UseCaseGetUserProjectsByIdDeveloper _useCaseGetUserProjectsByIdDeveloper;
        private readonly UseCaseGetUserProjectsByIdDeveloperIsAppliance _useCaseGetUserProjectsByIdDeveloperIsAppliance;
        private readonly UseCaseGetByIdUserIdProject _useCaseGetByIdUserIdProject;

        private readonly UseCaseGetUserProjectByIdDeveloperIfIsWorking
            _useCaseGetUserProjectByIdDeveloperIfIsWorking;

        private readonly UseCaseGetUserProjectByIdDeveloperIfIsNotWorking
            _useCaseGetUserProjectByIdDeveloperIfIsNotWorking;
        
        private readonly UseCaseCreateDeveloperProject _useCaseCreateDeveloperProject;
        
        private readonly UseCaseUpdateDeveloperProject _useCaseUpdateDeveloperProject;
        
        private readonly UseCaseDeleteUserProject _useCaseDeleteUserProject;
        
        // Constructor

        public UserProjectController(
            UseCaseGetAllUserProjects caseGetAllUserProjects,
            UseCaseGetUserProjectsByIdDeveloper caseGetUserProjectsByIdDeveloper,
            UseCaseCreateDeveloperProject useCaseCreateDeveloperProject,
            UseCaseUpdateDeveloperProject useCaseUpdateDeveloperProject,
            UseCaseDeleteUserProject caseDeleteUserProject,
            UseCaseGetUserProjectsByIdDeveloperIsAppliance caseGetUserProjectsByIdDeveloperIsAppliance,
            UseCaseGetByIdUserIdProject caseGetByIdUserIdProject,
            UseCaseGetUserProjectByIdDeveloperIfIsWorking caseGetUserProjectByIdDeveloperIfIsWorking,
            UseCaseGetUserProjectByIdDeveloperIfIsNotWorking caseGetUserProjectByIdDeveloperIfIsNotWorking
        )
        {
            _useCaseGetAllUserProjects = caseGetAllUserProjects;
            _useCaseGetUserProjectsByIdDeveloper = caseGetUserProjectsByIdDeveloper;
            _useCaseGetUserProjectsByIdDeveloperIsAppliance = caseGetUserProjectsByIdDeveloperIsAppliance;
            _useCaseGetByIdUserIdProject = caseGetByIdUserIdProject;
            _useCaseGetUserProjectByIdDeveloperIfIsWorking = caseGetUserProjectByIdDeveloperIfIsWorking;
            _useCaseGetUserProjectByIdDeveloperIfIsNotWorking = caseGetUserProjectByIdDeveloperIfIsNotWorking;
            
            _useCaseCreateDeveloperProject = useCaseCreateDeveloperProject;
            
            _useCaseUpdateDeveloperProject = useCaseUpdateDeveloperProject;
            
            _useCaseDeleteUserProject = caseDeleteUserProject;
        }
        
        // Get requests
        [HttpGet]
        [Authorize(true, true, true)]
        public ActionResult<List<OutputDtoUserProject>> GetAll()
        {
            return _useCaseGetAllUserProjects.Execute();
        }

        [HttpGet]
        [Route("byIdDeveloper/{idDeveloper:int}")]
        [Authorize(true, true, true)]
        public ActionResult<List<OutputDtoUserProject>> GetByIdDeveloper(int idDeveloper)
        {
            return _useCaseGetUserProjectsByIdDeveloper.Execute(idDeveloper);
        }
        
        [HttpGet]
        [Route("byIdDeveloperIsAppliance/{idDeveloper:int}")]
        [Authorize(true, true, true)]
        public ActionResult<List<OutputDtoUserProject>> GetByIdDeveloperIsAppliance(int idDeveloper)
        {
            return _useCaseGetUserProjectsByIdDeveloperIsAppliance.Execute(idDeveloper);
        }
        
        [HttpGet]
        [Route("byIdDeveloperIdProject/{idDeveloper:int},{idProject:int}")]
        [Authorize(true, true, true)]
        public ActionResult<OutputDtoUserProject> GetByIdDeveloperIdProject(int idDeveloper,int idProject)
        {
            return _useCaseGetByIdUserIdProject.Execute(idDeveloper,idProject);
        }
        
        [HttpGet]
        [Route("byIdDeveloperIfIsWorking/{idDeveloper:int}")]
        [Authorize(true, true, true)]
        public ActionResult<List<OutputDtoUserProject>> GetByIdDeveloperIfIsWorking(int idDeveloper)
        {
            return _useCaseGetUserProjectByIdDeveloperIfIsWorking.Execute(idDeveloper);
        }
        
        [HttpGet]
        [Route("byIdDeveloperIfIsNotWorking/{idDeveloper:int}")]
        [Authorize(true, true, true)]
        public ActionResult<List<OutputDtoUserProject>> GetByIdDeveloperIfIsNotWorking(int idDeveloper)
        {
            return _useCaseGetUserProjectByIdDeveloperIfIsNotWorking.Execute(idDeveloper);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(409)]
        [Authorize(true, true, true)]
        public ActionResult<OutputDtoUserProject> Create([FromBody] InputDtoUserProject inputDtoUserProject)
        {
            var result = _useCaseCreateDeveloperProject.Execute(inputDtoUserProject);
            return result == null ? StatusCode(409, null) : StatusCode(201, result);
        }

        [HttpPut]
        [Route("{idDeveloper:int}, {idProject:int}")]
        [Authorize(true, true, true)]
        public ActionResult Update(int idDeveloper, int idProject, InputDtoUserProject newUserProject)
        {
            var inputDtoUpdate = new InputDtoUpdateUserProject
            {
                IdDeveloper = idDeveloper,
                IdProject = idProject,
                InternIsApply = new InputDtoUpdateUserProject.IsApply
                {
                    IsAppliance = newUserProject.IsAppliance
                }
            };

            var result = _useCaseUpdateDeveloperProject.Execute(inputDtoUpdate);

            if (result) return Ok();
            return BadRequest();
        }
        
        //  Delete requests
        [HttpDelete]
        [Route("{idDeveloper:int}, {idProject:int}")]
        [Authorize(true, true, true)]
        public ActionResult Delete(int idDeveloper, int idProject)
        {
            var result = _useCaseDeleteUserProject.Execute(idDeveloper, idProject);

            if (result) return Ok();
            return NotFound();
        }
    }
}