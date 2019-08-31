using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace beermeAPI.Models
{
    public class BeerMeContext : DbContext
    {
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=BeerMe;Integrated Security=True");
        }
    }

    public class Beer
    {
        public int BeerId { get; set; }
        public string Name { get; set; }
    }

    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string Quantity { get; set; }
        public string Description { get; set; }
    }
}
