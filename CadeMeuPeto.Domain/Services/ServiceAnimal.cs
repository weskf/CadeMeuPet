using CadeMeuPet.Domain.Entities;
using CadeMeuPet.Domain.Interfaces;
using CadeMeuPet.Domain.Interfaces.Services;
using CadeMeuPet.MVC.ViewModel;
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
            _objAnimal.Localizacao.Bairro = objAnimal.Localizacao.Bairro;
            _objAnimal.Localizacao.Logradouro = objAnimal.Localizacao.Logradouro;
            _objAnimal.Localizacao.EstadoId = objAnimal.Localizacao.EstadoId;
            _objAnimal.Localizacao.CidadeId = objAnimal.Localizacao.CidadeId;

            _AnimalRepository.Update(_objAnimal);
            
        }

        public IEnumerable<Animal> Filter(AnimalViewModel filter)
        {
            
            var lstAnimal = _AnimalRepository.GetAll();

            if(!string.IsNullOrWhiteSpace(filter.Caracteristica))
                lstAnimal = lstAnimal.Where(x => x.Caracteristica.Contains(filter.Caracteristica));
            
            if(filter.Localizacao.EstadoId != 0)
                lstAnimal = lstAnimal.Where(x => x.Localizacao.EstadoId == filter.Localizacao.EstadoId);

            if(filter.Localizacao.CidadeId != 0)
                lstAnimal = lstAnimal.Where(x => x.Localizacao.CidadeId == filter.Localizacao.CidadeId);

            if(string.IsNullOrEmpty(filter.Localizacao.Bairro))
                lstAnimal = lstAnimal.Where(x => x.Localizacao.Bairro.Contains(filter.Localizacao.Bairro));

            if(filter.EspecieAnimalId != 0)
                lstAnimal = lstAnimal.Where(x => x.EspecieAnimalId == filter.EspecieAnimalId);

            if(filter.RacaAnimalId != 0)
                lstAnimal = lstAnimal.Where(x => x.RacaAnimalId == filter.RacaAnimalId);

            if(filter.PorteAnimalId != 0)
                lstAnimal = lstAnimal.Where(x => x.PorteAnimalId == filter.PorteAnimalId);

            if(filter.CorAnimalId != 0)
                lstAnimal = lstAnimal.Where(x => x.CorAnimalId == filter.CorAnimalId);

            return lstAnimal;
        }
    }
}
