using CadeMeuPet.Domain.Entities;
using CadeMeuPet.Domain.Interfaces.Services;
using CadeMeuPet.Domain.Interfaces;

namespace CadeMeuPet.Domain.Services
{
    public class ServiceCorAnimal : ServiceBase<CorAnimal>, IServiceCorAnimal
    {
        private readonly IRepositoryCorAnimal _corAnimalRepository;

        public ServiceCorAnimal(IRepositoryCorAnimal corAnimalRepository) : base(corAnimalRepository)
        {
            _corAnimalRepository = corAnimalRepository;
        }
    }
}
