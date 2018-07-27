using System;

namespace Checklist.WebApi.Domain
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

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