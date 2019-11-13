using CadeMeuPet.Domain.Entities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CadeMeuPet.MVC.ViewModel
{
    public class AnimalViewModel
    {
        public int AnimalId { get; set; }
        public int EspecieAnimalId { get; set; }
        public int RacaAnimalId { get; set; }
        public int CorAnimalId { get; set; }
        public int PorteAnimalId { get; set; }
        public string Identificacao { get; set; }
        public string Caracteristica { get; set; }
        public bool Ativo { get; set; }
        public Localizacao Localizacao { get; set; }
        public Usuario Usuario { get; set; }
        
        public IEnumerable<EspecieAnimal> EspecieList { get; set; }
        public IEnumerable<RacaAnimal> RacaList { get; set; }
        public IEnumerable<CorAnimal> CorList { get; set; }
        public IEnumerable<PorteAnimal> PorteList { get; set; }
        public List<SelectListItem> IdentificacaoList { get; set; }

        public IEnumerable<Estado> EstadoList { get; set; }
        public IEnumerable<Cidade> CidadeList { get; set; }
        public IEnumerable<Fotos> FotosList { get; set; }
    }
}