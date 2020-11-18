using AirflightsDomain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirflightsDomain.Repositories
{
    public interface IDictRepository
    {
        Task<IEnumerable<CityDTO>> GetAsync();
    }
}
