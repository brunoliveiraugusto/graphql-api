using GraphQL.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Infra.IoC.DependencyInjection
{
    public static class Injector
    {
        public static void RegisterDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GraphQLContext>(options => options.UseInMemoryDatabase("GraphQLDB"), ServiceLifetime.Singleton);

            //services.AddTransient<ITargetService>
        }
    }
}
