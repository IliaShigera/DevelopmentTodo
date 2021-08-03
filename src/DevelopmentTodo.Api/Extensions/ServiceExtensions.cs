using DevelopmentTodo.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevelopmentTodo.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlServer(this IServiceCollection service, IConfiguration config)
        {
            var connectionStrings = "Default";

            service.AddDbContext<DataContext>(options =>
                options.UseSqlServer(config.GetConnectionString(connectionStrings)));
        }
    }
}
