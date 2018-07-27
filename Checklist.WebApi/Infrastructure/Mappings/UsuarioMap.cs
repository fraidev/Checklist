﻿using Checklist.WebApi.Domain;
using FluentNHibernate.Mapping;

namespace Checklist.WebApi.Infrastructure.Mappings
{
    public class UsuarioMap: ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Table("Usuario");

            Id(x => x.Id);
            
            Map(x => x.Nome);
        }
    }
}