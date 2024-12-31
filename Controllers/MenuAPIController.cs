using Fooddeliverywebsite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fooddeliverywebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuAPIController : ControllerBase
    {
        private readonly DbFooddeliveryContext context;

        public MenuAPIController(DbFooddeliveryContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Menu>>> GetMenus()
        {
            var data = await context.Menus.ToListAsync();
            return Ok(data);

        }

        [HttpPost]
        public async Task<ActionResult<List<Menu>>> CreateMenus(Menu mn)
        {
            await context.Menus.AddAsync(mn);
            await context.SaveChangesAsync();
            return Ok(mn);

        }
        [HttpPut("{Menuid}")]
        public async Task<ActionResult<List<Menu>>> UpdateMenus(int Menuid, Menu mn)
        {
            if (Menuid != mn.Menuid)
            {
                return BadRequest();
            }
            context.Entry(mn).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(mn);
        }

        [HttpDelete("{Menuid}")]
        public async Task<ActionResult<List<Menu>>> DeleteMenus(int Menuid)
        {
            var mn = await context.Menus.FindAsync(Menuid);
            if (Menuid != mn.Menuid)
            {
                return BadRequest();
            }
            context.Menus.Remove(mn);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
