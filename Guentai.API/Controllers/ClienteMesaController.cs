using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Guentai.API.Domain;

namespace Guentai.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteMesaController : ControllerBase
    {
        private readonly GuentaiDbContext _context;

        public ClienteMesaController(GuentaiDbContext context)
        {
            _context = context;
        }

        // GET: api/ClienteMesa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteMesa>>> GetClientesMesas()
        {
            return await _context.ClientesMesas.ToListAsync();
        }

        // GET: api/ClienteMesa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteMesa>> GetClienteMesa(int id)
        {
            var clienteMesa = await _context.ClientesMesas.FindAsync(id);

            if (clienteMesa == null)
            {
                return NotFound();
            }

            return clienteMesa;
        }

        // PUT: api/ClienteMesa/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClienteMesa(int id, ClienteMesa clienteMesa)
        {
            if (id != clienteMesa.Id)
            {
                return BadRequest();
            }

            _context.Entry(clienteMesa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteMesaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(clienteMesa);
        }

        // POST: api/ClienteMesa
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClienteMesa>> PostClienteMesa(ClienteMesa clienteMesa)
        {
            _context.ClientesMesas.Add(clienteMesa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClienteMesa", new { id = clienteMesa.Id }, clienteMesa);
        }

        // DELETE: api/ClienteMesa/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClienteMesa(int id)
        {
            var clienteMesa = await _context.ClientesMesas.FindAsync(id);
            if (clienteMesa == null)
            {
                return NotFound();
            }

            _context.ClientesMesas.Remove(clienteMesa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteMesaExists(int id)
        {
            return _context.ClientesMesas.Any(e => e.Id == id);
        }
    }
}
