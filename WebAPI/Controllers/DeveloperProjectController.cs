﻿using System.Collections.Generic;
using Application.UseCases.DeveloperProject.Delete;
using Application.UseCases.DeveloperProject.Dtos;
using Application.UseCases.DeveloperProject.Get;
using Application.UseCases.DeveloperProject.Post;
using Application.UseCases.DeveloperProject.Put;
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
        private readonly UseCaseGetDeveloperProjectsByIdDeveloperIsAppliance _useCaseGetDeveloperProjectsByIdDeveloperIsAppliance;
        private readonly UseCaseGetByIdDeveloperIdProject _useCaseGetByIdDeveloperIdProject;
        
        private readonly UseCaseCreateDeveloperProject _useCaseCreateDeveloperProject;
        
        private readonly UseCaseUpdateDeveloperProject _useCaseUpdateDeveloperProject;
        
        private readonly UseCaseDeleteDeveloperProject _useCaseDeleteDeveloperProject;
        
        // Constructor

        public DeveloperProjectController(
            UseCaseGetAllDeveloperProjects useCaseGetAllDeveloperProjects,
            UseCaseGetDeveloperProjectsByIdDeveloper useCaseGetDeveloperProjectsByIdDeveloper,
            UseCaseGetDeveloperProjectsByIdProject useCaseGetDeveloperProjectsByIdProject,
            UseCaseCreateDeveloperProject useCaseCreateDeveloperProject,
            UseCaseUpdateDeveloperProject useCaseUpdateDeveloperProject,
            UseCaseDeleteDeveloperProject useCaseDeleteDeveloperProject,
            UseCaseGetDeveloperProjectsByIdDeveloperIsAppliance useCaseGetDeveloperProjectsByIdDeveloperIsAppliance,
            UseCaseGetByIdDeveloperIdProject useCaseGetByIdDeveloperIdProject
        )
        {
            _useCaseGetAllDeveloperProjects = useCaseGetAllDeveloperProjects;
            _useCaseGetDeveloperProjectsByIdDeveloper = useCaseGetDeveloperProjectsByIdDeveloper;
            _useCaseGetDeveloperProjectsByIdProject = useCaseGetDeveloperProjectsByIdProject;
            _useCaseGetDeveloperProjectsByIdDeveloperIsAppliance = useCaseGetDeveloperProjectsByIdDeveloperIsAppliance;
            _useCaseGetByIdDeveloperIdProject = useCaseGetByIdDeveloperIdProject;
            
            _useCaseCreateDeveloperProject = useCaseCreateDeveloperProject;
            
            _useCaseUpdateDeveloperProject = useCaseUpdateDeveloperProject;
            
            _useCaseDeleteDeveloperProject = useCaseDeleteDeveloperProject;
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
        
        [HttpGet]
        [Route("byIdDeveloperIsAppliance/{idDeveloper:int}")]
        public ActionResult<List<OutputDtoDeveloperProject>> GetByIdDeveloperIsAppliance(int idDeveloper)
        {
            return _useCaseGetDeveloperProjectsByIdDeveloperIsAppliance.Execute(idDeveloper);
        }
        
        [HttpGet]
        [Route("byIdDeveloperIdProject/{idDeveloper:int},{idProject:int}")]
        public ActionResult<OutputDtoDeveloperProject> GetByIdDeveloperIdProject(int idDeveloper,int idProject)
        {
            return _useCaseGetByIdDeveloperIdProject.Execute(idDeveloper,idProject);
        }
        
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<OutputDtoDeveloperProject> Create([FromBody] InputDtoDeveloperProject inputDtoDeveloperProject)
        {
            return StatusCode(201, _useCaseCreateDeveloperProject.Execute(inputDtoDeveloperProject));
        }

        [HttpPut]
        [Route("{idDeveloper:int}, {idProject:int}")]
        public ActionResult Update(int idDeveloper, int idProject, InputDtoDeveloperProject newDeveloperProject)
        {
            var inputDtoUpdate = new InputDtoUpdateDeveloperProject
            {
                IdDeveloper = idDeveloper,
                IdProject = idProject,
                InternIsApply = new InputDtoUpdateDeveloperProject.IsApply
                {
                    IsAppliance = newDeveloperProject.IsAppliance
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
            var result = _useCaseDeleteDeveloperProject.Execute(idDeveloper,idProject);

            if (result) return Ok();
            return NotFound();
        }
        
    }
}