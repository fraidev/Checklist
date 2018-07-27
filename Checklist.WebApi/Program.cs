using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Checklist.WebApi.Domain;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Checklist.WebApi.Infrastructure;

namespace Checklist.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var sessionFactory = NHibernateHelper.CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var felipe = new Usuario("Felipe");
                    /*var tarefa1 = new Tarefa("Ir no Dentista", false, felipe);
                    var tarefa2 = new Tarefa("Cortar o cabelo", false, felipe);
                    var tarefa3 = new Tarefa("Estudar", true, felipe);*/

                    session.SaveOrUpdate(felipe);
                    /*session.SaveOrUpdate(tarefa1);
                    session.SaveOrUpdate(tarefa2);
                    session.SaveOrUpdate(tarefa3);*/

                    transaction.Commit();

                    Console.WriteLine("Usuario Criado: " + felipe.Nome + "\t");
                    /*Console.WriteLine("Tarefa Criada Created: " + tarefa1.Descricao + "\t");
                    Console.WriteLine("Tarefa Criada Created: " + tarefa2.Descricao + "\t");
                    Console.WriteLine("Tarefa Criada Created: " + tarefa3.Descricao + "\t");*/
                }
            }

        CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}