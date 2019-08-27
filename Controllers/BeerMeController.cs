using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using beermeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace beermeAPI.Controllers
{
    [Route("api")]
    public class BeerMeController : Controller
    {
        // GET api/values
        [HttpGet]
        public List<Recipe> Get()
        {
            return new List<Recipe>() {
                new Recipe()
                {
                    RecipeId = 1,
                    Name = "IPA"
                },
                new Recipe()
                {
                    RecipeId = 2,
                    Name = "Golden Ale"
                },
                new Recipe()
                {
                    RecipeId = 3,
                    Name = "Orange Belgian Wheat"
                }
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Recipe Get(int id)
        {
            return new Recipe() {
                RecipeId = 1,
                Name = "IPA",
                Ingredients = new List<Ingredient>() {
                    new Ingredient(){
                        IngredientId = 1,
                        Description = "Malted Hops",
                        Quantity = "1 oz"
                    },
                    new Ingredient(){
                        IngredientId = 2,
                        Description = "Some other hops",
                        Quantity = "1 oz"
                    },
                    new Ingredient(){
                        IngredientId = 3,
                        Description = "Even more hops",
                        Quantity = "1 oz"
                    }
                }
            };
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
