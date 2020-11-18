using AirflightsDomain.Models.Flight;
using AirflightsDomain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Airflights.Controllers
{
    /// <summary>
    /// рейсы
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightsService _flightService;

        /// <summary>
        /// конструктор - точка входа внедрения сервисов
        /// </summary>
        /// <param name="flightsService">сервис для рейсов</param>
        public FlightsController(IFlightsService flightsService)
        {
            this._flightService = flightsService;
        }

        /// <summary>
        /// получить все рейсы
        /// </summary>
        /// <returns></returns>
        // GET: api/<FlightsController>
        [HttpGet]
        public async Task<IEnumerable<FlightDTO>> Get()
        {
            return await _flightService.GetAllAsync();
        }

        /// <summary>
        /// получить рейс по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<FlightsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FlightsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FlightsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FlightsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
