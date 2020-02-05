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

        [Route("api/Cruises/Members/{cruiseId}")]
        [HttpGet]
        public IEnumerable<string> GetEnrolledUsers(int cruiseId)
        {
            var enrolledUsers = _context.CruiseMembers.Where(c => c.CruiseId == cruiseId).ToList();
            List<string> userNames = new List<string>(); 
            foreach (CruiseMember user in enrolledUsers){
                var appUser = _context.AppUsers.SingleOrDefault(u => u.Id == user.UserId);
                userNames.Add(appUser.Name + " " + appUser.Surname);
            }
            return userNames;
        }
        [Route("api/Cruises/Members/{memberId}")]
        [HttpDelete]
        public IHttpActionResult DeleteCruiseMember(int memberId)
        {
            var cruiseMember = _context.CruiseMembers.Single(c => c.UserId == memberId);
            if (cruiseMember == null)
            {
                return NotFound();
            }
            _context.CruiseMembers.Remove(cruiseMember);
            _context.SaveChanges();
            return Ok(cruiseMember);
        }
        // POST: api/Cruises
        [Route("api/Cruises/Members")]
        [HttpPost]
        public IHttpActionResult PostCruiseMember(CruiseMember cruiseMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CruiseMembers.Add(cruiseMember);
            _context.SaveChanges();

            return Created("Created successfully", cruiseMember);
        }

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
                cruiseDto.OwnerId = _context.Ships.SingleOrDefault(s => s.Id == cruise.ShipId).OwnerId;
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
        [HttpPut]
        // PUT: api/Cruises/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCruise(int id, CruiseDto cruiseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cruise = _context.Cruises.SingleOrDefault(c => c.Id == id);
            //_context.Cruises.Remove(cruise);
            if (cruiseDto.ArrivalDateDto != null)
            {
                cruise.ArrivalDate = new DateTime(cruiseDto.ArrivalDateDto.Year, cruiseDto.ArrivalDateDto.Month, cruiseDto.ArrivalDateDto.Day, cruiseDto.ArrivalDateDto.Hour, cruiseDto.ArrivalDateDto.Minute, 0);
            }
            if(cruiseDto.DepartureDateDto != null)
            {
                cruise.DepartureDate = new DateTime(cruiseDto.DepartureDateDto.Year, cruiseDto.DepartureDateDto.Month, cruiseDto.DepartureDateDto.Day, cruiseDto.DepartureDateDto.Hour, cruiseDto.DepartureDateDto.Minute, 0);
            }
            if(cruiseDto.ArrivalHarborName != null)
            {
                cruise.ArrivalHarborId = _context.Harbors.SingleOrDefault(h => h.City == cruiseDto.ArrivalHarborName).Id;
            }
            if(cruiseDto.DepartureHarborName != null)
            {
                cruise.DepartureHarborId = _context.Harbors.SingleOrDefault(h => h.City == cruiseDto.DepartureHarborName).Id;
            }
            if(cruiseDto.ShipName != null)
            {
                cruise.ShipId = _context.Ships.SingleOrDefault(s => s.Name == cruiseDto.ShipName).Id;
            }
            //_context.Cruises.Add(cruise);
            _context.SaveChanges();
            return Ok();
        }

        // POST: api/Cruises
        [ResponseType(typeof(Cruise))]
        public IHttpActionResult PostCruise(CruiseDto cruiseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cruise = new Cruise();
            cruise.ArrivalDate = new DateTime(cruiseDto.ArrivalDateDto.Year, cruiseDto.ArrivalDateDto.Month, cruiseDto.ArrivalDateDto.Day, cruiseDto.ArrivalDateDto.Hour, cruiseDto.ArrivalDateDto.Minute, 0);
            cruise.DepartureDate = new DateTime(cruiseDto.DepartureDateDto.Year, cruiseDto.DepartureDateDto.Month, cruiseDto.DepartureDateDto.Day, cruiseDto.DepartureDateDto.Hour, cruiseDto.DepartureDateDto.Minute, 0);
            cruise.ArrivalHarborId = _context.Harbors.SingleOrDefault(h => h.City == cruiseDto.ArrivalHarborName).Id;
            cruise.DepartureHarborId = _context.Harbors.SingleOrDefault(h => h.City == cruiseDto.DepartureHarborName).Id;
            cruise.ShipId = _context.Ships.SingleOrDefault(s => s.Name == cruiseDto.ShipName).Id;
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