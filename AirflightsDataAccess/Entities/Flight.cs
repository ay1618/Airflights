using System;
using System.Collections.Generic;
using System.Text;

namespace AirflightsDataAccess.Entities
{
    public class Flight
    {
        public int Id { get; set; }
        public string RegNum { get; set; }
        public int FromCityId { get; set; }
        public int ToCityId { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public long Delay { get; set; }
        public int UserId { get; set; }
        public bool IsArchive { get; set; }
    }
}
