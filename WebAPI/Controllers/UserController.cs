using System.Collections.Generic;
using System.Web;
using Application.Security.Models;
using Application.UseCases.User.Delete;
using Application.UseCases.User.Dtos;
using Application.UseCases.User.Get;
using Application.UseCases.User.Post;
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
        private readonly UseCaseGetUserByEmail _useCaseGetUserByEmail;
        private readonly UseCaseGetUsersByIdMeeting _useCaseGetUsersByIdMeeting;
        private readonly UseCaseGetUsersByIdProject _useCaseGetUsersByIdProject;

        private readonly UseCaseCreateUser _useCaseCreateUser;

        private readonly UseCaseUpdateUserRole _useCaseUpdateUserRole;
        private readonly UseCaseUpdateUserEmail _useCaseUpdateUserEmail;
        private readonly UseCaseUpdateUserPassword _useCaseUpdateUserPassword;
        private readonly UseCaseUpdateUserFirstNameLastName _useCaseUpdateUserFirstNameLastName;
        
        private readonly UseCaseDeleteUser _useCaseDeleteUser;
        
        private readonly UseCaseAuthenticateUser _useCaseAuthenticateUser;
        
        // Constructor
        public UserController(
            UseCaseGetAllUsers useCaseGetAllUsers,
            UseCaseGetUserById useCaseGetUserById,
            UseCaseGetUserByEmail useCaseGetUserByEmail,
            UseCaseGetUsersByIdMeeting useCaseGetUsersByIdMeeting,
            UseCaseGetUsersByIdProject useCaseGetUsersByIdProject,
            UseCaseCreateUser useCaseCreateUser,
            UseCaseUpdateUserEmail useCaseUpdateUserEmail,
            UseCaseUpdateUserPassword useCaseUpdateUserPassword,
            UseCaseUpdateUserRole useCaseUpdateUserRole,
            UseCaseDeleteUser useCaseDeleteUser,
            UseCaseAuthenticateUser useCaseAuthenticateUser,
            UseCaseUpdateUserFirstNameLastName useCaseUpdateUserFirstNameLastName)
        {
            _useCaseGetAllUsers = useCaseGetAllUsers;
            _useCaseGetUserById = useCaseGetUserById;
            _useCaseGetUserByEmail = useCaseGetUserByEmail;
            _useCaseGetUsersByIdMeeting = useCaseGetUsersByIdMeeting;
            _useCaseGetUsersByIdProject = useCaseGetUsersByIdProject;
            
            _useCaseCreateUser = useCaseCreateUser;

            _useCaseUpdateUserEmail = useCaseUpdateUserEmail;
            _useCaseUpdateUserPassword = useCaseUpdateUserPassword;
            _useCaseUpdateUserRole = useCaseUpdateUserRole;
            _useCaseUpdateUserFirstNameLastName = useCaseUpdateUserFirstNameLastName;
            
            _useCaseDeleteUser = useCaseDeleteUser;
            
            _useCaseAuthenticateUser = useCaseAuthenticateUser;
        }

        // Get requests
        //[Authorize]
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
        [Route("byId/{id:int}")]
        public ActionResult<OutputDtoUser> GetById(int id)
        {
            return _useCaseGetUserById.Execute(id);
        }

        [HttpGet]
        [Route("byEmail/{email:required}")]
        public ActionResult<OutputDtoUser> GetByEmail(string email)
        {
            var correctEmail = HttpUtility.UrlDecode(email);
            return _useCaseGetUserByEmail.Execute(correctEmail);
        }

        // Post requests
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<OutputDtoUser> Create([FromBody] InputDtoUser inputDtoUser)
        {
            return StatusCode(201, _useCaseCreateUser.Execute(inputDtoUser));
        }
        
        // Post requests : authentication
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateRequest model)
        {
            var response = _useCaseAuthenticateUser.Execute(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
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
        [Route("emailUpdate/{idForEmailUpdate:int}")]
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
        [Route("firstNameLastNameUpdate/{idForFirstNameLastNameUpdate:int}")]
        public ActionResult UpdateFirstNameLastName(int idForFirstNameLastNameUpdate, InputDtoUser inputDtoUser)
        {
            var inputDtoUpdate = new InputDtoUpdateUserFirstNameLastName
            {
                Id = idForFirstNameLastNameUpdate,
                InternUser = new InputDtoUpdateUserFirstNameLastName.User
                {
                    FirstName = inputDtoUser.Firstname,
                    LastName = inputDtoUser.Lastname
                }
            };
            
            var result = _useCaseUpdateUserFirstNameLastName.Execute(inputDtoUpdate);

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