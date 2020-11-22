using AirflightsDataAccess.Entities;
using AirflightsDomain.Models;
using AirflightsDomain.Models.Entities;
using AirflightsDomain.Models.Flight;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<Flight>> GetAsync(FlightFilterRequestDTO filter)
        {
            IQueryable<Flight> flights = _dbContext.Flights;


            if (filter.From != null)
            {
                flights = flights.Where(f => f.FromCityId == filter.From);
            }

            if (filter.To != null)
            {
                flights = flights.Where(f => f.ToCityId == filter.To);
            }

            if (filter.DepartureTimeFrom != null && filter.DepartureTimeFrom != DateTime.MinValue)
            {
                flights = flights
                   .Where(f => f.DepartureTime >= filter.DepartureTimeFrom);
            }

            if (filter.DepartureTimeUntil != null && filter.DepartureTimeUntil != DateTime.MaxValue)
            {
                flights = flights
                   .Where(f => f.DepartureTime <= filter.DepartureTimeUntil);
            }

            //if (filter.ArrivalTimeFrom != DateTime.MinValue)
            //{
            //    flights = flights
            //       .Where(f => f.ArrivalTime >= filter.ArrivalTimeFrom);
            //}

            //if (filter.ArrivalTimeUntil != DateTime.MaxValue)
            //{
            //    flights = flights
            //       .Where(f => f.ArrivalTime <= filter.ArrivalTimeUntil);
            //}

            return await flights
                .Include(f => f.FromCity)
                .Include(f => f.ToCity)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task UpdateAsync(Flight flight)
        {
            _dbContext.Flights.Update(flight);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateDelayAsync(UpdateFlightDelayDTO flightDelay)
        {
            Flight flight = await _dbContext.Flights.FirstOrDefaultAsync(f => f.Id == flightDelay.Id);
            flight.Delay = flightDelay.Delay;
            await _dbContext.SaveChangesAsync();
        }
    }
}
