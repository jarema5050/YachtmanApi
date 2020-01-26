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
using YachmanAPI.Models;
using YachmanAPI.Dtos;
using System.Web.Http.Cors;


namespace YachmanAPI.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class CruisesController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: api/Cruises
        [HttpGet]
        public IEnumerable<CruiseDto> GetCruises()
        {
            var cruises = new List<Cruise>();
            cruises = _context.Cruises.ToList();
            var cruisesResponse = new List<CruiseDto>();
            foreach(Cruise cruise in cruises)
            {
                var cruiseDto = new CruiseDto();
                cruiseDto.ArrivalDate = cruise.ArrivalDate;
                cruiseDto.DepartureDate = cruise.DepartureDate;
                cruiseDto.ShipName = _context.Ships.SingleOrDefault(s => s.Id == cruise.ShipId).Name;
                cruiseDto.DepartureHarborName = _context.Harbors.SingleOrDefault(h => h.Id == cruise.DepartureHarborId).City;
                cruiseDto.ArrivalHarborName = _context.Harbors.SingleOrDefault(h => h.Id == cruise.ArrivalHarborId).City;
                cruiseDto.Id = cruise.Id;
                cruisesResponse.Add(cruiseDto);
            }
            return cruisesResponse;
        }

        // GET: api/Cruises/5
        [ResponseType(typeof(Cruise))]
        public IHttpActionResult GetCruise(int id)
        {
            Cruise cruise = _context.Cruises.Find(id);
            if (cruise == null)
            {
                return NotFound();
            }

            return Ok(cruise);
        }

        // PUT: api/Cruises/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCruise(int id, Cruise cruise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cruise.Id)
            {
                return BadRequest();
            }

            _context.Entry(cruise).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CruiseExists(id))
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

        // POST: api/Cruises
        [ResponseType(typeof(Cruise))]
        public IHttpActionResult PostCruise(Cruise cruise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Cruises.Add(cruise);
            _context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cruise.Id }, cruise);
        }

        // DELETE: api/Cruises/5
        [ResponseType(typeof(Cruise))]
        public IHttpActionResult DeleteCruise(int id)
        {
            Cruise cruise = _context.Cruises.Find(id);
            if (cruise == null)
            {
                return NotFound();
            }

            _context.Cruises.Remove(cruise);
            _context.SaveChanges();

            return Ok(cruise);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CruiseExists(int id)
        {
            return _context.Cruises.Count(e => e.Id == id) > 0;
        }
    }
}