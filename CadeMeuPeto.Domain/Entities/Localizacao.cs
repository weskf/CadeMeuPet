using System;
using System.Collections.Generic;

namespace CadeMeuPet.Domain.Entities
{
    public class Localizacao
    {
        public int LocalizacaoId { get; set; }
        public int EstadoId { get; set; }
        public int CidadeId { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public DateTime DataLocalizacao { get; set; }

        public virtual Estado Estado { get; set; }
        public virtual Cidade Cidade { get; set; }
    }

    public class Estado
    {
        public int EstadoId { get; set; }
        public string NomeEstado { get; set; }
        public virtual IEnumerable<Cidade> Cidades { get; set; }
    }

    public class Cidade
    {
        public int CidadeId { get; set; }
        public string NomeCidade { get; set; }
        public int EstadoId { get; set; }
        public virtual Estado Estado { get; set; }
    }




}
