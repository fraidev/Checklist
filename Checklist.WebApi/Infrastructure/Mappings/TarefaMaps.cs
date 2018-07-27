using Checklist.WebApi.Domain;
using FluentNHibernate.Mapping;

namespace Checklist.WebApi.Infrastructure.Mappings
{
    public class TarefaMaps: ClassMap<Tarefa>
    {
        public TarefaMaps()
        {
            Table("Tarefa");

            Id(x => x.Id);
            
            Map(x => x.Descricao);
            Map(x => x.Criador);
            Map(x => x.Criacao);
            Map(x => x.Concluido);
            References(x => x.Responsavel, "ResponsavelId");
        }
    }
}