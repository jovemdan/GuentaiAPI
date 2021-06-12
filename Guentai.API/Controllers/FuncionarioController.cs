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
    public class FuncionarioController : ControllerBase
    {
        private readonly GuentaiDbContext _context;

        public FuncionarioController(GuentaiDbContext context)
        {
            _context = context;
        }

        // GET: api/Funcionario
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Funcionario>>> GetFuncionarios()
        {
            return await _context.Funcionarios.ToListAsync();
        }

        // GET: api/Funcionario/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Funcionario>> GetFuncionario(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            return Ok(funcionario);
        }

        // GET: api/Funcionario
        [HttpGet("funcionario/{strLogin}/{strSenha}")]
        [Authorize]
        public async Task<ActionResult<Funcionario>> GetFuncionarioLogin(string strLogin, string strSenha)
        {
            var funcionario = await _context.Funcionarios.ToListAsync();

            var result = funcionario.FindAll(q => q.Username == strLogin && q.Senha == strSenha ).ToList();


            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }

        // PUT: api/Funcionario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutFuncionario(int id, [FromBody] Funcionario funcionario)
        {
            if (id != funcionario.Id)
            {
                return BadRequest();
            }

            _context.Entry(funcionario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncionarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(funcionario);
        }

        // POST: api/Funcionario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Funcionario>> PostFuncionario(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFuncionario", new { id = funcionario.Id }, funcionario);
        }

        // DELETE: api/Funcionario/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteFuncionario(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }

            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FuncionarioExists(int id)
        {
            return _context.Funcionarios.Any(e => e.Id == id);
        }
    }
}
