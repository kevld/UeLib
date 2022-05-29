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
    public class AssetsController : ControllerBase
    {
        private readonly UeLibContext _context;

        public AssetsController(UeLibContext context)
        {
            _context = context;
        }

        // GET: api/Assets
        [HttpGet]
        public async Task<IEnumerable<AssetDTO>> GetAssets()
        {


            return await _context.Assets.Select(x => new AssetDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Url = x.Url,
                MinVersion = x.MinVersion,
                MaxVersion = x.MaxVersion,
                AssetType = x.AssetType,
                Tags = x.AssetTags.OrderBy(at => at.TagId).Select(at => new TagDTO(at.Tag)),
            }).OrderBy(x => x.Id).ToListAsync();
        }

        // GET: api/Assets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssetDTO>> GetAsset(int id)
        {
            Asset asset = await _context.Assets.FindAsync(id);

            if (asset == null)
            {
                return NotFound();
            }

            return new AssetDTO(asset);
        }

        // POST: api/Assets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AssetDTO>> PostAsset(AssetDTO assetDto)
        {
            Asset asset = assetDto.ToNewAsset();

            List<string> tagNames = assetDto.Tags.Select(x => x.Name).ToList();
            List<Tag> refTags = await _context.Tags.Where(x => tagNames.Contains(x.Name)).ToListAsync();

            foreach (TagDTO tagDto in assetDto.Tags)
            {
                Tag refTag = refTags.FirstOrDefault(x => x.Name == tagDto.Name);

                asset.AssetTags.Add(new AssetTag()
                {
                    Tag = refTag ?? tagDto.ToTag(),
                });
            }

            _context.Assets.Add(asset);
            await _context.SaveChangesAsync();

            return Created("GetAsset", assetDto);
        }

        // DELETE: api/Assets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsset(int id)
        {
            var asset = await _context.Assets.FindAsync(id);
            if (asset == null)
            {
                return NotFound();
            }

            _context.Assets.Remove(asset);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
