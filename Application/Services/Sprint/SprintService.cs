using System.Collections.Generic;
using System.Linq;
using Infrastructure.SqlServer.Repositories.Sprint;

namespace Application.Services.Sprint
{
    public class SprintService : ISprintService
    {
        private readonly ISprintRepository _sprintRepository;

        public SprintService(ISprintRepository sprintRepository)
        {
            _sprintRepository = sprintRepository;
        }
        
        public List<Domain.Sprint> GetByIdProject(int idProject)
        {
            return _sprintRepository.GetByIdProject(idProject);
        }

        public int FindMaxSprintNumber(List<Domain.Sprint> sprints)
        {
            var sprintNumbers = new int[sprints.Count];
            for (int i = 0 ; i < sprints.Count ; i++)
            {
                sprintNumbers.SetValue(sprints[i].SprintNumber, i);
            }

            return sprintNumbers.Max();
        }
    }
}