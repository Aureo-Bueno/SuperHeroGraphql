using SuperHeroesGraphQL.Entities;

namespace SuperHeroesGraphQL.Context;
public class Query
{
  [UseProjection]
  [UseFiltering]
  [UseSorting]
  public IQueryable<SuperHero> GetSuperHeroes([Service] AppDbContext context) => context.Set<SuperHero>();
}
