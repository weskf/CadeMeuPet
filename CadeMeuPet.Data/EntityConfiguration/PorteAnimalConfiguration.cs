using CadeMeuPet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeMeuPet.Data.EntityConfiguration
{
    public class PorteAnimalConfiguration : EntityTypeConfiguration<PorteAnimal>
    {
        public PorteAnimalConfiguration()
        {
            ToTable("TAB_PORTE");
            HasKey(e => e.PorteAnimalId);
        }
    }
}
