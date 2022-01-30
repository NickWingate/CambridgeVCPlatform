#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models.Squads;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SquadsController : ApiControllerBase<SquadsController>
    {
        public SquadsController(CVCPlatformDbContext context,
            IMapper mapper,
            ILogger<SquadsController> logger) : base(context, mapper, logger)
        {
        }

        // GET: api/Squads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Squad>>> GetSquads()
        {
            try
            {
                return await _context.Squads.ToListAsync();
            }
            catch (Exception ex)
            {
                return HandleException(ex, nameof(GetSquads));
            }
        }

        // GET: api/Squads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Squad>> GetSquad(int id)
        {
            try
            {
                var squad = await _context.Squads.FindAsync(id);

                if (squad == null)
                {
                    return NotFound();
                }

                return squad;
            }
            catch (Exception ex)
            {
                return HandleException(ex, nameof(GetSquad));
            }
        }

        // PUT: api/Squads/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSquad(int id, Squad squad)
        {
            if (id != squad.Id)
            {
                return BadRequest();
            }

            _context.Entry(squad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!SquadExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return HandleException(ex, nameof(PutSquad));
                }
            }

            return NoContent();
        }

        // POST: api/Squads
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Squad>> PostSquad(SquadCreateDto squadDto)
        {
            try
            {
                var squad = _mapper.Map<Squad>(squadDto);
                _context.Squads.Add(squad);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetSquad), new { id = squad.Id }, squad);
            }
            catch (Exception ex)
            {
                return HandleException(ex, nameof(PostSquad));
            }
        }

        // DELETE: api/Squads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSquad(int id)
        {
            try
            {
                var squad = await _context.Squads.FindAsync(id);
                if (squad == null)
                {
                    return NotFound();
                }

                _context.Squads.Remove(squad);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return HandleException(ex, nameof(DeleteSquad));
            }
        }

        private bool SquadExists(int id)
        {
            return _context.Squads.Any(e => e.Id == id);
        }
    }
}
