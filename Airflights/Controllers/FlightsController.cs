using AirflightsDomain.Models;
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
    public class FlightsController : _BaseController//ControllerBase
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
        public async Task<List<FlightDTO>> Get()
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
        public async Task<ActionResult<FlightDTO>> Get(int id)
        {
            return await _flightService.GetAsync(id);
        }

        // POST api/<FlightsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<FlightsController>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] CreateFlightDTO flight)
        {
            await _flightService.CreateAsync(flight);
            return Ok();
        }

        // DELETE api/<FlightsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _flightService.DeleteAsync(id);
            return Ok();
        }
    }
}
