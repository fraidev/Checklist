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
    }
}