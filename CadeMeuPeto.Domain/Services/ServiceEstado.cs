using CadeMeuPet.Domain.Interfaces.Services;
using CadeMeuPet.Domain.Entities;
using CadeMeuPet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeMeuPet.Domain.Services
{
    public class ServiceEstado : ServiceBase<Estado>, IServiceEstado
    {
        private readonly IRepositoryEstado _EstadoRepository;

        public ServiceEstado(IRepositoryEstado EstadoRepository) : base(EstadoRepository)
        {
            _EstadoRepository = EstadoRepository;
        }

        public List<Estado> RetornaEstados()
        {
            return _EstadoRepository.GetAll().ToList();
        }
    }
}
