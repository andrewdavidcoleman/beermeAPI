using System.Collections.Generic;
using beermeAPI;
using beermeAPI.Connections;
using System.Linq;
using System.Threading.Tasks;
using beermeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace beermeAPI.Controllers
{
  public class BeerController
  {

    private MySqlCommand db { get; set; }
    public BeerController(MySqlDatabase db)
    {
      this.db = db.Connection.CreateCommand() as MySqlCommand;
    }

   [Route("")]
   [Route("GetAllBeers")]
    public List<Beer> GetAllBeers()
    {
      var beerList = new List<Beer>();

      db.CommandText = @"SELECT beerId, name FROM beers";

      using(var reader = db.ExecuteReader())
      {
        while(reader.Read()){
          var beer = new Beer()
          {
            BeerId = reader.GetInt32("beerId"),
            Name = reader.GetString("name")
          };
          beerList.Add(beer);
        }
      }
      return beerList;
    }

    [Route("GetBeerById")]
    public Beer GetBeerById(int beerId){
      db.CommandText = $"SELECT * FROM beers WHERE beerId = {beerId}";
      var beer = new Beer();

      using(var reader = db.ExecuteReader())
      {
        while(reader.Read()){
          beer.BeerId = reader.GetInt32("beerId");
          beer.Name = reader.GetString("name");
        }
      }
      return beer;
    }

    [Route("GetIngredientsByBeerId")]
    public List<Ingredient> GetIngredientsByBeerId(int beerId){
      db.CommandText = $"SELECT * FROM ingredients WHERE beerId = {beerId} ORDER BY sequence ASC";
      var ingredientList = new List<Ingredient>();

      using(var reader = db.ExecuteReader())
      {
        while(reader.Read()){
          var ingredient = new Ingredient()
          {
            IngredientId = reader.GetInt32("ingredientId"),
            BeerId = reader.GetInt32("beerId"),
            Description = reader.GetString("description"),
            Sequence = reader.GetInt32("sequence")
          };
          ingredientList.Add(ingredient);
        }
      }
      return ingredientList;
    }

    [Route("GetDirectionsByBeerId")]
    public List<Direction> GetDirectionsByBeerId(int beerId){
      db.CommandText = $"SELECT * FROM ingredients WHERE beerId = {beerId} ORDER BY sequence ASC";
      var ingredientList = new List<Ingredient>();

      using(var reader = db.ExecuteReader())
      {
        while(reader.Read()){
          var ingredient = new Ingredient()
          {
            IngredientId = reader.GetInt32("ingredientId"),
            BeerId = reader.GetInt32("beerId"),
            Description = reader.GetString("description"),
            Sequence = reader.GetInt32("sequence")
          };
          ingredientList.Add(ingredient);
        }
      }
      return ingredientList;
    }

  }
}
