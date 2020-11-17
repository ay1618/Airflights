using AirflightsDomain.Models;
using AirflightsDomain.Services;
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
    public class DictController : ControllerBase
    {
        private readonly DictService _dictService;

        public DictController(DictService dictService)
        {
            this._dictService = dictService;
        }

        [HttpGet("cities")]
        public async Task<List<CityDTO>> Cities()
        {
            return await _dictService.GetAll();
        }
        
    }
}
