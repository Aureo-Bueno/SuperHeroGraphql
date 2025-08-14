using Microsoft.EntityFrameworkCore;
using SuperHeroesGraphQL.Context;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);
{
  builder.Services.AddControllers();
  builder.Services.AddEndpointsApiExplorer();
  builder.Services.AddSwaggerGen();

  builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
  });


  builder.Services.AddGraphQLServer().AddQueryType<Query>().AddMutationType<Mutation>().AddProjections().AddFiltering().AddSorting();
}

WebApplication? app = builder.Build();
{
  if (app.Environment.IsDevelopment())
  {
    app.UseSwagger();
    app.UseSwaggerUI();
  }

  app.UseHttpsRedirection();

  app.UseAuthorization();

  app.MapControllers();

  app.MapGraphQL("/graphql");

  app.Run();
}
