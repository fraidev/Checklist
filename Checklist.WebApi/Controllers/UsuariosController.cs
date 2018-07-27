using System.Collections;
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
    public class UsuariosController : Controller
    {
        // GET api/usuarios
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            List<Usuario> usuarios;

            var sessionFactory =  NHibernateHelper.CreateSessionFactory();
            using (ISession session = sessionFactory.OpenSession())  // Open a session to conect to the database
            {
                usuarios = session.Query<Usuario>().ToList(); //  Querying to get all the books
            }

            return usuarios;
        }
    }
}