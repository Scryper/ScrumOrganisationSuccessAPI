using System.Collections.Generic;
using Application.UseCases.UserTechnology.Delete;
using Application.UseCases.UserTechnology.Dtos;
using Application.UseCases.UserTechnology.Get;
using Application.UseCases.UserTechnology.Post;
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
    [Route("api/userTechnologies")]
    public class UserTechnologyController : ControllerBase
    {
        // Use cases
        private readonly UseCaseGetAllUserTechnologies _useCaseGetAllUserTechnologies;
        private readonly UseCaseGetUserTechnologyByIdTechnology _useCaseGetUserTechnologyByIdTechnology;
        private readonly UseCaseGetUserTechnologyByIdUser _useCaseGetUserTechnologyByIdUser;
        private readonly UseCaseGetUserTechnologyByIdTechnologyIdUser _useCaseGetUserTechnologyByIdTechnologyIdUser;
        private readonly UseCaseCreateUserTechnology _useCaseCreateUserTechnology;
        private readonly UseCaseDeleteUserTechnology _useCaseDeleteUserTechnology;

        public UserTechnologyController(
            UseCaseGetAllUserTechnologies useCaseGetAllUserTechnologies,
            UseCaseGetUserTechnologyByIdTechnology useCaseGetUserTechnologyByIdTechnology,
            UseCaseGetUserTechnologyByIdUser useCaseGetUserTechnologyByIdUser,
            UseCaseCreateUserTechnology useCaseCreateUserTechnology,
            UseCaseDeleteUserTechnology useCaseDeleteUserTechnology,
            UseCaseGetUserTechnologyByIdTechnologyIdUser useCaseGetUserTechnologyByIdTechnologyIdUser)
        {
            _useCaseGetAllUserTechnologies = useCaseGetAllUserTechnologies;
            _useCaseGetUserTechnologyByIdTechnology = useCaseGetUserTechnologyByIdTechnology;
            _useCaseGetUserTechnologyByIdUser = useCaseGetUserTechnologyByIdUser;
            _useCaseCreateUserTechnology = useCaseCreateUserTechnology;
            _useCaseDeleteUserTechnology = useCaseDeleteUserTechnology;
            _useCaseGetUserTechnologyByIdTechnologyIdUser =useCaseGetUserTechnologyByIdTechnologyIdUser;
        }
        
        // Get requests
        [HttpGet]
        [Authorize(true, true, true)]
        public ActionResult<List<OutputDtoUserTechnology>> GetAll()
        {
            return _useCaseGetAllUserTechnologies.Execute();
        }
        
        [HttpGet]
        [Route("byUser/{idUser:int}")]
        [Authorize(true, true, true)]
        public ActionResult<List<OutputDtoUserTechnology>> GetByIdUser(int idUser)
        {
            return _useCaseGetUserTechnologyByIdUser.Execute(idUser);
        }
        
        [HttpGet]
        [Route("byTechnology/{idTechnology:int}")]
        [Authorize(true, true, true)]
        public ActionResult<List<OutputDtoUserTechnology>> GetByIdTechnology(int idTechnology)
        {
            return _useCaseGetUserTechnologyByIdTechnology.Execute(idTechnology);
        }
        
        [HttpGet]
        [Route("byTechnologyUser/{idTechnology:int},{idUser:int}")]
        [Authorize(true, true, true)]
        public ActionResult<List<OutputDtoUserTechnology>> GetByIdTechnologyIdUser(int idTechnology,int idUser)
        {
            return _useCaseGetUserTechnologyByIdTechnologyIdUser.Execute(idTechnology,idUser);
        }
        
        // Post requests
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(409)]
        [Authorize(true, true, true)]
        public ActionResult<OutputDtoUserTechnology> Create([FromBody] InputDtoUserTechnology inputDtoUserTechnology)
        {
            var result = _useCaseCreateUserTechnology.Execute(inputDtoUserTechnology);
            return result == null ? StatusCode(409, null) : StatusCode(201, result);
        }
        
        // Delete requests
        [HttpDelete]
        [Route("{idUser:int},{idTechnology:int}")]
        [Authorize(true, true, true)]
        public ActionResult Delete(int idUser, int idTechnology)
        {
            var result = _useCaseDeleteUserTechnology.Execute(idUser,idTechnology);
            
            if (result) return Ok();
            return NotFound();
        }
    }
}