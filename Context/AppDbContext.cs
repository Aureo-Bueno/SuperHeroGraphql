using Microsoft.EntityFrameworkCore;
using SuperHeroesGraphQL.Context.ContextConfiguration;

namespace SuperHeroesGraphQL.Context;
public class AppDbContext : DbContext 
{
  private readonly SlowQueryInterceptor _slowQueryInterceptor;
  public AppDbContext(DbContextOptions<AppDbContext> options, SlowQueryInterceptor slowQueryInterceptor)
    : base(options)
  {
    _slowQueryInterceptor = slowQueryInterceptor;
  }
  
  protected override void OnModelCreating(ModelBuilder builder)
  {
    Guid[] ids = new Guid[]{ Guid.NewGuid(), Guid.NewGuid() };

    builder.ApplyConfiguration(new SuperHeroContextConfiguration(ids));
    builder.ApplyConfiguration(new PowerContextConfiguration(ids));
    builder.ApplyConfiguration(new MovieContextConfiguration(ids));
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.AddInterceptors(_slowQueryInterceptor);
  }
}
