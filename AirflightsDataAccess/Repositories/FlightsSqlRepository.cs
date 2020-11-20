using AirflightsDataAccess.Entities;
using AirflightsDomain.Models;
using AirflightsDomain.Models.Entities;
using AirflightsDomain.Models.Flight;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirflightsDataAccess.Repositories
{
    public class FlightsSqlRepository : AirflightsDomain.Repositories.IFlightsRepository
    {
        private readonly ApplicationContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FlightsSqlRepository(ApplicationContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
            this._httpContextAccessor = httpContextAccessor;
        }

        public Task AddDelayAsync(int flightId, TimeSpan delay)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(Flight flight)
        {
            await _dbContext.AddAsync(flight);
            await _dbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(int flightId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Flight>> GetAsync()
            => await _dbContext.Flights
                .Include(f => f.FromCity)
                .Include(f => f.ToCity)
                .ToListAsync();

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
