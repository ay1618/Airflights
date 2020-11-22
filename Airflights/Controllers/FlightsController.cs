using AirflightsDomain.Models;
using AirflightsDomain.Models.Flight;
using AirflightsDomain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airflights.Attributes;

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
        public async Task<ActionResult<List<FlightDTO>>> Get()
        {
            return Ok(await _flightService.GetAllAsync());
        }

        /// <summary>
        /// получить рейсы по фильтру
        /// </summary>
        /// <returns></returns>
        // GET: api/<FlightsController>
        [HttpGet("filter")]
        public async Task<ActionResult<List<FlightDTO>>> GetFiltered([FromQuery] FlightFilterRequestDTO filterData)
        {
            return Ok(await _flightService.GetFiltered(filterData));
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
            return Ok(await _flightService.GetAsync(id));
        }

        /// <summary>
        /// создание
        /// </summary>
        /// <param name="flight"></param>
        /// <returns></returns>
        // PUT api/<FlightsController>
        [Authorize(Roles = "ADM")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] CreateFlightDTO flight)
        {
            await _flightService.CreateAsync(flight);
            return Ok();
        }


        /// <summary>
        /// редактирование
        /// </summary>
        /// <param name="flight"></param>
        /// <returns></returns>
        [Authorize(Roles = "ADM")]
        [HttpPatch]
        public async Task<ActionResult> Patch([FromBody] UpdateFlightDTO flight)
        {
            await _flightService.UpdateAsync(flight);
            return Ok();
        }

        /// <summary>
        /// редактировать задержку 
        /// </summary>
        /// <param name="flight"></param>
        /// <returns></returns>
        [Authorize(Roles = "ADM, MOD")]
        [HttpPatch("delayEdit")]
        public async Task<ActionResult> PatchDelay([FromBody] UpdateFlightDelayDTO delayFlight)
        {
            await _flightService.UpdateDelayAsync(delayFlight);
            return Ok();
        }

        /// <summary>
        /// удаление
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<FlightsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _flightService.DeleteAsync(id);
            return Ok();
        }
    }
}
