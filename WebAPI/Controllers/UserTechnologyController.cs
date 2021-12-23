using System.Collections.Generic;
using Application.UseCases.UserTechnology.Delete;
using Application.UseCases.UserTechnology.Dtos;
using Application.UseCases.UserTechnology.Get;
using Application.UseCases.UserTechnology.Post;
using Microsoft.AspNetCore.Mvc;


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
        private readonly UseCaseCreateUserTechnology _useCaseCreateUserTechnology;
        private readonly UseCaseDeleteUserTechnology _useCaseDeleteUserTechnology;

        public UserTechnologyController(
            UseCaseGetAllUserTechnologies useCaseGetAllUserTechnologies,
            UseCaseGetUserTechnologyByIdTechnology useCaseGetUserTechnologyByIdTechnology,
            UseCaseGetUserTechnologyByIdUser useCaseGetUserTechnologyByIdUser,
            UseCaseCreateUserTechnology useCaseCreateUserTechnology,
            UseCaseDeleteUserTechnology useCaseDeleteUserTechnology)
        {
            _useCaseGetAllUserTechnologies = useCaseGetAllUserTechnologies;
            _useCaseGetUserTechnologyByIdTechnology = useCaseGetUserTechnologyByIdTechnology;
            _useCaseGetUserTechnologyByIdUser = useCaseGetUserTechnologyByIdUser;
            _useCaseCreateUserTechnology = useCaseCreateUserTechnology;
            _useCaseDeleteUserTechnology = useCaseDeleteUserTechnology;
        }
        
        // Get requests
        [HttpGet]
        public ActionResult<List<OutputDtoUserTechnology>> GetAll()
        {
            return _useCaseGetAllUserTechnologies.Execute();
        }
        
        [HttpGet]
        [Route("byUser/{idUser:int}")]
        public ActionResult<List<OutputDtoUserTechnology>> GetByIdUser(int idUser)
        {
            return _useCaseGetUserTechnologyByIdUser.Execute(idUser);
        }
        
        [HttpGet]
        [Route("byTechnology/{idTechnology:int}")]
        public ActionResult<List<OutputDtoUserTechnology>> GetByIdTechnology(int idTechnology)
        {
            return _useCaseGetUserTechnologyByIdTechnology.Execute(idTechnology);
        }
        
        // Post requests
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<OutputDtoUserTechnology> Create([FromBody] InputDtoUserTechnology inputDtoUserTechnology)
        {
            var result = _useCaseCreateUserTechnology.Execute(inputDtoUserTechnology);
            return result == null ? null : StatusCode(201, result);
        }
        
        // Delete requests
        [HttpDelete]
        [Route("{idUser:int},{idTechnology:int}")]
        public ActionResult Delete(int idUser, int idTechnology)
        {
            var result = _useCaseDeleteUserTechnology.Execute(idUser,idTechnology);
            
            if (result) return Ok();
            return NotFound();
        }
    }
}