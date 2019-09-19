using CadeMeuPet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeMeuPet.Data.EntityConfiguration
{
    public class EstadoConfiguration : EntityTypeConfiguration<Estado>
    {
        public EstadoConfiguration()
        {
            ToTable("TAB_ESTADO");
            HasKey(e => e.EstadoId);
        }
    }
}
