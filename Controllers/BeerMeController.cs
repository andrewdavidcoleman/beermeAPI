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
   [Route("API")]
   [Route("API/GetAllBeers")]
    public List<Beer> GetAllBeers()
    {
      var beerList = new List<Beer>();

      db.CommandText = @"SELECT beerId, name FROM beers";

      using(var reader = db.ExecuteReader())
      {
        while(reader.Read()){
          var beer = new Beer()
          {
            BeerId = reader.GetFieldValue<int>(0),
            Name = reader.GetFieldValue<string>(1)
          };
          beerList.Add(beer);
        }
      }
      return beerList;
    }

    [Route("GetBeerById")]
    public Beer GetBeerById(int beerId){
      db.CommandText = $"SELECT beerId, name FROM beers where beerId = {beerId}";
      var beer = new Beer();

      using(var reader = db.ExecuteReader())
      {
        while(reader.Read()){
          beer.BeerId = reader.GetFieldValue<int>(0);
          beer.Name = reader.GetFieldValue<string>(1);
        }
      }
      return beer;
    }
  }
}
