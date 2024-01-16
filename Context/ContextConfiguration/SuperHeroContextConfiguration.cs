using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperHeroesGraphQL.Entities;

namespace SuperHeroesGraphQL.Context.ContextConfiguration;
public class SuperHeroContextConfiguration : IEntityTypeConfiguration<SuperHero>
{
  private Guid[] _ids;

  public SuperHeroContextConfiguration(Guid[] ids)
  {
    _ids = ids;
  }

  public void Configure(EntityTypeBuilder<SuperHero> builder)
  {
    builder.HasData(
      new SuperHero {
        Id = _ids[0],
        Name = "Superman",
        Description = "Superman is a fictional superhero. The character was created by writer Jerry Siegel and artist Joe Shuster, and first appeared in the comic book Action Comics #1 (cover-dated June 1938 and published April 18, 1938).",
      },
      new SuperHero {
        Id = _ids[1],
        Name = "Batman",
        Description = "Batman is a fictional superhero appearing in American comic books published by DC Comics. The character was created by artist Bob Kane and writer Bill Finger,[2][3] and first appeared in Detective Comics #27 (May 1939).",
      }
    );
  }
        
}
