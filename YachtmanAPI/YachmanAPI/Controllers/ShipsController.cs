using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using YachmanAPI.Models;

namespace YachmanAPI.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class ShipsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //GET
        [Route("api/ships/owner/{id}")]
        public IEnumerable<Ship> GetShipsbyOwnerId(int id)
        {
            var ships= db.Ships.Where(s => s.OwnerId == id);
 
            return ships;
        }

        // GET: api/Ships
        public IQueryable<Ship> GetShips()
        {
            return db.Ships;
        }

        // GET: api/Ships/5
        [ResponseType(typeof(Ship))]
        public IHttpActionResult GetShip(int id)
        {
            Ship ship = db.Ships.Find(id);
            if (ship == null)
            {
                return NotFound();
            }

            return Ok(ship);
        }

        // PUT: api/Ships/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutShip(int id, Ship ship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ship.Id)
            {
                return BadRequest();
            }

            db.Entry(ship).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShipExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Ships
        [ResponseType(typeof(Ship))]
        public IHttpActionResult PostShip(Ship ship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ships.Add(ship);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ship.Id }, ship);
        }

        // DELETE: api/Ships/5
        [ResponseType(typeof(Ship))]
        public IHttpActionResult DeleteShip(int id)
        {
            Ship ship = db.Ships.Find(id);
            if (ship == null)
            {
                return NotFound();
            }

            db.Ships.Remove(ship);
            db.SaveChanges();

            return Ok(ship);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShipExists(int id)
        {
            return db.Ships.Count(e => e.Id == id) > 0;
        }
    }
}