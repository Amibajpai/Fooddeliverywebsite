using Fooddeliverywebsite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fooddeliverywebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasteruserAPIController : ControllerBase
    {
        private readonly DbFooddeliveryContext context;

        public MasteruserAPIController(DbFooddeliveryContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Masteruser>>> GetMasterusers()
        {
            var data = await context.Masterusers.ToListAsync();
            return Ok(data);

        }

        [HttpPost]
        public async Task<ActionResult<List<Masteruser>>> CreateMasterusers(Masteruser usr)
        {
            await context.Masterusers.AddAsync(usr);
            await context.SaveChangesAsync();
            return Ok(usr);

        }
        [HttpPut("{Userid}")]
        public async Task<ActionResult<List<Masteruser>>> UpdateMaterusers(int Userid, Masteruser usr)
        {
            if (Userid != usr.Userid)
            {
                return BadRequest();
            }
            context.Entry(usr).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(usr);
        }

        [HttpDelete("{Userid}")]
        public async Task<ActionResult<List<Masteruser>>> DeleteMasterusers(int Userid)
        {
            var Masteruser = await context.Masterusers.FindAsync(Userid);
            if (Userid != Masteruser.Userid)
            {
                return BadRequest();
            }
            context.Masterusers.Remove(Masteruser);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
