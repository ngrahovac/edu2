using edu2Model.Domain;
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
    [Route("faculties")]
    public class FacultiesController : ControllerBase
    {
        private readonly Edu2DbContext dbContext;

        public FacultiesController(Edu2DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ActionResult<IEnumerable<Faculty>>> GetAllAsync()
        {
            using (dbContext)
            {
                try
                {
                    var faculties = await dbContext.Faculties.ToListAsync();

                    if (faculties.Count == 0)
                        return NoContent();
                    else
                        return Ok(faculties);
                }
                catch (Exception e)
                {
                    return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                }
            }
        }
    }
}
