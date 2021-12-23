using Application.Security;
using Application.Security.Models;
using Application.Services.Sprint;
using Application.Services.User;
using Application.UseCases.Comment.Delete;
using Application.UseCases.Comment.Get;
using Application.UseCases.Comment.Post;
using Application.UseCases.Comment.Put;
using Application.UseCases.DeveloperProject.Post;
using Application.UseCases.DeveloperProject.Put;
using Application.UseCases.Meeting;
using Application.UseCases.Meeting.Get;
using Application.UseCases.Meeting.Post;
using Application.UseCases.Participation.Get;
using Application.UseCases.Participation.Post;
using Application.UseCases.Project;
using Application.UseCases.Project.Get;
using Application.UseCases.Project.Post;
using Application.UseCases.Project.Put;
using Application.UseCases.ProjectTechnology.Delete;
using Application.UseCases.ProjectTechnology.Get;
using Application.UseCases.ProjectTechnology.Post;
using Application.UseCases.Sprint.Get;
using Application.UseCases.Sprint.Post;
using Application.UseCases.SprintUserStory.Get;
using Application.UseCases.SprintUserStory.Post;
using Application.UseCases.Technology.Get;
using Application.UseCases.User.Delete;
using Application.UseCases.User.Get;
using Application.UseCases.User.Post;
using Application.UseCases.User.Put;
using Application.UseCases.UserProject.Delete;
using Application.UseCases.UserProject.Get;
using Application.UseCases.UserStory;
using Application.UseCases.UserStory.Delete;
using Application.UseCases.UserStory.Get;
using Application.UseCases.UserStory.Post;
using Application.UseCases.UserStory.Put;
using Application.UseCases.UserTechnology.Delete;
using Application.UseCases.UserTechnology.Get;
using Application.UseCases.UserTechnology.Post;
using Infrastructure.SqlServer.Repositories.Comment;
using Infrastructure.SqlServer.Repositories.Meeting;
using Infrastructure.SqlServer.Repositories.Participation;
using Infrastructure.SqlServer.Repositories.Project;
using Infrastructure.SqlServer.Repositories.ProjectTechnology;
using Infrastructure.SqlServer.Repositories.Sprint;
using Infrastructure.SqlServer.Repositories.SprintUserStory;
using Infrastructure.SqlServer.Repositories.Technology;
using Infrastructure.SqlServer.Repositories.User;
using Infrastructure.SqlServer.Repositories.UserProject;
using Infrastructure.SqlServer.Repositories.UserStory;
using Infrastructure.SqlServer.Repositories.UserTechnology;
using Infrastructure.SqlServer.System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using UserProjectRepository = Infrastructure.SqlServer.Repositories.UserProject.UserProjectRepository;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            // Security
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            
            // Add repositories
            // services.AddSingleton<Interface, Implementation>();
            services.AddSingleton<ICommentRepository, CommentRepository>();
            services.AddSingleton<IMeetingRepository, MeetingRepository>();
            services.AddSingleton<IProjectRepository, ProjectRepository>();
            services.AddSingleton<ISprintRepository, SprintRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IUserStoryRepository, UserStoryRepository>();
            services.AddSingleton<IUserProjectRepository, UserProjectRepository>();
            services.AddSingleton<ITechnologyRepository, TechnologyRepository>();
            services.AddSingleton<ISprintUserStoryRepository, SprintUserStoryRepository>();
            services.AddSingleton<IUserTechnologyRepository, UserTechnologyRepository>();
            services.AddSingleton<IProjectTechnologyRepository, ProjectTechnologyRepository>();
            services.AddSingleton<IParticipationRepository, ParticipationRepository>();
            
            services.AddSingleton<IDatabaseManager, DatabaseManager>();
            
            // Add services
            // services.AddSingleton<Interface, Implementation>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<ISprintService, SprintService>();
            
            // Add use cases
            // Comments use cases
            services.AddSingleton<UseCaseGetCommentsByIdUserStory>();

            services.AddSingleton<UseCaseCreateComment>();
            
            services.AddSingleton<UseCaseUpdateCommentContent>();
            
            services.AddSingleton<UseCaseDeleteComment>();
            
            // Meetings use cases
            services.AddSingleton<UseCaseGetAllMeetings>();
            services.AddSingleton<UseCaseGetMeetingsByIdUser>();
            
            services.AddSingleton<UseCaseCreateMeeting>();

            // Projects use cases
            services.AddSingleton<UseCaseGetAllProjects>();
            services.AddSingleton<UseCaseGetProjectById>();
            services.AddSingleton<UseCaseGetProjectByName>();
            services.AddSingleton<UseCaseGetByIdUserActiveProject>();
            services.AddSingleton<UseCaseGetActiveProjects>();
            services.AddSingleton<UseCaseGetProjectByIdUserNotFinishedIsLinkedToUser>();

            services.AddSingleton<UseCaseCreateProject>();
            
            services.AddSingleton<UseCaseUpdateProjectStatus>();
            
            // Sprints use cases
            services.AddSingleton<UseCaseGetAllSprints>();
            services.AddSingleton<UseCaseGetSprintsByIdProject>();
            services.AddSingleton<UseCaseGetSprintById>();
            services.AddSingleton<UseCaseGetMaximumSprintNumber>();

            services.AddSingleton<UseCaseCreateSprint>();
            
            // Users use cases
            services.AddSingleton<UseCaseGetAllUsers>();
            services.AddSingleton<UseCaseGetUserById>();
            services.AddSingleton<UseCaseGetUserByEmail>();
            services.AddSingleton<UseCaseGetUsersByIdProject>();
            services.AddSingleton<UseCaseGetUsersByIdProjectIsWorking>();
            services.AddSingleton<UseCaseGetUsersByIdMeeting>();
            services.AddSingleton<UseCaseGetUserDaysOfXP>();
            services.AddSingleton<UseCaseGetUserByIdProjectIsApplying>();
            services.AddSingleton<UseCaseGetUsersByCommentOnUserStory>();

            services.AddSingleton<UseCaseCreateUser>();
            services.AddSingleton<UseCaseAuthenticateUser>();
            
            services.AddSingleton<UseCaseUpdateUserEmail>();
            services.AddSingleton<UseCaseUpdateUserPassword>();
            services.AddSingleton<UseCaseUpdateUserRole>();
            services.AddSingleton<UseCaseUpdateUserFirstNameLastName>();
            
            services.AddSingleton<UseCaseDeleteUser>();
            
            // User stories use cases
            services.AddSingleton<UseCaseGetAllUserStories>();
            services.AddSingleton<UseCaseGetUserStoriesByIdProject>();
            services.AddSingleton<UseCaseGetUserStoryById>();
            services.AddSingleton<UseCaseGetUserStoriesByIdSprint>();
            
            
            services.AddSingleton<UseCaseCreateUserStory>();

            services.AddSingleton<UseCaseUpdateUserStory>();
            
            services.AddSingleton<UseCaseDeleteUserStory>();
            
            // DeveloperProject use cases
            services.AddSingleton<UseCaseGetAllUserProjects>();
            services.AddSingleton<UseCaseGetUserProjectsByIdDeveloper>();
            services.AddSingleton<UseCaseGetUserProjectsByIdDeveloperIsAppliance>();
            services.AddSingleton<UseCaseGetByIdUserIdProject>();
            services.AddSingleton<UseCaseGetUserProjectByIdDeveloperIfIsWorking>();
            services.AddSingleton<UseCaseGetUserProjectByIdDeveloperIfIsNotWorking>();

            services.AddSingleton<UseCaseCreateDeveloperProject>();
            
            services.AddSingleton<UseCaseUpdateDeveloperProject>();
            
            services.AddSingleton<UseCaseDeleteUserProject>();
            
            // Technology uses cases
            services.AddSingleton<UseCaseGetAllTechnologies>();
            services.AddSingleton<UseCaseGetTechnologyByName>();
            
            // SprintUserStory use cases
            services.AddSingleton<UseCaseGetAllSprintUserStory>();
            services.AddSingleton<UseCaseGetSprintUserStoryByIdSprint>();
            
            services.AddSingleton<UseCaseCreateSprintUserStory>();
            
            //UserTechnology uses cases
            services.AddSingleton<UseCaseGetAllUserTechnologies>();
            services.AddSingleton<UseCaseGetUserTechnologyByIdUser>();
            services.AddSingleton<UseCaseGetUserTechnologyByIdTechnology>();
            services.AddSingleton<UseCaseGetUserTechnologyByIdTechnologyIdUser>();
            services.AddSingleton<UseCaseDeleteUserTechnology>();
            services.AddSingleton<UseCaseCreateUserTechnology>();
            
            //ProjectTechnology uses cases
            services.AddSingleton<UseCaseGetAllProjectTechnologies>();
            services.AddSingleton<UseCaseGetProjectTechnologiesByIdProject>();
            services.AddSingleton<UseCaseGetProjectTechnologiesByIdTechnology>();
            services.AddSingleton<UseCaseDeleteProjectTechnology>();
            services.AddSingleton<UseCaseCreateProjectTechnologies>();
            
            //Participation uses cases
            services.AddSingleton<UseCaseGetAllParticipations>();
            services.AddSingleton<UseCaseGetParticipationsByIdMeeting>();
            services.AddSingleton<UseCaseGetParticipationsByIdUser>();
            services.AddSingleton<UseCaseCreateParticipation>();

            services.AddControllers();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "ScrumOrganisationSuccessAPI", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ScrumOrganisationSuccessAPI v1");
                });
            }
            else
            {
                app.UseHttpsRedirection();

            }
            
            app.UseRouting();

            app.UseAuthorization();
            
            app.UseMiddleware<JwtMiddleware>();
            
            app.UseCors(builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}