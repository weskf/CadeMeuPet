using CadeMeuPet.Domain.Entities;
using CadeMeuPet.Domain.Interfaces;
using CadeMeuPet.Domain.Interfaces.Services;
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

        public Animal CadastrarAnimal(Animal objAnimal)
        {
            _AnimalRepository.Add(objAnimal);

            return _AnimalRepository.GetAll()
                                    .Where(_ => _.UsuarioId == objAnimal.UsuarioId)
                                    .OrderByDescending(_ => _.AnimalId)
                                    .FirstOrDefault();
        }
    }
}
