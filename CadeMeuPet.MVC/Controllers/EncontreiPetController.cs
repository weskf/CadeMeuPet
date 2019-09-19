using AutoMapper;
using CadeMeuPet.Domain.Entities;
using CadeMeuPet.Domain.Interfaces.Services;
using CadeMeuPet.MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CadeMeuPet.MVC.Controllers
{
    public class EncontreiPetController : Controller
    {
        private readonly IServiceEspecieAnimal _EspecieService;
        private readonly IServiceEstado _EstadoService;
        private readonly IServiceCidade _CidadeService;
        private readonly IServiceRacaAnimal _RacaService;
        private readonly IServiceCorAnimal _CorService;
        private readonly IServicePorteAnimal _PorteService;
        private readonly IServiceAnimal _AnimalService;
        private readonly IServiceUsuario _UsuarioService;
        private readonly IServiceFotos _FotosService;

        public EncontreiPetController(IServiceEspecieAnimal especieService,
                                      IServiceRacaAnimal racaService,
                                      IServiceEstado estadoService,
                                      IServiceCidade cidadeService,
                                      IServiceCorAnimal corAnimalService,
                                      IServicePorteAnimal porteAnimalService,
                                      IServiceAnimal animalService,
                                      IServiceUsuario usuarioService,
                                      IServiceFotos fotosService)
        {
            _EspecieService = especieService;
            _EstadoService = estadoService;
            _CidadeService = cidadeService;
            _RacaService = racaService;
            _CorService = corAnimalService;
            _PorteService = porteAnimalService;
            _AnimalService = animalService;
            _UsuarioService = usuarioService;
            _FotosService = fotosService;
        }

        #region .: Actions :.

        public ActionResult Index()
        {
            var usuarioID = TempData["UsuarioID"];
            TempData.Keep("UsuarioID");

            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");
            else
            {
                IEnumerable<Animal> AnimalViewModel = _UsuarioService.RetornaFotosAnimal((int)usuarioID);
                return View(AnimalViewModel);
            }
        }

        [HttpGet]
        public ActionResult Editar(int AnimalId)
        {
            Animal objAnimal = _AnimalService.GetById(AnimalId);
            CarregaCombos();
            var config = new MapperConfiguration(c => c.CreateMap<Animal, AnimalViewModel>());
            IMapper iMapper = config.CreateMapper();

            var animalViewModel = iMapper.Map<Animal, AnimalViewModel>(objAnimal);

            return View(animalViewModel);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");
            else
            {
                CarregaCombos();
                return View();
            }
        }

        [HttpPost]
        public JsonResult Cadastrar(AnimalViewModel animalViewModel)
        {
            string _msgRetorno = string.Empty;
            string _Retorno = string.Empty;
            if (ModelState.IsValid)
            {
                Usuario objUsuario = new Usuario();
                objUsuario.Nome = User.Identity.Name;

                var config = new MapperConfiguration(c => c.CreateMap<AnimalViewModel, Animal>());
                IMapper iMapper = config.CreateMapper();

                var objAnimal = iMapper.Map<AnimalViewModel, Animal>(animalViewModel);

                objUsuario = _UsuarioService.DadosUsuario(objUsuario);
                objAnimal.UsuarioId = objUsuario.UsuarioId;

                var Animal = _AnimalService.CadastrarAnimal(objAnimal);
                TempData["AnimalId"] = Animal.AnimalId;

                _msgRetorno = "Dados confirmados. Por favor anexe as fotos";
                _Retorno = "sucesso";
            }
            else
            {
                _Retorno = "erro";
                _msgRetorno = "Antes de anexar, preencha os campos obrigatórios";
            }

            var resultado = new
            {
                retorno = _Retorno,
                msgRetorno = _msgRetorno
            };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UploadFile()
        {
            var AnimalId = TempData["AnimalId"];

            string url = ConfigurationManager.AppSettings["UrlImagens"];
            string urlPath = url + AnimalId +"/";
            string path = Server.MapPath(urlPath);

            Directory.CreateDirectory(path);
            try
            {
                HttpFileCollectionBase files = Request.Files;
                int totalImagens = files.Count;
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFileBase file = files[i];
                    file.SaveAs(path + file.FileName);
                    var caminhoFoto = url + AnimalId + "//" + file.FileName;

                    Fotos objFoto = new Fotos();
                    objFoto.AnimalId = (int)AnimalId;
                    objFoto.CaminhoFoto = caminhoFoto;
                    objFoto.DescricaoFoto = file.FileName;
                    _FotosService.Add(objFoto);
                }
                
                return Json(new { success = "s", message = totalImagens + " Imagem(ns) Salva(s)." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = "n", message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult UploadFiles(IEnumerable<HttpPostedFileBase> fileData)
        {
            var animalId = ViewBag.AnimalId;
            foreach (var file in fileData)
            {
                string filePath = Guid.NewGuid() + Path.GetExtension(file.FileName);
                string urlPath = "~/Imagens/Upload/" + animalId;
                file.SaveAs(Path.Combine(Server.MapPath(urlPath), filePath));

                Fotos objFoto = new Fotos();
                objFoto.AnimalId = animalId;
                objFoto.CaminhoFoto = urlPath;
                objFoto.DescricaoFoto = file.FileName;
                _FotosService.Add(objFoto);
            }

            var viewModel = _FotosService.FotosPorAnimal(animalId);
            return Json("Arquivo anexados com sucesso", JsonRequestBehavior.AllowGet);
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