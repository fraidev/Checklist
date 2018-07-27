using System;

namespace Checklist.WebApi.Domain
{
    public class Usuario
    {
        public virtual Guid Id { get; set; }
        public virtual string Nome { get; set; }

        public Usuario()
        {
            
        }
        
        public Usuario(string nome)
        {
            Id = new Guid();
            Nome = nome;
        }
    }
}