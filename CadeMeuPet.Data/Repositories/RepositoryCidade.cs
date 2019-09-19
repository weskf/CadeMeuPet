using CadeMeuPet.Domain.Entities;
using CadeMeuPet.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CadeMeuPet.Data.Repositories
{
    public class RepositoryCidade : RepositoryBase<Cidade>, IRepositoryCidade
    {
        public List<Cidade> RetornaCidadePorEstado(int EstadoId)
        {
            List<Cidade> ListCidade = Db.Cidade.Where(x => x.EstadoId == EstadoId).ToList();
            return ListCidade;
        }
    }
}
