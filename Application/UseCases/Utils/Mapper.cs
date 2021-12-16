using Application.UseCases.Comment.Dtos;
using Application.UseCases.DeveloperProject.Dtos;
using Application.UseCases.Meeting.Dtos;
using Application.UseCases.Project.Dtos;
using Application.UseCases.Sprint.Dtos;
using Application.UseCases.Technology.Dtos;
using Application.UseCases.User.Dtos;
using Application.UseCases.UserStory.Dtos;
using AutoMapper;

namespace Application.UseCases.Utils
{
    public static class Mapper
    {
        private static AutoMapper.Mapper _instance;

        public static AutoMapper.Mapper GetInstance()
        {
            return _instance ??= CreateMapper();
        }

        private static AutoMapper.Mapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // cfg.CreateMap<Source, Destination>();
                // From inputs to element
                cfg.CreateMap<InputDtoComment, Domain.Comment>();
                cfg.CreateMap<InputDtoMeeting, Domain.Meeting>();
                cfg.CreateMap<InputDtoProject, Domain.Project>();
                cfg.CreateMap<InputDtoSprint, Domain.Sprint>();
                cfg.CreateMap<InputDtoUser, Domain.User>();
                cfg.CreateMap<InputDtoUserStory, Domain.UserStory>();
                cfg.CreateMap<InputDtoDeveloperProject, Domain.DeveloperProject>();
                cfg.CreateMap<InputDtoTechnology, Domain.Technology>();
                
                // From elements to output
                cfg.CreateMap<Domain.Comment, OutputDtoComment>();
                cfg.CreateMap<Domain.Meeting, OutputDtoMeeting>();
                cfg.CreateMap<Domain.Project, OutputDtoProject>();
                cfg.CreateMap<Domain.Sprint, OutputDtoSprint>();
                cfg.CreateMap<Domain.User, OutputDtoUser>();
                cfg.CreateMap<Domain.UserStory, OutputDtoUserStory>();
                cfg.CreateMap<Domain.DeveloperProject, OutputDtoDeveloperProject>();
                cfg.CreateMap<Domain.Technology, OutputDtoTechnology>();
            });

            return new AutoMapper.Mapper(config);
        }
    }
}