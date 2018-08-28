using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConfigMgrClientHealthWebservice.Models;

namespace ConfigMgrClientHealthWebservice.Controllers
{
    [Produces("application/json")]
    [Route("Clients")]
    public class ClientsController : Controller
    {
        private readonly ClientHealthContext _context;

        public ClientsController(ClientHealthContext context)
        {
            _context = context;
        }

        // GET: /Clients
        [HttpGet]
        public IEnumerable<Clients> GetClients()
        {
            return _context.Clients;
        }

        // GET: /Clients/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClients([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clients = await _context.Clients.SingleOrDefaultAsync(m => m.Hostname == id);

            if (clients == null)
            {
                return NotFound();
            }

            return Ok(clients);
        }

        // PUT: /Clients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClients([FromRoute] string id, [FromBody] Clients clients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            if (id.ToUpper() != clients.Hostname.ToUpper())
            {
                return BadRequest();
            }
            

            _context.Entry(clients).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientsExists(id))
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

        // POST: /Clients
        [HttpPost]
        public async Task<IActionResult> PostClients([FromBody] Clients clients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Clients.Add(clients);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClientsExists(clients.Hostname))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClients", new { id = clients.Hostname }, clients);
        }

        /* Disable DELETE. We do not support deleting objects by this webservice.
        // DELETE: /Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClients([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clients = await _context.Clients.SingleOrDefaultAsync(m => m.Hostname == id);
            if (clients == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(clients);
            await _context.SaveChangesAsync();

            return Ok(clients);
        }
        */

        private bool ClientsExists(string id)
        {
            return _context.Clients.Any(e => e.Hostname == id);
        }
    }
}