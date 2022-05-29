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
    public class TagsController : ControllerBase
    {
        private readonly UeLibContext _context;

        public TagsController(UeLibContext context)
        {
            _context = context;
        }

        // GET: api/Tags
        [HttpGet]
        public async Task<IEnumerable<TagDTO>> GetTags()
        {
            return await _context.Tags
                .Select(x => new TagDTO()
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        //// GET: api/Tags/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<TagDTO>> GetTag(int id)
        //{
        //    var tag = await _context.Tags.FindAsync(id);

        //    if (tag == null)
        //    {
        //        return NotFound();
        //    }

        //    return new TagDTO(tag);
        //}

        // POST: api/Tags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TagDTO>> PostTag(string tagName)
        {
            string lowerName = tagName.ToLower();
            string firstLetter = lowerName.Substring(0, 1).ToUpper();
            string end = lowerName.Substring(1);
            tagName = string.Concat(firstLetter, end);

            Tag tag = new Tag()
            {
                Name = tagName,
            };

            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTag", new TagDTO(tag));
        }
    }
}
