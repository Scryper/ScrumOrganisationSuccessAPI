using System.Collections.Generic;
using Application.UseCases.Participation.Delete;
using Application.UseCases.Participation.Dtos;
using Application.UseCases.Participation.Get;
using Application.UseCases.Participation.Post;
using Application.UseCases.UserTechnology.Dtos;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    
    [ApiController]
    [Route("api/participations")]
    public class ParticipationController : ControllerBase
    {
        // use cases
        private readonly UseCaseGetAllParticipations _useCaseGetAllParticipations;
        private readonly UseCaseGetParticipationsByIdMeeting _useCaseGetParticipationsByIdMeeting;
        private readonly UseCaseGetParticipationsByIdUser _useCaseGetParticipationsByIdUser;
        private readonly UseCaseDeleteParticipation _useCaseDeleteParticipation;
        private readonly UseCaseCreateParticipation _useCaseCreateParticipation;

        public ParticipationController(
            UseCaseGetAllParticipations useCaseGetAllParticipations,
            UseCaseGetParticipationsByIdMeeting useCaseGetParticipationsByIdMeeting,
            UseCaseGetParticipationsByIdUser useCaseGetParticipationsByIdUser,
            UseCaseCreateParticipation useCaseCreateParticipation,
            UseCaseDeleteParticipation useCaseDeleteParticipation
        )
        {
            _useCaseCreateParticipation = useCaseCreateParticipation;
            _useCaseDeleteParticipation = useCaseDeleteParticipation;
            _useCaseGetAllParticipations = useCaseGetAllParticipations;
            _useCaseGetParticipationsByIdMeeting = useCaseGetParticipationsByIdMeeting;
            _useCaseGetParticipationsByIdUser = useCaseGetParticipationsByIdUser;
        }
        
        // Get requests
        [HttpGet]
        public ActionResult<List<OutputDtoParticipation>> GetAll()
        {
            return _useCaseGetAllParticipations.Execute();
        }
        
        [HttpGet]
        [Route("byUser/{idUser:int}")]
        public ActionResult<List<OutputDtoParticipation>> GetByIdUser(int idUser)
        {
            return _useCaseGetParticipationsByIdUser.Execute(idUser);
        }
        
        [HttpGet]
        [Route("byMeeting/{idMeeting:int}")]
        public ActionResult<List<OutputDtoParticipation>> GetByIdMeeting(int idMeeting)
        {
            return _useCaseGetParticipationsByIdMeeting.Execute(idMeeting);
        }
        
        // Post requests
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(409)]
        public ActionResult<OutputDtoParticipation> Create([FromBody] InputDtoParticipation inputDtoParticipation)
        {
            var result = _useCaseCreateParticipation.Execute(inputDtoParticipation);
            return result == null ? StatusCode(409, null) : StatusCode(201, result);
        }
        
        // Delete requests
        [HttpDelete]
        [Route("{idUser:int},{idMeeting:int}")]
        public ActionResult Delete(int idUser, int idMeeting)
        {
            var result = _useCaseDeleteParticipation.Execute(idUser,idMeeting);
            
            if (result) return Ok();
            return NotFound();
        }
    }
}