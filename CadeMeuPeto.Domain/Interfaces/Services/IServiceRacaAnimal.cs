using CadeMeuPet.Domain.Entities;
using System.Collections.Generic;

namespace CadeMeuPet.Domain.Interfaces.Services
{
    public interface IServiceRacaAnimal : IServiceBase<RacaAnimal>
    {
        List<RacaAnimal> RetornaRacaPorEspecie(int especieAnimalId);
    }
}
