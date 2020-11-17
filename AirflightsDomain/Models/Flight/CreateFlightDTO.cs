using System;
using System.Collections.Generic;
using System.Text;

namespace AirflightsDomain.Models.Flight
{
    public class CreateFlightDTO
    {
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }

        public int FromCityId { get; set; }

        public int ToCityId { get; set; }
    }
}
