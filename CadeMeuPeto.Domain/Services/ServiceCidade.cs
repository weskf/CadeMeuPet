using CadeMeuPet.Domain.Entities;
using CadeMeuPet.Domain.Interfaces;
using CadeMeuPet.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace CadeMeuPet.Domain.Services
{
    public class ServiceCidade : ServiceBase<Cidade>, IServiceCidade
    {
        private readonly IRepositoryCidade _cidadeRepository;

        public ServiceCidade(IRepositoryCidade cidadeRepository) : base(cidadeRepository)
        {
            _cidadeRepository = cidadeRepository;
        }

        public List<Cidade> BuscarCidadePorEstado(int EstadoId)
        {
            return _cidadeRepository.RetornaCidadePorEstado(EstadoId);
        }
    }
}
