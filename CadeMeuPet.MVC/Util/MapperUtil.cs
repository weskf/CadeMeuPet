using AutoMapper;
using CadeMeuPet.Domain.Entities;
using CadeMeuPet.MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadeMeuPet.MVC.Util
{
    public class MapperUtil
    {
        public Animal MapperAnimal(AnimalViewModel ViewModel)
        {
            var config = new MapperConfiguration(c => c.CreateMap<AnimalViewModel, Animal>());
            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<AnimalViewModel, Animal>(ViewModel);
        }

        public AnimalViewModel MapperAnimalViewModel(Animal objAnimal)
        {
            var config = new MapperConfiguration(c => c.CreateMap<Animal, AnimalViewModel>());
            IMapper iMapper = config.CreateMapper();

            return iMapper.Map<Animal, AnimalViewModel> (objAnimal);
        }
    }
}