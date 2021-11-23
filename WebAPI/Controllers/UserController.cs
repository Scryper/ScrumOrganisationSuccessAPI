using System;
using System.Collections.Generic;
using Application.UseCases.User;
using Application.UseCases.User.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ScrumOrganisationSuccessAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        // Use cases
        private readonly UseCaseGetAllUsers _useCaseGetAllUsers;
        private readonly UseCaseCreateUser _useCaseCreateUser;
        
        // Constructor
        public UserController(
            UseCaseGetAllUsers useCaseGetAllUsers,
            UseCaseCreateUser useCaseCreateUser)
        {
            _useCaseGetAllUsers = useCaseGetAllUsers;
            _useCaseCreateUser = useCaseCreateUser;
        }
        
        // Get requests
        [HttpGet]
        public ActionResult<List<OutputDtoUser>> GetAll()
        {
            return _useCaseGetAllUsers.Execute();
        }

        // TODO : implement
        [HttpGet]
        [Route("{idProject:int}")]
        public ActionResult<List<OutputDtoUser>> GetByIdProject(int idProject)
        {
            throw new NotImplementedException();
        }
        
        // TODO : implement
        [HttpGet]
        [Route("{idMeeting:int}")]
        public ActionResult<List<OutputDtoUser>> GetByIdMeeting(int idMeeting)
        {
            throw new NotImplementedException();
        }
        
        // TODO : implement
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<OutputDtoUser> GetById(int id)
        {
            throw new NotImplementedException();
        }

        // Post requests
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<OutputDtoUser> Create([FromBody] InputDtoUser inputDtoUser)
        {
            return StatusCode(201, _useCaseCreateUser.Execute(inputDtoUser));
        }

        // Put requests
        // ids have different name because same name for same request type produces api load error
        // TODO : implement
        [HttpPut]
        [Route("{idForRoleUpdate:int}")]
        public ActionResult UpdateRole(int idForRoleUpdate, InputDtoUser inInputDtoUser)
        {
            throw new NotImplementedException();
        }
        
        // TODO : implement
        [HttpPut]
        [Route("{idForPasswordUpdate:int}")]
        public ActionResult UpdatePassword(int idForPasswordUpdate, InputDtoUser inInputDtoUser)
        {
            throw new NotImplementedException();
        }
        
        // TODO : implement
        [HttpPut]
        [Route("{idForEmailUpdate:int}")]
        public ActionResult UpdateEmail(int idForEmailUpdate, InputDtoUser inInputDtoUser)
        {
            throw new NotImplementedException();
        }
        
        // TODO : implement
        [HttpPut]
        [Route("{idForPseudoUpdate:int}")]
        public ActionResult UpdatePseudo(int idForPseudoUpdate, InputDtoUser inInputDtoUser)
        {
            throw new NotImplementedException();
        }

        //  Delete requests
        // TODO : implement
        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}