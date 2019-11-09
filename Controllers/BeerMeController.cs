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
  [Route("")]
  public class BeerController
  {

    private MySqlDatabase db { get; set; }
    public BeerController(MySqlDatabase db)
    {
      this.db = db;
    }

    [HttpGet]
    public List<Beer> GetAllBeers()
    {
      var beerList = new List<Beer>();
      // 
      // var cmd = this.db.Connection.CreateCommand() as MySqlCommand;
      // cmd.CommandText = @"SELECT beerId, name FROM beers";
      //
      // using(var reader = cmd.ExecuteReader())
      // {
      //   while(reader.Read()){
      //   var beer = new Beer()
      //   {
      //     BeerId = reader.GetFieldValue<int>(0),
      //     Name = reader.GetFieldValue<string>(1)
      //   };
      //   beerList.Add(beer);
      //   }
      // }
      return beerList;
    }
  }
}
