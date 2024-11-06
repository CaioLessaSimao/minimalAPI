using Microsoft.AspNetCore.Mvc;
using minimalAPI.Data;
using minimalAPI.Models;

namespace minimalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        private readonly Banco _context;

        public EnderecosController(Banco context)
        {
            _context = context;
        }

        // POST: api/Enderecos
        [HttpPost]
        public async Task<ActionResult<Endereco>> PostEndereco(Endereco endereco)
        {
            var pessoa = await _context.Pessoas.FindAsync(endereco.PessoaId);
            if (pessoa == null)
            {
                return NotFound("Pessoa não encontrada.");
            }

            _context.Enderecos.Add(endereco);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostEndereco), new { id = endereco.Id }, endereco);
        }
    }
}