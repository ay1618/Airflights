using AirflightsDomain.Models.Entities;
using AirflightsDomain.Models.Flight;
using AirflightsDomain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
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
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FlightsService(IFlightsRepository flightsRepository
            , IUserRepository userRepository
            , IMapper mapper
            , IHttpContextAccessor httpContextAccessor)
        {
            this._flightsRepository = flightsRepository;
            this._userRepository = userRepository;
            this._mapper = mapper;
            this._httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateAsync(CreateFlightDTO flight)
        {
            Flight instance = _mapper.Map<Flight>(flight);
            instance.Created = DateTime.Now;

            instance.UserId = await _userRepository
                .GetUserIdByLoginAsync(_httpContextAccessor.HttpContext.User.Identity.Name);

            await _flightsRepository.CreateAsync(instance);
        }

        public async Task DeleteAsync(int id) => await _flightsRepository.DeleteAsync(id);

        public async Task<List<FlightDTO>> GetAllAsync()
        {
            List<Flight> flights = await _flightsRepository.GetAsync();
            return _mapper.Map<List<FlightDTO>>(flights);
        }
        public async Task<FlightDTO> GetAsync(int id) => await _flightsRepository.GetAsync(id);

        public async Task<List<FlightDTO>> GetFiltered(FlightFilterRequestDTO filter)
        {
            List<Flight> flightsFromDb = await _flightsRepository.GetAsync(filter);
            return _mapper.Map<List<FlightDTO>>(flightsFromDb);
        }
    }
}
