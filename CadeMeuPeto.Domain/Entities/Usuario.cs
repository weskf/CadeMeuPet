using System;
using System.Collections.Generic;

namespace CadeMeuPet.Domain.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string RedeSocial { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public int AnimalId { get; set; }
        
        public virtual ICollection<Animal> Animais { get; set; }

        public Usuario()
        {
            Animais = new HashSet<Animal>();
        }
    }
}
