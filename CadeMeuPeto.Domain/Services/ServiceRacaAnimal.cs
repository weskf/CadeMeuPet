using System.Collections.Generic;
using CadeMeuPet.Domain.Entities;
using CadeMeuPet.Domain.Interfaces.Services;
using CadeMeuPet.Domain.Interfaces;

namespace CadeMeuPet.Domain.Services
{
    public class ServiceRacaAnimal : ServiceBase<RacaAnimal>, IServiceRacaAnimal
    {
        private readonly IRepositoryRacaAnimal _RacaAnimalRepository;

        public ServiceRacaAnimal(IRepositoryRacaAnimal RacaAnimalRepository) : base(RacaAnimalRepository)
        {
            _RacaAnimalRepository = RacaAnimalRepository;
        }

        public List<RacaAnimal> RetornaRacaPorEspecie(int especieAnimalId)
        {
            return _RacaAnimalRepository.RetornaRacaPorEspecie(especieAnimalId);
        }
    }
}
