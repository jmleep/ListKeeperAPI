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
    public class LKTasksController : ControllerBase
    {
        private readonly ListKeeperAPIContext _context;

        public LKTasksController(ListKeeperAPIContext context)
        {
            _context = context;
        }

        // GET: api/LKTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LKTask>>> GetLKTask()
        {
          if (_context.LKTask == null)
          {
              return NotFound();
          }
            return await _context.LKTask.ToListAsync();
        }

        // GET: api/LKTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LKTask>> GetLKTask(int id)
        {
          if (_context.LKTask == null)
          {
              return NotFound();
          }
            var lKTask = await _context.LKTask.FindAsync(id);

            if (lKTask == null)
            {
                return NotFound();
            }

            return lKTask;
        }

        // PUT: api/LKTasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLKTask(int id, LKTask lKTask)
        {
            if (id != lKTask.ID)
            {
                return BadRequest();
            }

            _context.Entry(lKTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LKTaskExists(id))
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

        // POST: api/LKTasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LKTask>> PostLKTask(LKTask lKTask)
        {
          if (_context.LKTask == null)
          {
              return Problem("Entity set 'ListKeeperAPIContext.LKTask'  is null.");
          }
            _context.LKTask.Add(lKTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLKTask", new { id = lKTask.ID }, lKTask);
        }

        // DELETE: api/LKTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLKTask(int id)
        {
            if (_context.LKTask == null)
            {
                return NotFound();
            }
            var lKTask = await _context.LKTask.FindAsync(id);
            if (lKTask == null)
            {
                return NotFound();
            }

            _context.LKTask.Remove(lKTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LKTaskExists(int id)
        {
            return (_context.LKTask?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
