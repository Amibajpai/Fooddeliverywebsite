using Fooddeliverywebsite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fooddeliverywebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterRestaurantAPIController : ControllerBase
    {
        private readonly DbFooddeliveryContext context;

        public MasterRestaurantAPIController(DbFooddeliveryContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<MasterRestaurant>>> GetMasterRestaurants()
        {
            var mr = await context.MasterRestaurants.ToListAsync();
            return Ok(mr);

        }

        [HttpPost]
        public async Task<ActionResult<List<MasterRestaurant>>> CreateMasterRestaurants(MasterRestaurant mr)
        {
            await context.MasterRestaurants.AddAsync(mr);
            await context.SaveChangesAsync();
            return Ok(mr);

        }
        [HttpPut("{Restaurantid}")]
        public async Task<ActionResult<List<MasterRestaurant>>> UpdateMasterRestaurant(int Restaurantid, MasterRestaurant mr)
        {
            if (Restaurantid != mr.Restaurantid)
            {
                return BadRequest();
            }
            context.Entry(mr).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(mr);
        }

        [HttpDelete("{Restaurantid}")]
        public async Task<ActionResult<List<MasterRestaurant>>> DeleteMasterRestaurants(int Restaurantid)
        {
            var mr = await context.MasterRestaurants.FindAsync(Restaurantid);
            if (Restaurantid != mr.Restaurantid)
            {
                return BadRequest();
            }
            context.MasterRestaurants.Remove(mr);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
