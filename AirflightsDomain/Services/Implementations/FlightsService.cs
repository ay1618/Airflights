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

        public Task CreateAsync(CreateFlightDTO flight)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FlightDTO>> GetAllAsync() => (await _flightsRepository.GetAsync()).ToList();

        public Task<FlightDTO> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
