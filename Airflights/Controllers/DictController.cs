using AirflightsDomain.Models;
using AirflightsDomain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airflights.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DictController : _BaseController //ControllerBase
    {
        private readonly IDictService _dictService;

        public DictController(IDictService dictService)
        {
            this._dictService = dictService;
        }

        [HttpGet("cities")]
        public async Task<ActionResult<List<CityDTO>>> Cities()
        {
            return Ok(await _dictService.GetCitiesAsync());
        }
        
    }
}
