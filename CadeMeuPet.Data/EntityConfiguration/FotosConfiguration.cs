using CadeMeuPet.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CadeMeuPet.Data.EntityConfiguration
{
    public class FotosConfiguration : EntityTypeConfiguration<Fotos>
    {
        public FotosConfiguration()
        {
            ToTable("TAB_FOTOS_ANIMAL");
            HasKey(u => u.FotoId);
        }
    }
}
