using CadeMeuPet.Domain.Entities;
using System.Collections.Generic;

namespace CadeMeuPet.Domain.Interfaces
{
    public interface IRepositoryCidade : IRepositoryBase<Cidade>
    {
        List<Cidade> RetornaCidadePorEstado(int EstadoId);
    }
}
