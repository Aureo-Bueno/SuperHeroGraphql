using SuperHeroesGraphQL.Entities;

namespace SuperHeroesGraphQL.Context;
public class Query
{
  
  private readonly ILogger<Query> _logger;

  public Query(ILogger<Query> logger)
  {
    _logger = logger;
  }
  
  [UseProjection]
  [UseFiltering]
  [UseSorting]
  public IQueryable<SuperHero> GetSuperHeroes([Service] AppDbContext context) => context.Set<SuperHero>();
}
