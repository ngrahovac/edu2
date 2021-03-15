using edu2Model.Display;
using edu2WebAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace edu2WebAPI.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly Edu2DbContext dbContext;

        public UsersController(Edu2DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [Route("{id}")]
        public async Task<ActionResult<UserDetailsDisplayModel>> GetByIdAsync(int id)
        {
            using (dbContext)
            {
                try
                {
                    var user = await dbContext.Users
                                              .Include(u => u.UserSettings)
                                              .ThenInclude(s => s.UserSocials)
                                              .Include(u => u.UserSettings)
                                              .ThenInclude(s => s.UserTags)
                                              .Include(u => u.UserSettings)
                                              .ThenInclude(s => s.UserSocials)
                                              .ThenInclude(us => us.Social)
                                              .Where(u => u.Id == id)
                                              .SingleAsync();
                    Console.WriteLine(user.UserSettings);

                    if (user == null)
                        return NotFound();

                    var model = user.GetDisplayModel();
                    model.FromUser(user);

                    // TODO: Add Email and Phone 

                    return Ok(model);
                }
                catch (Exception ex)
                {
                    //return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                    return BadRequest(ex.Message + "\n" + ex.StackTrace);
                }
            }
        }
    }
}
