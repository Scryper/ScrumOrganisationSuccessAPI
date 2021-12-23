using System.Collections.Generic;
using Application.UseCases.DeveloperProject.Post;
using Application.UseCases.DeveloperProject.Put;
using Application.UseCases.UserProject.Delete;
using Application.UseCases.UserProject.Dtos;
using Application.UseCases.UserProject.Get;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/userProject")]
    public class UserProjectController : ControllerBase
    {
        // Use cases
        private readonly UseCaseGetAllUserProjects _useCaseGetAllUserProjects;
        private readonly UseCaseGetUserProjectsByIdDeveloper _useCaseGetUserProjectsByIdDeveloper;
        private readonly UseCaseGetUserProjectsByIdProject _useCaseGetUserProjectsByIdProject;
        private readonly UseCaseGetUserProjectsByIdDeveloperIsAppliance _useCaseGetUserProjectsByIdDeveloperIsAppliance;
        private readonly UseCaseGetByIdUserIdProject _useCaseGetByIdUserIdProject;
        private readonly UseCaseGetUserByIdProject _useCaseGetUserByIdProject;
        private readonly UseCaseGetScrumMasterByIdProject _useCaseGetScrumMasterByIdProject;

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
            UseCaseGetUserProjectsByIdProject caseGetUserProjectsByIdProject,
            UseCaseCreateDeveloperProject useCaseCreateDeveloperProject,
            UseCaseUpdateDeveloperProject useCaseUpdateDeveloperProject,
            UseCaseDeleteUserProject caseDeleteUserProject,
            UseCaseGetUserProjectsByIdDeveloperIsAppliance caseGetUserProjectsByIdDeveloperIsAppliance,
            UseCaseGetByIdUserIdProject caseGetByIdUserIdProject,
            UseCaseGetUserProjectByIdDeveloperIfIsWorking caseGetUserProjectByIdDeveloperIfIsWorking,
            UseCaseGetUserProjectByIdDeveloperIfIsNotWorking caseGetUserProjectByIdDeveloperIfIsNotWorking,
            UseCaseGetUserByIdProject caseGetUserByIdProject,
            UseCaseGetScrumMasterByIdProject useCaseGetScrumMasterByIdProject
        )
        {
            _useCaseGetAllUserProjects = caseGetAllUserProjects;
            _useCaseGetUserProjectsByIdDeveloper = caseGetUserProjectsByIdDeveloper;
            _useCaseGetUserProjectsByIdProject = caseGetUserProjectsByIdProject;
            _useCaseGetUserProjectsByIdDeveloperIsAppliance = caseGetUserProjectsByIdDeveloperIsAppliance;
            _useCaseGetByIdUserIdProject = caseGetByIdUserIdProject;
            _useCaseGetUserProjectByIdDeveloperIfIsWorking = caseGetUserProjectByIdDeveloperIfIsWorking;
            _useCaseGetUserProjectByIdDeveloperIfIsNotWorking = caseGetUserProjectByIdDeveloperIfIsNotWorking;
            _useCaseGetUserByIdProject = caseGetUserByIdProject;
            _useCaseGetScrumMasterByIdProject = useCaseGetScrumMasterByIdProject;
            
            _useCaseCreateDeveloperProject = useCaseCreateDeveloperProject;
            
            _useCaseUpdateDeveloperProject = useCaseUpdateDeveloperProject;
            
            _useCaseDeleteUserProject = caseDeleteUserProject;
        }
        
        // Get requests
        [HttpGet]
        public ActionResult<List<OutputDtoUserProject>> GetAll()
        {
            return _useCaseGetAllUserProjects.Execute();
        }

        [HttpGet]
        [Route("byIdDeveloper/{idDeveloper:int}")]
        public ActionResult<List<OutputDtoUserProject>> GetByIdDeveloper(int idDeveloper)
        {
            return _useCaseGetUserProjectsByIdDeveloper.Execute(idDeveloper);
        }

        [HttpGet]
        [Route("byIdProject/{idProject:int}")]
        public ActionResult<List<OutputDtoUserProject>> GetByIdProject(int idProject)
        {
            return _useCaseGetUserProjectsByIdProject.Execute(idProject);
        }
        
        [HttpGet]
        [Route("byIdDeveloperIsAppliance/{idDeveloper:int}")]
        public ActionResult<List<OutputDtoUserProject>> GetByIdDeveloperIsAppliance(int idDeveloper)
        {
            return _useCaseGetUserProjectsByIdDeveloperIsAppliance.Execute(idDeveloper);
        }
        
        [HttpGet]
        [Route("byIdDeveloperIdProject/{idDeveloper:int},{idProject:int}")]
        public ActionResult<OutputDtoUserProject> GetByIdDeveloperIdProject(int idDeveloper,int idProject)
        {
            return _useCaseGetByIdUserIdProject.Execute(idDeveloper,idProject);
        }
        
        [HttpGet]
        [Route("byIdDeveloperIfIsWorking/{idDeveloper:int}")]
        public ActionResult<List<OutputDtoUserProject>> GetByIdDeveloperIfIsWorking(int idDeveloper)
        {
            return _useCaseGetUserProjectByIdDeveloperIfIsWorking.Execute(idDeveloper);
        }
        
        [HttpGet]
        [Route("byIdDeveloperIfIsNotWorking/{idDeveloper:int}")]
        public ActionResult<List<OutputDtoUserProject>> GetByIdDeveloperIfIsNotWorking(int idDeveloper)
        {
            return _useCaseGetUserProjectByIdDeveloperIfIsNotWorking.Execute(idDeveloper);
        }
        [HttpGet]
        [Route("scrumMasterByIdProject/{idProject:int}")]
        public ActionResult<List<OutputDtoUserProject>> GetScrumMasterByIdProject(int idProject)
        {
            return _useCaseGetScrumMasterByIdProject.Execute(idProject);
        }
        [HttpGet]
        [Route("developersByIdProject/{idProject:int}")]
        public ActionResult<List<OutputDtoUserProject>> GetDevelopersByIdProject(int idProject)
        {
            return _useCaseGetUserByIdProject.Execute(idProject);
        }
        
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<OutputDtoUserProject> Create([FromBody] InputDtoUserProject inputDtoUserProject)
        {
            var result = _useCaseCreateDeveloperProject.Execute(inputDtoUserProject);
            return result == null ? null : StatusCode(201, result);
        }

        [HttpPut]
        [Route("{idDeveloper:int}, {idProject:int}")]
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
        public ActionResult Delete(int idDeveloper,int idProject)
        {
            var result = _useCaseDeleteUserProject.Execute(idDeveloper,idProject);

            if (result) return Ok();
            return NotFound();
        }
    }
}