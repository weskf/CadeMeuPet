using CadeMeuPet.Domain.Entities;
using CadeMeuPet.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CadeMeuPet.Data.Repositories
{
    public class RepositoryRacaAnimal : RepositoryBase<RacaAnimal>, IRepositoryRacaAnimal
    {
        public List<RacaAnimal> RetornaRacaPorEspecie(int especieAnimalId)
        {
            List<RacaAnimal> ListRaca = Db.RacaAnimal.Where(x => x.EspecieAnimalId == especieAnimalId).ToList();
            return ListRaca;
        }
    }
}
