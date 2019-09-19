using CadeMeuPet.Domain.Entities;
using System.Collections.Generic;

namespace CadeMeuPet.Domain.Interfaces.Services
{
    public interface IServiceEstado : IServiceBase<Estado>
    {
        List<Estado> RetornaEstados();
    }
}
