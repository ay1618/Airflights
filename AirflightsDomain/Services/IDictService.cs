using AirflightsDomain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirflightsDomain.Services
{
    public interface IDictService
    {
        Task<List<CityDTO>> GetAllAsync();
    }
}
