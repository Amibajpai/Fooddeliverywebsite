using Fooddeliverywebsite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fooddeliverywebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderAPIController : ControllerBase
    {
        private readonly DbFooddeliveryContext context;

        public OrderAPIController(DbFooddeliveryContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetOrders()
        {
            var data = await context.Orders.ToListAsync();
            return Ok(data);

        }

        [HttpPost]
        public async Task<ActionResult<List<Order>>> CreateOrders(Order or)
        {
            await context.Orders.AddAsync(or);
            await context.SaveChangesAsync();
            return Ok(or);

        }
        [HttpPut("{OrderId}")]
        public async Task<ActionResult<List<Order>>> UpdateOrders(int OrderId, Order or)
        {
            if (OrderId != or.OrderId)
            {
                return BadRequest();
            }
            context.Entry(or).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(or);
        }

        [HttpDelete("{OrderId}")]
        public async Task<ActionResult<List<Order>>> DeleteOrders(int OrderId)
        {
            var or = await context.Orders.FindAsync(OrderId);
            if (OrderId != or.OrderId)
            {
                return BadRequest();
            }
            context.Orders.Remove(or);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
