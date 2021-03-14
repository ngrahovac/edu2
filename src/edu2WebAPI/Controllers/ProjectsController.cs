using edu2Model.Display;
using edu2WebAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace edu2WebAPI.Controllers
{
    [ApiController]
    [Route("projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly Edu2DbContext dbContext;
        public ProjectsController(Edu2DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [Route("{id}")]
        public async Task<ActionResult<ProjectDetailsDisplayModel>> GetByIdAsync(int id)
        {
            using (dbContext)
            {
                try
                {
                    var project = await dbContext.Projects
                                           .Include(p => p.CollaboratorProfiles)
                                           .Include(p => p.Tags)
                                           .Where(p => p.Id == id)
                                           .SingleAsync();

                    if (project == null)
                        return NotFound();

                    var author = await dbContext.Users.FindAsync(project.AuthorId);

                    return Ok(new ProjectDetailsDisplayModel(project, author));

                }
                catch (Exception ex)
                {
                    return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                }
            }
        }
    }
}
