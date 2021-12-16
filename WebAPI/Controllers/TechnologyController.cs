using System.Collections.Generic;
using Application.UseCases.Technology.Dtos;
using Application.UseCases.Technology.Get;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/technology")]
    public class TechnologyController
    {
        // Use cases 
        private readonly UseCaseGetAllTechnologies _useCaseGetAllTechnologies;
        private readonly UseCaseGetTechnologyById _useCaseGetTechnologyById;
        private readonly UseCaseGetTechnologyByName _useCaseGetTechnologyByName;

        public TechnologyController(
            UseCaseGetAllTechnologies useCaseGetAllTechnologies,
            UseCaseGetTechnologyById useCaseGetTechnologyById,
            UseCaseGetTechnologyByName useCaseGetTechnologyByName)
        {
            _useCaseGetAllTechnologies = useCaseGetAllTechnologies;
            _useCaseGetTechnologyById = useCaseGetTechnologyById;
            _useCaseGetTechnologyByName = useCaseGetTechnologyByName;
        }
        
        // Get requests
        [HttpGet]
        public ActionResult<List<OutputDtoTechnology>> GetAll()
        {
            return _useCaseGetAllTechnologies.Execute();
        }

        [HttpGet]
        [Route("byId/{id:int}")] 
        public ActionResult<OutputDtoTechnology> GetById(int id)
        {
            return _useCaseGetTechnologyById.Execute(id);
        }
        
        [HttpGet]
        [Route("byName/{name:alpha}")] 
        public ActionResult<OutputDtoTechnology> GetByName(string name)
        {
            return _useCaseGetTechnologyByName.Execute(name);
        }
    }
}