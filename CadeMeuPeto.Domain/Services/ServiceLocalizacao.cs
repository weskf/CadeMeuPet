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
    public class ServiceLocalizacao : ServiceBase<Localizacao>, IServiceLocalizacao
    {
        private readonly IRepositoryLocalizacao _LocalizacaoRepository;

        public ServiceLocalizacao(IRepositoryLocalizacao LocalizacaoRepository) : base(LocalizacaoRepository)
        {
            _LocalizacaoRepository = LocalizacaoRepository;
        }
    }
}
