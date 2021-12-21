using System.Collections.Generic;

namespace Application.Services.Sprint
{
    public interface ISprintService
    {
        public List<Domain.Sprint> GetByIdProject(int idProject);
        int FindMaxSprintNumber(List<Domain.Sprint> sprints);
    }
}