using CadeMeuPet.Domain.Entities;

namespace CadeMeuPet.MVC.ViewModel
{
    public class AnimalViewModel
    {
        public int EspecieAnimalId { get; set; }
        public int RacaAnimalId { get; set; }
        public int CorAnimalId { get; set; }
        public int PorteAnimalId { get; set; }
        public bool Identificacao { get; set; }
        public string Caracteristica { get; set; }
        public Localizacao Localizacao { get; set; }
        public Usuario Usuario { get; set; }
    }
}