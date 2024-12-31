using Fooddeliverywebsite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fooddeliverywebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliverypartnerAPIController : ControllerBase
    {
        private readonly DbFooddeliveryContext context;

        public DeliverypartnerAPIController(DbFooddeliveryContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Deliverypartner>>> GetDeliverypartners()
        {
            var data = await context.Deliverypartners.ToListAsync();
            return Ok(data);

        }

        [HttpPost]
        public async Task<ActionResult<List<Deliverypartner>>> CreateDeliverypartners(Deliverypartner dp)
        {
            await context.Deliverypartners.AddAsync(dp);
            await context.SaveChangesAsync();
            return Ok(dp);

        }
        [HttpPut("{Deliverypartnerid}")]
        public async Task<ActionResult<List<Deliverypartner>>> UpdateDeliverypartners(int Deliverypartnerid, Deliverypartner dp)
        {
            if (Deliverypartnerid != dp.Deliverypartnerid)
            {
                return BadRequest();
            }
            context.Entry(dp).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(dp);
        }

        [HttpDelete("{Deliverypartnerid}")]
        public async Task<ActionResult<List<Deliverypartner>>> DeleteDeliverypartners(int Deliverypartnerid)
        {
            var dp = await context.Deliverypartners.FindAsync(Deliverypartnerid);
            if (Deliverypartnerid != dp.Deliverypartnerid)
            {
                return BadRequest();
            }
            context.Deliverypartners.Remove(dp);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
