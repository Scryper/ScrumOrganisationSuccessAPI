using Application.UseCases.Sprint.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Sprint;

namespace Application.UseCases.Sprint.Put
{
    public class UseCaseUpdateSprintProgression : IWriting<bool, InputDtoUpdateSprintProgression>
    {
        private readonly ISprintRepository _sprintRepository;

        public UseCaseUpdateSprintProgression(ISprintRepository sprintRepository)
        {
            _sprintRepository = sprintRepository;
        }

        public bool Execute(InputDtoUpdateSprintProgression data)
        {
            return _sprintRepository.UpdateProgression(data.Id, data.InternSprint.Progression);
        }
    }
}