using AirflightsDomain.Models.Flight;
using AirflightsDomain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirflightsDomain.Services.Implementations
{
    public class FlightsService : IFlightsService
    {
        private readonly IFlightsRepository _flightsRepository;

        public FlightsService(IFlightsRepository flightsRepository)
        {
            this._flightsRepository = flightsRepository;
        }

        public async Task<List<FlightDTO>> GetAllAsync() => (await _flightsRepository.GetAsync()).ToList();
    }
}
