using System;
using Microsoft.CodeAnalysis;

namespace Checklist.WebApi.Domain
{
    public class Tarefa
    {
        public virtual Guid Id { get; set; }
        public virtual string Criador { get; set; }
        public virtual DateTime Criacao { get; set; }
        
        public virtual string Descricao { get; set; }
        public virtual bool Concluido { get; set; }
        public virtual Usuario Responsavel { get; set; }

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