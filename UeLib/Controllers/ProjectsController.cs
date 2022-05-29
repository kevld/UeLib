#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UeLib.Data;
using UeLib.Data.DTO;
using UeLib.Data.Models;

namespace UeLib.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly UeLibContext _context;

        public ProjectsController(UeLibContext context)
        {
            _context = context;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<IEnumerable<ProjectDTO>> GetProjects()
        {
            return await _context.Projects.Select(x => new ProjectDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                //RankedAssets = x.RankedAssets.Select(ra => new RankedAssetDTO(ra.Asset, ra.Rank))
            }).OrderBy(x => x.Id).ToListAsync();
        }

        // POST: api/Projects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjectDTO>> PostProject(ProjectDTO projectDto)
        {
            Project project = projectDto.ToNewProject();
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return Created("GetProject", new ProjectDTO(project));
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
