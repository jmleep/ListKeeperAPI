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
    public class LKParentListsController : ControllerBase
    {
        private readonly ListKeeperAPIContext _context;

        public LKParentListsController(ListKeeperAPIContext context)
        {
            _context = context;
        }

        // GET: api/LKParentLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LKParentList>>> GetLKParentList()
        {
          if (_context.LKParentList == null)
          {
              return NotFound();
          }
            return await _context.LKParentList.ToListAsync();
        }

        // GET: api/LKParentLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LKParentList>> GetLKParentList(int id)
        {
          if (_context.LKParentList == null)
          {
              return NotFound();
          }
            var lKParentList = await _context.LKParentList.FindAsync(id);

            if (lKParentList == null)
            {
                return NotFound();
            }

            return lKParentList;
        }

        // PUT: api/LKParentLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLKParentList(int id, LKParentList lKParentList)
        {
            if (id != lKParentList.ID)
            {
                return BadRequest();
            }

            _context.Entry(lKParentList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LKParentListExists(id))
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

        // POST: api/LKParentLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LKParentList>> PostLKParentList(LKParentList lKParentList)
        {
          if (_context.LKParentList == null)
          {
              return Problem("Entity set 'ListKeeperAPIContext.LKParentList'  is null.");
          }
            _context.LKParentList.Add(lKParentList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLKParentList", new { id = lKParentList.ID }, lKParentList);
        }

        // DELETE: api/LKParentLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLKParentList(int id)
        {
            if (_context.LKParentList == null)
            {
                return NotFound();
            }
            var lKParentList = await _context.LKParentList.FindAsync(id);
            if (lKParentList == null)
            {
                return NotFound();
            }

            _context.LKParentList.Remove(lKParentList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LKParentListExists(int id)
        {
            return (_context.LKParentList?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
