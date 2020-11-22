using System;
using System.Collections.Generic;
using System.Text;

namespace AirflightsDomain.Models.Flight
{
    public class UpdateFlightDTO
    {
        public int Id { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public long Delay { get; set; }
        //public bool IsArchive { get; set; }

        public int FromCityId { get; set; }

        public int ToCityId { get; set; }
    }
}
