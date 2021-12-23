using System.Collections.Generic;
using Application.UseCases.Technology.Dtos;
using Application.UseCases.Technology.Get;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Security.Attributes;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/technology")]
    public class TechnologyController
    {
        // Use cases 
        private readonly UseCaseGetAllTechnologies _useCaseGetAllTechnologies;
        private readonly UseCaseGetTechnologyByName _useCaseGetTechnologyByName;

        public TechnologyController(
            UseCaseGetAllTechnologies useCaseGetAllTechnologies,
            UseCaseGetTechnologyByName useCaseGetTechnologyByName)
        {
            _useCaseGetAllTechnologies = useCaseGetAllTechnologies;
            _useCaseGetTechnologyByName = useCaseGetTechnologyByName;
        }
        
        // Get requests
        [HttpGet]
        [Authorize(true, true, true)]
        public ActionResult<List<OutputDtoTechnology>> GetAll()
        {
            return _useCaseGetAllTechnologies.Execute();
        }
        
        [HttpGet]
        [Route("byName/{name:alpha}")]
        [Authorize(true, true, true)]
        public ActionResult<OutputDtoTechnology> GetByName(string name)
        {
            return _useCaseGetTechnologyByName.Execute(name);
        }
    }
}