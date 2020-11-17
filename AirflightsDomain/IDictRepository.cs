using AirflightsDomain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirflightsDomain
{
    public interface IDictRepository
    {
        Task<IEnumerable<CityDTO>> GetAsync();
    }
}
