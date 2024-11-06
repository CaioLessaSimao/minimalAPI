using Microsoft.EntityFrameworkCore;
using minimalAPI.Models;

namespace minimalAPI.Data
{

    public class Banco : DbContext
    {
        public Banco(DbContextOptions<Banco> options) : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
    }
}