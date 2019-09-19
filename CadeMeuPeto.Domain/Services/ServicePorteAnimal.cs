using CadeMeuPet.Domain.Entities;
using CadeMeuPet.Domain.Interfaces.Services;
using CadeMeuPet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeMeuPet.Domain.Services
{
    public class ServicePorteAnimal : ServiceBase<PorteAnimal>, IServicePorteAnimal
    {
        private readonly IRepositoryPorteAnimal _PorteAnimalRepository;

        public ServicePorteAnimal(IRepositoryPorteAnimal PorteAnimalRepository) : base(PorteAnimalRepository)
        {
            _PorteAnimalRepository = PorteAnimalRepository;
        }
    }
}
