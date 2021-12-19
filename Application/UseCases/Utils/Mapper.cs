using Application.UseCases.Comment.Dtos;
using Application.UseCases.Meeting.Dtos;
using Application.UseCases.Participation.Dtos;
using Application.UseCases.Project.Dtos;
using Application.UseCases.ProjectTechnology.Dtos;
using Application.UseCases.Sprint.Dtos;
using Application.UseCases.SprintUserStory.Dtos;
using Application.UseCases.Technology.Dtos;
using Application.UseCases.User.Dtos;
using Application.UseCases.UserProject.Dtos;
using Application.UseCases.UserStory.Dtos;
using Application.UseCases.UserTechnology.Dtos;
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
                cfg.CreateMap<InputDtoUserProject, Domain.UserProject>();
                cfg.CreateMap<InputDtoTechnology, Domain.Technology>();
                cfg.CreateMap<InputDtoSprintUserStory, Domain.SprintUserStory>();
                cfg.CreateMap<InputDtoUserTechnology, Domain.UserTechnology>();
                cfg.CreateMap<InputDtoProjectTechnology, Domain.ProjectTechnology>();
                cfg.CreateMap<InputDtoParticipation, Domain.Participation>();

                // From elements to output
                cfg.CreateMap<Domain.Comment, OutputDtoComment>();
                cfg.CreateMap<Domain.Meeting, OutputDtoMeeting>();
                cfg.CreateMap<Domain.Project, OutputDtoProject>();
                cfg.CreateMap<Domain.Sprint, OutputDtoSprint>();
                cfg.CreateMap<Domain.User, OutputDtoUser>();
                cfg.CreateMap<Domain.UserStory, OutputDtoUserStory>();
                cfg.CreateMap<Domain.UserProject, OutputDtoUserProject>();
                cfg.CreateMap<Domain.Technology, OutputDtoTechnology>();
                cfg.CreateMap<Domain.SprintUserStory, OutputDtoSprintUserStory>();
                cfg.CreateMap<Domain.UserTechnology, OutputDtoUserTechnology>();
                cfg.CreateMap<Domain.ProjectTechnology,OutputDtoProjectTechnology>();
                cfg.CreateMap<Domain.Participation, OutputDtoParticipation>();
            });

            return new AutoMapper.Mapper(config);
        }
    }
}