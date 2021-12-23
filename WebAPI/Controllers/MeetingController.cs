using System.Collections.Generic;
using Application.UseCases.Meeting;
using Application.UseCases.Meeting.Dtos;
using Application.UseCases.Meeting.Get;
using Application.UseCases.Meeting.Post;
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
    [Route("api/meetings")]
    public class MeetingController : ControllerBase
    {
        // Use cases
        private readonly UseCaseGetAllMeetings _useCaseGetAllMeetings;
        private readonly UseCaseGetMeetingsByIdUser _useCaseGetMeetingsByIdUser;
        
        private readonly UseCaseCreateMeeting _useCaseCreateMeeting;

        // Constructor
        public MeetingController(
            UseCaseGetAllMeetings useCaseGetAllMeetings,
            UseCaseGetMeetingsByIdUser useCaseGetMeetingsByIdUser,
            UseCaseCreateMeeting useCaseCreateMeeting)
        {
            _useCaseGetAllMeetings = useCaseGetAllMeetings;
            _useCaseGetMeetingsByIdUser = useCaseGetMeetingsByIdUser;
            
            _useCaseCreateMeeting = useCaseCreateMeeting;
        }

        // Get requests
        [HttpGet]
        [Authorize(true, true, true)]
        public ActionResult<List<OutputDtoMeeting>> GetAll()
        {
            return _useCaseGetAllMeetings.Execute();
        }

        // If routes would only have {id:int}, even if the name would change, the url would be for both :
        // swagger/data/xxx -> so multiple endpoints matches
        [HttpGet]
        [Route("byUser/{idUser:int}")]
        [Authorize(true, true, true)]
        public ActionResult<List<OutputDtoMeeting>> GetByIdUser(int idUser)
        {
            return _useCaseGetMeetingsByIdUser.Execute(idUser);
        }

        // Post requests
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(409)]
        [Authorize(false, true, false)]
        public ActionResult<OutputDtoMeeting> Create([FromBody] InputDtoMeeting inputDtoMeeting)
        {
            var result = _useCaseCreateMeeting.Execute(inputDtoMeeting);
            return result == null ? StatusCode(409, null) : StatusCode(201, result);
        }
    }
}