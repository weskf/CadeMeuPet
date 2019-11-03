using CadeMeuPet.Domain.Entities;
using CadeMeuPet.Domain.Interfaces;
using CadeMeuPet.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace CadeMeuPet.Domain.Services
{
    public class ServiceAnimal : ServiceBase<Animal>, IServiceAnimal
    {
        private readonly IRepositoryAnimal _AnimalRepository;

        public ServiceAnimal(IRepositoryAnimal AnimalRepository) : base(AnimalRepository)
        {
            _AnimalRepository = AnimalRepository;
        }

        public Animal CadastrarPet(Animal objAnimal)
        {
            _AnimalRepository.Add(objAnimal);

            return _AnimalRepository.GetAll()
                                    .Where(_ => _.UsuarioId == objAnimal.UsuarioId)
                                    .OrderByDescending(_ => _.AnimalId)
                                    .FirstOrDefault();
        }

        public void ExcluirPet(int AnimalId)
        {
            Animal objAnimal = new Animal();
            objAnimal = _AnimalRepository.GetById(AnimalId);
            objAnimal.Ativo = false;
            _AnimalRepository.Update(objAnimal);
        }

        public void EditarPet(Animal objAnimal)
        {
            var _objAnimal = new Animal();
            _objAnimal = _AnimalRepository.GetById(objAnimal.AnimalId);

            _objAnimal.EspecieAnimalId = objAnimal.EspecieAnimalId;
            _objAnimal.RacaAnimalId = objAnimal.RacaAnimalId;
            _objAnimal.CorAnimalId = objAnimal.CorAnimalId;
            _objAnimal.PorteAnimalId = objAnimal.PorteAnimalId;
            _objAnimal.Identificacao = objAnimal.Identificacao;
            _objAnimal.Caracteristica = objAnimal.Caracteristica;
            _objAnimal.Ativo = objAnimal.Ativo;

            var _localizacao = new Localizacao();
            _localizacao.Bairro = objAnimal.Localizacao.Bairro;
            _localizacao.Logradouro = objAnimal.Localizacao.Logradouro;
            _localizacao.EstadoId = objAnimal.Localizacao.EstadoId;
            _localizacao.CidadeId = objAnimal.Localizacao.CidadeId;

            _AnimalRepository.Update(_objAnimal);
        }
    }
}
