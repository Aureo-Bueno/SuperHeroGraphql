using System.ComponentModel.DataAnnotations;

namespace SuperHeroesGraphQL.Entities;
public class SuperHero
{
  [Key]
  public Guid Id { get; set; } 
  public string? Name { get; set; }
  public string? Description { get; set; }

  [UseSorting]
  public ICollection<Power>? Powers { get; set; }

  [UseSorting]
  public ICollection<Movie>? Movies { get; set; }
}
