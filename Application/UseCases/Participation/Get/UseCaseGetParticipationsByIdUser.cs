using System.Collections.Generic;
using Application.UseCases.Participation.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Participation;

namespace Application.UseCases.Participation.Get
{
    public class UseCaseGetParticipationsByIdUser : IQueryFiltering<List<OutputDtoParticipation>,int>
    {
        private readonly  IParticipationRepository _participationRepository;

        public UseCaseGetParticipationsByIdUser(IParticipationRepository participationRepository)
        {
            _participationRepository = participationRepository;
        }
        
        public List<OutputDtoParticipation> Execute(int filter)
        {
            var participations = _participationRepository.GetByIdUser(filter);

            return Mapper.GetInstance().Map<List<OutputDtoParticipation>>(participations);
        }
    }
}