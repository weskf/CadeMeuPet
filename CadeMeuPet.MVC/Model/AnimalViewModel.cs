using CadeMeuPet.Domain.Entities;
using CadeMeuPet.Domain.Interfaces;
using CadeMeuPet.Domain.Interfaces.Services;
using CadeMeuPet.Domain.Services;
using System;
using System.Collections.Generic;

namespace CadeMeuPet.MVC.ViewModel
{
    public class AnimalViewModel
    {
        private readonly ServiceEspecieAnimal _EspecieService;
        private readonly IServiceEstado _EstadoService;
        private readonly IServiceCidade _CidadeService;
        private readonly IServiceRacaAnimal _RacaService;
        private readonly IServiceCorAnimal _CorService;
        private readonly IServicePorteAnimal _PorteService;
        private readonly IServiceAnimal _AnimalService;
        private readonly IServiceFotos _FotosService;

        public AnimalViewModel()
        {
            IRepositoryEspecieAnimal repositoryAnimal;
            _EspecieService = new ServiceEspecieAnimal(repositoryAnimal);
        }

        public int EspecieAnimalId { get; set; }
        public int RacaAnimalId { get; set; }
        public int CorAnimalId { get; set; }
        public int PorteAnimalId { get; set; }
        public bool Identificacao { get; set; }
        public string Caracteristica { get; set; }
        public Localizacao Localizacao { get; set; }
        public Usuario Usuario { get; set; }

        public IEnumerable<Estado> EstadoList
        {
            get
            {
                return _EstadoService.GetAll();
            }
        }

        public IEnumerable<Cidade> CidadeList
        {
            get
            {
                return _CidadeService.GetAll();
            }
        }

        public IEnumerable<EspecieAnimal> EspecieList
        {
            get
            {
                return _EspecieService.GetAll();
            }
        }

        public IEnumerable<RacaAnimal> RacaList
        {
            get
            {
                    return _RacaService.GetAll();
            }
        }

        public IEnumerable<CorAnimal> CorList {
            get
            {
                return _CorService.GetAll();
            }
        }

        public IEnumerable<PorteAnimal> PorteList
        {
            get
            {
                return _PorteService.GetAll();
            }
        }

    }
}