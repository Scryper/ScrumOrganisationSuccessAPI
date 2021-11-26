using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Sprint;

namespace Application.UseCases.Sprint.Delete
{
    public class UseCaseDeleteSprint : IWriting<bool, int>
    {
        private readonly ISprintRepository _sprintRepository;

        public UseCaseDeleteSprint(ISprintRepository sprintRepository)
        {
            _sprintRepository = sprintRepository;
        }

        public bool Execute(int data)
        {
            return _sprintRepository.Delete(data);
        }
    }
}