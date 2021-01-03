using Microsoft.EntityFrameworkCore;
using TesteConfitec.Entities;

namespace TesteConfitec
{
    public class Contexto : DbContext
    {
        public Contexto() { }


        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Escolaridade> Escolaridades { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.UseIdentityColumns();
            MappingEscolaridade(builder);
            MappingUsuario(builder);
        }

        private void MappingUsuario(ModelBuilder builder)
        {
            builder.Entity<Usuario>(etd =>
            {
                etd.ToTable("tb_usuario");
                etd.HasKey(c => c.Id);
                etd.Property(c => c.Id).HasColumnName("id").ValueGeneratedOnAdd();
                etd.Property(c => c.Nome).HasColumnName("nome").IsRequired().HasMaxLength(30);
                etd.Property(c => c.Sobrenome).HasColumnName("sobrenome").HasMaxLength(30);
                etd.Property(c => c.DataNascimento).HasColumnName("dataNascimento").IsRequired().HasMaxLength(30);
                etd.Property(c => c.Email).HasColumnName("email").IsRequired().HasMaxLength(30);
            });

            builder.Entity<Usuario>().HasOne(p => p.Escolaridade).WithMany().HasForeignKey(fk => fk.EscolaridadeId);
        }
        private void MappingEscolaridade(ModelBuilder builder)
        {
            builder.Entity<Escolaridade>(etd =>
            {
                etd.ToTable("tb_escolaridade");
                etd.HasKey(c => c.Id);
                etd.Property(c => c.Id).HasColumnName("id").ValueGeneratedOnAdd();
                etd.Property(c => c.Descricao).HasColumnName("descricao").IsRequired().HasMaxLength(30);
            });
        }




    }
}
