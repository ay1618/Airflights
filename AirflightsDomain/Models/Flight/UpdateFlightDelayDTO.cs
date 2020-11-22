using System;
using System.Collections.Generic;
using System.Text;

namespace AirflightsDomain.Models.Flight
{
    public class UpdateFlightDelayDTO
    {
        public int Id { get; set; }
        public long Delay { get; set; }
    }
}
