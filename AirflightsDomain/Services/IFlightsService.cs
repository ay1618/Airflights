using AirflightsDomain.Models.Flight;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirflightsDomain.Services
{
    public interface IFlightsService
    {
        Task<List<FlightDTO>> GetAllAsync();
        Task<FlightDTO> GetAsync(int id);
        Task DeleteAsync(int id);
        Task CreateAsync(CreateFlightDTO flight);
    }
}
