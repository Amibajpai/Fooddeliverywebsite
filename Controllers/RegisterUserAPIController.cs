using Fooddeliverywebsite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fooddeliverywebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterUserAPIController : ControllerBase
    {
        private readonly DbFooddeliveryContext context;

        public RegisterUserAPIController(DbFooddeliveryContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Registeruser>>> GetRegisterUsers()
        {
            var data = await context.Registerusers.ToListAsync();
            return Ok(data);

        }

        [HttpPost]
        public async Task<ActionResult<List<Registeruser>>> CreateRegisterusers(Registeruser usr)
        {
            await context.Registerusers.AddAsync(usr);
            await context.SaveChangesAsync();
            return Ok(usr);

        }
        [HttpPut("{PhoneNo}")]
        public async Task<ActionResult<List<Registeruser>>> UpdateRegisterusers(String PhoneNo, Registeruser usr)
        {
            if (PhoneNo != usr.PhoneNo)
            {
                return BadRequest();
            }
            context.Entry(usr).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(usr);
        }

        [HttpDelete("{PhoneNo}")]
        public async Task<ActionResult<List<Registeruser>>> DeleteRegisterusers(String PhoneNo)
        {
            var usr = await context.Registerusers.FindAsync(PhoneNo);
            if (PhoneNo != usr.PhoneNo)
            {
                return BadRequest();
            }
            context.Registerusers.Remove(usr);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
