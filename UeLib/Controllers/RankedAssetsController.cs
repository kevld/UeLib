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
    public class RankedAssetsController : ControllerBase
    {
        private readonly UeLibContext _context;

        public RankedAssetsController(UeLibContext context)
        {
            _context = context;
        }

        // GET: api/RankedAssets
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<RankedAsset>>> GetRankedAssets()
        //{
        //    return await _context.RankedAssets.ToListAsync();
        //}

        // GET: api/RankedAssets/Project/5
        // Get ranked assets by project
        [HttpGet("Project/{projectId}")]
        public async Task<ActionResult<IEnumerable<RankedAssetDTO>>> GetRankedAsset(int projectId)
        {
            var project = await _context.Projects.FindAsync(projectId);

            if (project == null)
                return NotFound();

            var rankedAssets = from q in (
                                    from a in _context.Assets
                                    join ra in _context.RankedAssets.Where(x => x.ProjectId == projectId) on a.Id equals ra.AssetId
                                    into joined
                                    from j in joined.DefaultIfEmpty()
                                    select new RankedAssetDTO()
                                    {
                                        Id = j != null ? j.Id : null,
                                        AssetId = a.Id,
                                        AssetName = a.Name,
                                        Rank = j != null ? j.Rank : 0,
                                    }
                                )
                               orderby q.Rank descending, q.AssetName
                               select q;
            return await rankedAssets.ToListAsync();
        }

        // POST: api/RankedAssets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RankedAssetDTO>> PostRankedAsset(PostRankedAssetDTO postRankedAsset)
        {
            RankedAsset rankedAsset = await _context.RankedAssets.Where(x => x.AssetId == postRankedAsset.AssetId && x.ProjectId == postRankedAsset.ProjectId).FirstOrDefaultAsync();

            if(rankedAsset == null)
            {
                rankedAsset = postRankedAsset.ToRankedAsset();
                _context.RankedAssets.Add(rankedAsset);
            }
            else
            {
                rankedAsset.Rank = postRankedAsset.Rank;
            }

            await _context.SaveChangesAsync();

            Asset asset = await _context.Assets.FindAsync(postRankedAsset.AssetId);

            RankedAssetDTO result = new RankedAssetDTO()
            {
                Id = rankedAsset.Id,
                AssetId = rankedAsset.AssetId,
                AssetName = asset.Name,
                Rank = rankedAsset.Rank,
            };

            return Created("GetRankedAsset", result);
        }

        // DELETE: api/RankedAssets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRankedAsset(int id)
        {
            var rankedAsset = await _context.RankedAssets.FindAsync(id);
            if (rankedAsset == null)
            {
                return NotFound();
            }

            _context.RankedAssets.Remove(rankedAsset);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //private bool RankedAssetExists(int id)
        //{
        //    return _context.RankedAssets.Any(e => e.Id == id);
        //}
    }
}
