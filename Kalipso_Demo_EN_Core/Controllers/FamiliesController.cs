using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kalipso_Demo_EN_Core.Models;

namespace Kalipso_Demo_EN_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamiliesController : ControllerBase
    {
        private readonly Kalipso_Demo_ENContext _context;

        public FamiliesController(Kalipso_Demo_ENContext context)
        {
            _context = context;
        }

        // GET: api/Families
        [HttpGet]
        public IEnumerable<Families> GetFamilies()
        {
            return _context.Families;
        }

        // GET: api/Families/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFamilies([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var families = await _context.Families.FindAsync(id);

            if (families == null)
            {
                return NotFound();
            }

            return Ok(families);
        }

        // PUT: api/Families/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFamilies([FromRoute] string id, [FromBody] Families families)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != families.Code)
            {
                return BadRequest();
            }

            _context.Entry(families).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FamiliesExists(id))
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

        // POST: api/Families
        [HttpPost]
        public async Task<IActionResult> PostFamilies([FromBody] Families families)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Families.Add(families);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FamiliesExists(families.Code))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFamilies", new { id = families.Code }, families);
        }

        // DELETE: api/Families/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFamilies([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var families = await _context.Families.FindAsync(id);
            if (families == null)
            {
                return NotFound();
            }

            _context.Families.Remove(families);
            await _context.SaveChangesAsync();

            return Ok(families);
        }

        private bool FamiliesExists(string id)
        {
            return _context.Families.Any(e => e.Code == id);
        }
    }
}