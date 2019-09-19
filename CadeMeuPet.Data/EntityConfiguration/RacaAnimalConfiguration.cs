using CadeMeuPet.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CadeMeuPet.Data.EntityConfiguration
{
    public class RacaAnimalConfiguration : EntityTypeConfiguration<RacaAnimal>
    {
        public RacaAnimalConfiguration()
        {
            ToTable("TAB_RACA");
            HasKey(e => e.RacaAnimalId);
  
        }
    }
}
