using CadeMeuPet.Domain.Componente;
using CadeMeuPet.Domain.Interfaces.Services;
using CadeMeuPet.MVC.Util;
using CadeMeuPet.MVC.ViewModel;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CadeMeuPet.MVC.Controllers
{
    public class CadeMeuPetController : Controller
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
        
        private AnimalComponent _AnimalComponent;
        private UrlPath _UrlPath;
        private MapperUtil _Mapper;

        public CadeMeuPetController(IServiceEstado estadoService,
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

        #region .: Actions :.

        public ActionResult Index()
        {
            var usuarioID = TempData["UsuarioID"];
            TempData.Keep("UsuarioID");

            if(!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");
            else
            {
                CarregaCombos();
                return View();
            }
        }


        public ActionResult Filtro(AnimalViewModel filter)
        {

            AnimalViewModel model = _AnimalService.Filter(filter);

            return PartialView("_Filtro");
        }

        #endregion

        #region .: Metodos Auxiliares :.

        private void CarregaCombos()
        {
            List<SelectListItem> lstIdentificacao = new List<SelectListItem>();
            lstIdentificacao.Add(new SelectListItem { Text = "Não", Value = "0" });
            lstIdentificacao.Add(new SelectListItem { Text = "Sim", Value = "1" });

            ViewData["Estado"] = new SelectList(_EstadoService.RetornaEstados(), "EstadoId", "NomeEstado");
            ViewData["Especie"] = new SelectList(_EspecieService.GetAll(), "EspecieAnimalId", "Especie");
            ViewData["Cor"] = new SelectList(_CorService.GetAll(), "CorAnimalId", "Cor");
            ViewData["Porte"] = new SelectList(_PorteService.GetAll(), "PorteAnimalId", "Porte");
            ViewData["Identificacao"] = lstIdentificacao;
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

        #endregion
    }
}