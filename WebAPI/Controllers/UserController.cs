using System.Collections.Generic;
using Application.UseCases.User;
using Application.UseCases.User.Delete;
using Application.UseCases.User.Dtos;
using Application.UseCases.User.Get;
using Application.UseCases.User.Put;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        // Use cases
        private readonly UseCaseGetAllUsers _useCaseGetAllUsers;
        private readonly UseCaseGetUserById _useCaseGetUserById;
        private readonly UseCaseGetUsersByIdMeeting _useCaseGetUsersByIdMeeting;
        private readonly UseCaseGetUsersByIdProject _useCaseGetUsersByIdProject;
        
        private readonly UseCaseCreateUser _useCaseCreateUser;

        private readonly UseCaseUpdateUserRole _useCaseUpdateUserRole;
        private readonly UseCaseUpdateUserEmail _useCaseUpdateUserEmail;
        private readonly UseCaseUpdateUserPassword _useCaseUpdateUserPassword;
        private readonly UseCaseUpdateUserPseudo _useCaseUpdateUserPseudo;
        
        private readonly UseCaseDeleteUser _useCaseDeleteUser;
        
        // Constructor
        public UserController(
            UseCaseGetAllUsers useCaseGetAllUsers,
            UseCaseGetUserById useCaseGetUserById,
            UseCaseGetUsersByIdMeeting useCaseGetUsersByIdMeeting,
            UseCaseGetUsersByIdProject useCaseGetUsersByIdProject,
            UseCaseCreateUser useCaseCreateUser,
            UseCaseUpdateUserEmail useCaseUpdateUserEmail,
            UseCaseUpdateUserPassword useCaseUpdateUserPassword,
            UseCaseUpdateUserPseudo useCaseUpdateUserPseudo,
            UseCaseUpdateUserRole useCaseUpdateUserRole,
            UseCaseDeleteUser useCaseDeleteUser)
        {
            _useCaseGetAllUsers = useCaseGetAllUsers;
            _useCaseGetUserById = useCaseGetUserById;
            _useCaseGetUsersByIdMeeting = useCaseGetUsersByIdMeeting;
            _useCaseGetUsersByIdProject = useCaseGetUsersByIdProject;
            
            _useCaseCreateUser = useCaseCreateUser;

            _useCaseUpdateUserEmail = useCaseUpdateUserEmail;
            _useCaseUpdateUserPassword = useCaseUpdateUserPassword;
            _useCaseUpdateUserPseudo = useCaseUpdateUserPseudo;
            _useCaseUpdateUserRole = useCaseUpdateUserRole;
            
            _useCaseDeleteUser = useCaseDeleteUser;
        }
        
        // Get requests
        [HttpGet]
        public ActionResult<List<OutputDtoUser>> GetAll()
        {
            return _useCaseGetAllUsers.Execute();
        }

        // If routes would only have {id:int}, even if the name would change, the url would be for both :
        // swagger/data/xxx -> so multiple endpoints matches
        [HttpGet]
        [Route("byProject/{idProject:int}")]
        public ActionResult<List<OutputDtoUser>> GetByIdProject(int idProject)
        {
            return _useCaseGetUsersByIdProject.Execute(idProject);
        }
        
        [HttpGet]
        [Route("byMeeting/{idMeeting:int}")]
        public ActionResult<List<OutputDtoUser>> GetByIdMeeting(int idMeeting)
        {
            return _useCaseGetUsersByIdMeeting.Execute(idMeeting);
        }
        
        [HttpGet]
        [Route("byId{id:int}")]
        public ActionResult<OutputDtoUser> GetById(int id)
        {
            return _useCaseGetUserById.Execute(id);
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
        // If routes would only have {id:int}, even if the name would change, the url would be for both :
        // swagger/data/xxx -> so multiple endpoints matches
        [HttpPut]
        [Route("roleUpdate/{idForRoleUpdate:int}")]
        public ActionResult UpdateRole(int idForRoleUpdate, InputDtoUser inputDtoUser)
        {
            var inputDtoUpdate = new InputDtoUpdateUserRole
            {
                Id = idForRoleUpdate,
                InternUser = new InputDtoUpdateUserRole.User
                {
                    Role = inputDtoUser.Role
                }
            };
            
            var result = _useCaseUpdateUserRole.Execute(inputDtoUpdate);

            if (result) return Ok();
            return NotFound();
        }
        
        [HttpPut]
        [Route("passwordUpdate/{idForPasswordUpdate:int}")]
        public ActionResult UpdatePassword(int idForPasswordUpdate, InputDtoUser inputDtoUser)
        {
            var inputDtoUpdate = new InputDtoUpdateUserPassword
            {
                Id = idForPasswordUpdate,
                InternUser = new InputDtoUpdateUserPassword.User
                {
                    Password = inputDtoUser.Password
                }
            };
            
            var result = _useCaseUpdateUserPassword.Execute(inputDtoUpdate);

            if (result) return Ok();
            return NotFound();
        }
        
        [HttpPut]
        [Route("emailUpdate{idForEmailUpdate:int}")]
        public ActionResult UpdateEmail(int idForEmailUpdate, InputDtoUser inputDtoUser)
        {
            var inputDtoUpdate = new InputDtoUpdateUserEmail
            {
                Id = idForEmailUpdate,
                InternUser = new InputDtoUpdateUserEmail.User
                {
                    Email = inputDtoUser.Email
                }
            };
            
            var result = _useCaseUpdateUserEmail.Execute(inputDtoUpdate);

            if (result) return Ok();
            return NotFound();
        }
        
        [HttpPut]
        [Route("pseudoUpdate{idForPseudoUpdate:int}")]
        public ActionResult UpdatePseudo(int idForPseudoUpdate, InputDtoUser inputDtoUser)
        {
            var inputDtoUpdate = new InputDtoUpdateUserPseudo
            {
                Id = idForPseudoUpdate,
                InternUser = new InputDtoUpdateUserPseudo.User
                {
                    Pseudo = inputDtoUser.Pseudo
                }
            };
            
            var result = _useCaseUpdateUserPseudo.Execute(inputDtoUpdate);

            if (result) return Ok();
            return NotFound();
        }

        //  Delete requests
        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _useCaseDeleteUser.Execute(id);
            
            if (result) return Ok();
            return NotFound();
        }
    }
}