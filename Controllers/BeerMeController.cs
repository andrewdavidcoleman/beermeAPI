using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using beermeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace beermeAPI.Controllers
{
    [Route("/")]
    public class BeerMeController : Controller
    {
        // GET api/values
        [HttpGet]
        public List<Beer> Get()
        {
            return new List<Beer>() {
                new Beer()
                {
                    BeerId = 1,
                    Name = "IPA"
                },
                new Beer()
                {
                    BeerId = 2,
                    Name = "Golden Ale"
                },
                new Beer()
                {
                    BeerId = 3,
                    Name = "Orange Belgian Wheat"
                }
            };
        }

        [HttpGet("{id}")]
        public Beer Get(int id)
        {
            return new Beer();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
