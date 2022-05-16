using GraphQL.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Infra.IoC
{
    public static class Injector
    {
        public static void RegisterDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<Database>();
            services.AddDbContext<Database>(options => options.UseSqlServer(configuration.GetConnectionString("GraphQLDatabase")));
        }
    }
}
