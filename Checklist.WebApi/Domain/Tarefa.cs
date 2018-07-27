using System;
using Microsoft.CodeAnalysis;

namespace Checklist.WebApi.Domain
{
    public class Tarefa
    {
        public Guid Id { get; set; }
        public string Criador { get; set; }
        public DateTime Criacao { get; set; }
        
        public string Descricao { get; set; }
        public bool Concluido { get; set; }
        public Usuario Responsavel { get; set; }

        public Tarefa()
        {
            
        }

        public Tarefa(string descricao, bool concluido, Usuario responsavel)
        {
            Id = new Guid();
            Descricao = descricao;
            Criador = responsavel.Nome;
            Criacao = DateTime.Now;
            Concluido = concluido;
            Responsavel = responsavel;
        }
    }
}