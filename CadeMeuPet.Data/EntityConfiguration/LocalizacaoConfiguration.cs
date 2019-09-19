using CadeMeuPet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeMeuPet.Data.EntityConfiguration
{
    public class LocalizacaoConfiguration : EntityTypeConfiguration<Localizacao>
    {
        public LocalizacaoConfiguration()
        {
            ToTable("TAB_LOCALIZACAO");
            HasKey(l => l.LocalizacaoId);

            Property(l => l.Logradouro)
                .IsRequired()
                .HasMaxLength(500);

            Property(l => l.Bairro)
                .HasMaxLength(250);
        }
    }
}
