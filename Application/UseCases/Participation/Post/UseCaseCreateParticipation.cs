using Application.UseCases.Participation.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Participation;

namespace Application.UseCases.Participation.Post
{
    public class UseCaseCreateParticipation : IWriting<OutputDtoParticipation, InputDtoParticipation>
    {
        private readonly IParticipationRepository _participationRepository;

        public UseCaseCreateParticipation(IParticipationRepository participationRepository)
        {
            _participationRepository = participationRepository;
        }
        
        public OutputDtoParticipation Execute(InputDtoParticipation data)
        {
            var participationFromDb = Mapper.GetInstance().Map<Domain.Participation>(data);
            var participation = _participationRepository.Create(participationFromDb);

            return Mapper.GetInstance().Map<OutputDtoParticipation>(participation);
        }
    }
}