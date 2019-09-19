using CadeMeuPet.Domain.Interfaces.Services;
using CadeMeuPet.MVC.Model;
using System.Web.Mvc;
using AutoMapper;
using CadeMeuPet.Domain.Entities;
using System;
using System.Web.Security;


namespace CadeMeuPet.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IServiceUsuario _UsuarioService;

        public AccountController(IServiceUsuario usuarioService)
        {
            _UsuarioService = usuarioService;

        }
        [HttpGet]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "EncontreiPet");
            else
                return View();
        }

        [HttpPost]
        public JsonResult Login(string email, string senha)
        {
            Usuario objUsuario = new Usuario();
            objUsuario.Email = email;
            objUsuario.Senha = senha;

            var UsuarioAutenticado = _UsuarioService.ValidaAcesso(objUsuario);
            string _msgRetorno = string.Empty;
            string _Retorno = string.Empty;

            if (UsuarioAutenticado != null)
            { 
                TempData["UsuarioID"] = UsuarioAutenticado.UsuarioId;
                FormsAuthentication.SetAuthCookie(UsuarioAutenticado.Nome, false);
                _Retorno = "sucesso";
                _msgRetorno = "Usuário Autenticado.";
            }
            else
            {
                _Retorno = "erro";
                _msgRetorno = "E-mail / Senha não validos.";
            }

            var resultado = new
            {
                retorno = _Retorno,
                msgRetorno = _msgRetorno
            };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Cadastrar(UsuarioViewModel usuarioViewModel)
        {
            string _msgRetorno = string.Empty;
            string _Retorno = string.Empty;

            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(c => c.CreateMap<UsuarioViewModel, Usuario>());
                IMapper iMapper = config.CreateMapper();

                var objUsuario = iMapper.Map<UsuarioViewModel, Usuario>(usuarioViewModel);
                _UsuarioService.CadastrarUsuario(objUsuario);

                _msgRetorno = "Usuário Cadastrado com sucesso.";
                _Retorno = "sucesso";
            }
            else
            {
                _Retorno = "erro";
                _msgRetorno = "Preencha os campos obrigatórios.";
            }

            var resultado = new {   retorno = _Retorno,                                   
                                    msgRetorno = _msgRetorno };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        private bool ValidaSenha(UsuarioViewModel viewModel)
        {
            return viewModel.Senha.Equals(viewModel.ConfirmacaoSenha);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}