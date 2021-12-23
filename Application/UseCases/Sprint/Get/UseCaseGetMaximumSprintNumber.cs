using Application.Services.Sprint;
using Application.UseCases.Utils;

namespace Application.UseCases.Sprint.Get
{
    public class UseCaseGetMaximumSprintNumber : IQueryFiltering<int, int>
    {
        private readonly ISprintService _sprintService;

        public UseCaseGetMaximumSprintNumber(ISprintService sprintService)
        {
            _sprintService = sprintService;
        }

        public int Execute(int filter)
        {
            var sprints = _sprintService.GetByIdProject(filter);

            return _sprintService.FindMaxSprintNumber(sprints);
        }
    }
}