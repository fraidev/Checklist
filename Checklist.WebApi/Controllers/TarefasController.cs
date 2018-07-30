using System;
using System.Collections.Generic;
using System.Linq;
using Checklist.WebApi.Domain;
using Checklist.WebApi.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using NHibernate;

namespace Checklist.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : Controller
    {
        // GET api/tarefas
        [HttpGet]
        public ActionResult<IEnumerable<Tarefa>> Get()
        {
            List<Tarefa> tarefas;

            var sessionFactory =  NHibernateHelper.CreateSessionFactory();
            using (ISession session = sessionFactory.OpenSession())  // Open a session to conect to the database
            {
                tarefas = session.Query<Tarefa>().ToList(); //  Querying to get all the books
            }
            return tarefas;
        }

        // GET api/tarefas
        [HttpGet("byUsuario/{id}")]
        public ActionResult<IEnumerable<Tarefa>> GetByUsuario(Guid id)
        {
            List<Tarefa> tarefas;

            var sessionFactory =  NHibernateHelper.CreateSessionFactory();
            using (ISession session = sessionFactory.OpenSession())  // Open a session to conect to the database
            {
                tarefas = session.Query<Tarefa>().Where(x => x.Responsavel.Id == id).ToList();
            }
            return tarefas;
        }
        
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Tarefa> Get(Guid id)
        {
            List<Tarefa> tarefa;

            var sessionFactory =  NHibernateHelper.CreateSessionFactory();
            using (ISession session = sessionFactory.OpenSession())  // Open a session to conect to the database
            {
                tarefa = session.Query<Tarefa>().ToList(); //  Querying to get all the books
            }

            return tarefa.First(x => x.Id == id);
        }
        
        // POST api/values
        [HttpPost]
        public void Post(Tarefa tarefa)
        {
            var sessionFactory =  NHibernateHelper.CreateSessionFactory();
            using (ISession session = sessionFactory.OpenSession())  // Open a session to conect to the database
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(new Tarefa(tarefa.Descricao, tarefa.Concluido, tarefa.Responsavel));
                    transaction.Commit();
                }
            }
        }
        
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(string nome, bool concluido, Usuario responsavel)
        {
            var sessionFactory =  NHibernateHelper.CreateSessionFactory();
            using (ISession session = sessionFactory.OpenSession())  // Open a session to conect to the database
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(new Tarefa(nome, concluido, responsavel));
                    transaction.Commit();
                }
            }
        }
        
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var sessionFactory =  NHibernateHelper.CreateSessionFactory();
            using (ISession session = sessionFactory.OpenSession())  // Open a session to conect to the database
            {
                using (var transaction = session.BeginTransaction())
                {
                    var tarefa = session.Query<Tarefa>().ToList();
                    var l = tarefa.First(x => x.Id == id);
                    session.Delete(l);
                    transaction.Commit();
                }
            }
        }
    }
}