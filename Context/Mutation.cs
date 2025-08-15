using SuperHeroesGraphQL.Entities;
using SuperHeroesGraphQL.Service;

namespace SuperHeroesGraphQL.Context;

public class Mutation
{
  private readonly SuperHeroService _superHeroService;
  private readonly PowerService _powerService;

  public Mutation(SuperHeroService superHeroService, PowerService powerService)
  {
    _superHeroService = superHeroService;
    _powerService = powerService;
  }
  
  public Task<SuperHero> AddSuperHero(string name, string description) =>
    _superHeroService.AddSuperHero(name, description);

  public Task<SuperHero> UpdateSuperHero(Guid id, string? name, string? description) =>
    _superHeroService.UpdateSuperHero(id, name, description);
  
  public Task<Power> AddPower(
    Guid superHeroId,
    string? description,
    string? superPower) => _powerService.AddPower(superHeroId, description, superPower);
  
  public Task<Power> UpdatePower(
    Guid id,
    Guid? superHeroId,
    string? description,
    string? superPower) => _powerService.UpdatePower(id, superHeroId, description, superPower);
}
