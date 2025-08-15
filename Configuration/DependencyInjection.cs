using Microsoft.EntityFrameworkCore;
using SuperHeroesGraphQL.Context;
using SuperHeroesGraphQL.Service;

namespace SuperHeroesGraphQL.Configuration;

public static class DependencyInjection
{
  public static IServiceCollection AddApplicationServices(this IServiceCollection services, string connectionString)
  {
    // DbContext
    services.AddSingleton<SlowQueryInterceptor>();

    services.AddDbContext<AppDbContext>(options =>
    {
      options.UseNpgsql(connectionString);
    });

    // Services
    services.AddScoped<SuperHeroService>();
    services.AddScoped<PowerService>();

    // GraphQL
    services.AddGraphQLServer()
      .AddQueryType<Query>()
      .AddMutationType<Mutation>()
      .AddProjections()
      .AddFiltering()
      .AddSorting();

    return services;
  }
}
