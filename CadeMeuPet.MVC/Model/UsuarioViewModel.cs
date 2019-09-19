using System.ComponentModel.DataAnnotations;

namespace CadeMeuPet.MVC.Model
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "Preencha o Campo Nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Preencha o Campo Sobrenome")]
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Preencha o Campo Celular")]
        public string Celular { get; set; }
        public string LinkRedeSocial { get; set; }
        [Required(ErrorMessage = "Preencha o Campo E-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Preencha o Campo Senha")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Preencha o Campo Confirmação Senha")]
        public string ConfirmacaoSenha { get; set; }
    }
}