using CadeMeuPet.Domain.Entities;
using System.Collections.Generic;

namespace CadeMeuPet.Domain.Interfaces
{
    public interface IRepositoryRacaAnimal : IRepositoryBase<RacaAnimal>
    {
        List<RacaAnimal> RetornaRacaPorEspecie(int especieAnimalId);
    }
}
