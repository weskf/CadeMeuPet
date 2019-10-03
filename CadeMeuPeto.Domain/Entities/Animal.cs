using CadeMeuPet.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CadeMeuPet.Domain.Entities
{
    public class Animal
    {
        public int AnimalId { get; set; }
        public int EspecieAnimalId { get; set; }
        public int RacaAnimalId { get; set; }
        public int CorAnimalId { get; set; }
        public int PorteAnimalId { get; set; }
        public string Identificacao { get; set; }
        public string Caracteristica { get; set; }
        public int UsuarioId { get; set; }
        public int LocalizacaoId { get; set; }
        public int FotoId { get; set; }
        public bool Ativo { get; set; }

        public virtual EspecieAnimal Especies { get; set; }
        public virtual RacaAnimal Racas { get; set; }
        public virtual CorAnimal Cores { get; set; }
        public virtual PorteAnimal Tamanhos { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Localizacao Localizacao { get; set; }
        public virtual ICollection<Fotos> Fotos { get; set; }

        public Animal()
        {
            Fotos = new HashSet<Fotos>();
        }
        
    }

    public class EspecieAnimal
    {
        [Key]
        public int EspecieAnimalId { get; set; }
        public string Especie { get; set; }

        public virtual IEnumerable<Animal> Animal { get; set; }
        public virtual IEnumerable<RacaAnimal> Raca { get; set; }
    }

    public class RacaAnimal
    {
        [Key]
        public int RacaAnimalId { get; set; }
        public string Raca { get; set; }
        public int EspecieAnimalId { get; set; }

        public virtual IEnumerable<Animal> Animal { get; set; }
        public virtual EspecieAnimal EspecieAnimal { get; set; }
    }

    public class CorAnimal
    {
        [Key]
        public int CorAnimalId { get; set; }
        public string Cor { get; set; }
        public virtual IEnumerable<Animal> Animal { get; set; }
    }

    public class PorteAnimal
    {
        [Key]
        public int PorteAnimalId { get; set; }
        public string Porte { get; set; }
        public virtual IEnumerable<Animal> Animal { get; set; }
    }

    public class ImagemAnimal
    {
        [Key]
        public int ImagemAnimalId { get; set; }
        public string Descricao { get; set; }
        public string Caminho { get; set; }
        public virtual IEnumerable<Animal> Animal { get; set; }
    }
}
