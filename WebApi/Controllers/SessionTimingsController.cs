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
using WebApi.Models.SessionTimings;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionTimingsController : ApiControllerBase<SessionTimingsController>
    {
        public SessionTimingsController(
            CVCPlatformDbContext context,
            IMapper mapper,
            ILogger<SessionTimingsController> logger) : base(context, mapper, logger)
        {
        }

        // GET: api/SessionTimings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SessionTimingReadOnlyDto>>> GetSessionTimings()
        {
            try
            {
                var timiningDtos = _mapper.Map<IEnumerable<SessionTimingReadOnlyDto>>(await _context.SessionTimings.ToListAsync());
                return Ok(timiningDtos);
            }
            catch (Exception ex)
            {
                return HandleException(ex, nameof(GetSessionTimings));
            }
        }

        // GET: api/SessionTimings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SessionTimingReadOnlyDto>> GetSessionTiming(int id)
        {
            try
            {
                var sessionTiming = await _context.SessionTimings.FindAsync(id);

                if (sessionTiming == null)
                {
                    return NotFound();
                }

                return _mapper.Map<SessionTimingReadOnlyDto>(sessionTiming);
            }
            catch (Exception ex)
            {
                return HandleException(ex, nameof(GetSessionTiming));
            }
        }

        // PUT: api/SessionTimings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSessionTiming(int id, SessionTimingUpdateDto sessionTimingDto)
        {
            if (id != sessionTimingDto.Id)
            {
                return BadRequest();
            }

            var timing = await _context.SessionTimings.FindAsync(id);

            _mapper.Map(sessionTimingDto, timing);
            _context.Entry(timing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!SessionTimingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return HandleException(ex, nameof(PutSessionTiming));
                }
            }

            return NoContent();
        }

        // POST: api/SessionTimings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SessionTiming>> PostSessionTiming(SessionTimingCreateDto sessionTimingDto)
        {
            try
            {
                var timing = _mapper.Map<SessionTiming>(sessionTimingDto);
                _context.SessionTimings.Add(timing);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetSessionTiming), new { id = timing.Id }, timing);
            }
            catch (Exception ex)
            {
                return HandleException(ex, nameof(PostSessionTiming));
            }
        }

        // DELETE: api/SessionTimings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSessionTiming(int id)
        {
            try
            {
                var sessionTiming = await _context.SessionTimings.FindAsync(id);
                if (sessionTiming == null)
                {
                    return NotFound();
                }

                _context.SessionTimings.Remove(sessionTiming);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return HandleException(ex, nameof(DeleteSessionTiming));
            }
        }

        private bool SessionTimingExists(int id)
        {
            return _context.SessionTimings.Any(e => e.Id == id);
        }
    }
}
