using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Servico
{
    public class DbContexto : DbContext
    {
         
        public DbContexto(DbContextOptions<DbContexto> options) : base(options) {}
        
        public DbSet<Aluno> Alunos {get; set;}

    }
}