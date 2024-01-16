using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperHeroesGraphQL.Entities;
public class Movie
{
  [Key]
  public Guid Id { get; set; }
  public string? Title { get; set; }
  public string? Description { get; set; }

  [ForeignKey("SuperHeroId")]
  public Guid SuperHeroId { get; set; }
  public SuperHero? SuperHero { get; set; }
}
