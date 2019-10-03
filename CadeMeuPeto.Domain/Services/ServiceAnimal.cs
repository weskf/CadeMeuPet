using CadeMeuPet.Domain.Entities;
using CadeMeuPet.Domain.Interfaces;
using CadeMeuPet.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace CadeMeuPet.Domain.Services
{
    public class ServiceAnimal : ServiceBase<Animal>, IServiceAnimal
    {
        private readonly IRepositoryAnimal _AnimalRepository;

        public ServiceAnimal(IRepositoryAnimal AnimalRepository) : base(AnimalRepository)
        {
            _AnimalRepository = AnimalRepository;
        }

        public Animal CadastrarPet(Animal objAnimal)
        {
            _AnimalRepository.Add(objAnimal);

            return _AnimalRepository.GetAll()
                                    .Where(_ => _.UsuarioId == objAnimal.UsuarioId)
                                    .OrderByDescending(_ => _.AnimalId)
                                    .FirstOrDefault();
        }

        public void ExcluirPet(int AnimalId)
        {
            Animal objAnimal = new Animal();
            objAnimal = _AnimalRepository.GetById(AnimalId);
            objAnimal.Ativo = false;
            _AnimalRepository.Update(objAnimal);
        }
    }
}
