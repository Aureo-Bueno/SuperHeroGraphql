using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperHeroesGraphQL.Entities;

namespace SuperHeroesGraphQL.Context.ContextConfiguration;
public class PowerContextConfiguration : IEntityTypeConfiguration<Power>
{
  Guid[] _ids;

  public PowerContextConfiguration(Guid[] ids)
  {
    _ids = ids;
  }

  public void Configure(EntityTypeBuilder<Power> builder)
  {
    builder.HasData(
      new Power
      {
        Id = Guid.NewGuid(),
        SuperPower = "Superhuman strength, speed, stamina and durability",
        Description = "Superman's powers include incredible strength, the ability to fly, and invulnerability.",
        SuperHeroId = _ids[0],
      },
      new Power
      {
        Id = Guid.NewGuid(),
        SuperPower = "Genius-level intellect",
        Description = "Batman's primary character traits can be summarized as \"wealthy, physical prowess, deductive abilities and obsession\".",
        SuperHeroId = _ids[1],
      }
    );
  }
        
}
