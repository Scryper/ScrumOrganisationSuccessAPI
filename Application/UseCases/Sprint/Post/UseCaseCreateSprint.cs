using Application.UseCases.Sprint.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Sprint;

namespace Application.UseCases.Sprint.Post
{
    public class UseCaseCreateSprint : IWriting<OutputDtoSprint, InputDtoSprint>
    {
        private readonly ISprintRepository _sprintRepository;

        public UseCaseCreateSprint(ISprintRepository sprintRepository)
        {
            _sprintRepository = sprintRepository;
        }
        
        public OutputDtoSprint Execute(InputDtoSprint dto)
        {
            var sprintFromDto = Mapper.GetInstance().Map<Domain.Sprint>(dto);

            var sprint = _sprintRepository.Create(sprintFromDto);

            return Mapper.GetInstance().Map<OutputDtoSprint>(sprint);
        }
    }
}