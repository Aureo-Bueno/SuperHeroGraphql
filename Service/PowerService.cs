using SuperHeroesGraphQL.Context;
using SuperHeroesGraphQL.Entities;

namespace SuperHeroesGraphQL.Service;

public class PowerService
{
  private readonly AppDbContext _context;
  private readonly ILogger<PowerService> _logger;
  private readonly SuperHeroService _superHeroService;
  
  public PowerService(AppDbContext context, ILogger<PowerService> logger, SuperHeroService superHeroService)
  {
    _context = context; 
    _logger = logger;
    _superHeroService = superHeroService;
  }

  public async Task<Power> AddPower(Guid? superHeroId, string? description, string? superPower)
  {
    SuperHero? superHero =  await _superHeroService.FindSuperHeroById(superHeroId);

    if (superHero is null)
    {
      _logger.LogInformation($"Super hero with id {superHeroId} not found");
      throw new Exception("SuperHero not found");
    }
    
    Power power = new()
    {
      Id = Guid.NewGuid(),
      SuperHero = superHero,
      Description = description,
      SuperPower = superPower,
    };
    
    _context.Set<Power>().Add(power);
    await _context.SaveChangesAsync();
    return power;
  }

  public async Task<Power> UpdatePower(Guid? id, Guid? superHeroId, string? description, string? superPower)
  {
    Power? power = await FindPowerById(id);

    if (power is null)
    {
      _logger.LogError($"Could not find power {id}");
      throw new Exception("Power not found");
    }

    if (superHeroId is not null) power.SuperHero = await _superHeroService.FindSuperHeroById(superHeroId);
    if (description is not null ) power.Description = description;
    if (superPower is not null) power.SuperPower = superPower;

    await _context.SaveChangesAsync();
    _logger.LogInformation($"Power {id} was updated");
    return power;
  }

  public async Task<Power?> FindPowerById(Guid? id)
  {
    if (id is null)
      throw new ArgumentNullException(nameof(id), "Power ID cannot be null.");
    
    return await _context.Set<Power>().FindAsync(id.Value) 
           ?? throw new KeyNotFoundException($"Power with id {id} not found.");
  }
}
