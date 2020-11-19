using AirflightsDomain.Models;
using AirflightsDomain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirflightsDomain.Repositories
{
    public interface IDictRepository
    {
        Task<List<City>> GetCitiesAsync();
    }
}
