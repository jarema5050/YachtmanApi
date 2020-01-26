using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using YachmanAPI.Models;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using YachmanAPI.App_Start;

namespace YachmanAPI.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class HarborsController : ApiController
    {
        AutoMapperBase mapperBase = new AutoMapperBase();
        private ApplicationDbContext _context = new ApplicationDbContext();
        
        [HttpGet]
        // GET: api/harbors
        public IEnumerable<HarborDto> GetHarbors()
        {
            var harbors = _context.Harbors.ToList().Select(harbor => mapperBase._mapper.Map<HarborDto>(harbor));
            return harbors;
        }

    }
}
