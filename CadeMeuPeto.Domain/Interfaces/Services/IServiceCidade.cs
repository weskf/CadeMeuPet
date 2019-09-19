using CadeMeuPet.Domain.Entities;
using System.Collections.Generic;

namespace CadeMeuPet.Domain.Interfaces.Services
{
    public interface IServiceCidade : IServiceBase<Cidade>
    {
        List<Cidade> BuscarCidadePorEstado(int EstadoId);
    }
}
