using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Guentai.API.Domain;
using Microsoft.AspNetCore.Authorization;

namespace Guentai.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly GuentaiDbContext _context;

        public PerfilController(GuentaiDbContext context)
        {
            _context = context;
        }

        // GET: api/Perfil
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Perfil>>> GetPerfis()
        {
            return await _context.Perfis.ToListAsync();
        }

        // GET: api/Perfil/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Perfil>> GetPerfil(int id)
        {
            var perfil = await _context.Perfis.FindAsync(id);

            if (perfil == null)
            {
                return NotFound();
            }

            return Ok(perfil);
        }

        // PUT: api/Perfil/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutPerfil(int id, [FromBody] Perfil perfil)
        {
            if (id != perfil.Id)
            {
                return BadRequest();
            }

            _context.Entry(perfil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerfilExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(perfil);
        }

        // POST: api/Perfil
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Perfil>> PostPerfil(Perfil perfil)
        {
            _context.Perfis.Add(perfil);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerfil", new { id = perfil.Id }, perfil);
        }

        // DELETE: api/Perfil/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeletePerfil(int id)
        {
            var perfil = await _context.Perfis.FindAsync(id);
            if (perfil == null)
            {
                return NotFound();
            }

            _context.Perfis.Remove(perfil);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PerfilExists(int id)
        {
            return _context.Perfis.Any(e => e.Id == id);
        }
    }
}
