using System;

namespace Checklist.WebApi.Domain
{
    public class Tarefa
    {
        public string Descricao { get; set; }
        public string Criador { get; set; }
        public DateTime Criacao { get; set; }
        public bool Concluido { get; set; }
        public Usuario Responsavel { get; set; }
    }
}