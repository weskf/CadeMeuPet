using CadeMeuPet.Domain.Entities;
using CadeMeuPet.MVC.ViewModel;
using System.Collections.Generic;

namespace CadeMeuPet.Domain.Interfaces.Services
{
    public interface IServiceAnimal : IServiceBase<Animal>
    {
        Animal CadastrarPet(Animal objAnimal);
        void ExcluirPet(int AnimalId);
        void EditarPet(Animal objAnimal);
        IEnumerable<Animal> Filter(AnimalViewModel filter);
    }
}
