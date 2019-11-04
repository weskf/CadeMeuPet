using CadeMeuPet.Domain.Entities;
using CadeMeuPet.Domain.Interfaces;
using CadeMeuPet.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace CadeMeuPet.Domain.Services
{
    public class ServiceFotos : ServiceBase<Fotos>, IServiceFotos
    {
        private readonly IRepositoryFoto _RepositoryFotos;

        public ServiceFotos(IRepositoryFoto RepositoryFotos) : base(RepositoryFotos)
        {
            _RepositoryFotos = RepositoryFotos;
        }

        public List<Fotos> FotosPorAnimal(int animalId)
        {
            return _RepositoryFotos.GetAll().Where(x => x.AnimalId == animalId).ToList();
        }

        public void RemoverFotoPet(string descricaoPet)
        {
            Fotos objFoto = new Fotos();
            objFoto = _RepositoryFotos.GetAll().Where(x => x.DescricaoFoto == descricaoPet).FirstOrDefault();
            _RepositoryFotos.Remove(objFoto);
        }
    }
}
