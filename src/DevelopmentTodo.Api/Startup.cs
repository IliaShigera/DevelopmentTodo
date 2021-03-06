using DevelopmentTodo.Api.Extensions;
using DevelopmentTodo.Api.Filters;
using DevelopmentTodo.Application.Handlers.User.Commands;
using DevelopmentTodo.Application.Handlers.User.Queries;
using DevelopmentTodo.Application.MapperConfiguration;
using DevelopmentTodo.Application.Repository;
using DevelopmentTodo.Domain.Interfaces.Repository;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DevelopmentTodo.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureSqlServer(Configuration);

            services.AddMediatR(typeof(GetAllUsersQuery).Assembly);
            services.AddAutoMapper(typeof(UserMapperConfiguration).Assembly);

            services.AddFluentValidation(config =>
                config.RegisterValidatorsFromAssemblyContaining<CreateTaskValidator>());

            services.AddScoped(typeof(IAsyncRepository<>), typeof(EFBaseRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();

            services.AddControllers(config =>
            {
                config.Filters.Add<ValidateRequestModelFilter>();
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DevelopmentTodo.Api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DevelopmentTodo.Api v1"));
            }

            app.UseCustomExceptionHandler();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
