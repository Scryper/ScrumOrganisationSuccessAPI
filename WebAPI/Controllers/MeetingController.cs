using System;
using System.Collections.Generic;
using Application.UseCases.Meeting;
using Application.UseCases.Meeting.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ScrumOrganisationSuccessAPI.Controllers
{
    [ApiController]
    [Route("api/meetings")]
    public class MeetingController : ControllerBase
    {
        // Use cases
        private readonly UseCaseGetAllMeetings _useCaseGetAllMeetings;
        private readonly UseCaseCreateMeeting _useCaseCreateMeeting;

        // Constructor
        public MeetingController(
            UseCaseGetAllMeetings useCaseGetAllMeetings,
            UseCaseCreateMeeting useCaseCreateMeeting)
        {
            _useCaseGetAllMeetings = useCaseGetAllMeetings;
            _useCaseCreateMeeting = useCaseCreateMeeting;
        }

        // Get requests
        [HttpGet]
        public ActionResult<List<OutputDtoMeeting>> GetAll()
        {
            return _useCaseGetAllMeetings.Execute();
        }

        // TODO : implement
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<List<OutputDtoMeeting>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        // TODO : implement
        [HttpGet]
        [Route("{idUser:int}")]
        public ActionResult<List<OutputDtoMeeting>> GetByIdUser(int idUser)
        {
            throw new NotImplementedException();
        }

        // TODO : implement
        [HttpGet]
        [Route("{idSprint:int}")]
        public ActionResult<List<OutputDtoMeeting>> GetByIdSprint(int idSprint)
        {
            throw new NotImplementedException();
        }

        // Post requests
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<OutputDtoMeeting> Create([FromBody] InputDtoMeeting inputDtoMeeting)
        {
            return StatusCode(201, _useCaseCreateMeeting.Execute(inputDtoMeeting));
        }

        // Put requests
        // TODO : implement
        [HttpPut]
        [Route("{id:int}")]
        public ActionResult UpdateSchedule(int id, InputDtoMeeting newMeeting)
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