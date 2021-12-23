using System.Collections.Generic;
using System.Web;
using Application.Security.Models;
using Application.UseCases.User.Delete;
using Application.UseCases.User.Dtos;
using Application.UseCases.User.Get;
using Application.UseCases.User.Post;
using Application.UseCases.User.Put;
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
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        // Use cases
        private readonly UseCaseGetAllUsers _useCaseGetAllUsers;
        private readonly UseCaseGetUserById _useCaseGetUserById;
        private readonly UseCaseGetUserByEmail _useCaseGetUserByEmail;
        private readonly UseCaseGetUsersByIdMeeting _useCaseGetUsersByIdMeeting;
        private readonly UseCaseGetUsersByIdProject _useCaseGetUsersByIdProject;
        private readonly UseCaseGetUserDaysOfXP _useCaseGetUserDaysOfXp;
        private readonly UseCaseGetUsersByIdProjectIsWorking _useCaseGetUsersByIdProjectIsWorking;
        private readonly UseCaseGetUserByIdProjectIsApplying _useCaseGetUserByIdProjectIsApplying;
        private readonly UseCaseGetUsersByCommentOnUserStory _useCaseGetUsersByCommentOnUserStory;

        private readonly UseCaseCreateUser _useCaseCreateUser;

        private readonly UseCaseUpdateUserRole _useCaseUpdateUserRole;
        private readonly UseCaseUpdateUserFirstNameLastName _useCaseUpdateUserFirstNameLastName;
        
        private readonly UseCaseAuthenticateUser _useCaseAuthenticateUser;
        
        // Constructor
        public UserController(
            UseCaseGetAllUsers useCaseGetAllUsers,
            UseCaseGetUserById useCaseGetUserById,
            UseCaseGetUserByEmail useCaseGetUserByEmail,
            UseCaseGetUsersByIdMeeting useCaseGetUsersByIdMeeting,
            UseCaseGetUsersByIdProject useCaseGetUsersByIdProject,
            UseCaseCreateUser useCaseCreateUser,
            UseCaseUpdateUserRole useCaseUpdateUserRole,
            UseCaseAuthenticateUser useCaseAuthenticateUser,
            UseCaseUpdateUserFirstNameLastName useCaseUpdateUserFirstNameLastName,
            UseCaseGetUserDaysOfXP useCaseUserDaysOfXp,
            UseCaseGetUsersByIdProjectIsWorking useCaseGetUsersByIdProjectIsWorking,
            UseCaseGetUserByIdProjectIsApplying useCaseGetUserByIdProjectIsApplying,
            UseCaseGetUsersByCommentOnUserStory usecaseGetUsersByCommentOnUserStory)
        {
            _useCaseGetAllUsers = useCaseGetAllUsers;
            _useCaseGetUserById = useCaseGetUserById;
            _useCaseGetUserByEmail = useCaseGetUserByEmail;
            _useCaseGetUsersByIdMeeting = useCaseGetUsersByIdMeeting;
            _useCaseGetUsersByIdProject = useCaseGetUsersByIdProject;
            _useCaseGetUserDaysOfXp = useCaseUserDaysOfXp;
            _useCaseGetUsersByIdProjectIsWorking = useCaseGetUsersByIdProjectIsWorking;
            _useCaseGetUserByIdProjectIsApplying = useCaseGetUserByIdProjectIsApplying;
            _useCaseGetUsersByCommentOnUserStory = usecaseGetUsersByCommentOnUserStory;
            
            _useCaseCreateUser = useCaseCreateUser;

            _useCaseUpdateUserRole = useCaseUpdateUserRole;
            _useCaseUpdateUserFirstNameLastName = useCaseUpdateUserFirstNameLastName;
            
            _useCaseAuthenticateUser = useCaseAuthenticateUser;
        }

        // Get requests
        [HttpGet]
        [Authorize(true, true, true)]
        public ActionResult<List<OutputDtoUser>> GetAll()
        {
            return _useCaseGetAllUsers.Execute();
        }

        // If routes would only have {id:int}, even if the name would change, the url would be for both :
        // swagger/data/xxx -> so multiple endpoints matches
        [HttpGet]
        [Route("byProject/{idProject:int}")]
        [Authorize(true, true, true)]
        public ActionResult<List<OutputDtoUser>> GetByIdProject(int idProject)
        {
            return _useCaseGetUsersByIdProject.Execute(idProject);
        }
        
        [HttpGet]
        [Route("byProjectIsWorking/{idProject:int}")]
        [Authorize(true, true, true)]
        public ActionResult<List<OutputDtoUser>> GetByIdProjectIsWorking(int idProject)
        {
            return _useCaseGetUsersByIdProjectIsWorking.Execute(idProject);
        }
        
        [HttpGet]
        [Route("byMeeting/{idMeeting:int}")]
        [Authorize(true, true, true)]
        public ActionResult<List<OutputDtoUser>> GetByIdMeeting(int idMeeting)
        {
            return _useCaseGetUsersByIdMeeting.Execute(idMeeting);
        }
        
        [HttpGet]
        [Route("byId/{id:int}")]
        [Authorize(true, true, true)]
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
        
        [HttpGet]
        [Route("daysOfXP/{idUser:int}")]
        [Authorize(true, true, true)]
        public int GetDaysOfXP(int idUser)
        {
            return _useCaseGetUserDaysOfXp.Execute(idUser);
        }

        [HttpGet]
        [Route("byProjectIsApplying/{idProject:int}")]
        [Authorize(false, false, true)]
        public ActionResult<List<OutputDtoUser>> GetByIdProjectIsApplying(int idProject)
        {
            return _useCaseGetUserByIdProjectIsApplying.Execute(idProject);
        }
        
        [HttpGet]
        [Route("byCommentOnUserStory/{idUserStory:int}")]
        [Authorize(true, true, true)]
        public ActionResult<List<OutputDtoUser>> GetByCommentOnUserStory(int idUserStory)
        {
            return _useCaseGetUsersByCommentOnUserStory.Execute(idUserStory);
        }
        
        // Post requests
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(409)]
        public ActionResult<OutputDtoUser> Create([FromBody] InputDtoUser inputDtoUser)
        {
            var result = _useCaseCreateUser.Execute(inputDtoUser);
            return result == null ? StatusCode(409, null) : StatusCode(201, result);
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
        [Authorize(true, true, true)]
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
        /*
        [HttpPut]
        [Authorize]
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
        }*/

        [HttpPut]
        [Route("firstNameLastNameUpdate/{idForFirstNameLastNameUpdate:int}")]
        [Authorize(true, true, true)]
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
        
        /*
        //  Delete requests
        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _useCaseDeleteUser.Execute(id);
            
            if (result) return Ok();
            return NotFound();
        }*/
    }
}
