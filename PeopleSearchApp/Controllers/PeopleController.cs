using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using PeopleSearchApp.Models;
using PeopleSearchApp.Models.DAL;

namespace PeopleSearchApp.Controllers
{
    public class PeopleController : ApiController
    {
        private PersonContext db = new PersonContext();

        /// <summary>
        /// Returning all persons in database
        /// </summary>
        /// <returns></returns>
        // GET: api/People
        public IQueryable<Person> GetPerson()
        {
            return db.Person;
        }

        /// <summary>
        /// Returning single person with specified person id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/People/5
        [ResponseType(typeof(Person))]
        public IHttpActionResult GetPerson(int id)
        {
            Person person = db.Person.Find(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }
        /// <summary>
        /// Editing person from database with new property data
        /// and binding properties to protect overposting
        /// </summary>
        /// <param name="id"></param>
        /// <param name="person"></param>
        /// <returns></returns>
        // PUT: api/People/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPerson(int id, [Bind(Include = "PersonID, FirstName, LastName, StreetAddress, City, State, Zip, Age, Interests, PhotoPath")] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.PersonID)
            {
                return BadRequest();
            }

            db.Entry(person).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Content(HttpStatusCode.Accepted, person);
        }
        /// <summary>
        /// Adding new person to databse
        /// and binding properties to protect overposting
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        // POST: api/People
        [ResponseType(typeof(Person))]
        public IHttpActionResult PostPerson([Bind(Include = "PersonID, FirstName, LastName, StreetAddress, City, State, Zip, Age, Interests, PhotoPath")] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Person.Add(person);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = person.PersonID }, person);
        }
        /// <summary>
        /// Deleting person from database using person id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/People/5
        [ResponseType(typeof(Person))]
        public IHttpActionResult DeletePerson(int id)
        {
            Person person = db.Person.Find(id);
            if (person == null)
            {
                return NotFound();
            }

            db.Person.Remove(person);
            db.SaveChanges();

            return Ok(person);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonExists(int id)
        {
            return db.Person.Count(e => e.PersonID == id) > 0;
        }
    }
}