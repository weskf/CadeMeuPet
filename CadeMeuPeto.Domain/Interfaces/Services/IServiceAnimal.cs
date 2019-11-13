using CadeMeuPet.Domain.Entities;
using CadeMeuPet.MVC.ViewModel;

namespace CadeMeuPet.Domain.Interfaces.Services
{
    public interface IServiceAnimal : IServiceBase<Animal>
    {
        Animal CadastrarPet(Animal objAnimal);
        void ExcluirPet(int AnimalId);
        void EditarPet(Animal objAnimal);
        AnimalViewModel Filter(AnimalViewModel filter);
    }
}
