using AirflightsDomain.Models;
using AirflightsDomain.Models.Entities;
using AirflightsDomain.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirflightsDomain.Services.Implementations
{
    public class DictService : IDictService
    {
        private readonly IMapper _mapper;
        private readonly IDictRepository _dictRepository;

        public DictService(IDictRepository dictRepository, IMapper mapper)
        {
            this._dictRepository = dictRepository;
            this._mapper = mapper;
        }

        public async Task<List<CityDTO>> GetCitiesAsync()
        {
            List<City> cities = await _dictRepository.GetCitiesAsync();
            return _mapper.Map<List<CityDTO>>(cities);
        }
    }
}
