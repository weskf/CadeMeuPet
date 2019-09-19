using CadeMeuPet.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CadeMeuPet.Data.EntityConfiguration
{
    public class ImagemAnimalConfiguration : EntityTypeConfiguration<ImagemAnimal>
    {
        public ImagemAnimalConfiguration()
        {
            ToTable("TAB_IMAGEM");
            HasKey(e => e.ImagemAnimalId);
        }
    }
}
