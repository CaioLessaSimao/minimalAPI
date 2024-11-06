using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using minimalAPI.Data;
using minimalAPI.Models;

namespace minimalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly Banco _context;

        public PessoasController(Banco context)
        {
            _context = context;
        }

        // POST: api/Pessoas
        [HttpPost]
        public async Task<ActionResult<Pessoa>> PostPessoa(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPessoa), new { id = pessoa.Id }, pessoa);
        }

        // GET: api/Pessoas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetPessoa(int id)
        {
            var pessoa = await _context.Pessoas
                .Include(p => p.Enderecos)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pessoa == null)
            {
                return NotFound("Pessoa não encontrada.");
            }

            return pessoa;
        }
    }
}