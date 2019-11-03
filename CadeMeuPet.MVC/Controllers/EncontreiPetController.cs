using AutoMapper;
using CadeMeuPet.Domain.Componente;
using CadeMeuPet.Domain.Entities;
using CadeMeuPet.Domain.Interfaces.Services;
using CadeMeuPet.MVC.Util;
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
        private AnimalComponent _AnimalComponent;
        private UrlPath _UrlPath;
        private MapperUtil _Mapper;
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
            _AnimalComponent = new AnimalComponent(especieService, racaService, estadoService, cidadeService, corAnimalService, porteAnimalService, animalService, fotosService);
            _UrlPath = new UrlPath();
            _Mapper = new MapperUtil();
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
            TempData["AnimalId"] = AnimalId;

            Animal objAnimal = _AnimalService.GetById(AnimalId);
            CarregaCombos();

            var animalViewModel = _Mapper.MapperAnimalViewModel(objAnimal);
            animalViewModel = CarregarListasViewModel(animalViewModel);
            
            return View(animalViewModel);
        }

        [HttpPost]
        public JsonResult Editar(AnimalViewModel animalViewModel)
        {
            string _msgRetorno = string.Empty;
            string _Retorno = string.Empty;
            var AnimalId = TempData["AnimalId"];
            try
            {
                if(ModelState.IsValid)
                {
                    animalViewModel.AnimalId = (int)AnimalId;
                    var objAnimal = _Mapper.MapperAnimal(animalViewModel);

                    _AnimalService.EditarPet(objAnimal);

                    _msgRetorno = "Informações alteradas com sucesso.";
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
            catch(Exception ex)
            {
                _Retorno = "erro";
                _msgRetorno = "Houve um erro ao tentar salvar. Por favor tente novamente." + ex.Message;

                var resultado = new
                {
                    retorno = _Retorno,
                    msgRetorno = _msgRetorno
                };

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }

            
        }

        [HttpPost]
        public JsonResult Excluir(int AnimalId)
        {
            try
            {
                _AnimalService.ExcluirPet(AnimalId);
                RemoverImagensPet(AnimalId);

                var resultado = new
                {
                    retorno = "sucesso",
                    msgRetorno = "Pet removido com sucesso."
                };

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                var resultado = new
                {
                    retorno = "erro",
                    msgRetorno = "Houve um problema ao tentar excluir o Pet. Por favor tente novamente." + ex.Message
                };

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
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
                
                var objAnimal = _Mapper.MapperAnimal(animalViewModel);

                objUsuario = _UsuarioService.DadosUsuario(objUsuario);
                objAnimal.UsuarioId = objUsuario.UsuarioId;

                var Animal = _AnimalService.CadastrarPet(objAnimal);
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
            var AnimalId = (int)TempData["AnimalId"];

            try
            {
                int totalImagens = CriarDiretorioImagens(AnimalId);

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

        private AnimalViewModel CarregarListasViewModel(AnimalViewModel animalViewModel)
        {
            animalViewModel.EspecieList = _AnimalComponent.EspecieAnimalList;
            animalViewModel.RacaList = _AnimalComponent.RacaList;
            animalViewModel.CorList = _AnimalComponent.CorList;
            animalViewModel.PorteList = _AnimalComponent.PorteList;
            animalViewModel.EstadoList = _AnimalComponent.EstadoList;
            animalViewModel.CidadeList = _AnimalComponent.CidadeList;
            animalViewModel.FotosList = _AnimalComponent.FotosList.Where(x => x.AnimalId.Equals(animalViewModel.AnimalId));

            List<SelectListItem> lstIdentificacao = new List<SelectListItem>
            {
                new SelectListItem { Text = "Não", Value = "0" },
                new SelectListItem { Text = "Sim", Value = "1" }
            };

            animalViewModel.IdentificacaoList = lstIdentificacao;

            return animalViewModel;
        }

        private int CriarDiretorioImagens(int AnimalId)
        {
            string urlPath = _UrlPath.RetornaUrlPet(AnimalId);
            string path = Server.MapPath(urlPath);

            Directory.CreateDirectory(path);
            HttpFileCollectionBase files = Request.Files;

            int totalImagens = files.Count;
            for(int i = 0; i < files.Count; i++)
            {
                HttpPostedFileBase file = files[i];
                file.SaveAs(path + file.FileName);
                var caminhoFoto = urlPath + "/" + file.FileName;

                Fotos objFoto = new Fotos
                {
                    AnimalId = (int)AnimalId,
                    CaminhoFoto = caminhoFoto,
                    DescricaoFoto = file.FileName
                };
                _FotosService.Add(objFoto);
            }

            return totalImagens;
        }

        private void RemoverImagensPet(int AnimalId)
        {
            string urlPath = _UrlPath.RetornaUrlPet(AnimalId);
            string path = Server.MapPath(urlPath);
            Directory.Delete(path, true);
        }

        #endregion
    }
}