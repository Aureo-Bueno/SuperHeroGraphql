using SuperHeroesGraphQL.Entities;

namespace SuperHeroesGraphQL.Context;

public class Mutation
{
  public async Task<SuperHero> AddSuperHero(
    string name,
    string description,
    [Service] AppDbContext context)
  {
    SuperHero hero = new()
    {
      Name = name,
      Description = description,
    };
    
    context.Set<SuperHero>().Add(hero);
    await context.SaveChangesAsync();
    return hero;
  }

  public async Task<SuperHero> UpdateSuperHero(
    Guid id,
    string? name,
    string? description,
    [Service] AppDbContext context)
  {
    SuperHero? hero = await context.Set<SuperHero>().FindAsync(id);
    
    if (hero is null) throw new Exception("SuperHero not found");

    if (name is not null ) hero.Name = name;
    if (description is not null ) hero.Description = description;

    await context.SaveChangesAsync();
    return hero;
  }
}
