using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using beermeAPI;
using System.ComponentModel.DataAnnotations;

namespace beermeAPI.Models
{
  public class BeerMeContext : DbContext
  {
    public DbSet<Beer> Beers { get; set; }

    public DbSet<Ingredient> Ingredients { get; set; }

    public DbSet<Direction> Directions { get; set; }

    public BeerMeContext(DbContextOptions options): base(options) { }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //  optionsBuilder.UseMySQL("server=localhost:3306;database=BeerMe;user=user;password=password");
    // }
  }

  public class Beer
  {
    [Required]
    public int BeerId { get; set; }

    [Required]
    public string Name { get; set; }
  }

  public class Ingredient
  {
    [Required]
    public int IngredientId { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public int BeerId { get; set; }

    [Required]
    public int Sequence { get; set; }
  }

  public class Direction
  {
    [Required]
    public int DirectionId { get; set; }

    [Required]
    public int BeerId { get; set; }

    [Required]
    public int Description { get; set; }

    [Required]
    public int Sequence { get; set; }
  }
}
