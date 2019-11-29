using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EvolveHelthProject.Models;

namespace EvolveHelthProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactDetailsController : ControllerBase
    {
        private readonly ContactDetailsContext _context;

        public ContactDetailsController(ContactDetailsContext context)
        {
            _context = context;
        }

        // GET: api/ContactDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactDetails>>> GetEvolveHelthContactDetails()
        {
            return await _context.EvolveHelthContactDetails.ToListAsync();
        }

        // GET: api/ContactDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactDetails>> GetContactDetails(int id)
        {
            var contactDetails = await _context.EvolveHelthContactDetails.FindAsync(id);

            if (contactDetails == null)
            {
                return NotFound();
            }

            return contactDetails;
        }

        // PUT: api/ContactDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactDetails(int id, ContactDetails contactDetails)
        {
            if (id != contactDetails.CId)
            {
                return BadRequest();
            }

            _context.Entry(contactDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactDetailsExists(id))
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

        // POST: api/ContactDetails
        [HttpPost]
        public async Task<ActionResult<ContactDetails>> PostContactDetails(ContactDetails contactDetails)
        {
            _context.EvolveHelthContactDetails.Add(contactDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactDetails", new { id = contactDetails.CId }, contactDetails);
        }

        // DELETE: api/ContactDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContactDetails>> DeleteContactDetails(int id)
        {
            var contactDetails = await _context.EvolveHelthContactDetails.FindAsync(id);
            if (contactDetails == null)
            {
                return NotFound();
            }

            _context.EvolveHelthContactDetails.Remove(contactDetails);
            await _context.SaveChangesAsync();

            return contactDetails;
        }

        private bool ContactDetailsExists(int id)
        {
            return _context.EvolveHelthContactDetails.Any(e => e.CId == id);
        }
    }
}
