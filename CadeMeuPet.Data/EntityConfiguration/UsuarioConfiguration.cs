using CadeMeuPet.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CadeMeuPet.Data.EntityConfiguration
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            ToTable("TAB_USUARIO");

            HasKey(u => u.UsuarioId);

            Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(u => u.Sobrenome)
                .IsRequired()
                .HasMaxLength(150);

            Property(u => u.Senha)
                .IsRequired()
                .HasMaxLength(10);
        }
    }
}
