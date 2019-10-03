using CadeMeuPet.Domain.Entities;

namespace CadeMeuPet.Domain.Interfaces.Services
{
    public interface IServiceAnimal : IServiceBase<Animal>
    {
        Animal CadastrarPet(Animal objAnimal);
        void ExcluirPet(int AnimalId);
    }
}
