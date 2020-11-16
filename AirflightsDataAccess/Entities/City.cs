using System;
using System.Collections.Generic;
using System.Text;

namespace AirflightsDataAccess.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public List<Flight> OutgoingFlights { get; set; }
        public List<Flight> IncomingFlights { get; set; }
    }
}
