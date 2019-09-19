using CadeMeuPet.Domain.Entities;
using System.Collections.Generic;

namespace CadeMeuPet.Domain.Interfaces.Services
{
    public interface IServiceUsuario : IServiceBase<Usuario>
    {
        void CadastrarUsuario(Usuario objUsuario);
        Usuario ValidaAcesso(Usuario objUsuario);
        Usuario DadosUsuario(Usuario objUsuario);
        IEnumerable<Animal> RetornaFotosAnimal(int UsuarioId);
    }
}
