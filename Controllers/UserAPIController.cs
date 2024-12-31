using Fooddeliverywebsite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fooddeliverywebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {
        private readonly DbFooddeliveryContext context;

        public UserAPIController(DbFooddeliveryContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var data = await context.Users.ToListAsync();
            return Ok(data);

        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> CreateUsers(User usr)
        {
            await context.Users.AddAsync(usr);
            await context.SaveChangesAsync();
            return Ok(usr);

        }
        [HttpPut("{PhoneNo}")]
        public async Task<ActionResult<List<User>>> UpdateUsers(int PhoneNo, User usr)
        {
            if(PhoneNo != usr.PhoneNo)
            {
                return BadRequest();
            }
            context.Entry(usr).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(usr);
        }

        [HttpDelete("{PhoneNo}")]
        public async Task<ActionResult<List<User>>> DeleteUsers(int PhoneNo)
        {
            var usr = await context.Users.FindAsync(PhoneNo);
            if(PhoneNo != usr.PhoneNo)
            {
                return BadRequest();
            }
            context.Users.Remove(usr);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
