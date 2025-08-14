using Microsoft.EntityFrameworkCore;
using SuperHeroesGraphQL.Context.ContextConfiguration;

namespace SuperHeroesGraphQL.Context;
public class AppDbContext : DbContext 
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  { }
  
  protected override void OnModelCreating(ModelBuilder builder)
  {
    Guid[] ids = new Guid[]{ Guid.NewGuid(), Guid.NewGuid() };

    builder.ApplyConfiguration(new SuperHeroContextConfiguration(ids));
    builder.ApplyConfiguration(new PowerContextConfiguration(ids));
    builder.ApplyConfiguration(new MovieContextConfiguration(ids));
  }
}
