using AirflightsDomain.Models.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirflightsDomain.Services
{
    public class FlightsService
    {
        private readonly IFlightsRepository _flightsRepository;

        public FlightsService(IFlightsRepository flightsRepository)
        {
            this._flightsRepository = flightsRepository;
        }

        public async Task<List<FlightDTO>> GetAll() => (await _flightsRepository.GetAsync()).ToList();
    }
}
