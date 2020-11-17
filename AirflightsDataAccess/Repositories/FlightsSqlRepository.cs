using AirflightsDataAccess.Entities;
using AirflightsDomain.Models;
using AirflightsDomain.Models.Flight;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirflightsDataAccess.Repositories
{
    public class FlightsSqlRepository : AirflightsDomain.IFlightsRepository
    {
        private readonly ApplicationContext _dbContext;
        private readonly IMapper _mapper;

        public FlightsSqlRepository(ApplicationContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        public Task AddDelayAsync(int flightId, TimeSpan delay)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAsync(CreateFlightDTO flight)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int flightId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FlightDTO>> GetAsync()
        {
            IEnumerable<Flight> flights = await _dbContext.Flights.ToListAsync();
            return _mapper.Map<IEnumerable<FlightDTO>>(flights);
        }

        public Task<FlightDTO> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UpdateFlightDTO flight)
        {
            throw new NotImplementedException();
        }
    }
}
