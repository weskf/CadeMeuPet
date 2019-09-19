using System.ComponentModel.DataAnnotations;

namespace CadeMeuPet.Domain.Entities
{
    public class Fotos
    {
        [Key]
        public int FotoId { get; set; }
        public int AnimalId { get; set; }
        public string CaminhoFoto { get; set; }
        public string DescricaoFoto { get; set; }
        
        public virtual Animal Animal { get; set; }
    }
}
