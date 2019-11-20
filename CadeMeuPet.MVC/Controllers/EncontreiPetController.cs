using CadeMeuPet.Domain.Componente;
using CadeMeuPet.Domain.Entities;
using CadeMeuPet.Domain.Interfaces.Services;
using CadeMeuPet.MVC.Util;
using CadeMeuPet.MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CadeMeuPet.MVC.Controllers
{
    public class EncontreiPetController : Controller
    {
        public readonly IServiceEstado _EstadoService;
        public readonly IServiceCidade _CidadeService;
        public readonly IServiceEspecieAnimal _EspecieService;
        public readonly IServiceRacaAnimal _RacaService;
        public readonly IServiceCorAnimal _CorService;
        public readonly IServicePorteAnimal _PorteService;
        public readonly IServiceAnimal _AnimalService;
        public readonly IServiceUsuario _UsuarioService;
        public readonly IServiceFotos _FotosService;

        public AnimalComponent _AnimalComponent;
        public UrlPath _UrlPath;
        public MapperUtil _Mapper;

        public EncontreiPetController(IServiceEstado estadoService,
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

            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");
            else
            {
                if(usuarioID == null)
                    RedirectToAction("Login", "Account");

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
            TempData.Keep();
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
            var AnimalId = TempData["AnimalId"];
            TempData.Keep();

            try
            {
                int totalImagens = CriarDiretorioImagens((int)AnimalId);

                return Json(new { success = "s", message = totalImagens + " Imagem(ns) Salva(s)." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = "n", message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult RemoverImagemPet(string descricaoPet)
        {
            var animalId = TempData["AnimalId"];
            string _msgRetorno = string.Empty;
            string _Retorno = string.Empty;

            try
            {
                string urlPath = _UrlPath.RetornaUrlPet((int)animalId);
                string path = Server.MapPath(urlPath);

                string[] files = Directory.GetFiles(path);
                foreach(var item in files)
                {
                    var file = item.Remove(0, item.LastIndexOf("\\", item.Length) + 1);

                    if(descricaoPet == file)
                    {
                        System.IO.File.Delete(item);
                        _FotosService.RemoverFotoPet(descricaoPet);
                    }
                }

                var resultado = new
                {
                    retorno = "sucesso",
                    message = "Imagem excluída."
                };

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {

                var resultado = new
                {
                    retorno = "erro",
                    message = "Houve um erro ao tentar excluir a imagem: " + ex.Message
                };

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            
        }

        //[HttpPost]
        //public ActionResult UploadFiles(IEnumerable<HttpPostedFileBase> fileData)
        //{
        //    var animalId = ViewBag.AnimalId;
        //    foreach (var file in fileData)
        //    {
        //        string filePath = Guid.NewGuid() + Path.GetExtension(file.FileName);
        //        string urlPath = "~/Imagens/Upload/" + animalId;
        //        file.SaveAs(Path.Combine(Server.MapPath(urlPath), filePath));

        //        Fotos objFoto = new Fotos();
        //        objFoto.AnimalId = animalId;
        //        objFoto.CaminhoFoto = urlPath;
        //        objFoto.DescricaoFoto = file.FileName;
        //        _FotosService.Add(objFoto);
        //    }

        //    var viewModel = _FotosService.FotosPorAnimal(animalId);
        //    return Json("Arquivo anexados com sucesso", JsonRequestBehavior.AllowGet);
        //}

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
            animalViewModel.Fotos = _AnimalComponent.FotosList.Where(x => x.AnimalId.Equals(animalViewModel.AnimalId));

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