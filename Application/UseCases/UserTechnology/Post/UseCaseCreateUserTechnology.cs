using Application.UseCases.UserTechnology.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.UserTechnology;

namespace Application.UseCases.UserTechnology.Post
{
    public class UseCaseCreateUserTechnology : IWriting<OutputDtoUserTechnology,InputDtoUserTechnology>
    {
        private readonly IUserTechnologyRepository _userTechnologyRepository;

        public UseCaseCreateUserTechnology(IUserTechnologyRepository userTechnologyRepository)
        {
            _userTechnologyRepository = userTechnologyRepository;
        }

        public OutputDtoUserTechnology Execute(InputDtoUserTechnology data)
        {
            var userTechnologyFromDb = Mapper.GetInstance().Map<Domain.UserTechnology>(data);
            
            var userTechnology = _userTechnologyRepository.Create(userTechnologyFromDb);
            
            return Mapper.GetInstance().Map<OutputDtoUserTechnology>(userTechnology);
        }
    }
}