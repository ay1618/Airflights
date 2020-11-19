using AirflightsDataAccess.Entities;
using AirflightsDomain.Models;
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

        public async Task CreateAsync(CreateFlightDTO flight)
        {
            Flight newFlight = _mapper.Map<Flight>(flight);
            newFlight.Created = DateTime.Now;

            newFlight.UserId = (await _dbContext.Users
                .FirstOrDefaultAsync(
                    u => u.Login == _httpContextAccessor.HttpContext.User.Identity.Name
                 )).Id;

            await _dbContext.AddAsync(newFlight);
            await _dbContext.SaveChangesAsync();
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
