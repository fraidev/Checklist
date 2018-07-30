using System;
using System.Collections.Generic;

namespace Checklist.WebApi.Domain
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public IList<Tarefa> Tarefas { get; set; } = new List<Tarefa>();

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