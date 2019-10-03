using CadeMeuPet.Domain.Entities;
using CadeMeuPet.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace CadeMeuPet.Domain.Componente
{
    public class AnimalComponent
    {
        private readonly IServiceEspecieAnimal _EspecieService;
        private readonly IServiceEstado _EstadoService;
        private readonly IServiceCidade _CidadeService;
        private readonly IServiceRacaAnimal _RacaService;
        private readonly IServiceCorAnimal _CorService;
        private readonly IServicePorteAnimal _PorteService;
        private readonly IServiceAnimal _AnimalService;
        private readonly IServiceFotos _FotosService;

        public AnimalComponent(IServiceEspecieAnimal especieService,
                               IServiceRacaAnimal racaService,
                               IServiceEstado estadoService,
                               IServiceCidade cidadeService,
                               IServiceCorAnimal corAnimalService,
                               IServicePorteAnimal porteAnimalService,
                               IServiceAnimal animalService,
                               IServiceFotos fotosService)
        {
            _EspecieService = especieService;
            _EstadoService = estadoService;
            _CidadeService = cidadeService;
            _RacaService = racaService;
            _CorService = corAnimalService;
            _PorteService = porteAnimalService;
            _AnimalService = animalService;
            _FotosService = fotosService;
        }

        public IEnumerable<EspecieAnimal> EspecieAnimalList {
            get
            {
                return _EspecieService.GetAll();
            }
        }

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

        public IEnumerable<CorAnimal> CorList
        {
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

        public IEnumerable<Fotos> FotosList {
            get
            {
                return _FotosService.GetAll();
            }
        }
    }
}

    

