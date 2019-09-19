using CadeMeuPet.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CadeMeuPet.Data.EntityConfiguration
{
    public class AnimalConfiguration : EntityTypeConfiguration<Animal>
    {
        public AnimalConfiguration()
        {
            ToTable("TAB_ANIMAL");
            HasKey(u => u.AnimalId);

            Property(u => u.Caracteristica)
                .IsRequired()
                .HasMaxLength(500);
        }
    }
}
