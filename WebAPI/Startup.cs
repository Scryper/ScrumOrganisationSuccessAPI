using Application.Services.Comment;
using Application.Services.Meeting;
using Application.Services.Project;
using Application.Services.Sprint;
using Application.Services.User;
using Application.Services.UserStory;
using Application.UseCases.Comment;
using Application.UseCases.Comment.Delete;
using Application.UseCases.Comment.Get;
using Application.UseCases.Comment.Put;
using Application.UseCases.Meeting;
using Application.UseCases.Meeting.Delete;
using Application.UseCases.Meeting.Get;
using Application.UseCases.Meeting.Put;
using Application.UseCases.Project;
using Application.UseCases.Sprint;
using Application.UseCases.User;
using Application.UseCases.UserStory;
using Infrastructure.SqlServer.Repositories.Comment;
using Infrastructure.SqlServer.Repositories.Meeting;
using Infrastructure.SqlServer.Repositories.Project;
using Infrastructure.SqlServer.Repositories.Sprint;
using Infrastructure.SqlServer.Repositories.User;
using Infrastructure.SqlServer.Repositories.UserStory;
using Infrastructure.SqlServer.System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

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
            // Add repositories
            // services.AddSingleton<Interface, Implementation>();
            services.AddSingleton<ICommentRepository, CommentRepository>();
            services.AddSingleton<IMeetingRepository, MeetingRepository>();
            services.AddSingleton<IProjectRepository, ProjectRepository>();
            services.AddSingleton<ISprintRepository, SprintRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IUserStoryRepository, UserStoryRepository>();
            
            services.AddSingleton<IDatabaseManager, DatabaseManager>();
            
            // Add services
            // services.AddSingleton<Interface, Implementation>();
            services.AddSingleton<ICommentService, CommentService>();
            services.AddSingleton<IMeetingService, MeetingService>();
            services.AddSingleton<IProjectService, ProjectService>();
            services.AddSingleton<ISprintService, SprintService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IUserStoryService, UserStoryService>();
            
            // Add use cases
            // Comments use cases
            services.AddSingleton<UseCaseGetAllComments>();
            services.AddSingleton<UseCaseGetCommentById>();
            services.AddSingleton<UseCaseGetCommentsByIdUserStory>();

            services.AddSingleton<UseCaseCreateComment>();
            
            services.AddSingleton<UseCaseUpdateCommentContent>();
            
            services.AddSingleton<UseCaseDeleteComment>();
            
            // Meetings use cases
            services.AddSingleton<UseCaseGetAllMeetings>();
            services.AddSingleton<UseCaseGetMeetingById>();
            services.AddSingleton<UseCaseGetMeetingsByIdSprint>();
            services.AddSingleton<UseCaseGetMeetingsByIdUser>();
            
            services.AddSingleton<UseCaseCreateMeeting>();
            
            services.AddSingleton<UseCaseUpdateMeetingSchedule>();
            
            services.AddSingleton<UseCaseDeleteMeeting>();

            // Projects use cases
            services.AddSingleton<UseCaseGetAllProjects>();
            services.AddSingleton<UseCaseCreateProject>();
            
            // Sprints use cases
            services.AddSingleton<UseCaseGetAllSprints>();
            services.AddSingleton<UseCaseCreateSprint>();
            
            // Users use cases
            services.AddSingleton<UseCaseGetAllUsers>();
            services.AddSingleton<UseCaseCreateUser>();
            
            // User stories use cases
            services.AddSingleton<UseCaseGetAllUserStories>();
            services.AddSingleton<UseCaseCreateUserStory>();
            
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

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}