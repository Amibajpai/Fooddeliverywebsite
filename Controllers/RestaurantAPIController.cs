using Fooddeliverywebsite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fooddeliverywebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantAPIController : ControllerBase
    {
        private readonly DbFooddeliveryContext context;

        public RestaurantAPIController(DbFooddeliveryContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Restaurant>>> GetRestaurants()
        {
            var data = await context.Restaurants.ToListAsync();
            return Ok(data);

        }

        [HttpPost]
        public async Task<ActionResult<List<Restaurant>>> CreateRestaurants(Restaurant res)
        {
            await context.Restaurants.AddAsync(res);
            await context.SaveChangesAsync();
            return Ok(res);

        }
        [HttpPut("{Ordereditem}")]
        public async Task<ActionResult<List<Restaurant>>> UpdateRestaurant(String Ordereditem, Restaurant res)
        {
            if (Ordereditem != res.Ordereditem)
            {
                return BadRequest();
            }
            context.Entry(res).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(res);
        }

        [HttpDelete("{Ordereditem}")]
        public async Task<ActionResult<List<Restaurant>>> DeleteRestaurants(String Ordereditem)
        {
            var res = await context.Restaurants.FindAsync(Ordereditem);
            if (Ordereditem != res.Ordereditem)
            {
                return BadRequest();
            }
            context.Restaurants.Remove(res);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
