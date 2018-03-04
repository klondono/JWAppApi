using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JWAppApi.DbEntities;
using BusinessServices.Interfaces;

namespace JWAppApi.Controllers
{
    [Route("api/[controller]")]
    public class TerritoriesController : Controller
    {
        private readonly ITerritoryService _territoryService;

        public TerritoriesController(ITerritoryService territoryService){

            _territoryService = territoryService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_territoryService.GetTerritories());

            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
