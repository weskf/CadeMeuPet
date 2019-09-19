using CadeMeuPet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeMeuPet.Domain.Interfaces.Services
{
    public interface IServiceFotos : IServiceBase<Fotos>
    {
        List<Fotos> FotosPorAnimal(int animalId);
    }
}
