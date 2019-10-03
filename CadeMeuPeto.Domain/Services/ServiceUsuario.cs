using CadeMeuPet.Domain.Entities;
using CadeMeuPet.Domain.Interfaces.Services;
using CadeMeuPet.Domain.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;

namespace CadeMeuPet.Domain.Services
{
    public class ServiceUsuario : ServiceBase<Usuario>, IServiceUsuario
    {
        private readonly IRepositoryUsuario _UsuarioRepository;

        public ServiceUsuario(IRepositoryUsuario UsuarioRepository) : base(UsuarioRepository)
        {
            _UsuarioRepository = UsuarioRepository;
        }

        public void CadastrarUsuario(Usuario objUsuario)
        {
            objUsuario.DataCadastro = DateTime.Now;

            _UsuarioRepository.Add(objUsuario);
        }

        public Usuario DadosUsuario(Usuario objUsuario)
        {
            Usuario retUsuario = new Usuario();
            retUsuario = _UsuarioRepository.GetAll()
                                           .Where(x => x.Nome == objUsuario.Nome).FirstOrDefault();

            return retUsuario;
        }

        public IEnumerable<Animal> RetornaFotosAnimal(int usuarioId)
        {
            Usuario objUsuario = new Usuario();
            objUsuario = _UsuarioRepository.GetAll().Where(x => x.UsuarioId == usuarioId).FirstOrDefault();
            List<Animal> ListAnimal = objUsuario.Animais.Where(x => x.Ativo == true).ToList();

            return ListAnimal;
            

        }

        public Usuario ValidaAcesso(Usuario objUsuario)
        {
            Usuario retUsuario = new Usuario();
            retUsuario = _UsuarioRepository.GetAll()
                                    .Where(x => x.Email == objUsuario.Email && 
                                                x.Senha == objUsuario.Senha)
                                    .FirstOrDefault();

            return retUsuario;
        }
    }
}
