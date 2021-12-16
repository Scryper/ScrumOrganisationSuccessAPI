using System.Collections.Generic;
using Application.UseCases.Meeting;
using Application.UseCases.Meeting.Delete;
using Application.UseCases.Meeting.Dtos;
using Application.UseCases.Meeting.Get;
using Application.UseCases.Meeting.Post;
using Application.UseCases.Meeting.Put;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/meetings")]
    public class MeetingController : ControllerBase
    {
        // Use cases
        private readonly UseCaseGetAllMeetings _useCaseGetAllMeetings;
        private readonly UseCaseGetMeetingById _useCaseGetMeetingById;
        private readonly UseCaseGetMeetingsByIdSprint _useCaseGetMeetingsByIdSprint;
        private readonly UseCaseGetMeetingsByIdUser _useCaseGetMeetingsByIdUser;
        
        private readonly UseCaseCreateMeeting _useCaseCreateMeeting;

        private readonly UseCaseUpdateMeetingSchedule _useCaseUpdateMeetingSchedule;

        private readonly UseCaseDeleteMeeting _useCaseDeleteMeeting;

        // Constructor
        public MeetingController(
            UseCaseGetAllMeetings useCaseGetAllMeetings,
            UseCaseGetMeetingById useCaseGetMeetingById,
            UseCaseGetMeetingsByIdSprint useCaseGetMeetingsByIdSprint,
            UseCaseGetMeetingsByIdUser useCaseGetMeetingsByIdUser,
            UseCaseCreateMeeting useCaseCreateMeeting,
            UseCaseUpdateMeetingSchedule useCaseUpdateMeetingSchedule,
            UseCaseDeleteMeeting useCaseDeleteMeeting)
        {
            _useCaseGetAllMeetings = useCaseGetAllMeetings;
            _useCaseGetMeetingById = useCaseGetMeetingById;
            _useCaseGetMeetingsByIdSprint = useCaseGetMeetingsByIdSprint;
            _useCaseGetMeetingsByIdUser = useCaseGetMeetingsByIdUser;
            
            _useCaseCreateMeeting = useCaseCreateMeeting;

            _useCaseUpdateMeetingSchedule = useCaseUpdateMeetingSchedule;
            
            _useCaseDeleteMeeting = useCaseDeleteMeeting;
        }

        // Get requests
        [HttpGet]
        public ActionResult<List<OutputDtoMeeting>> GetAll()
        {
            return _useCaseGetAllMeetings.Execute();
        }

        // If routes would only have {id:int}, even if the name would change, the url would be for both :
        // swagger/data/xxx -> so multiple endpoints matches
        [HttpGet]
        [Route("byId/{id:int}")]
        public ActionResult<OutputDtoMeeting> GetById(int id)
        {
            return _useCaseGetMeetingById.Execute(id);
        }

        [HttpGet]
        [Route("byUser/{idUser:int}")]
        public ActionResult<List<OutputDtoMeeting>> GetByIdUser(int idUser)
        {
            return _useCaseGetMeetingsByIdUser.Execute(idUser);
        }

        [HttpGet]
        [Route("bySprint/{idSprint:int}")]
        public ActionResult<List<OutputDtoMeeting>> GetByIdSprint(int idSprint)
        {
            return _useCaseGetMeetingsByIdSprint.Execute(idSprint);
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
        [HttpPut]
        [Route("{id:int}")]
        public ActionResult UpdateSchedule(int id, InputDtoMeeting newMeeting)
        {
            var inputDtoUpdate = new InputDtoUpdateScheduleMeeting
            {
                Id = id,
                InternMeeting = new InputDtoUpdateScheduleMeeting.Meeting
                {
                    Schedule = newMeeting.Schedule
                }
            };
            
            var result = _useCaseUpdateMeetingSchedule.Execute(inputDtoUpdate);

            if (result) return Ok();
            return NotFound();
        }

        //  Delete requests
        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _useCaseDeleteMeeting.Execute(id);

            if (result) return Ok();
            return NotFound();
        }
    }
}