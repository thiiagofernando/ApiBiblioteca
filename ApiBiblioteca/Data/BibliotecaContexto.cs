using ApiBiblioteca.Data.Map;
using ApiBiblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiBiblioteca.Data
{
    public class BibliotecaContexto : DbContext
    {
        public BibliotecaContexto(DbContextOptions<BibliotecaContexto> options)
            : base(options)
        {

        }
        public DbSet<Editora> Editoras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EditoraMap());
        }
    }
}
