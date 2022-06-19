using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ListKeeperAPI.Data;
using ListKeeperAPI.Models;

namespace ListKeeperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LKSubListsController : ControllerBase
    {
        private readonly ListKeeperAPIContext _context;

        public LKSubListsController(ListKeeperAPIContext context)
        {
            _context = context;
        }

        // GET: api/LKSubLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LKSubList>>> GetLKSubList()
        {
          if (_context.LKSubList == null)
          {
              return NotFound();
          }
            return await _context.LKSubList.ToListAsync();
        }

        // GET: api/LKSubLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LKSubList>> GetLKSubList(int id)
        {
          if (_context.LKSubList == null)
          {
              return NotFound();
          }
            var lKSubList = await _context.LKSubList.FindAsync(id);

            if (lKSubList == null)
            {
                return NotFound();
            }

            return lKSubList;
        }

        // PUT: api/LKSubLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLKSubList(int id, LKSubList lKSubList)
        {
            if (id != lKSubList.ID)
            {
                return BadRequest();
            }

            _context.Entry(lKSubList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LKSubListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LKSubLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LKSubList>> PostLKSubList(LKSubList lKSubList)
        {
          if (_context.LKSubList == null)
          {
              return Problem("Entity set 'ListKeeperAPIContext.LKSubList'  is null.");
          }
            _context.LKSubList.Add(lKSubList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLKSubList", new { id = lKSubList.ID }, lKSubList);
        }

        // DELETE: api/LKSubLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLKSubList(int id)
        {
            if (_context.LKSubList == null)
            {
                return NotFound();
            }
            var lKSubList = await _context.LKSubList.FindAsync(id);
            if (lKSubList == null)
            {
                return NotFound();
            }

            _context.LKSubList.Remove(lKSubList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LKSubListExists(int id)
        {
            return (_context.LKSubList?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
