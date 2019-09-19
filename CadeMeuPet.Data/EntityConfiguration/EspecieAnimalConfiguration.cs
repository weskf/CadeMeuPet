using CadeMeuPet.Domain.Entities;
using CadeMeuPet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeMeuPet.Data.EntityConfiguration
{
    public class EspecieAnimalConfiguration : EntityTypeConfiguration<EspecieAnimal>
    {
        public EspecieAnimalConfiguration()
        {
            ToTable("TAB_ESPECIE");
            HasKey(e => e.EspecieAnimalId);
        }
    }
}
