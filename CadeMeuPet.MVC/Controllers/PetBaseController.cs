using CadeMeuPet.Domain.Componente;
using CadeMeuPet.Domain.Interfaces.Services;
using CadeMeuPet.MVC.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CadeMeuPet.MVC.Controllers
{
    public class PetBaseController : Controller
    {
        private readonly IServiceEstado _EstadoService;
        private readonly IServiceCidade _CidadeService;
        private readonly IServiceEspecieAnimal _EspecieService;
        private readonly IServiceRacaAnimal _RacaService;
        private readonly IServiceCorAnimal _CorService;
        private readonly IServicePorteAnimal _PorteService;
        private readonly IServiceAnimal _AnimalService;
        private readonly IServiceUsuario _UsuarioService;
        private readonly IServiceFotos _FotosService;
        
        public AnimalComponent _AnimalComponent;
        public UrlPath _UrlPath;
        public MapperUtil _Mapper;

        public PetBaseController(IServiceEstado estadoService,
                                 IServiceCidade cidadeService,
                                 IServiceEspecieAnimal especieService,
                                 IServiceRacaAnimal racaService,
                                 IServiceCorAnimal corAnimalService,
                                 IServicePorteAnimal porteAnimalService,
                                 IServiceAnimal animalService,
                                 IServiceUsuario usuarioService,
                                 IServiceFotos fotosService)
        {
            _EstadoService = estadoService;
            _CidadeService = cidadeService;
            _EspecieService = especieService;
            _RacaService = racaService;
            _CorService = corAnimalService;
            _PorteService = porteAnimalService;
            _AnimalService = animalService;
            _UsuarioService = usuarioService;
            _FotosService = fotosService;
            _UrlPath = new UrlPath();
            _Mapper = new MapperUtil();
            _AnimalComponent = new AnimalComponent(especieService, racaService, estadoService, cidadeService, corAnimalService, porteAnimalService, animalService, fotosService);
        }

        [HttpPost]
        public JsonResult RetornaCidadePorEstado(int EstadoId)
        {
            var jsonSerializer = new JavaScriptSerializer();
            var ListCidade = _CidadeService.BuscarCidadePorEstado(EstadoId);

            return Json(ListCidade);
        }

        [HttpPost]
        public JsonResult RetornaRacaPorEspecie(int EspecieId)
        {
            var jsonSerializer = new JavaScriptSerializer();
            var ListRaca = _RacaService.RetornaRacaPorEspecie(EspecieId);

            return Json(ListRaca);
        }
    }
}