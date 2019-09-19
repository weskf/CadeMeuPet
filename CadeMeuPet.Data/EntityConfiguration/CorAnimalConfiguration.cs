using CadeMeuPet.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CadeMeuPet.Data.EntityConfiguration
{
    public class CorAnimalConfiguration : EntityTypeConfiguration<CorAnimal>
    {
        public CorAnimalConfiguration()
        {
            ToTable("TAB_COR");
            HasKey(e => e.CorAnimalId);


        }
    }
}
