using AirflightsDomain.Models;
using AirflightsDomain.Models.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirflightsDataAccess.Repositories
{
    public class DictSqlRepository : AirflightsDomain.Repositories.IDictRepository
    {
        private readonly ApplicationContext _dbContext;
        private readonly IMapper _mapper;

        public DictSqlRepository(ApplicationContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        public async Task<List<City>> GetCitiesAsync() => await _dbContext.Cities.ToListAsync();
          
    }
}
