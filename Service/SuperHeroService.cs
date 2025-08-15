using SuperHeroesGraphQL.Context;
using SuperHeroesGraphQL.Entities;

namespace SuperHeroesGraphQL.Service;

public class SuperHeroService
{
  private readonly AppDbContext _context;
  private readonly ILogger<SuperHeroService> _logger;

  public SuperHeroService(AppDbContext context, ILogger<SuperHeroService> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<SuperHero> AddSuperHero(string name, string description)
  {
    SuperHero hero = new() { Name = name, Description = description };

    _context.Set<SuperHero>().Add(hero);
    await _context.SaveChangesAsync();

    _logger.LogInformation($"Added SuperHero {name}");
    return hero;
  }

  public async Task<SuperHero> UpdateSuperHero(Guid id, string? name, string? description)
  {
    var hero = await _context.Set<SuperHero>().FindAsync(id);
    if (hero is null)
    {
      _logger.LogError($"SuperHero {id} not found");
      throw new Exception("SuperHero not found");
    }

    if (name != null) hero.Name = name;
    if (description != null) hero.Description = description;

    await _context.SaveChangesAsync();
    _logger.LogInformation($"Updated SuperHero {hero.Id}");
    return hero;
  }

  public async Task<SuperHero?> FindSuperHeroById(Guid? id)
  {
    if (id is null)
      throw new ArgumentNullException(nameof(id), "SuperHero ID cannot be null.");

    return await _context.Set<SuperHero>().FindAsync(id.Value) 
           ?? throw new KeyNotFoundException($"SuperHero with id {id} not found.");
  }
}
