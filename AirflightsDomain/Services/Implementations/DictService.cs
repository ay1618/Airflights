using AirflightsDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirflightsDomain.Services.Implementations
{
    public class DictService : IDictService
    {
        private readonly IDictRepository _dictRepository;

        public DictService(IDictRepository dictRepository)
        {
            this._dictRepository = dictRepository;
        }

        public async Task<List<CityDTO>> GetAllAsync() => (await _dictRepository.GetAsync()).ToList();
    }
}
