using CadeMeuPet.Domain.Entities;
using CadeMeuPet.Domain.Interfaces;
using CadeMeuPet.Domain.Interfaces.Services;

namespace CadeMeuPet.Domain.Services
{
    public class ServiceEspecieAnimal : ServiceBase<EspecieAnimal>, IServiceEspecieAnimal
    {
        private readonly IRepositoryEspecieAnimal _especieAnimalRepository;

        public ServiceEspecieAnimal(IRepositoryEspecieAnimal especieAnimalRepository) : base(especieAnimalRepository)
        {
            _especieAnimalRepository = especieAnimalRepository;
        }


    }
}
