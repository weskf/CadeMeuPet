using CadeMeuPet.Domain.Entities;

namespace CadeMeuPet.Domain.Interfaces.Services
{
    public interface IServiceAnimal : IServiceBase<Animal>
    {
        Animal CadastrarAnimal(Animal objAnimal);
    }
}
