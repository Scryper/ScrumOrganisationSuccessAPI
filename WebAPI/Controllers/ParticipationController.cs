using System.Collections.Generic;
using Application.UseCases.Participation.Dtos;
using Application.UseCases.Participation.Get;
using Application.UseCases.Participation.Post;
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
    [Route("api/participations")]
    public class ParticipationController : ControllerBase
    {
        // use cases
        private readonly UseCaseGetAllParticipations _useCaseGetAllParticipations;
        private readonly UseCaseGetParticipationsByIdMeeting _useCaseGetParticipationsByIdMeeting;
        private readonly UseCaseGetParticipationsByIdUser _useCaseGetParticipationsByIdUser;
        private readonly UseCaseCreateParticipation _useCaseCreateParticipation;

        public ParticipationController(
            UseCaseGetAllParticipations useCaseGetAllParticipations,
            UseCaseGetParticipationsByIdMeeting useCaseGetParticipationsByIdMeeting,
            UseCaseGetParticipationsByIdUser useCaseGetParticipationsByIdUser,
            UseCaseCreateParticipation useCaseCreateParticipation)
        {
            _useCaseCreateParticipation = useCaseCreateParticipation;
            _useCaseGetAllParticipations = useCaseGetAllParticipations;
            _useCaseGetParticipationsByIdMeeting = useCaseGetParticipationsByIdMeeting;
            _useCaseGetParticipationsByIdUser = useCaseGetParticipationsByIdUser;
        }
        
        // Get requests
        [HttpGet]
        [Authorize(false, true, true)]
        public ActionResult<List<OutputDtoParticipation>> GetAll()
        {
            return _useCaseGetAllParticipations.Execute();
        }
        
        [HttpGet]
        [Route("byUser/{idUser:int}")]
        [Authorize(false, true, true)]
        public ActionResult<List<OutputDtoParticipation>> GetByIdUser(int idUser)
        {
            return _useCaseGetParticipationsByIdUser.Execute(idUser);
        }
        
        [HttpGet]
        [Route("byMeeting/{idMeeting:int}")]
        [Authorize(false, true, true)]
        public ActionResult<List<OutputDtoParticipation>> GetByIdMeeting(int idMeeting)
        {
            return _useCaseGetParticipationsByIdMeeting.Execute(idMeeting);
        }
        
        // Post requests
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(409)]
        [Authorize(false, true, false)]
        public ActionResult<OutputDtoParticipation> Create([FromBody] InputDtoParticipation inputDtoParticipation)
        {
            var result = _useCaseCreateParticipation.Execute(inputDtoParticipation);
            return result == null ? StatusCode(409, null) : StatusCode(201, result);
        }
    }
}