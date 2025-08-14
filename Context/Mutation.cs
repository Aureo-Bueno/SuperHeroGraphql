using Microsoft.EntityFrameworkCore;
using SuperHeroesGraphQL.Entities;

namespace SuperHeroesGraphQL.Context;

public class Mutation
{
  private readonly ILogger<Mutation> _logger;

  public Mutation(ILogger<Mutation> logger)
  {
    _logger = logger;
  }
  
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
    _logger.LogInformation($"Added SuperHero {name} to database");
    return hero;
  }

  public async Task<SuperHero> UpdateSuperHero(
    Guid id,
    string? name,
    string? description,
    [Service] AppDbContext context)
  {
    _logger.LogInformation($"Finding SuperHero {id}");
    SuperHero? hero = await context.Set<SuperHero>().FindAsync(id);

    if (hero is null)
    {
      _logger.LogError($"Could not find SuperHero {id}");
      throw new Exception("SuperHero not found");
    }
    
    if (name is not null ) hero.Name = name;
    if (description is not null ) hero.Description = description;
    
    await context.SaveChangesAsync();
    _logger.LogInformation($"Updated SuperHero with id: {hero.Id} to database");
    return hero;
  }
  
  public async Task<Power> AddPower(
    Guid superHeroId,
    string? description,
    string? superPower,
    [Service] AppDbContext context)
  {
    _logger.LogInformation($"Finding Power {superHeroId}");
    SuperHero? superHero = await context.Set<SuperHero>().FirstOrDefaultAsync(superHero => superHero.Id == superHeroId);

    if (superHero is null)
    {
      _logger.LogError($"Could not find SuperHero {superHeroId}");
      throw new Exception("SuperHero not found");
    }
    
    _logger.LogInformation($"Creating Power on database with super hero id: {superHero.Id}");
    Power power = new()
    {
      Id = Guid.NewGuid(),
      SuperHero = superHero,
      Description = description,
      SuperPower = superPower,
    };
    
    context.Set<Power>().Add(power);
    await context.SaveChangesAsync();
    _logger.LogInformation($"Added Power with id: {power.Id} to database");
    return power;
  }
  
  public async Task<Power> UpdatePower(
    Guid id,
    Guid? superHeroId,
    string? description,
    string? superPower,
    [Service] AppDbContext context)
  {
    _logger.LogInformation($"Finding Power {id}");
    Power? power = await context.Set<Power>().FindAsync(id);

    if (power is null)
    {
      _logger.LogError($"Could not find Power {id}");
      throw new Exception("Power not found");
    }

    _logger.LogInformation($"Updating Power with id: {power.Id} to database");
    if (superHeroId is not null ) power.SuperHero = await context.Set<SuperHero>().FirstOrDefaultAsync(superHero => superHero.Id == superHeroId);
    if (description is not null ) power.Description = description;
    if (superPower is not null) power.SuperPower = superPower;

    await context.SaveChangesAsync();
    _logger.LogInformation($"Updated Power with id: {power.Id} to database");
    return power;
  }
}
