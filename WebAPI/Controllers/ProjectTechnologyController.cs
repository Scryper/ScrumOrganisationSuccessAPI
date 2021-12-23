﻿using System.Collections.Generic;
using Application.UseCases.ProjectTechnology.Delete;
using Application.UseCases.ProjectTechnology.Dtos;
using Application.UseCases.ProjectTechnology.Get;
using Application.UseCases.ProjectTechnology.Post;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/projectTechnologies")]
    public class ProjectTechnologyController : ControllerBase
    {
        // Use cases
        private readonly UseCaseGetAllProjectTechnologies _useCaseGetAllProjectTechnologies;
        private readonly UseCaseGetProjectTechnologiesByIdProject _useCaseGetProjectTechnologiesByIdProject;
        private readonly UseCaseGetProjectTechnologiesByIdTechnology _useCaseGetProjectTechnologiesByIdTechnology;
        private readonly UseCaseDeleteProjectTechnology _useCaseDeleteProjectTechnology;
        private readonly UseCaseCreateProjectTechnologies _useCaseCreateProjectTechnologies;


        public ProjectTechnologyController(
            UseCaseGetAllProjectTechnologies useCaseGetAllProjectTechnologies,
            UseCaseGetProjectTechnologiesByIdProject useCaseGetProjectTechnologiesByIdProject,
            UseCaseGetProjectTechnologiesByIdTechnology useCaseGetProjectTechnologiesByIdTechnology,
            UseCaseDeleteProjectTechnology useCaseDeleteProjectTechnology,
            UseCaseCreateProjectTechnologies useCaseCreateProjectTechnologies)
        {
            _useCaseGetAllProjectTechnologies = useCaseGetAllProjectTechnologies;
            _useCaseGetProjectTechnologiesByIdProject = useCaseGetProjectTechnologiesByIdProject;
            _useCaseGetProjectTechnologiesByIdTechnology = useCaseGetProjectTechnologiesByIdTechnology;
            _useCaseCreateProjectTechnologies = useCaseCreateProjectTechnologies;
            _useCaseDeleteProjectTechnology = useCaseDeleteProjectTechnology;
        }
        
        // Get requests
        [HttpGet]
        public ActionResult<List<OutputDtoProjectTechnology>> GetAll()
        {
            return _useCaseGetAllProjectTechnologies.Execute();
        }
        
        [HttpGet]
        [Route("byProject/{idProject:int}")]
        public ActionResult<List<OutputDtoProjectTechnology>> GetByIdProject(int idProject)
        {
            return _useCaseGetProjectTechnologiesByIdProject.Execute(idProject);
        }
        
        [HttpGet]
        [Route("byTechnology/{idTechnology:int}")]
        public ActionResult<List<OutputDtoProjectTechnology>> GetByIdTechnology(int idTechnology)
        {
            return _useCaseGetProjectTechnologiesByIdTechnology.Execute(idTechnology);
        }
        
        // Post requests
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<OutputDtoProjectTechnology> Create([FromBody] InputDtoProjectTechnology inputDtoProjectTechnology)
        {
            var result = _useCaseCreateProjectTechnologies.Execute(inputDtoProjectTechnology);
            return result == null ? null : StatusCode(201, result);
        }
        
        // Delete requests
        [HttpDelete]
        [Route("{idProject:int},{idTechnology:int}")]
        public ActionResult Delete(int idProject, int idTechnology)
        {
            var result = _useCaseDeleteProjectTechnology.Execute(idProject,idTechnology);
            
            if (result) return Ok();
            return NotFound();
        }
    }
}