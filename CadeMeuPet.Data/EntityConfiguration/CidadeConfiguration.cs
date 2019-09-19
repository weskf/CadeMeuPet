using CadeMeuPet.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CadeMeuPet.Data.EntityConfiguration
{
    public class CidadeConfiguration : EntityTypeConfiguration<Cidade>
    {
        public CidadeConfiguration()
        {
            ToTable("TAB_CIDADE");
            HasKey(e => e.CidadeId);
        }
    }
}
