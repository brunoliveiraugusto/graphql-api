using GraphQL.Application.Interfaces;
using GraphQL.Application.Services;
using GraphQL.Infra.Context;
using GraphQL.Infra.Interfaces;
using GraphQL.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Infra.IoC.DependencyInjection
{
    public static class Injector
    {
        public static void RegisterDependencyInjection(this IServiceCollection services)
        {
            services.AddDbContext<GraphQLContext>(options => options.UseInMemoryDatabase("GraphQLDB"), ServiceLifetime.Singleton);

            services.AddTransient<ITargetService, TargetService>();

            services.AddTransient<ITargetRepository, TargetRepository>();
        }
    }
}
