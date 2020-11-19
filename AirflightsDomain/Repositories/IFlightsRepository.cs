using AirflightsDomain.Models;
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
        Task<IEnumerable<FlightDTO>> GetAsync();

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
        Task CreateAsync(CreateFlightDTO flight);

        Task UpdateAsync(UpdateFlightDTO flight);

        Task DeleteAsync(int flightId);

        Task AddDelayAsync(int flightId, TimeSpan delay);
    }
}
