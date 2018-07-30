using System;
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
        
        // GET api/usuarios/5
        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(Guid id)
        {
            List<Usuario> usuario;

            var sessionFactory =  NHibernateHelper.CreateSessionFactory();
            using (ISession session = sessionFactory.OpenSession())  // Open a session to conect to the database
            {
                usuario = session.Query<Usuario>().ToList(); //  Querying to get all the books
            }

            return usuario.First(x => x.Id == id);
        }
        
        // POST api/usuarios
        [HttpPost]
        public void Post(Usuario usuario)
        {
            var sessionFactory =  NHibernateHelper.CreateSessionFactory();
            using (ISession session = sessionFactory.OpenSession())  // Open a session to conect to the database
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(usuario);
                    transaction.Commit();
                }
            }
        }

        // PUT api/usuarios/5
        [HttpPut("{id}")]
        public void Put(Usuario usuario)
        {
            var sessionFactory =  NHibernateHelper.CreateSessionFactory();
            using (ISession session = sessionFactory.OpenSession())  // Open a session to conect to the database
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(usuario);
                    transaction.Commit();
                }
            }
        }

        // DELETE api/usuarios/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var sessionFactory =  NHibernateHelper.CreateSessionFactory();
            using (ISession session = sessionFactory.OpenSession())  // Open a session to conect to the database
            {
                using (var transaction = session.BeginTransaction())
                {
                    var usuario = session.Query<Usuario>().ToList();
                    var l = usuario.First(x => x.Id == id);
                    session.Delete(l);
                    transaction.Commit();
                }
            }
        }
    }
}