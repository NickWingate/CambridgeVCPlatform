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
using WebApi.Models.Address;

namespace WebApi.Controllers
{
    public class AddressesController : ApiControllerBase<AddressesController>
    {
        public AddressesController(
            CVCPlatformDbContext context,
            IMapper mapper,
            ILogger<AddressesController> logger) : base(context, mapper, logger)
        {
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressReadOnlyDto>>> GetAddresses()
        {
            try
            {
                var addressDtos = _mapper.Map<IEnumerable<AddressReadOnlyDto>>(await _context.Addresses.ToListAsync());
                return Ok(addressDtos);
            }
            catch (Exception ex)
            {
                return HandleException(ex, nameof(GetAddresses));
            }
        }


        // GET: api/Addresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressReadOnlyDto>> GetAddress(int id)
        {
            try
            {
                var address = await _context.Addresses.FindAsync(id);

                if (address == null)
                {
                    return NotFound();
                }

                return _mapper.Map<AddressReadOnlyDto>(address);
            }
            catch (Exception ex)
            {
                return HandleException(ex, nameof(GetAddress));
            }
        }

        // PUT: api/Addresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(int id, AddressUpdateDto addressDto)
        {
            if (id != addressDto.Id)
            {
                return BadRequest();
            }

            var address = await _context.Addresses.FindAsync(id);

            _mapper.Map(addressDto, address);
            _context.Entry(address).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!await AddressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return HandleException(ex, nameof(PutAddress));
                }
            }

            return NoContent();
        }

        // POST: api/Addresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(AddressCreateDto addressDto)
        {
            try
            {
                var address = _mapper.Map<Address>(addressDto);
                _context.Addresses.Add(address);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetAddress", new { id = address.Id }, address);
            }
            catch (Exception ex)
            {
                return HandleException(ex, nameof(PostAddress));
            }
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            try
            {
                var address = await _context.Addresses.FindAsync(id);
                if (address == null)
                {
                    return NotFound();
                }

                _context.Addresses.Remove(address);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return HandleException(ex, nameof(DeleteAddress));
            }
        }

        private async Task<bool> AddressExists(int id)
        {
            return await _context.Addresses.AnyAsync(e => e.Id == id);
        }
    }
}
