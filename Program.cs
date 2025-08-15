using SuperHeroesGraphQL.Configuration;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);
{
  builder.Services.AddControllers();
  builder.Services.AddEndpointsApiExplorer();
  builder.Services.AddSwaggerGen();
  
  builder.Services.AddApplicationServices(builder.Configuration.GetConnectionString("DefaultConnection")
                                           ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found."));
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
