using Fooddeliverywebsite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fooddeliverywebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MastercuisineAPIController : ControllerBase
    {
        private readonly DbFooddeliveryContext context;

        public MastercuisineAPIController(DbFooddeliveryContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Mastercuisine>>> GetMastercuisines()
        {
            var data = await context.Mastercuisines.ToListAsync();
            return Ok(data);

        }

        [HttpPost]
        public async Task<ActionResult<List<Mastercuisine>>> CreateMastercuisines(Mastercuisine ms)
        {
            await context.Mastercuisines.AddAsync(ms);
            await context.SaveChangesAsync();
            return Ok(ms);

        }
        [HttpPut("{Cuisineid}")]
        public async Task<ActionResult<List<Mastercuisine>>> UpdateMastercuisines(int Cuisineid, Mastercuisine ms)
        {
            if (Cuisineid != ms.Cuisineid)
            {
                return BadRequest();
            }
            context.Entry(ms).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(ms);
        }

        [HttpDelete("{Cuisineid}")]
        public async Task<ActionResult<List<Mastercuisine>>> DeleteMastercuisines(int Cuisineid)
        {
            var ms = await context.Mastercuisines.FindAsync(Cuisineid);
            if (Cuisineid != ms.Cuisineid)
            {
                return BadRequest();
            }
            context.Mastercuisines.Remove(ms);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
