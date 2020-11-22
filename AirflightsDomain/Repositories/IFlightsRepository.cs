using AirflightsDomain.Models;
using AirflightsDomain.Models.Entities;
using AirflightsDomain.Models.Flight;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirflightsDomain.Repositories
{
    public interface IFlightsRepository
    {
        /// <summary>
        /// вытащить все
        /// </summary>
        /// <returns></returns>
        Task<List<Flight>> GetAsync();
        Task<List<Flight>> GetAsync(FlightFilterRequestDTO filter);

        /// <summary>
        /// вытащить по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<FlightDTO> GetAsync(int id);

        /// <summary>
        /// создать рейс
        /// </summary>
        /// <param name="flight"></param>
        /// <returns></returns>
        Task CreateAsync(Flight flight);

        Task UpdateAsync(Flight flight);
        Task UpdateDelayAsync(UpdateFlightDelayDTO flight);

        Task DeleteAsync(int flightId);

        Task AddDelayAsync(int flightId, TimeSpan delay);
    }
}
