using System.Collections.Generic;
using beermeAPI;
using System.Linq;
using System.Threading.Tasks;
using beermeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace beermeAPI.Controllers
{
  [Route("")]
  public class BeerController : InjectedController
  {

    public BeerController(BeerMeContext context) : base(context) { }

    // GET api/values
    // [HttpGet]
    // public async Task<IActionResult> GetAllBeers()
    // {
    //   var beerList = await db.Beers.FindAsync();
    //   if (beerList == default(List<Beer>))
    //   {
    //     return NotFound();
    //   }
    //   return Ok(beerList);
    // }

    [HttpGet("/GetAllBeers")]
    public IActionResult GetAllBeers()
    {
      var beerList = db.Beers.ToList();
      if (beerList == null)
      {
        return NotFound();
      }
      return Ok(beerList);
    }

    [HttpGet("/GetBeer/{beerId}")]
    public async Task<IActionResult> GetBeer(int beerId)
    {
      var beer = await db.Beers.FindAsync(beerId);
      if (beer == null)
      {
          return NotFound();
      }
      return Ok(beer);
    }

    [HttpPost("/AddBeer")]
    public async Task<IActionResult> AddBeer(string name)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }
      await db.Beers.AddAsync(new Beer(){ Name = name });
      await db.SaveChangesAsync();
      return Ok(new { Message = "New beer added!" });
    }
  }

  // Helper class to take care of db context injection.
  public class InjectedController: ControllerBase
  {
    protected readonly BeerMeContext db;

    public InjectedController(BeerMeContext context)
    {
      db = context;
    }
  }
}
