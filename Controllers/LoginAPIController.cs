using Fooddeliverywebsite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fooddeliverywebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginAPIController : ControllerBase
    {
        private readonly DbFooddeliveryContext context;

        public LoginAPIController(DbFooddeliveryContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Login>>> GetLogins()
        {
            var data = await context.Logins.ToListAsync();
            return Ok(data);

        }

        [HttpPost]
        public async Task<ActionResult<List<Login>>> CreateLogins(Login lg)
        {
            await context.Logins.AddAsync(lg);
            await context.SaveChangesAsync();
            return Ok(lg);

        }
        [HttpPut("{password}")]
        public async Task<ActionResult<List<Login>>> UpdateLogins(String Password, Login lg)
        {
            if (Password != lg.Password)
            {
                return BadRequest();
            }
            context.Entry(lg).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(lg);
        }

        [HttpDelete("{Password}")]
        public async Task<ActionResult<List<Login>>> DeleteLogins(String Password)
        {
            var lg = await context.Logins.FindAsync(Password);
            if (Password != lg.Password)
            {
                return BadRequest();
            }
            context.Logins.Remove(lg);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}

    