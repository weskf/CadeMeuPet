using CadeMeuPet.Domain.Entities;
using System.Collections.Generic;

namespace CadeMeuPet.Domain.Interfaces.Services
{
    public interface IServiceFotos : IServiceBase<Fotos>
    {
        List<Fotos> FotosPorAnimal(int animalId);
        void RemoverFotoPet(string descricaoPet);
    }
}
